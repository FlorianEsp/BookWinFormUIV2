/*
 * background.js — service worker (Manifest V3).
 * - Initialise les réglages par défaut à l'installation.
 * - Relaie les demandes de génération du content script vers l'API DeepSeek
 *   (l'appel réseau se fait ici pour éviter les contraintes CORS côté page).
 */
importScripts("storage.js", "deepseek.js");

chrome.runtime.onInstalled.addListener(async (details) => {
  const current = await TDR.get();
  if (details.reason === "install") {
    await TDR.set(current);
  }
});

chrome.runtime.onMessage.addListener((msg, _sender, sendResponse) => {
  if (!msg || msg.type !== "lia:generate") return false;

  (async () => {
    try {
      const settings = await TDR.get();
      const cfg = settings.deepseek;
      if (!cfg.enabled) throw new Error("L'assistante Lia est désactivée dans les options.");
      const reply = await TDR_DeepSeek.generateReply(cfg, msg.messages || []);
      sendResponse({ ok: true, reply });
    } catch (e) {
      sendResponse({ ok: false, error: e && e.message ? e.message : String(e) });
    }
  })();

  // true => réponse asynchrone (on garde le canal ouvert).
  return true;
});
