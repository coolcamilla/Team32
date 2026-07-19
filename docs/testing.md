# Testing

This document is the canonical testing status artifact for Operation: EarthCore.

## Critical Modules and Coverage

Critical modules are defined as source files responsible for core gameplay workflows where defects would materially affect the player experience.

| Critical module | Why critical | Required line coverage | Current line coverage | Evidence |
| --- | --- | --- | --- | --- |
| `Assets/Scripts/Game management/Level/InventoryManager/InventoryManager.cs` | Core inventory logic - adding, spending, and stacking items. Used by every gameplay system. | 30% | **90.7%** | [Coverage report](CodeCoverageReport.htm) |
| `Assets/Scripts/Game management/Level/CraftManager/CraftManager.cs` | Crafting business rules - validates recipes, deducts materials, adds crafted items. | 30% | **100%** | [Coverage report](CodeCoverageReport.htm) |
| `Assets/Scripts/Game management/Level/GridGenerator.cs` | World generation - spawns all blocks on scene load. Failure breaks the entire game. | 30% | **90.9%** | [Coverage report](CodeCoverageReport.htm) |

All three critical modules clear the 30% threshold individually, with substantial margin. `InventoryManager`'s coverage decreased slightly from the previous report (96% -> 90.7%) and `GridGenerator`'s increased (88.8% -> 90.9%) - both remain comfortably above threshold.

Total line coverage: **66.7%** (2170/3249 coverable lines).

### Known Untested or Lightly Tested Areas

| Class | Line coverage | Why it's not (yet) covered | 
| --- | --- | --- |
| `CoinBehaviour` | 0% | New this Sprint. Coin pickup trigger; not yet covered by a PlayMode test. |
| `CollectableBehaviour` | 0% | Relies on physics trigger events (`OnTriggerEnter2D`) in a live scene; not exercised by current PlayMode tests. |
| `CraftPanelRenderer` | 0% | UI rendering class; requires a fully wired canvas hierarchy. |
| `CursorBehaviour` | 0% | Cursor/visual-only class with no gameplay logic. |
| `DepositDefinition` | 0% | Plain data container populated via the Inspector; no behavior to test. |
| `DrillLayer` | 0% | New this Sprint. Plain data container (drop chances, tile art) populated via the Inspector. |
| `Fuel` | 0% | New this Sprint. `ScriptableObject` data container; no behavior beyond its `Energy` field. |
| `GameExit` | 0% | Wraps `Application.Quit()`; not meaningfully testable in an automated Editor run. |
| `InventorySlot` | 0% | UI slot rendering; requires wired canvas hierarchy, same as `CraftPanelRenderer`. |
| `LayerDefinition` | 0% | Plain data container populated via the Inspector. |
| `MenuesManager` | 0% | Main-menu screen navigation; out of scope for current gameplay-focused tests. |
| `MiningStation` | 0% | New this Sprint. `MonoBehaviour` wrapper around `MiningStationLogic` (100% covered separately); the wrapper itself has no PlayMode test yet. |
| `SceneLoader` | 0% | Wraps `SceneManager.LoadScene`; scene transitions are not exercised by the current PlayMode suite. |
| `StationRecipe` | 0% | New this Sprint. `ScriptableObject` data container for mining station recipes; no behavior to test directly. |
| `TypeToPrefab` | 0% | Static Resources-loading converter; not directly tested, though it is exercised indirectly wherever `BlockBehaviour` drops items. |
| `BuildStationUI` | 15.6% | New this Sprint. UI panel singleton for building mining stations; not yet covered by a dedicated PlayMode test. |
| `BeerBarrelBehaviour` | 16.2% | New this Sprint. Trigger-zone interactable; not yet covered by a PlayMode test - see `docs/architecture/README.md` for the confirmed real mechanic (5 coins -> `PlayerManager.UpgradeStamina()`). |
| `DepositNode` | 14.7% | New this Sprint. Handles the mining-station build prompt/flow; not yet covered by a PlayMode test. |
| `PlayerInput` | 20.6% | Auto-generated Input System action bindings; most of this file is generated boilerplate. |
| `PlayerDig` | 34% | Input-driven `MonoBehaviour`; requires simulated input hardware to test in headless CI. Has partial coverage from indirect exercise via other systems. |
| `DrillBehaviour` | 34.5% | New this Sprint. Autonomous drill/layer-transition `MonoBehaviour`; its logic class (`DrillLogic`, 73.7%) has EditMode unit tests, but the wrapper itself does not yet have a PlayMode test. |
| `PlayerDigLogic` | 36.3% | Companion logic class to `PlayerDig`; partially covered. |
| `PlayerManager` | 37.5% | Now tracks `Coins` in addition to `EquippedItem` (see `PlayerManagerLogic`, 100% covered separately); the `MonoBehaviour` wrapper itself is only partially covered. |
| `BlockBehaviour` | 38.8% | The `MonoBehaviour` wrapper has partial coverage; most of its logic lives in `BlockBehaviourLogic` (100% covered) per the Logic/MonoBehaviour split documented in [ADR-003](architecture/adr/ADR-003-separate-logic-classes-from-monobehaviour-wrappers.md). |
| `PlayerMovement` | 49.1% | Input-driven `MonoBehaviour`; same input-simulation limitation as `PlayerDig`. |
| `DrillLogic` | 73.7% | New this Sprint. Below 100% by design this pass - depth-threshold-crossing and `IsStuck()` gate tests were deliberately deferred, since the real "Basic" tier stat values (`Speed`/`Power`/`Capacity`/`Fuel.Energy`) were not confirmed from source when `DrillLogicTests.cs` was written. See that file's header comment. |
| `DeathController` | 61.7% | New this Sprint. Partial coverage likely from indirect exercise via `PlayerStaminaTests`' `OnDeath`-related assertions rather than a dedicated `DeathController` PlayMode test. |

## Automated Test Status

### EditMode Unit Tests

| Test class | Scope | File | Latest result |
| --- | --- | --- | --- |
| `BlockLogicTests` | `BlockBehaviourLogic` - damage, suitability, destruction, drop calculation | `Assets/Tests/EditMode/BlockLogicTests.cs` | Passing (9/9) |
| `InventoryLogicTests` | `InventoryLogic` - add, stack, overflow, spend, move/swap | `Assets/Tests/EditMode/InventoryLogicTests.cs` | Passing (19/19) |
| `CraftLogicTests` | `CraftLogic` - recipe validation, material spending, edge cases | `Assets/Tests/EditMode/CraftLogicTests.cs` | Passing (7/7) |
| `StaminaLogicTests` | `StaminaLogic` - drain, regeneration, multipliers, climbing threshold, **death (`OnDeath`) and respawn (`ResetStamina`) added this Sprint** | `Assets/Tests/EditMode/StaminaLogicTests.cs` | Passing (23/23) |
| `MiningStationLogicTests` *(new this Sprint)* | `MiningStationLogic` - production interval timing, overflow handling | `Assets/Tests/EditMode/MiningStationLogicTests.cs` | Passing (6/6) |
| `PlayerManagerLogicTests` *(new this Sprint)* | `PlayerManagerLogic` - `Coins`/`AddCoin`/`TrySpend`. **`ChangeItem()` deliberately excluded** - see file header for the real static-`PlayerAnimator`-dependency risk found while writing these tests. | `Assets/Tests/EditMode/PlayerManagerLogicTests.cs` | Passing (8/8) |
| `DrillLogicTests` *(new this Sprint)* | `DrillLogic` - construction defaults, fuel capacity, `TryProcessSecond` fuel/timing gates. **Depth-threshold and `IsStuck()` gate testing intentionally deferred** - real "Basic" tier stat values (`Speed`/`Power`/`Capacity`/`Fuel.Energy`) are not yet confirmed from source; see file header. | `Assets/Tests/EditMode/DrillLogicTests.cs` | Passing (10/10) |

**Total EditMode tests: 82** (52 previously existing + 6 new `StaminaLogic` death/respawn tests + 6 `MiningStationLogicTests` + 8 `PlayerManagerLogicTests` + 10 `DrillLogicTests`), **all passing**.

**Note on static analysis scope:** `MiningStationLogic`, `PlayerManagerLogic`, and `DrillLogic` are not currently included in `static-analysis/StaticAnalysis.csproj`'s `<Compile Include>` list - the team's static-analysis scope is deliberately kept minimal for this project. Roslyn `NetAnalyzers` does not run against these three classes even though they follow the same plain-C# Logic pattern as the classes that are covered. Unit test coverage of these classes via the Unity Test Runner is unaffected by this and remains in place, as confirmed by the coverage report above.

### PlayMode Integration Tests

| Test class | Scope | File | Latest result |
| --- | --- | --- | --- |
| `InventoryIntegrationTests` | `InventoryManager` wrapper - real scene instance, real Stick resource | `Assets/Tests/PlayMode/InventoryIntegrationTests.cs` | Passing (5/5) |
| `CraftingIntegrationTests` | `CraftManager` + `InventoryManager` - full craft flow via real scene instances | `Assets/Tests/PlayMode/CraftingIntegrationTests.cs` | Passing (3/3) |
| `GridGeneratorIntegrationTests` | `GridGenerator` - singleton init, block spawn count, regeneration | `Assets/Tests/PlayMode/GridGeneratorIntegrationTests.cs` | Passing (3/3) |
| `InGameMenuManagerTests` | `InGameMenuManager` - pause/resume toggle state machine | `Assets/Tests/PlayMode/InGameMenuManagerTests.cs` | Passing (4/4) |
| `PlayerStaminaTests` | `PlayerStamina` wrapper - real Player instance, drain/regen/events | `Assets/Tests/PlayMode/PlayerStaminaTests.cs` | Passing (9/9) |
| `QualityRequirementTests` | QRT-001, QRT-002, QRT-003 | `Assets/Tests/PlayMode/Qualityrequirementtests.cs` | Passing (3/3) |

**Total PlayMode tests: 27, all passing** (confirmed). The `PlayModeTests` assembly shows 89.2% line coverage (below the EditMode assembly's 100%), meaning some conditional branches within these test files did not execute (e.g. an `if (!crafted)` fallback branch that never hit that case) - this is expected for tests with conditional logic and is consistent with all tests passing.

**Not yet covered by PlayMode integration tests, flagged rather than silently omitted:** `MiningStation`/`DepositNode` (build flow, production trigger), `DrillBehaviour` (fuel/upgrade flow, layer transition trigger), `DeathController` (death -> respawn coroutine sequence), and `BeerBarrelBehaviour` (purchase flow) are all new `MonoBehaviour` wrappers this Sprint with 0-35% coverage and no dedicated PlayMode test yet (see the Known Untested table above for exact current numbers). Their underlying Logic classes (where they exist) are covered above; the wrapper-level integration behavior is not yet.

**Total automated tests: 109** (82 EditMode + 27 PlayMode), all confirmed executed per the real coverage report uploaded 12.07.2026.

## Automated Quality Requirement Tests

See [`docs/quality-requirement-tests.md`](quality-requirement-tests.md) for full QRT definitions, verification methods, and evidence.

| QRT | Linked QR | Status |
| --- | --- | --- |
| QRT-001 | QR-001 (time behaviour) | Passing |
| QRT-002 | QR-002 (fault tolerance) | Passing |
| QRT-003 | QR-003 (operability) | Passing |

## CI and QA Check Status

| Gate or check | Required for Done? | Latest protected-branch status | Evidence |
| --- | --- | --- | --- |
| Static analysis - Roslyn NetAnalyzers | Yes | Passing | [CI run](https://github.com/coolcamilla/Team32/actions) |
| Linting (included in Roslyn NetAnalyzers) | Yes | Passing | [CI run](https://github.com/coolcamilla/Team32/actions) |
| EditMode unit tests | Yes | Passing (82/82) | [CI run](https://github.com/coolcamilla/Team32/actions) |
| PlayMode integration + QRT tests | Yes | Passing (27/27) | [CI run](https://github.com/coolcamilla/Team32/actions) |
| Line coverage reporting | Yes | Generated | [Coverage report](CodeCoverageReport.htm) |
| Lychee link checking | Yes | Passing | [CI run](https://github.com/coolcamilla/Team32/actions) |

## Additional QA Check Rationale

| QA objective or risk | Additional QA check | Scope | Latest result | Evidence | Limitations or follow-up |
| --- | --- | --- | --- | --- | --- |
| Catch code defects beyond the Unity compiler - unused method results, undisposed objects, empty finalizers - that would not surface during normal gameplay testing. | Roslyn `Microsoft.CodeAnalysis.NetAnalyzers`, run via `dotnet build` in a standalone `static-analysis/StaticAnalysis.csproj` against `UnityStubs.cs`. | Pure C# logic classes: `BlockBehaviourLogic`, `InventoryLogic`, `CraftLogic`, `StaminaLogic`, `Item`. | Passing | [CI run](https://github.com/coolcamilla/Team32/actions) | `MonoBehaviour` classes are excluded since they depend on `UnityEngine` types not available to the isolated .NET SDK build; these are covered by PlayMode integration tests instead. The `<Compile Include>` list in `StaticAnalysis.csproj` must be updated manually whenever a logic-class file is renamed or moved. |

## Quality Gates That Remain Active for Later Project Work

All Assignment 4 quality gates are maintained project assets and continue to apply:

- EditMode and PlayMode tests must continue to pass on every PR and protected-branch push.
- QRT-001, QRT-002, QRT-003 must continue to pass.
- Critical module line coverage must remain >= 30% individually for `InventoryManager`, `CraftManager`, and `GridGenerator` (currently 96%, 100%, and 88.8% respectively, well above threshold).
- Roslyn static analysis must pass on every PR and protected-branch push.
- If a product change makes a critical module or QRT obsolete, the Definition of Done and this document must be updated, and an equivalent or stronger check must replace it rather than being silently dropped.

## Manual Evidence That Does Not Count as QRT

| Evidence | Scope | Result | Follow-up PBI or issue |
| --- | --- | --- | --- |
| Customer UAT - Verify that the mole cannot fly out of the gameplay zone by pressing Space repeatedly. | Movement | Pass (Sprint 3; not re-executed since) | [Corner-grab Jump](https://github.com/coolcamilla/Team32/issues/170) |
| Customer UAT - Verify that the mole can enter climbing mode and climb the background walls. | Movement (Climbing) | Pass (Sprint 3; not re-executed since) | [Interactive Game Tutorial](https://github.com/coolcamilla/Team32/issues/200) |
| Customer UAT - Verify that the crafting system works correctly, and the player can craft a tool when they have sufficient resources. | Crafting System | **Pass (Sprint 5 - current)** | None |
| Customer UAT - Verify that the inventory correctly tracks resources, allows adding and spending items. | Inventory | Pass (Sprint 2 only; not re-executed since) | [Simplify Inventory](https://github.com/coolcamilla/Team32/issues/174) |
| Customer UAT - Verify that the drill can be refueled and upgraded correctly. | Drill System | **Pass (Sprint 5 - current)** | None |
| Customer UAT - Verify that stamina depletes in Climbing Mode and that reaching zero triggers the death mechanic and the beer vending machine correctly increases max stamina for 5 coins. | Stamina / Death / Beer System | **Pass (Sprint 5 - current)** | None |
| Customer UAT - Verify that jump stacking and pause-related force accumulation have been fixed. | Movement (Jump/Pause) | Pass (Sprint 3; not re-executed since) | None |
| Customer UAT - Verify that the player can discover a deposit, build a mining station on it, and that the station autonomously collects resources into the inventory. | Mining Stations | Pass (Sprint 4; not re-executed Sprint 5) | [Improve Game Balance](https://github.com/coolcamilla/Team32/issues/237) |
| Customer UAT - Verify that the drill correctly triggers a layer transition, drops the required resources, and allows the mole to access and dig in the new layer with a crafted stone pickaxe. | Layer Transition | Pass (Sprint 4; not re-executed Sprint 5) | [Improve Game Balance](https://github.com/coolcamilla/Team32/issues/237) |
| Customer UAT - Verify that the introductory cutscene plays on new game, followed by the tutorial, and the ending cutscene plays when the drill completes the stone layer. | Cutscenes *(new Sprint 5)* | **Pass (Sprint 5 - current)** | None |

**4 of 10 UATs were executed this Sprint** (Crafting, Drill, Stamina/Death/Beer, and the new Cutscenes scenario). UAT-003, UAT-005, and UAT-006 were updated before execution to align with current implementation. No UATs failed; several UX and polish issues were identified but none require immediate product changes - see the Sprint 5 execution history in `docs/user-acceptance-tests.md` for the full list.

See [`docs/user-acceptance-tests.md`](user-acceptance-tests.md) for full UAT scenarios, IDs, and execution history.
