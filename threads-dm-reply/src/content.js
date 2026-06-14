/*
 * content.js
 * Injecté sur les pages Threads. Détecte l'ouverture d'une conversation de
 * messages privés (DM) et ajoute une barre de réponses rapides au-dessus de la
 * zone de saisie. Un clic insère le modèle dans le composer (et l'envoie si
 * l'option autoSend est active).
 */
(function () {
  "use strict";

  const BAR_ID = "tdr-quick-reply-bar";
  let settings = null;
  let observer = null;

  /* ----------------------------- Détection DM ----------------------------- */

  // Les conversations DM de Threads vivent sous des URLs de type /messages ou
  // /direct. On reste permissif pour suivre les évolutions du produit.
  function isDmView() {
    const p = location.pathname.toLowerCase();
    return p.includes("/messages") || p.includes("/direct") || p.includes("/inbox");
  }

  function findComposer() {
    const sel = settings.selectors.composer;
    const nodes = Array.from(document.querySelectorAll(sel));
    // On privilégie un champ visible (largeur/hauteur non nulles).
    return (
      nodes.find((n) => n.offsetParent !== null && n.getClientRects().length > 0) ||
      nodes[0] ||
      null
    );
  }

  /* --------------------------- Insertion de texte ------------------------- */

  function insertIntoComposer(composer, text) {
    composer.focus();

    if (composer.tagName === "TEXTAREA" || composer.tagName === "INPUT") {
      const proto = composer.tagName === "TEXTAREA"
        ? window.HTMLTextAreaElement.prototype
        : window.HTMLInputElement.prototype;
      const setter = Object.getOwnPropertyDescriptor(proto, "value").set;
      const next = (composer.value || "") + text;
      setter.call(composer, next);
      composer.dispatchEvent(new Event("input", { bubbles: true }));
      return;
    }

    // contenteditable (cas le plus courant sur Threads, basé sur Lexical/Draft).
    // execCommand reste l'approche la plus fiable pour déclencher les listeners
    // internes de l'éditeur riche.
    const ok = document.execCommand && document.execCommand("insertText", false, text);
    if (!ok) {
      composer.textContent = (composer.textContent || "") + text;
      composer.dispatchEvent(new InputEvent("input", { bubbles: true, data: text, inputType: "insertText" }));
    }
  }

  function trySend(composer) {
    // Simule l'appui sur Entrée, qui envoie le message dans l'interface Threads.
    const opts = {
      bubbles: true,
      cancelable: true,
      key: "Enter",
      code: "Enter",
      keyCode: 13,
      which: 13
    };
    composer.dispatchEvent(new KeyboardEvent("keydown", opts));
    composer.dispatchEvent(new KeyboardEvent("keypress", opts));
    composer.dispatchEvent(new KeyboardEvent("keyup", opts));
  }

  function applyTemplate(text) {
    const composer = findComposer();
    if (!composer) {
      flashMessage("Champ de saisie introuvable. Ouvrez une conversation puis réessayez.");
      return;
    }
    insertIntoComposer(composer, text);
    if (settings.autoSend) {
      // Laisse l'éditeur traiter l'input avant d'envoyer.
      setTimeout(() => trySend(composer), 60);
    }
  }

  /* --------------------- Lecture du contexte (DOM Threads) ---------------- */

  // Reconstitue les derniers messages de la conversation pour donner du
  // contexte à l'IA. La distinction émetteur/destinataire est heuristique :
  // dans une UI de chat, les messages envoyés (« me ») sont alignés à droite.
  function scrapeConversation() {
    const container =
      document.querySelector(settings.selectors.conversation) || document.body;
    const cRect = container.getBoundingClientRect();
    const midX = cRect.left + cRect.width / 2;

    const nodes = Array.from(container.querySelectorAll(settings.selectors.message));
    const seen = new Set();
    const out = [];

    for (const node of nodes) {
      // Ignore la barre injectée et la zone de saisie.
      if (node.closest("#" + BAR_ID)) continue;
      if (node.closest('[contenteditable="true"], textarea')) continue;

      const text = (node.innerText || node.textContent || "").trim();
      if (!text || text.length > 2000) continue;
      // Filtre le bruit d'interface (horodatages courts, mentions « Vu »).
      if (/^(vu|seen|aujourd|today|hier|yesterday|\d{1,2}:\d{2})/i.test(text) && text.length < 12) {
        continue;
      }
      if (seen.has(text)) continue;
      seen.add(text);

      const r = node.getBoundingClientRect();
      if (r.width === 0 || r.height === 0) continue;
      const center = r.left + r.width / 2;
      const role = center > midX ? "me" : "them";

      out.push({ role, text, top: r.top });
    }

    // Ordre vertical (du plus ancien en haut au plus récent en bas).
    out.sort((a, b) => a.top - b.top);
    const max = settings.deepseek.maxContextMessages || 12;
    return out.slice(-max).map(({ role, text }) => ({ role, text }));
  }

  function setLiaLoading(loading) {
    const btn = document.getElementById("tdr-lia-btn");
    if (!btn) return;
    btn.disabled = loading;
    btn.classList.toggle("tdr-loading", loading);
    btn.textContent = loading ? "✨ Lia rédige…" : "✨ Répondre avec Lia";
  }

  function generateWithLia() {
    const composer = findComposer();
    if (!composer) {
      flashMessage("Ouvrez une conversation avant de demander à Lia.");
      return;
    }
    const messages = scrapeConversation();
    if (!messages.length) {
      flashMessage("Aucun message détecté pour le contexte.");
      return;
    }

    setLiaLoading(true);
    chrome.runtime.sendMessage({ type: "lia:generate", messages }, (res) => {
      setLiaLoading(false);
      if (chrome.runtime.lastError) {
        flashMessage("Erreur interne : " + chrome.runtime.lastError.message);
        return;
      }
      if (!res || !res.ok) {
        flashMessage((res && res.error) || "Échec de la génération.");
        return;
      }
      insertIntoComposer(composer, res.reply);
      if (settings.autoSend) setTimeout(() => trySend(composer), 60);
    });
  }

  /* ------------------------------ Barre UI -------------------------------- */

  function flashMessage(msg) {
    const bar = document.getElementById(BAR_ID);
    if (!bar) return;
    let note = bar.querySelector(".tdr-note");
    if (!note) {
      note = document.createElement("span");
      note.className = "tdr-note";
      bar.appendChild(note);
    }
    note.textContent = msg;
    clearTimeout(note._t);
    note._t = setTimeout(() => { note.textContent = ""; }, 4000);
  }

  function buildBar() {
    const bar = document.createElement("div");
    bar.id = BAR_ID;
    bar.setAttribute("role", "toolbar");
    bar.setAttribute("aria-label", "Réponses rapides Threads");

    const title = document.createElement("span");
    title.className = "tdr-title";
    title.textContent = "Réponses rapides";
    bar.appendChild(title);

    // Bouton de génération IA (Lia / DeepSeek).
    if (settings.deepseek && settings.deepseek.enabled) {
      const lia = document.createElement("button");
      lia.type = "button";
      lia.id = "tdr-lia-btn";
      lia.className = "tdr-lia";
      lia.textContent = "✨ Répondre avec Lia";
      lia.title = "Générer une réponse via DeepSeek d'après la conversation";
      lia.addEventListener("click", (e) => {
        e.preventDefault();
        e.stopPropagation();
        generateWithLia();
      });
      bar.appendChild(lia);
    }

    const list = document.createElement("div");
    list.className = "tdr-chips";
    bar.appendChild(list);

    renderChips(list);
    return bar;
  }

  function renderChips(list) {
    list.textContent = "";
    if (!settings.templates.length) {
      const empty = document.createElement("span");
      empty.className = "tdr-empty";
      empty.textContent = "Aucun modèle. Ajoutez-en depuis l'icône de l'extension.";
      list.appendChild(empty);
      return;
    }
    settings.templates.forEach((tpl) => {
      const chip = document.createElement("button");
      chip.type = "button";
      chip.className = "tdr-chip";
      chip.textContent = tpl.label || tpl.text.slice(0, 24);
      chip.title = tpl.text;
      chip.addEventListener("click", (e) => {
        e.preventDefault();
        e.stopPropagation();
        applyTemplate(tpl.text);
      });
      list.appendChild(chip);
    });
  }

  function ensureBar() {
    if (!settings.enabled || !isDmView()) {
      removeBar();
      return;
    }
    const composer = findComposer();
    if (!composer) {
      removeBar();
      return;
    }
    let bar = document.getElementById(BAR_ID);
    if (!bar) {
      bar = buildBar();
    }
    // Place la barre juste au-dessus de la zone de saisie.
    const anchor = composer.closest('div[role="textbox"]') || composer;
    const host = anchor.parentElement || document.body;
    if (bar.parentElement !== host) {
      host.insertBefore(bar, anchor);
    }
  }

  function removeBar() {
    const bar = document.getElementById(BAR_ID);
    if (bar) bar.remove();
  }

  /* ----------------------------- Observation ------------------------------ */

  // Threads est une SPA : le DOM et l'URL changent sans rechargement. On
  // observe les mutations (avec throttle) pour replacer la barre au besoin.
  let pending = false;
  function scheduleEnsure() {
    if (pending) return;
    pending = true;
    requestAnimationFrame(() => {
      pending = false;
      try { ensureBar(); } catch (_) { /* no-op */ }
    });
  }

  function start() {
    observer = new MutationObserver(scheduleEnsure);
    observer.observe(document.body, { childList: true, subtree: true });

    // Détecte les navigations SPA en patchant l'history API.
    ["pushState", "replaceState"].forEach((m) => {
      const orig = history[m];
      history[m] = function () {
        const r = orig.apply(this, arguments);
        window.dispatchEvent(new Event("tdr:locationchange"));
        return r;
      };
    });
    window.addEventListener("popstate", scheduleEnsure);
    window.addEventListener("tdr:locationchange", scheduleEnsure);

    scheduleEnsure();
  }

  /* -------------------------------- Init ---------------------------------- */

  TDR.get().then((s) => {
    settings = s;
    start();
    TDR.onChanged((next) => {
      settings = next;
      // Reconstruit entièrement la barre pour refléter l'état de Lia et des modèles.
      removeBar();
      scheduleEnsure();
    });
  });
})();
