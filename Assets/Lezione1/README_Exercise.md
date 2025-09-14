
# Unity 6 — Esercizio per classe di **Design** (no code)

**Obiettivi didattici**

- Prendere confidenza con l’interfaccia dell’Editor (Scene/Game/Inspector/Console/Hierarchy/Project).
- Applicare una **Naming Convention** per cartelle, asset, scene, prefab, materiali.
- Comprendere i concetti base: **GameObject**, **Component**, **Prefab/Prefab Variant** e il **Life Cycle** (`Awake/OnEnable/Start/Update/OnDisable/OnDestroy`).
- Interagire con **campi pubblici/privati/serializzati** senza scrivere codice: tutto si fa via **Inspector**.

---

## Materiale fornito

- `Assets/_Project/Scripts/Core/LifecycleDemo.cs`
- `Assets/_Project/Scripts/Core/Rotator.cs`
- `Assets/_Project/Scripts/Data/ColorPalette.cs` (ScriptableObject)
- Cartelle già impostate: `Art`, `Materials`, `Prefabs`, `Scenes`, `Scripts`

> Suggerimento naming (esempio, adattabile al vostro corso):  
>
> - Scene: `DES_01_InterfaceBasics.unity`  
> - Prefab: prefisso `pf_` → `pf_Actor`, `pf_Actor_VariantFast`  
> - Materiali: prefisso `mat_` → `mat_Actor_Cyan`  
> - ScriptableObject: prefisso `so_` → creato dal menu **Create → DES → Color Palette**

---

## Durata: 60–90 minuti

### Parte 1 — Setup (10’)

1. Create un **nuovo progetto URP** (o usate quello del corso).  
2. Importate la cartella `Assets/_Project` in **Project**.  
3. Aprite la **Console** e fissate l’**Inspector** su *Debug* normale (non necessario, ma utile vedere i log).

### Parte 2 — Naming & Struttura (10’)

1. In `Assets/_Project/Scenes/` create la scena `DES_01_InterfaceBasics.unity`.  
2. In `Assets/_Project/Materials/` create `mat_Actor_Base`. Cambiate colore a piacere.  
3. In `Assets/_Project/Prefabs/` create una cartella `Actors`.

### Parte 3 — Primo Actor (20’)

1. In **Hierarchy** create un **3D Object → Cube** e rinominatelo `go_Actor`.
2. Aggiungete i componenti: **Rotator**, **LifecycleDemo**.
3. Trascinate il **MeshRenderer** nella reference `targetRenderer` del `LifecycleDemo` (se non già assegnato).
4. Assegnate `mat_Actor_Base` al Renderer del Cube.
5. Impostate via Inspector:  
   - `LifecycleDemo`: `label = "Actor A"`, `emission = 0.3`.  
   - `Rotator`: `axes = (0, 90, 0)`.
6. Create un **Prefab** trascinando `go_Actor` nella cartella `Prefabs/Actors/` con nome `pf_Actor`.
7. Fate **Play**: leggete in Console i log del **Life Cycle**.

### Parte 4 — Prefab Variant + Campi serializzati (15’)

1. Duplicate `pf_Actor` e create una **Prefab Variant** `pf_Actor_VariantFast`.
2. Nella Variant cambiate `Rotator.axes` a `(0, 180, 0)` e in `LifecycleDemo` `label = "Actor Fast"`.
3. In **Scene**, istanziate 3 attori:  
   - `pf_Actor` (default)  
   - `pf_Actor` con `baseColor` diverso dal Material (usate il campo nel `LifecycleDemo`)  
   - `pf_Actor_VariantFast`
4. **Toggle** l’icona **Active** dell’oggetto durante Play per osservare `OnEnable/OnDisable` in Console.

### Parte 5 — ScriptableObject Palette (10’)

1. Create `Assets/_Project/Data/so_Palette.asset` dal menu **Create → DES → Color Palette**.
2. Impostate 4 colori diversi nella palette.
3. Selezionate ciascun attore in scena e cambiate rapidamente i colori editando `baseColor` ispirandovi alla palette.

### Parte 6 — Picnic di interfaccia (10’)

Esplorate:

- **Hierarchy vs Project**: differenza tra scena e asset.
- **Inspector**: campi **pubblici**, **privati [SerializeField]**, **[HideInInspector]**.
- **Console**: filtrare e leggere i messaggi del ciclo di vita.
- **Prefabs**: Override, Revert, **Open Prefab** editing mode.

---

## Consegna (deliverables)

- La scena `DES_01_InterfaceBasics.unity` organizzata con 3 attori istanziati.
- Cartelle e asset rinominati secondo la Naming Convention.
- 1 screenshot della Console con i log del Life Cycle.

## Valutazione (rubrica sintetica)

- **Struttura & naming (40%)**: cartelle e asset coerenti.
- **Utilizzo Inspector (30%)**: corretta modifica dei campi serializzati e public.
- **Comprensione ciclo di vita (20%)**: screenshot + azioni che lo dimostrano (toggle Active, Play/Stop).
- **Pulizia progetto (10%)**: niente asset orfani, nomi chiari.

---

## Estensioni (opzionali, 10–15’)

- Create `pf_Actor_VariantGlow` con `emission > 1` e testate in scena scura.
- Aggiungete un **Empty** `go_Anchor` e annidate gli attori per provare trasformazioni padre/figlio.
- Provate **Unscaled Time** su `Rotator` e un **Time Scale** diverso da 1 nel **Time Manager**.

---

### Note per il Docente

- Gli studenti **non devono scrivere codice**: tutto si fa via Inspector.
- Potete mostrare dal vivo come `public`, `private [SerializeField]` e `HideInInspector` cambiano la visibilità.
- Se usate HDRP/Standard, i setter di colore provano più proprietà (`_BaseColor`, `_Color`, `_EmissionColor`).

Buona lezione! ✨
