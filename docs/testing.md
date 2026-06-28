# Testing

This document is the canonical testing status artifact for Operation: EarthCore.

## Critical Modules and Coverage

Critical modules are defined as source files responsible for core gameplay workflows
where defects would materially affect the player experience.

| Critical module | Why critical | Required line coverage | Current line coverage | Evidence |
| --- | --- | --- | --- | --- |
| `Assets/Scripts/Game Management/Level/InventoryManager/InventoryManager.cs` | Core inventory logic - adding, spending, and stacking items. Used by every gameplay system. | 30% | 68% | [CI run](https://github.com/coolcamilla/Team32/actions/runs/28330602258) |
| `Assets/Scripts/MonoBehaviour/Game Management/Level/CraftManager/CraftManager.cs` | Crafting business rules - validates recipes, deducts materials, adds crafted items. | 30% | 100% | [CI run](https://github.com/coolcamilla/Team32/actions/runs/28330602258) |
| `Assets/Scripts/MonoBehaviour/Game Management/Level/GridGenerator.cs` | World generation - spawns all blocks on scene load. Failure breaks the entire game. | 30% | 88.8% | [CI run](https://github.com/coolcamilla/Team32/actions/runs/28330602258) |

Global assembly coverage: **55.8%** (TheMoleProject2D, 1061/1899 coverable lines).
Global coverage is lower than critical-module coverage because UI-only classes
(`CursorBehaviour`, `CraftPanelRenderer`, `MenuesManager`, `SceneLoader`) and
input-driven classes (`PlayerDig`, `PlayerMovement`) are not covered by automated
tests - these require manual or hardware input that cannot be simulated in headless CI.

## Automated Test Status

| Test type | Scope | Files | Command or CI check | Latest result | Evidence |
| --- | --- | --- | --- | --- | --- |
| Integration tests (PlayMode) | `InventoryManager` - TryAddItem, IsEnough | `Assets/Tests/PlayMode/InventoryIntegrationTests.cs` | Unity Test Runner - PlayMode | Passing | [CI run](https://github.com/coolcamilla/Team32/actions/runs/28330602258) |
| Integration tests (PlayMode) | `CraftManager` + `InventoryManager` - full craft flow, success and failure paths | `Assets/Tests/PlayMode/Craftingintegrationtests.cs` | Unity Test Runner - PlayMode | Passing | [CI run](https://github.com/coolcamilla/Team32/actions/runs/28330602258) |
| Integration tests (PlayMode) | `GridGenerator` - block spawn count, tags, BlockTypeData assignment | `Assets/Tests/PlayMode/Gridgeneratorintegrationtests.cs` | Unity Test Runner - PlayMode | Passing | [CI run](https://github.com/coolcamilla/Team32/actions/runs/28330602258) |
| Unit tests (EditMode) | Block Logic | `Assets/Tests/EditMode/UnitTests.cs` | Unity Test Runner - EditMode | Passing | [CI run](https://github.com/coolcamilla/Team32/actions/runs/28330602258) |
| Automated QRTs (PlayMode) | QR-001 (time behaviour), QR-002 (fault tolerance), QR-003 (operability) | `Assets/Tests/PlayMode/Qualityrequirementtests.cs` | Unity Test Runner - PlayMode | Passing | [CI run](https://github.com/coolcamilla/Team32/actions/runs/28330602258) |

Total automated Play/Edit Mode tests: **18**

- `GridGeneratorIntegrationTests`: 4 tests
- `InventoryIntegrationTests`: 4 tests
- `CraftingIntegrationPlayModeTests`: 4 tests
- `BlockLogicTests`: 3 tests
- `QualityRequirementTests`: 3 tests (QRT-001, QRT-002, QRT-003)

## CI and QA Check Status

| Gate or check | Required for Done? | Latest protected-branch status | Evidence |
| --- | --- | --- | --- |
| Static analysis - Roslyn NetAnalyzers | Yes | Passing | [CI run](https://github.com/coolcamilla/Team32/actions/runs/28330602153) |
| Linting (included in the Roslyn NetAnalyzers) | Yes | Passing | [CI run](https://github.com/coolcamilla/Team32/actions/runs/28330602153) |
| PlayMode integration + EditMode unit + QRT tests | Yes | Passing | [CI run](https://github.com/coolcamilla/Team32/actions/runs/28330602258) |
| Lychee link checking | Yes | Passing | [CI run](https://github.com/coolcamilla/Team32/actions/runs/28330602280) |

## Additional QA Check Rationale

| QA objective or risk | Additional QA check | Scope | Latest result | Evidence | Limitations or follow-up |
| --- | --- | --- | --- | --- | --- |
| Catch code defects beyond the Unity compiler - unused method results, undisposed objects, empty finalizers - that would not surface during normal gameplay testing. | Roslyn `Microsoft.CodeAnalysis.NetAnalyzers` (rules CA2000, CA1806, CA1821), run via `dotnet build /warnaserror` in a standalone `static-analysis/StaticAnalysis.csproj`. | Pure C# model classes: `BlockModel`, `InventoryModel`, `CraftingService`, `DefaultDropResolver`, `IDropResolver`, `IItemRepository`, `CraftRecipe`, `ItemType`. | Passing | [CI run](https://github.com/coolcamilla/Team32/actions/runs/28330602153) | MonoBehaviour classes (`InventoryManager`, `CraftManager`, `GridGenerator`) are excluded because they depend on UnityEngine types not available to the .NET SDK. These classes are covered by PlayMode integration tests instead. |

## Quality Gates That Remain Active for Later Project Work

All Assignment 4 quality gates are maintained project assets and must remain active:

- PlayMode integration tests must continue to pass on every PR and protected-branch push.
- QRT-001, QRT-002, QRT-003 must continue to pass.
- Critical module line coverage must remain >= 30% (`InventoryManager`, `CraftManager`, `GridGenerator`).
- Roslyn static analysis must pass on every PR and protected-branch push.
- If a product change makes a critical module obsolete, the Definition of Done must be updated and an equivalent or stronger check must replace it.

## Manual Evidence That Does Not Count as QRT

| Evidence | Scope | Result | Follow-up PBI or issue |
| --- | --- | --- | --- |
| Customer UAT - Verify that the mole cannot fly out of the gameplay zone by pressing Space repeatedly. | Movement | Pass | None |
| Customer UAT - Verify that the mole can enter climbing mode and climb the background walls. | Movement (Climbing) | Pass | None |
| Customer UAT - Verify that the crafting system works correctly, and the player can craft a tool when he or she has sufficient resources. | Crafting System | Pass | None |
| Customer UAT - Verify that the inventory correctly tracks resources, allows adding and spending items. | Inventory System | Pass | None |
| Customer UAT - Verify that the player can refuel the drill and apply an upgrade to improve its performance. | Drill | Pass | None |
