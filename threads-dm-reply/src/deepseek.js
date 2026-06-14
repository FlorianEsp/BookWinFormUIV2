/*
 * deepseek.js
 * Client minimal de l'API DeepSeek (compatible OpenAI Chat Completions).
 * Chargé dans le service worker via importScripts ; expose `TDR_DeepSeek`.
 *
 * Doc : https://api-docs.deepseek.com/  — endpoint POST {baseUrl}/chat/completions
 */
(function (global) {
  "use strict";

  /**
   * Génère une réponse à partir du contexte de la conversation.
   * @param {object} cfg  Réglages deepseek (apiKey, baseUrl, model, systemPrompt, temperature).
   * @param {Array<{role:string,text:string}>} messages  Historique (du plus ancien au plus récent).
   * @returns {Promise<string>} Le texte de la réponse générée.
   */
  async function generateReply(cfg, messages) {
    if (!cfg || !cfg.apiKey) {
      throw new Error("Clé API DeepSeek manquante. Renseignez-la dans les options.");
    }

    const base = (cfg.baseUrl || "https://api.deepseek.com").replace(/\/+$/, "");
    const url = base + "/chat/completions";

    // Construit l'historique : « them » (interlocuteur) -> user, « me » -> assistant.
    const history = (messages || []).map((m) => ({
      role: m.role === "me" ? "assistant" : "user",
      content: m.text
    }));

    const payload = {
      model: cfg.model || "deepseek-chat",
      messages: [
        { role: "system", content: cfg.systemPrompt || "" },
        ...history,
        // Consigne finale pour forcer la production d'une réponse à envoyer.
        { role: "user", content: "Rédige maintenant la réponse à envoyer." }
      ],
      temperature: typeof cfg.temperature === "number" ? cfg.temperature : 0.7,
      stream: false
    };

    const res = await fetch(url, {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
        Authorization: "Bearer " + cfg.apiKey
      },
      body: JSON.stringify(payload)
    });

    if (!res.ok) {
      let detail = "";
      try {
        const err = await res.json();
        detail = (err && err.error && err.error.message) || JSON.stringify(err);
      } catch (_) {
        detail = await res.text().catch(() => "");
      }
      throw new Error("DeepSeek " + res.status + " : " + (detail || res.statusText));
    }

    const data = await res.json();
    const text =
      data &&
      data.choices &&
      data.choices[0] &&
      data.choices[0].message &&
      data.choices[0].message.content;

    if (!text) throw new Error("Réponse DeepSeek vide ou inattendue.");
    return text.trim().replace(/^["«»\s]+|["«»\s]+$/g, "");
  }

  global.TDR_DeepSeek = { generateReply };
})(typeof window !== "undefined" ? window : self);
