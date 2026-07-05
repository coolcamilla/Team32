# Testing

This document is the canonical testing status artifact for Operation: EarthCore.  
As of the assignment 5 submission, some tests were rewritten to account for the new game logic. Without that, the game could not progress further and develop into a proper MVP v2

## Critical Modules and Coverage

Critical modules are defined as source files responsible for core gameplay workflows where defects would materially affect the player experience.

| Critical module | Why critical | Required line coverage | Current line coverage | Evidence |
| --- | --- | --- | --- | --- |
| [`InventoryManager.cs`](../source/Assets/Scripts/Game%20management/Level/InventoryManager/InventoryManager.cs) | Core inventory logic - adding, spending, and stacking items. Used by every gameplay system. | 30% | **96%** | [Coverage report](../docs/CodeCoverageReport.htm) |
| [`CraftManager.cs`](../source/Assets/Scripts/Game%20management/Level/CraftManager/CraftManager.cs) | Crafting business rules - validates recipes, deducts materials, adds crafted items. | 30% | **100%** | [Coverage report](../docs/CodeCoverageReport.htm) |
| [`GridGenerator.cs`](../source/Assets/Scripts/Game%20management/Level/GridGenerator.cs) | World generation - spawns all blocks on scene load. Failure breaks the entire game. | 30% | **88.8%** | [Coverage report](../docs/CodeCoverageReport.htm) |

All three critical modules clear the 30% threshold individually, with substantial margin.

Global assembly coverage (`GameScripts`): **57.1%** (1074/1879 coverable lines). Global coverage is lower than critical-module coverage because several UI-only and input-driven classes are not yet covered by automated tests - see the table below.

### Known Untested or Lightly Tested Areas

| Class | Line coverage | Why it's not (yet) covered |
| --- | --- | --- |
| [`CollectableBehaviour`](../source/Assets/Scripts/Items/CollectableBehaviour.cs) | 0% | Relies on physics trigger events (`OnTriggerEnter2D`) in a live scene; not exercised by current PlayMode tests. Candidate for a future PlayMode test. |
| [`CraftPanelRenderer`](../source/Assets/Scripts/UI/Inventory/CraftPanelRenderer.cs) | 0% | UI rendering class; requires a fully wired canvas hierarchy. |
| [`CursorBehaviour`](../source/Assets/Scripts/UI/Cursor/CursorBehaviour.cs) | 0% | Cursor/visual-only class with no gameplay logic. |
| [`DepositDefinition`](../source/Assets/Scripts/Blocks/Scriptable%20objects/DepositDefinition.cs) | 0% | Plain data container populated via the Inspector; no behavior to test. |
| [`GameExit`](../source/Assets/Scripts/Game%20management/GameExit.cs) | 0% | Wraps `Application.Quit()`; not meaningfully testable in an automated Editor run. |
| [`InventorySlot`](../source/Assets/Scripts/UI/Inventory/InventorySlot.cs) | 0% | UI slot rendering; requires wired canvas hierarchy, same as `CraftPanelRenderer`. |
| [`LayerDefinition`](../source/Assets/Scripts/Blocks/Scriptable%20objects/LayerDefinition.cs) | 0% | Plain data container populated via the Inspector. |
| [`MenuesManager`](../source/Assets/Scripts/Game%20management/MainMenu/MenuesManager.cs) | 0% | Main-menu screen navigation; out of scope for current gameplay-focused tests. |
| [`SceneLoader`](../source/Assets/Scripts/Game%20management/SceneLoader.cs) | 0% | Wraps `SceneManager.LoadScene`; scene transitions are not exercised by the current PlayMode suite. |
| [`TypeToPrefab`](../source/Assets/Scripts/Items/Converters/TypeToPrefab.cs) | 0% | Static Resources-loading converter; not directly tested, though it is exercised indirectly wherever `BlockBehaviour` drops items. |
| [`PlayerInput`](../source/Assets/Scripts/Player/PlayerInput.cs) | 20.6% | Auto-generated Input System action bindings; most of this file is generated boilerplate. |
| [`DrillBehaviour`](../source/Assets/Scripts/Game%20management/Level/DrillManager/DrillBehaviour.cs) | 27.1% | Drill subsystem; not yet covered by dedicated tests. |
| [`PlayerDig`](../source/Assets/Scripts/Player/PlayerDig/PlayerDig.cs) | 34.7% | Input-driven `MonoBehaviour`; requires simulated input hardware to test in headless CI. Has partial coverage from indirect exercise via other systems. |
| [`PlayerDigLogic`](../source/Assets/Scripts/Player/PlayerDig/PlayerDigLogic.cs) | 36.3% | Companion logic class to `PlayerDig`; partially covered. |
| [`BlockBehaviour`](../source/Assets/Scripts/Blocks/BlockBehaviour/BlockBehaviour.cs) | 39.7% | The `MonoBehaviour` wrapper has partial coverage; most of its logic lives in `BlockBehaviourLogic` (100% covered) per the Logic/MonoBehaviour split documented in [ADR-003](architecture/adr/ADR-003-separate-logic-classes-from-monobehaviour-wrappers.md). |
| [`PlayerMovement`](../source/Assets/Scripts/Player/PlayerMovement.cs) | 48.5% | Input-driven `MonoBehaviour`; same input-simulation limitation as `PlayerDig`. |

## Automated Test Status

### EditMode Unit Tests

| Test class | Scope | File | Latest result |
| --- | --- | --- | --- |
| [`BlockLogicTests`](../source/Assets/Tests/EditMode/BlockLogicTests.cs) | `BlockBehaviourLogic` - damage, suitability, destruction, drop calculation | `Assets/Tests/EditMode/BlockLogicTests.cs` | Passing (9/9) |
| [`InventoryLogicTests`](../source/Assets/Tests/EditMode/InventoryLogicTests.cs) | `InventoryLogic` - add, stack, overflow, spend, move/swap | `Assets/Tests/EditMode/InventoryLogicTests.cs` | Passing (19/19) |
| [`CraftLogicTests`](../source/Assets/Tests/EditMode/CraftLogicTests.cs) | `CraftLogic` - recipe validation, material spending, edge cases | `Assets/Tests/EditMode/CraftLogicTests.cs` | Passing (7/7) |
| [`StaminaLogicTests`](../source/Assets/Tests/EditMode/StaminaLogicTests.cs) | `StaminaLogic` - drain, regeneration, multipliers, climbing threshold | `Assets/Tests/EditMode/StaminaLogicTests.cs` | Passing (17/17) |

**Total EditMode tests: 52/52 passing.**

### PlayMode Integration Tests

| Test class | Scope | File | Latest result |
| --- | --- | --- | --- |
| [`InventoryIntegrationTests`](../source/Assets/Tests/PlayMode/InventoryIntegrationTests.cs) | `InventoryManager` wrapper - real scene instance, real Stick resource | `Assets/Tests/PlayMode/InventoryIntegrationTests.cs` | Passing (5/5) |
| [`CraftingIntegrationTests`](../source/Assets/Tests/PlayMode/CraftingIntegrationTests.cs) | `CraftManager` + `InventoryManager` - full craft flow via real scene instances | `Assets/Tests/PlayMode/CraftingIntegrationTests.cs` | Passing (3/3) |
| [`GridGeneratorIntegrationTests`](../source/Assets/Tests/PlayMode/GridGeneratorIntegrationTests.cs) | `GridGenerator` - singleton init, block spawn count, regeneration | `Assets/Tests/PlayMode/GridGeneratorIntegrationTests.cs` | Passing (3/3) |
| [`InGameMenuManagerTests`](../source/Assets/Tests/PlayMode/InGameMenuManagerTests.cs) | `InGameMenuManager` - pause/resume toggle state machine | `Assets/Tests/PlayMode/InGameMenuManagerTests.cs` | Passing (4/4) |
| [`PlayerStaminaTests`](../source/Assets/Tests/PlayMode/PlayerStaminaTests.cs) | `PlayerStamina` wrapper - real Player instance, drain/regen/events | `Assets/Tests/PlayMode/PlayerStaminaTests.cs` | Passing (9/9) |
| [`QualityRequirementTests`](../source/Assets/Tests/PlayMode/Qualityrequirementtests.cs) | QRT-001, QRT-002, QRT-003 | `Assets/Tests/PlayMode/Qualityrequirementtests.cs` | Passing (3/3) |

**Total PlayMode tests: 27/27 passing.**

**Total automated tests: 79** (52 EditMode + 27 PlayMode).

## Automated Quality Requirement Tests

See [`docs/quality-requirement-tests.md`](quality-requirement-tests.md) for full QRT definitions, verification methods, and evidence.

| QRT | Linked QR | Status |
| --- | --- | --- |
| [QRT-001](quality-requirement-tests.md#qrt-001) | [QR-001 (time behaviour)](quality-requirements.md#qr-001-grid-generation-performance) | Passing |
| [QRT-002](quality-requirement-tests.md#qrt-002) | [QR-002 (fault tolerance)](quality-requirements.md#qr-002-block-initialization-fault-tolerance) | Passing |
| [QRT-003](quality-requirement-tests.md#qrt-003) | [QR-003 (operability)](quality-requirements.md#qr-003-initial-game-state-operability) | Passing |

## CI and QA Check Status

| Gate or check | Required for Done? | Latest protected-branch status | Evidence |
| --- | --- | --- | --- |
| Static analysis - Roslyn NetAnalyzers | Yes | Passing | [CI run](https://github.com/coolcamilla/Team32/actions/runs/28713657500) |
| Linting (included in Roslyn NetAnalyzers) | Yes | Passing | [CI run](https://github.com/coolcamilla/Team32/actions/runs/28713657500) |
| EditMode unit tests | Yes | Passing (52/52) | [CI run](https://github.com/coolcamilla/Team32/actions/runs/28713657497) |
| PlayMode integration + QRT tests | Yes | Passing (27/27) | [CI run](https://github.com/coolcamilla/Team32/actions/runs/28713657497) |
| Line coverage reporting | Yes | Generated | [Coverage report](../docs/CodeCoverageReport.htm) |
| Lychee link checking | Yes | Passing | [CI run](https://github.com/coolcamilla/Team32/actions/runs/28713657485) |

## Additional QA Check Rationale

| QA objective or risk | Additional QA check | Scope | Latest result | Evidence | Limitations or follow-up |
| --- | --- | --- | --- | --- | --- |
| Catch code defects beyond the Unity compiler - unused method results, undisposed objects, empty finalizers - that would not surface during normal gameplay testing. | Roslyn `Microsoft.CodeAnalysis.NetAnalyzers`, run via `dotnet build` in a standalone [`static-analysis/StaticAnalysis.csproj`](../static-analysis/StaticAnalysis.csproj) against [`UnityStubs.cs`](../static-analysis/UnityStubs.cs). | Pure C# logic classes: `BlockBehaviourLogic`, `InventoryLogic`, `CraftLogic`, `StaminaLogic`, `Item`. | Passing | [CI run](https://github.com/coolcamilla/Team32/actions/runs/28713657500) | `MonoBehaviour` classes are excluded since they depend on `UnityEngine` types not available to the isolated .NET SDK build; these are covered by PlayMode integration tests instead. The `<Compile Include>` list in [`StaticAnalysis.csproj`](../static-analysis/StaticAnalysis.csproj) must be updated manually whenever a logic-class file is renamed or moved. |

## Quality Gates That Remain Active for Later Project Work

All Assignment 4 quality gates are maintained project assets and continue to apply:

- EditMode and PlayMode tests must continue to pass on every PR and protected-branch push.
- [QRT-001](quality-requirement-tests.md#qrt-001), [QRT-002](quality-requirement-tests.md#qrt-002), [QRT-003](quality-requirement-tests.md#qrt-003) must continue to pass.
- Critical module line coverage must remain >= 30% individually for `InventoryManager`, `CraftManager`, and `GridGenerator` (currently 96%, 100%, and 88.8% respectively, well above threshold).
- Roslyn static analysis must pass on every PR and protected-branch push.
- If a product change makes a critical module or QRT obsolete, the Definition of Done and this document must be updated, and an equivalent or stronger check must replace it rather than being silently dropped.

## Manual Evidence That Does Not Count as QRT

| Evidence | Scope | Result | Follow-up PBI or issue |
| --- | --- | --- | --- |
| Customer UAT - Verify that the mole cannot fly out of the gameplay zone by pressing Space repeatedly. | Movement | Pass | None |
| Customer UAT - Verify that the mole can enter climbing mode and climb the background walls, now stamina-limited. | Movement (Climbing) | Pass | [Interactive Game Tutorial](https://github.com/coolcamilla/Team32/issues/200) |
| Customer UAT - Verify that the crafting system works correctly, and the player can craft a tool when they have sufficient resources. | Crafting System | Pass | [Mouse-based Navigation in Crafting UI](https://github.com/coolcamilla/Team32/issues/201) |
| Customer UAT - Verify that the inventory correctly tracks resources, allows adding and spending items. | Inventory | Pass (Sprint 2; not re-executed since stack-size changes shipped) | None |
| Customer UAT - Verify that the drill can be refueled and upgraded correctly. | Drill System | Pass | [Improve Drill UI](https://github.com/coolcamilla/Team32/issues/203), [Change World Layout](https://github.com/coolcamilla/Team32/issues/204) |
| Customer UAT - Verify that stamina depletes while climbing and recovers when the mole returns to normal movement. | Stamina System | Pass | [Overheating/risk mechanic follow-up](https://github.com/coolcamilla/Team32/issues/153) |
| Customer UAT - Verify that jump stacking and pause-related force accumulation have been fixed. | Movement (Jump/Pause) | Pass | None |


See [`docs/user-acceptance-tests.md`](user-acceptance-tests.md) for full UAT scenarios, IDs, and execution history.
