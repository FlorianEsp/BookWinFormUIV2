# Threads DM Quick Reply

Extension de navigateur (Manifest V3) qui ajoute une **barre de réponses
rapides** dans les conversations de messages privés (DM) de
[Threads](https://www.threads.net). En un clic, un modèle de réponse est
inséré dans le champ de saisie — et envoyé automatiquement si vous le
souhaitez.

> Projet non officiel, sans aucun lien avec Meta / Threads. Conçu pour faire
> gagner du temps sur des réponses récurrentes, dans le respect des
> conditions d'utilisation de la plateforme.

## Fonctionnalités

- 🤖 **Assistante IA « Lia » (DeepSeek)** — un bouton *« Répondre avec Lia »*
  lit le contexte de la conversation et génère automatiquement une réponse
  via l'API DeepSeek.
- 💬 **Barre de réponses rapides** injectée au-dessus de la zone de saisie
  des DM.
- ⚡ **Insertion en un clic** d'un modèle (ou de la réponse de Lia) dans le
  composer (éditeur riche *contenteditable* ou `textarea`).
- 📨 **Envoi automatique** optionnel après insertion (simulation de la touche
  Entrée).
- 🗂️ **Gestion des modèles** depuis la popup (ajout / suppression, libellé +
  texte).
- 🔧 **Sélecteurs CSS configurables** dans les options — pour suivre les
  évolutions de l'interface de Threads sans modifier le code.
- ☁️ Réglages synchronisés via `chrome.storage.sync`.

## Lia — réponses générées par DeepSeek

1. Créez une clé API sur [platform.deepseek.com](https://platform.deepseek.com/).
2. Ouvrez les **Options** de l'extension (icône → *Options*).
3. Renseignez la **clé API**, choisissez le **modèle** (`deepseek-chat` ou
   `deepseek-reasoner`) et, si besoin, ajustez la **personnalité de Lia**
   (system prompt), la **température** et le **nombre de messages de contexte**.
4. Dans une conversation DM, cliquez sur **✨ Répondre avec Lia** : l'extension
   lit les derniers messages, interroge DeepSeek et insère la réponse dans le
   champ de saisie (envoyée automatiquement si l'option est active).

**Comment ça marche :** le content script reconstitue les derniers messages du
fil (en distinguant vos messages des messages reçus selon leur alignement),
les transmet au service worker, qui appelle l'endpoint
`POST {baseUrl}/chat/completions` de DeepSeek (format compatible OpenAI). La
clé API ne quitte jamais votre navigateur, hormis vers l'API DeepSeek
elle-même.

## Installation (mode développeur)

> **Icônes :** si vous récupérez le projet depuis GitHub, générez d'abord les
> icônes PNG (elles ne sont pas versionnées) :
> ```bash
> python3 scripts/make_icons.py
> ```
> (Inutile si vous partez du fichier ZIP, qui contient déjà les icônes.)

### Chrome / Edge / Brave

1. Téléchargez ou clonez ce dépôt.
2. Ouvrez `chrome://extensions` (ou `edge://extensions`).
3. Activez le **Mode développeur** (coin supérieur droit).
4. Cliquez sur **Charger l'extension non empaquetée** et sélectionnez le
   dossier du projet (celui qui contient `manifest.json`).
5. Ouvrez [threads.net](https://www.threads.net), allez dans vos messages,
   ouvrez une conversation : la barre « Réponses rapides » apparaît.

### Firefox

Firefox supporte Manifest V3. Pour un test temporaire :

1. Ouvrez `about:debugging#/runtime/this-firefox`.
2. **Charger un module complémentaire temporaire…** puis sélectionnez le
   fichier `manifest.json`.

## Utilisation

- Cliquez sur l'icône de l'extension pour **gérer vos modèles** et activer
  l'option *Envoyer automatiquement*.
- Dans une conversation DM, cliquez sur un **chip** (puce) de la barre pour
  insérer la réponse correspondante, ou sur **✨ Répondre avec Lia** pour une
  réponse générée par l'IA.
- Si la barre n'apparaît pas (mise à jour de l'interface Threads), ouvrez les
  **Options** de l'extension et ajustez le *sélecteur du champ de saisie*.

## Structure du projet

```
threads-dm-reply/
├── manifest.json          # Déclaration MV3, permissions, content scripts
├── src/
│   ├── storage.js         # Couche storage partagée (objet global TDR)
│   ├── content.js         # Injection de la barre, lecture du contexte, insertion/envoi
│   ├── content.css        # Styles de la barre injectée
│   ├── deepseek.js        # Client de l'API DeepSeek (Chat Completions)
│   ├── background.js       # Service worker : init + relai des requêtes Lia/DeepSeek
│   ├── popup.html/.js/.css # Gestion des modèles
│   └── options.html/.js    # Réglages DeepSeek/Lia + sélecteurs CSS
├── scripts/make_icons.py  # Génère les icônes PNG (non versionnées)
└── icons/                 # Icônes 16 / 48 / 128 (générées)
```

## Permissions

- `storage` — sauvegarder vos modèles, votre clé API et vos préférences.
- `host_permissions` :
  - `threads.net` / `threads.com` — le content script ne s'exécute que sur Threads.
  - `api.deepseek.com` — appels à l'API DeepSeek pour générer les réponses de Lia.

Aucune donnée n'est envoyée à un serveur tiers, hormis le contexte de la
conversation transmis à l'API DeepSeek **lorsque vous cliquez sur « Répondre
avec Lia »**. La clé API et les réglages restent dans le stockage
local/synchronisé de votre navigateur.

## Avertissement

Automatiser des interactions peut être contraire aux conditions d'utilisation
de certaines plateformes. Cette extension se contente d'**aider à la saisie**
(insertion de texte que vous déclenchez manuellement). Utilisez-la de manière
responsable.

## Licence

MIT — voir [LICENSE](LICENSE).
