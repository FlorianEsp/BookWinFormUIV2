/*
 * storage.js
 * Petite couche d'abstraction au-dessus de chrome.storage.sync.
 * Chargée à la fois par le content script, le popup et la page d'options.
 * Expose un objet global `TDR` (Threads DM Reply).
 */
(function (global) {
  "use strict";

  const STORAGE_KEY = "tdr_settings";

  /** Modèles de réponses fournis par défaut à la première installation. */
  const DEFAULT_TEMPLATES = [
    { id: "tpl-hello", label: "Salutation", text: "Bonjour ! Merci pour votre message 🙏" },
    { id: "tpl-thanks", label: "Remerciement", text: "Merci beaucoup, c'est très gentil !" },
    { id: "tpl-wait", label: "Patience", text: "Je reviens vers vous très vite, merci de votre patience." },
    { id: "tpl-link", label: "Plus d'infos", text: "Vous trouverez toutes les infos ici : " }
  ];

  /** Persona par défaut de l'assistante IA. */
  const DEFAULT_SYSTEM_PROMPT =
    "Tu es Lia, une assistante chaleureuse qui répond aux messages privés " +
    "(DM) Threads à la place de l'utilisateur. Réponds en français, de manière " +
    "naturelle, concise et amicale, sur le même ton que l'interlocuteur. " +
    "Rédige UNIQUEMENT le texte de la réponse à envoyer, sans guillemets, sans " +
    "préfixe (« Lia : ») ni explication. Si une information manque, reste " +
    "poli·e et propose de revenir vers la personne.";

  const DEFAULT_SETTINGS = {
    templates: DEFAULT_TEMPLATES,
    /** Insère le texte sans envoyer (false) ou insère puis envoie automatiquement (true). */
    autoSend: false,
    /** Affiche la barre d'outils de réponses rapides. */
    enabled: true,
    /** Intégration IA DeepSeek (« Lia »). */
    deepseek: {
      enabled: true,
      apiKey: "",
      baseUrl: "https://api.deepseek.com",
      model: "deepseek-chat",
      systemPrompt: DEFAULT_SYSTEM_PROMPT,
      temperature: 0.7,
      // Nombre de derniers messages de la conversation envoyés comme contexte.
      maxContextMessages: 12
    },
    /**
     * Sélecteurs CSS du DOM de Threads. Externalisés car l'interface de
     * Threads change régulièrement : l'utilisateur peut les ajuster dans les
     * options sans toucher au code.
     */
    selectors: {
      // Zone de saisie du message (contenteditable ou textarea).
      composer:
        'div[contenteditable="true"][role="textbox"], textarea[placeholder], div[aria-label][contenteditable="true"]',
      // Conteneur de la conversation, sert d'ancrage pour insérer la barre.
      conversation: 'div[role="main"]',
      // Lignes de messages individuelles (pour reconstituer le contexte).
      message: 'div[role="row"], div[data-pressable-container] div[dir="auto"]'
    }
  };

  function clone(obj) {
    return JSON.parse(JSON.stringify(obj));
  }

  /** Fusionne les réglages stockés avec les valeurs par défaut (deep pour selectors). */
  function withDefaults(stored) {
    const base = clone(DEFAULT_SETTINGS);
    if (!stored) return base;
    const merged = Object.assign(base, stored);
    merged.selectors = Object.assign(clone(DEFAULT_SETTINGS.selectors), stored.selectors || {});
    merged.deepseek = Object.assign(clone(DEFAULT_SETTINGS.deepseek), stored.deepseek || {});
    if (!Array.isArray(merged.templates)) merged.templates = clone(DEFAULT_TEMPLATES);
    return merged;
  }

  const api = (global.chrome && chrome.storage) ? chrome.storage.sync : null;

  function get() {
    return new Promise((resolve) => {
      if (!api) return resolve(clone(DEFAULT_SETTINGS));
      api.get(STORAGE_KEY, (res) => resolve(withDefaults(res && res[STORAGE_KEY])));
    });
  }

  function set(settings) {
    return new Promise((resolve) => {
      if (!api) return resolve();
      api.set({ [STORAGE_KEY]: settings }, () => resolve());
    });
  }

  function onChanged(callback) {
    if (!global.chrome || !chrome.storage || !chrome.storage.onChanged) return;
    chrome.storage.onChanged.addListener((changes, area) => {
      if (area === "sync" && changes[STORAGE_KEY]) {
        callback(withDefaults(changes[STORAGE_KEY].newValue));
      }
    });
  }

  function makeId() {
    return "tpl-" + Math.random().toString(36).slice(2, 9);
  }

  global.TDR = {
    STORAGE_KEY,
    DEFAULT_SETTINGS,
    DEFAULT_TEMPLATES,
    DEFAULT_SYSTEM_PROMPT,
    get,
    set,
    onChanged,
    withDefaults,
    makeId
  };
})(typeof window !== "undefined" ? window : self);
