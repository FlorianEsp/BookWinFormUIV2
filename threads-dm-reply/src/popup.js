/* popup.js — gestion rapide des modèles et des bascules depuis la popup. */
(function () {
  "use strict";

  const els = {
    enabled: document.getElementById("enabled"),
    autoSend: document.getElementById("autoSend"),
    list: document.getElementById("list"),
    empty: document.getElementById("empty"),
    newLabel: document.getElementById("new-label"),
    newText: document.getElementById("new-text"),
    add: document.getElementById("add"),
    openOptions: document.getElementById("open-options")
  };

  let settings = null;

  function render() {
    els.enabled.checked = !!settings.enabled;
    els.autoSend.checked = !!settings.autoSend;

    els.list.textContent = "";
    els.empty.hidden = settings.templates.length > 0;

    settings.templates.forEach((tpl) => {
      const li = document.createElement("li");
      li.className = "item";

      const meta = document.createElement("div");
      meta.className = "meta";
      const label = document.createElement("div");
      label.className = "label";
      label.textContent = tpl.label || "(sans libellé)";
      const text = document.createElement("div");
      text.className = "text";
      text.textContent = tpl.text;
      meta.appendChild(label);
      meta.appendChild(text);

      const del = document.createElement("button");
      del.type = "button";
      del.title = "Supprimer";
      del.textContent = "✕";
      del.addEventListener("click", () => removeTemplate(tpl.id));

      li.appendChild(meta);
      li.appendChild(del);
      els.list.appendChild(li);
    });
  }

  async function save() {
    await TDR.set(settings);
  }

  async function removeTemplate(id) {
    settings.templates = settings.templates.filter((t) => t.id !== id);
    await save();
    render();
  }

  async function addTemplate() {
    const text = els.newText.value.trim();
    if (!text) {
      els.newText.focus();
      return;
    }
    const label = els.newLabel.value.trim() || text.slice(0, 24);
    settings.templates.push({ id: TDR.makeId(), label, text });
    await save();
    els.newLabel.value = "";
    els.newText.value = "";
    render();
    els.newLabel.focus();
  }

  els.enabled.addEventListener("change", async () => {
    settings.enabled = els.enabled.checked;
    await save();
  });
  els.autoSend.addEventListener("change", async () => {
    settings.autoSend = els.autoSend.checked;
    await save();
  });
  els.add.addEventListener("click", addTemplate);
  els.newText.addEventListener("keydown", (e) => {
    // Ctrl/Cmd + Entrée pour ajouter rapidement.
    if ((e.ctrlKey || e.metaKey) && e.key === "Enter") addTemplate();
  });
  els.openOptions.addEventListener("click", (e) => {
    e.preventDefault();
    if (chrome.runtime.openOptionsPage) chrome.runtime.openOptionsPage();
  });

  TDR.get().then((s) => {
    settings = s;
    render();
  });
})();
