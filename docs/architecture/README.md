# Architecture

This document is the canonical maintained architecture index for **Operation: EarthCore**. It describes the current delivered architecture using three views - static, dynamic, and deployment - and links the Architecture Decision Records (ADRs) that explain why key structural choices were made.

Maintained architecture view sources live under:

- [`docs/architecture/static-view/`](static-view/) - component diagram source (PlantUML)
- [`docs/architecture/dynamic-view/`](dynamic-view/) - sequence diagram source (PlantUML)
- [`docs/architecture/deployment-view/`](deployment-view/) - deployment diagram source (PlantUML)
- [`docs/architecture/adr/`](adr/) - Architecture Decision Records

All diagrams are maintained as diagrams-as-code using **PlantUML**. Source `.puml` files are committed alongside their rendered `.svg` output so the architecture stays both versioned and directly readable without requiring a local renderer.

---

## Static View

![Component diagram](static-view/component-diagram.svg)

Source: [`static-view/component-diagram.puml`](static-view/component-diagram.puml)

### What the diagram shows

The component diagram groups the codebase into six subsystems, all running inside the Unity Editor/Player runtime - there is no backend, database, or external API:

- **Game Management** - `GameInitializer`, `GridGenerator`, `GameExit`, and `PauseManager` are all co-located on a single `"Game Manager"` `GameObject` in the `Level` scene. `GridGenerator` procedurally instantiates the block grid on scene load.
- **Player Subsystem** - `PlayerMovement` and `PlayerDig` are attached to the player `GameObject` (`PlayerDig` requires `PlayerMovement` via Unity's `[RequireComponent]`). Both read from the generated Unity `PlayerInput` action asset. `PlayerDigLogic` and `PlayerManager` are plain C# singletons that hold digging state and the currently equipped `Item`, decoupled from any single `MonoBehaviour`. `PlayerAnimator` is a singleton that subscribes to `PlayerDig`'s events and drives the `Animator`.
- **Blocks / World** - `BlockBehaviour` (`MonoBehaviour`) delegates all damage/HP/drop-table logic to `BlockBehaviourLogic` (plain C#), and reads its stats from a `BlockTypeData` `ScriptableObject`.
- **Items** - `Item` `ScriptableObject` assets are the single source of truth for item stats. `TypeToItemData` and `TypeToPrefab` are static converters that resolve an `ItemType` enum value to its `Item` asset or world prefab via `Resources.Load`.
- **Inventory Subsystem** - `InventoryManager` (`MonoBehaviour`, holds Unity references and input bindings) delegates all slot/stacking logic to `InventoryLogic` (plain C#, no Unity dependency). UI (`InventorySlot`, `InventoryItem`) talks only to `InventoryManager`, never to `InventoryLogic` directly.
- **Crafting Subsystem** - `CraftManager` requires `InventoryManager` on the same `GameObject` and delegates recipe validation and material spending to `CraftLogic`, which operates directly on `InventoryLogic`.

External dependencies are limited to the Unity Engine platform itself: the Input System (action-based input), Physics2D (raycasting for digging, trigger colliders for item pickup), the Animator, and the Scene Manager. The product interacts with exactly one external "actor" - the player - and no network services.

### Coupling, cohesion, and maintainability

- **Logic/MonoBehaviour separation is the dominant pattern** and is the codebase's strongest maintainability asset: `BlockBehaviourLogic`, `InventoryLogic`, `CraftLogic`, and `PlayerDigLogic` contain the actual game rules as plain C# classes with no `UnityEngine` scene dependencies. This is *why* `docs/testing.md` reports near-100% coverage on `BlockBehaviourLogic` (97.2%) and full coverage on `CraftManager`'s logic path (100%) - these classes can be unit-tested in isolation without loading a scene. The `MonoBehaviour` wrapper classes (`BlockBehaviour`, `InventoryManager`, `CraftManager`) stay thin: they wire Unity events/input to the logic class and forward calls.
- **Cohesion is high within each subsystem** - each package groups a `MonoBehaviour`, its logic class, and its data (`ScriptableObject`) together, and each has a single clear responsibility (block state, inventory state, crafting rules).
- **Coupling risk: singletons.** `PlayerManager`, `PlayerDigLogic`, and `PlayerAnimator` are accessed via static `Instance` properties rather than dependency injection. This keeps wiring simple for a small Unity team but means these three classes are implicitly global state - any subsystem can reach into them, which makes their lifecycle and mutation points harder to trace as the codebase grows. This tradeoff and its consequences are recorded in [ADR-002](adr/ADR-002-singleton-access-for-cross-cutting-player-state.md).
- **Coupling risk: `GameObject.FindWithTag("Game Manager")`.** UI classes (`InventoryItem`, `InventorySlot`, `CraftPanelRenderer`) and `CollectableBehaviour` all locate `InventoryManager`/`CraftManager` via a hardcoded tag lookup rather than a reference passed in or a singleton. This works because there is exactly one `"Game Manager"` object per scene, but it is a runtime-only, string-based coupling that the compiler cannot verify - a typo or missing tag fails silently or only at runtime.
- **Which quality requirements the structure supports or constrains:** the Logic/MonoBehaviour split directly supports **QR-002 (fault tolerance)** - `BlockBehaviourLogic` can be exercised with a null-data edge case in a PlayMode test without a full scene setup, which is exactly how [QRT-002](../quality-requirement-tests.md#qrt-002) is implemented. It also supports **Testability** as a maintainability concern more broadly. The tag-based lookup pattern is a constraint on **QR-003 (operability)**: if the `"Game Manager"` tag or `GameObject` were ever renamed or duplicated, dependent systems would fail at runtime with no compile-time warning.

---

## Dynamic View

![Dig, destroy block, drop item, and collect sequence diagram](dynamic-view/dig-pickup-sequence.svg)

Source: [`dynamic-view/dig-pickup-sequence.puml`](dynamic-view/dig-pickup-sequence.puml)

### What scenario the diagram represents

The diagram traces the core gameplay loop end to end: the player digs a block, the block takes damage and is potentially destroyed, a resource item drops into the world, and the player collects it into their inventory. This spans two separate runtime triggers (a dig input event, then later a physics trigger event when the player walks into the dropped item) and nine components across four subsystems (Player, Blocks/World, Items, Inventory).

### Why this scenario is important to the product

This is the single most-executed interaction loop in the game - every resource the player ever obtains passes through this exact path (`PlayerDig` -> `BlockBehaviour` -> `BlockBehaviourLogic` -> `TypeToPrefab` -> `CollectableBehaviour` -> `InventoryManager` -> `InventoryLogic`). If any link in this chain breaks, the entire game becomes unplayable, which is why `QR-002` specifically targets `BlockBehaviour`'s fault tolerance.

### What it helps the reader reason about

- **Integration boundary between "world" and "inventory":** items only enter the inventory system through `CollectableBehaviour.OnTriggerEnter2D`, which is a physics-driven boundary, not a direct method call from `BlockBehaviour`. This means a dropped item is genuinely a separate world entity for a period of time - it has its own `GameObject`, can be missed by the player, and is not guaranteed to be picked up.
- **Where fault tolerance actually lives:** `BlockBehaviourLogic.IsItemSuitable` gates whether damage is applied at all, and `InventoryLogic.TryAddItem` returns `-1`/`false` rather than throwing when the inventory is full - the diagram shows both of these as explicit `alt` branches rather than assumed-successful paths, which is directly what `QRT-002` verifies for the block side.
- **Why `PlayerAnimator` and `PlayerManager` exist as singletons:** the diagram shows `PlayerAnimator` reacting to `PlayerDig`'s `OnAnyDig` event and `PlayerManager` being read for the currently equipped item mid-flow - both without any direct object reference passed through the call chain, which is the architecture decision recorded in [ADR-002](adr/ADR-002-singleton-access-for-cross-cutting-player-state.md).

---

## Deployment View

![Deployment diagram](deployment-view/deployment-diagram.svg)

Source: [`deployment-view/deployment-diagram.puml`](deployment-view/deployment-diagram.puml)

### What the diagram shows

Operation: EarthCore is built and distributed as a **standalone offline executable** - there is no server component. A team member's local Unity Editor (pinned to **6000.4.10f1**, matching [`docs/development-process.md`](../development-process.md)) is where development happens; GitHub Actions CI installs the identical pinned Editor version headlessly to run tests and produce Windows and Linux player builds. Build artifacts are placed in the repository's `releases/` folder and attached to SemVer-tagged GitHub Releases (e.g. `v0.2.0`, `v0.3.0`). Customers and TAs download a platform-specific ZIP, extract it, and run `TheMoleProject2D.exe` (Windows) or `LinuxBuild.x86_64` (Linux, after `chmod +x`) - this is the customer-facing access path documented in the root `README.md`'s local setup instructions.

### Why this deployment model was chosen

A standalone build was the natural choice for a Unity 2D single-player game with no multiplayer, persistence-across-devices, or server-authoritative requirement - there is no gameplay reason to require a network connection or hosted backend. This keeps the deployment surface minimal: no infrastructure to provision, secure, or pay for, which matters for a student team with no operations capacity.

### How the current deployment supports or constrains the product

**Supports:** zero runtime network dependency means the game works identically for every customer regardless of connectivity, and there are no server costs, uptime concerns, or backend security surface to manage - consistent with the "no runtime secrets" configuration-management approach in `docs/development-process.md`.

**Constrains:** there is currently no save system (`#65`, tracked in `docs/roadmap.md`), which is a direct consequence of having no persistent storage layer beyond the local session - anything like cloud saves, leaderboards, or cross-device play would require introducing a new deployment component (local file I/O at minimum, a backend at most) that does not exist today. Distribution is also fully manual: builds are uploaded to `releases/` and GitHub Releases by hand after each Sprint rather than through an automated continuous-delivery pipeline, as documented in `docs/development-process.md`'s CI Process section.

### What must be considered when deploying or operating it for the customer

Because there is no auto-update mechanism, customers must be told which specific version ZIP to download each Sprint (the release notes and Week N report links serve this purpose). OS-specific instructions (unzip method, `chmod +x` on Linux) must stay accurate in the root `README.md`'s local setup instructions, since there is no installer to handle this automatically.

---

## Architecture Decisions

The following ADRs record the key architectural decisions behind the structure shown above. See [`docs/architecture/adr/`](adr/) for the full set.

| ADR | Decision | Quality requirement(s) addressed |
|---|---|---|
| [ADR-001](adr/ADR-001-unity-as-the-game-engine.md) | Use Unity as the game engine | QR-001 (time behaviour) |
| [ADR-002](adr/ADR-002-singleton-access-for-cross-cutting-player-state.md) | Use plain-C# singletons for cross-cutting player state (`PlayerManager`, `PlayerDigLogic`, `PlayerAnimator`) | QR-003 (operability) |
| [ADR-003](adr/ADR-003-separate-logic-classes-from-monobehaviour-wrappers.md) | Separate game-rule logic classes from `MonoBehaviour` wrapper classes | QR-002 (fault tolerance) |
