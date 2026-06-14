/* options.js — édition des réglages DeepSeek/Lia et des sélecteurs CSS. */
(function () {
  "use strict";

  const $ = (id) => document.getElementById(id);
  const els = {
    // DeepSeek
    dsEnabled: $("ds-enabled"),
    dsKey: $("ds-key"),
    dsModel: $("ds-model"),
    dsBase: $("ds-base"),
    dsPrompt: $("ds-prompt"),
    dsTemp: $("ds-temp"),
    dsCtx: $("ds-ctx"),
    // Sélecteurs
    composer: $("sel-composer"),
    conversation: $("sel-conversation"),
    message: $("sel-message"),
    // Actions
    save: $("save"),
    reset: $("reset"),
    status: $("status")
  };

  let settings = null;

  function fill() {
    const ds = settings.deepseek;
    els.dsEnabled.checked = !!ds.enabled;
    els.dsKey.value = ds.apiKey || "";
    els.dsModel.value = ds.model || "";
    els.dsBase.value = ds.baseUrl || "";
    els.dsPrompt.value = ds.systemPrompt || "";
    els.dsTemp.value = ds.temperature;
    els.dsCtx.value = ds.maxContextMessages;

    els.composer.value = settings.selectors.composer;
    els.conversation.value = settings.selectors.conversation;
    els.message.value = settings.selectors.message;
  }

  function flash(msg) {
    els.status.textContent = msg;
    clearTimeout(flash._t);
    flash._t = setTimeout(() => { els.status.textContent = ""; }, 2500);
  }

  function clampNumber(value, fallback, min, max) {
    const n = parseFloat(value);
    if (Number.isNaN(n)) return fallback;
    return Math.min(max, Math.max(min, n));
  }

  els.save.addEventListener("click", async () => {
    const def = TDR.DEFAULT_SETTINGS;

    settings.deepseek.enabled = els.dsEnabled.checked;
    settings.deepseek.apiKey = els.dsKey.value.trim();
    settings.deepseek.model = els.dsModel.value.trim() || def.deepseek.model;
    settings.deepseek.baseUrl = els.dsBase.value.trim() || def.deepseek.baseUrl;
    settings.deepseek.systemPrompt = els.dsPrompt.value.trim() || def.deepseek.systemPrompt;
    settings.deepseek.temperature = clampNumber(els.dsTemp.value, def.deepseek.temperature, 0, 2);
    settings.deepseek.maxContextMessages = Math.round(
      clampNumber(els.dsCtx.value, def.deepseek.maxContextMessages, 1, 50)
    );

    settings.selectors.composer = els.composer.value.trim() || def.selectors.composer;
    settings.selectors.conversation = els.conversation.value.trim() || def.selectors.conversation;
    settings.selectors.message = els.message.value.trim() || def.selectors.message;

    await TDR.set(settings);
    fill();
    flash("Enregistré ✓");
  });

  els.reset.addEventListener("click", async () => {
    settings.selectors = JSON.parse(JSON.stringify(TDR.DEFAULT_SETTINGS.selectors));
    await TDR.set(settings);
    fill();
    flash("Sélecteurs réinitialisés ✓");
  });

  TDR.get().then((s) => {
    settings = s;
    fill();
  });
})();
