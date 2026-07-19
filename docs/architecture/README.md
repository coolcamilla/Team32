# Architecture
 
This document is the canonical maintained architecture index for **Operation: EarthCore**. It describes the current delivered architecture using three views — static, dynamic, and deployment — and links the Architecture Decision Records (ADRs) that explain why key structural choices were made.
 
Maintained architecture view sources live under:
 
- [`docs/architecture/static-view/`](static-view/) — component diagram source (PlantUML)
- [`docs/architecture/dynamic-view/`](dynamic-view/) — sequence diagram source (PlantUML)
- [`docs/architecture/deployment-view/`](deployment-view/) — deployment diagram source (PlantUML)
- [`docs/architecture/adr/`](adr/) — Architecture Decision Records
All diagrams are maintained as diagrams-as-code using **PlantUML**. Source `.puml` files are committed alongside their rendered `.svg` output so the architecture stays both versioned and directly readable without requiring a local renderer.
 
---
 
## Static View
 
![Component diagram](static-view/component-diagram.svg)
 
Source: [`static-view/component-diagram.puml`](static-view/component-diagram.puml)
 
### What the diagram shows
 
The component diagram groups the codebase into subsystems, all running inside the Unity Editor/Player runtime — there is no backend, database, or external API. Sprint 4 added three new subsystems on top of the structure established in Assignment 5.
 
- **Game Management** — `GameInitializer`, `GridGenerator`, and `GameExit` are co-located on a single `"Game Manager"` `GameObject` in the `Level` scene. `GridGenerator` is a singleton that delegates procedural world generation to `WorldGenerator` (a plain C# class handling terrain, layers, and deposit generation) and then instantiates block/background prefabs directly under its own `transform`.
- **Menu System** — `InGameMenuManager` handles both pausing (`Esc`) and inventory toggling (`E`) through a single `Toggle(GameObject)` state machine, driven by the `InGameMenu` action map.
- **Player Subsystem** — `PlayerMovement` and `PlayerDig` are attached to the player `GameObject` (`PlayerDig` requires `PlayerMovement`, and `PlayerMovement` in turn requires `PlayerStamina`, both via Unity's `[RequireComponent]`). `PlayerAnimator` is a `MonoBehaviour` singleton (static `Instance`, assigned in `Awake()`); `PlayerDigLogic` is a plain C# singleton. `PlayerManager` is **not** a singleton — it is a plain `MonoBehaviour` reached via `GetComponent<PlayerManager>()` (same `GameObject`) or a `"Player"` tag lookup (cross-`GameObject`, used by `InGameMenuManager`, `ToggleUI`, `CoinBehaviour`, and `BeerBarrelBehaviour`). `PlayerMovement`, `PlayerDig`, `PlayerManager`, and `PlayerStamina` each delegate their rules to a plain C# companion (`PlayerMovementLogic`, `PlayerDigLogic`, `PlayerManagerLogic`, `StaminaLogic`).
- **Death Handling *(added Sprint 4)*** — `DeathController` subscribes to a new `StaminaLogic.OnDeath` event, fired exactly once when stamina reaches zero (guarded by `StaminaLogic.Drain`'s early-return once `CurrentStamina <= 0`). On death it activates a death screen, waits a 10-second respawn delay (Inspector-configured on the `DeathController` component), then calls `InventoryManager.ClearResources()` and respawns both the player and stamina. **Confirmed from real source:** `ClearResources()` clears resources specifically — coins and equipped/crafted tools are untouched by this call, consistent with what the team told the customer during the Sprint Review (*"you keep all the coins you've collected, and your tools stay with you too"*).
- **Blocks / World** — `BlockBehaviour` (`MonoBehaviour`) delegates all damage/HP/drop-table logic to `BlockBehaviourLogic` (plain C#), and reads its stats from a `BlockTypeData` `ScriptableObject`. `WorldGenerator` reads `LayerDefinition`/`DepositDefinition` data to decide what each grid cell contains before `GridGenerator` renders it.
- **Items** — `Item` `ScriptableObject` assets are the single source of truth for item stats. `TypeToItemData` and `TypeToPrefab` are static converters that resolve an `ItemType` enum value to its `Item` asset or world prefab via `Resources.Load`. `ItemType.Coin = 77` was added this Sprint — its value sits below both the instrument (100+) and resource (300+) ranges, meaning coins are deliberately never stored in the general inventory; `TypeToPrefab` special-cases the `Coin` prefab path.
- **Mining Stations *(added Sprint 4)*** — `DepositNode` detects the player approaching a resource deposit and shows a build prompt once surrounding foreground blocks are cleared; pressing `F` opens `BuildStationUI` (a singleton) to spend inventory resources per a `StationRecipe` `ScriptableObject` and instantiate a `MiningStation`. Once built, `MiningStation` delegates to `MiningStationLogic` (plain C#, following the established Logic/MonoBehaviour split), which ticks a production interval (`60 / unitsPerMinute` seconds) and spawns the recipe's produced item nearby, unattended.
- **Drill / Layer Subsystem *(added Sprint 4)*** — `DrillBehaviour` runs its own autonomous digging loop, independent of the player's own movement, delegating depth/fuel/energy rules to `DrillLogic` (plain C#). Fuel is consumed to accumulate `Depth`; upgrading the `Drill`, `Engine`, and `FuelTank` `ScriptableObject` components each costs specific resources (`Pebbles`+`Clay` for Engine, `Pebbles`+`Stick` for Drill, `Pebbles` for Fuel Tank — all spent via `InventoryManager`). **`DrillLogic.IsStuck()` is a hard progression gate:** once depth reaches `3.5m`, the drill halts completely unless *all three* components have been upgraded at least once from their "Basic" tier (an OR condition — even one un-upgraded component blocks all further progress). On a successful layer transition, `DrillBehaviour` swaps its own local `Tilemap` tiles (`_bgBlocks`/`_fgBlocks`) — this is a **cosmetic change to a small diorama near the drill sign only**; it does not alter the real, explorable game world, which has its own separate physical dirt/stone layers gated by the player crafting a stone pickaxe. The drill also drops layer-appropriate resources near itself per the current `DrillLayer` data (drop chances, tile art) as it digs.
- **Coins & Beer Economy *(added Sprint 4)*** — `CoinBehaviour` is a pickup trigger calling `PlayerManager.AddCoin()`. `BeerBarrelBehaviour` is a proximity-triggered interactable (confirmed real): pressing Interact near it calls `PlayerManager.TrySpendCoins(5)` — a **hardcoded, non-scaling cost, confirmed from real source** — and on success calls `PlayerManager.UpgradeStamina()` → `PlayerStamina.Upgrade()`, which permanently increases max stamina by a flat `+5` (`ModifyMaxStamina(MaxStamina + 5)`, no visible cap), with different particle-color feedback for success versus failure.
- **Inventory Subsystem** — `InventoryManager` (`MonoBehaviour`, holds Unity references and input bindings) delegates all slot/stacking logic to `InventoryLogic` (plain C#, no Unity dependency), now including a `ClearResources()` method used by the new death mechanic. UI (`InventorySlot`, `InventoryItem`) locates `InventoryManager` via a `"Game Manager"` tag lookup.
- **Crafting Subsystem** — `CraftManager` requires `InventoryManager` on the same `GameObject` and delegates recipe validation and material spending to `CraftLogic`, which operates directly on `InventoryLogic`. `CraftManager` also consults the static `CraftTracker` class to check whether a tool has already been crafted and to gate progressive-tool prerequisites. `CraftTracker` now supports save/load via `GetCraftedTypes()`, `LoadCraftedTypes()`, and `ResetTracker()` — the "no reset mechanism" constraint from earlier Sprints has been resolved as part of the save system work.
- **Save System *(added Sprint 5)*** — `SaveManager` is a `MonoBehaviour` singleton that persists game state via `JsonUtility` to a local `.json` file at `Application.persistentDataPath`. It serializes coins (`PlayerManager`), stamina max and regen multiplier (`PlayerStamina`), full inventory contents (`InventoryManager.Logic.Slots`), crafted-tool history (`CraftTracker.GetCraftedTypes()`), and drill progress including component tiers and depth (`DrillBehaviour`). Save triggers on application quit; load triggers on `Start()` if `SaveManager.PendingLoad` is set (controlled by the main menu's "Continue" button). `SaveData` is a plain `[Serializable]` C# class — not a `ScriptableObject`, not a Logic class. This is deliberately **not** a Logic/MonoBehaviour split — `SaveManager` is a single class with no companion logic file, since the serialization logic is straightforward enough that the split would add indirection without a testability benefit.
- **Tutorial *(added Sprint 5)*** — `TutorialManager` is a `MonoBehaviour` that shows sprite-based tutorial pages (navigable forward/backward), pausing the game (`Time.timeScale = 0`) and disabling player input during display. It accesses `PlayerManager.Input` via the `"Player"` tag lookup pattern used elsewhere in the codebase. Opens automatically on scene load (the commented-out `SaveManager.HasSaveFile()` check suggests the intent to skip it on loaded saves, but this is currently disabled).
- **UI — two independent "Depth" displays.** `DepthCounter` (in `Assets/Scripts/UI/`) tracks the **player's own** world Y-position, completely independent of `DrillBehaviour.SyncDepth()`, which displays the **autonomous drill's own** `DrillLogic.Depth` in its upgrade panel. These are two unrelated systems that happen to both render text reading `"Depth: X m"` — worth being precise about which one any future documentation or UI work refers to, since they can diverge.
External dependencies remain limited to the Unity Engine platform itself: the Input System (`Player` and `InGameMenu` action maps), Physics2D, the Animator, the Tilemap system, and the Scene Manager. The product interacts with exactly one external "actor" — the player — and no network services.
 
### Coupling, cohesion, and maintainability
 
- **Logic/MonoBehaviour separation continues to be applied consistently to new code.** `MiningStationLogic` and `DrillLogic` follow the exact same pattern as `BlockBehaviourLogic`, `StaminaLogic`, and the others — evidence the team is maintaining this convention under real feature-delivery pressure, not just when convenient. **Notable exception:** `SaveManager` (added Sprint 5) deliberately does *not* follow this split, since its serialization logic is straightforward enough that a companion `SaveLogic` class would add indirection without a testability benefit. Per the real coverage report, `BlockBehaviourLogic`, `CraftLogic`, `StaminaLogic`, and `PlayerManagerLogic` each reach **100%** line coverage, and `InventoryLogic` reaches **83.9%** — these classes are unit-tested in isolation without loading a scene. See [ADR-003](adr/ADR-003-separate-logic-classes-from-monobehaviour-wrappers.md) for the full breakdown.
- **Cohesion is high within each subsystem** — each package groups a `MonoBehaviour`, its logic class, and its data (`ScriptableObject`) together, and each has a single clear responsibility.
- **Coupling risk: singletons.** `PlayerAnimator`, `BuildStationUI`, and `SaveManager` are `MonoBehaviour` singletons; `PlayerDigLogic` is a plain C# singleton. All are reached via static access rather than dependency injection. `PlayerManager` is a related but distinct case: it's reached via `GetComponent`/tag lookup, not a static singleton — see [ADR-002](adr/ADR-002-singleton-access-for-cross-cutting-player-state.md) for the full distinction.
- **Coupling risk: `GameObject.FindWithTag("Game Manager")` and `"Player"`.** UI classes, Sprint 4 classes (`CoinBehaviour`, `BeerBarrelBehaviour`, `DepthCounter`), and Sprint 5's `TutorialManager` all locate their target components via hardcoded tag lookups rather than a reference passed in or a singleton — a runtime-only, string-based coupling the compiler cannot verify.
- **`CraftTracker` state is now resettable** (via `ResetTracker()`, added for save/load support) — the earlier "no public reset method" testability constraint has been resolved. `SaveManager.Start()` calls `CraftTracker.ResetTracker()` on a fresh game, and `CraftTracker.LoadCraftedTypes()` restores persisted state on a loaded save.
- **New coupling worth watching: hardcoded economy and progression values.** The beer cost (`5` coins), stamina upgrade amount (`+5`), and the drill's layer-transition threshold (`3.5m`, hardcoded as `NewLayerDepth`) are all hardcoded directly in their respective classes, rather than being data-driven the way `StationRecipe` externalizes mining station costs. Sprint Review feedback suggests balance will need frequent tuning (the customer explicitly asked about price scaling) — worth revisiting as `ScriptableObject`-based configuration, consistent with the rest of the economy.
- **Two separate systems both gate "progress deeper," worth a team conversation.** The drill's own depth progress is gated by `IsStuck()` (all three components upgraded), while the player's own physical access to the stone layer is gated by crafting a stone pickaxe. These are independent, non-redundant gates by design (per direct confirmation), but their interaction isn't yet documented anywhere customer-facing beyond this note.
- **Known gap: `Time.timeScale` is not actively enforced on scene load.** `GameInitializer.Start()` is empty — nothing there resets `Time.timeScale`. The only places that explicitly set it to `1` are `SceneLoader` and `InGameMenuManager.ResumeGame()`.
- **Which quality requirements the structure supports or constrains:** the Logic/MonoBehaviour split directly supports **QR-002 (fault tolerance)** — `BlockBehaviourLogic` can be exercised with a null-data edge case in a PlayMode test without a full scene setup, which is exactly how [QRT-002](../quality-requirement-tests.md#qrt-002) is implemented. The new `DeathController`'s clean separation of concerns (subscribes to one event, delegates respawn logic to `PlayerMovement`/`PlayerStamina`/`InventoryManager` rather than reimplementing their reset logic) is a good example of the architecture's existing patterns paying off for a genuinely new, cross-cutting feature. The tag-based lookup patterns and the `Time.timeScale` gap above remain constraints on **QR-003 (operability)**: if the `"Game Manager"` or `"Player"` tags were ever renamed or duplicated, or if the `Level` scene were ever loaded through a path other than `SceneLoader`, dependent systems could fail with no compile-time warning.
---
 
 
## Dynamic View
 
![Dig, destroy block, drop item, and collect sequence diagram](dynamic-view/dig-pickup-sequence.svg)
 
Source: [`dynamic-view/dig-pickup-sequence.puml`](dynamic-view/dig-pickup-sequence.puml)
 
### What scenario the diagram represents
 
The diagram traces the core gameplay loop end to end: the player attempts to dig, the attempt is gated by a per-item cooldown timer and a climbing-state check, a valid hit applies damage and potentially destroys the block, a resource item drops into the world, and the player collects it into their inventory. This spans two separate runtime triggers (a dig input event, then later a physics trigger event when the player walks into the dropped item) and ten components across four subsystems (Player, Blocks/World, Items, Inventory).
 
**Corrected from an earlier version of this diagram**, after being asked to double-check it against the current source rather than assume it was still accurate: the earlier version omitted two real behaviors confirmed in `PlayerDig.cs` and `PlayerDigLogic.cs` — (1) digging is a no-op entirely while the player is climbing (`if (_playerMovement.IsClimbing) return;`), and (2) `BlockHit()` is not a simple "is this a valid block" check — it gates every dig attempt behind a per-item cooldown timer (`_timer >= EquippedItem.Cooldown`), incremented every frame via `PlayerDigLogic.UpdateTimer()`. The earlier diagram read `EquippedItem` *after* a successful `BlockHit()`; in reality it's read *before*, since the item's `Cooldown` value is itself an input to the check.
 
### Why this scenario is important to the product
 
This is the single most-executed interaction loop in the game — every resource the player ever obtains passes through this exact path (`PlayerDig` → `BlockBehaviour` → `BlockBehaviourLogic` → `TypeToPrefab` → `CollectableBehaviour` → `InventoryManager` → `InventoryLogic`). If any link in this chain breaks, the entire game becomes unplayable, which is why `QR-002` specifically targets `BlockBehaviour`'s fault tolerance.
 
### What it helps the reader reason about
 
- **Tool-dependent dig speed is a real mechanic, not just a cosmetic cooldown.** Because `BlockHit()` compares the elapsed timer against the *equipped item's* `Cooldown` field, different tools genuinely dig at different rates — this is gameplay-relevant balancing logic living inside what looks like a simple validity check, and is easy to miss without tracing the actual method signature.
- **Integration boundary between "world" and "inventory":** items only enter the inventory system through `CollectableBehaviour.OnTriggerEnter2D`, which is a physics-driven boundary, not a direct method call from `BlockBehaviour`. This means a dropped item is genuinely a separate world entity for a period of time — it has its own `GameObject`, can be missed by the player, and is not guaranteed to be picked up.
- **Where fault tolerance actually lives:** `BlockBehaviourLogic.IsItemSuitable` gates whether damage is applied at all, and `InventoryLogic.TryAddItem` returns `-1`/`false` rather than throwing when the inventory is full — the diagram shows both of these as explicit `alt` branches rather than assumed-successful paths, which is directly what `QRT-002` verifies for the block side.
- **Why `PlayerAnimator` exists as a singleton, and why `PlayerManager` doesn't:** the diagram shows `PlayerAnimator` reacting to `PlayerDig`'s `OnAnyDig` event via its static `Instance`, while `PlayerManager` is read for the currently equipped item via a `GetComponent` reference obtained in `PlayerDig.Awake()` — a `MonoBehaviour` reached by component lookup, not a singleton. Both achieve the same goal (state reachable without threading a reference through every call in the chain) via different mechanisms; the distinction and the correction behind it are recorded in [ADR-002](adr/ADR-002-singleton-access-for-cross-cutting-player-state.md).
---
 
## Deployment View
 
![Deployment diagram](deployment-view/deployment-diagram.svg)
 
Source: [`deployment-view/deployment-diagram.puml`](deployment-view/deployment-diagram.puml)
 
### What the diagram shows
 
Operation: EarthCore is built and distributed as a **standalone offline executable** — there is no server component. A team member's local Unity Editor (pinned to **6000.4.10f1**, matching [`docs/development-process.md`](../development-process.md)) is where development happens; GitHub Actions CI installs the identical pinned Editor version headlessly to run tests and produce Windows and Linux player builds. Build artifacts are placed in the repository's `releases/` folder and attached to SemVer-tagged GitHub Releases. Customers and TAs download a platform-specific ZIP, extract it, and run `TheMoleProject2D.exe` (Windows) or `LinuxBuild.x86_64` (Linux, after `chmod +x`) — this is the customer-facing access path documented in the root `README.md`'s local setup instructions. This view is unaffected by Sprint 5's gameplay/test changes and remains accurate.
 
### Why this deployment model was chosen
 
A standalone build was the natural choice for a Unity 2D single-player game with no multiplayer, persistence-across-devices, or server-authoritative requirement — there is no gameplay reason to require a network connection or hosted backend. This keeps the deployment surface minimal: no infrastructure to provision, secure, or pay for, which matters for a student team with no operations capacity.
 
### How the current deployment supports or constrains the product
 
**Supports:** zero runtime network dependency means the game works identically for every customer regardless of connectivity, and there are no server costs, uptime concerns, or backend security surface to manage — consistent with the "no runtime secrets" configuration-management approach in `docs/development-process.md`.
 
**Constrains:** cloud saves, leaderboards, or cross-device play would require introducing a backend that does not exist today. A local save system was added in Sprint 5 (`SaveManager`, writing to `Application.persistentDataPath` via `JsonUtility`) — this provides session-to-session persistence on the same machine, but save files do not transfer between devices or platforms. Distribution now includes **itch.io** (added Sprint 5) alongside GitHub Releases — builds are uploaded manually rather than through an automated continuous-delivery pipeline, as documented in `docs/development-process.md`'s CI Process section.
 
### What must be considered when deploying or operating it for the customer
 
Because there is no auto-update mechanism, customers must be told which specific version ZIP to download each Sprint (the release notes and Week N report links serve this purpose). OS-specific instructions (unzip method, `chmod +x` on Linux) must stay accurate in the root `README.md`'s local setup instructions, since there is no installer to handle this automatically.
 
---
 
## Architecture Decisions
 
The following ADRs record the key architectural decisions behind the structure shown above. See [`docs/architecture/adr/`](adr/) for the full set.
 
| ADR | Decision | Quality requirement(s) addressed |
|---|---|---|
| [ADR-001](adr/ADR-001-unity-as-the-game-engine.md) | Use Unity as the game engine | QR-001 (time behaviour) |
| [ADR-002](adr/ADR-002-singleton-access-for-cross-cutting-player-state.md) | Use singleton access (`MonoBehaviour` singleton for `PlayerAnimator`, plain C# for `PlayerDigLogic`) for cross-cutting player state; `PlayerManager` uses a different, non-singleton mechanism | QR-003 (operability) |
| [ADR-003](adr/ADR-003-separate-logic-classes-from-monobehaviour-wrappers.md) | Separate game-rule logic classes from `MonoBehaviour` wrapper classes | QR-002 (fault tolerance) |
 
Each ADR links back to the specific quality requirement(s) it addresses in [`docs/quality-requirements.md`](../quality-requirements.md), and each affected quality requirement links back to its ADR — see the "Linked ADRs" field on QR-001, QR-002, and QR-003.
