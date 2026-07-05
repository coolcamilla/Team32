# ADR-003: Separate Logic Classes from MonoBehaviour Wrapper Classes

**Status:** Accepted

## Context

`MonoBehaviour`-derived classes in Unity cannot be instantiated directly in a unit test (`new SomeMonoBehaviour()` is not supported by the engine) - they require a `GameObject` and, for most gameplay code, a loaded scene. This makes pure `MonoBehaviour` classes expensive to test in isolation: any test touching them tends to become a slower, scene-dependent PlayMode integration test rather than a fast EditMode unit test. The team's Sprint 4 reflection recorded this directly as a friction point: *"unit tests have low line coverage because they are not applicable in many cases"* ([`reports/week4/reflection.md`](../../../reports/week4/reflection.md)), and Assignment 4 introduced coverage requirements that made this tension concrete.

At the same time, several core subsystems have real business rules that have nothing to do with Unity's engine APIs: whether a block can take damage, whether an inventory slot can accept a stack, whether a craft recipe's materials are available.

## Decision

Split each core gameplay subsystem into two classes: a thin `MonoBehaviour` wrapper that holds Unity-specific references (`SerializeField` fields, `GameObject`/`Transform`/`Animator` access, Unity event wiring) and delegates all actual decision logic to a plain C# class with no `UnityEngine` scene dependency. This pattern is applied consistently across the codebase:

| `MonoBehaviour` wrapper | Plain C# logic class |
| --- | --- |
| `BlockBehaviour` | `BlockBehaviourLogic` |
| `InventoryManager` | `InventoryLogic` |
| `CraftManager` | `CraftLogic` |
| `PlayerDig` | `PlayerDigLogic` |
| `PlayerMovement` | `PlayerMovementLogic` |
| `PlayerManager` | `PlayerManagerLogic` |
| `DrillBehaviour` (drill subsystem) | `DrillLogic` |
| `PlayerStamina` | `StaminaLogic` |

For example, `BlockBehaviour.TryTakeDamage(Item item)` does no damage calculation itself - it forwards to `_logic.TryTakeDamage(item)`, and `BlockBehaviourLogic` contains the actual HP/suitability/drop-table rules with zero Unity API calls beyond what's needed for `System.Random`.

## Consequences and Tradeoffs

**Positive:**

- Logic classes are directly unit-testable without a loaded scene. It is measured against the real coverage report: `BlockBehaviourLogic`, `CraftLogic`, `StaminaLogic`, and `PlayerManagerLogic` each reach **100%** line coverage, and `InventoryLogic` reaches **83.9%**. All are exercised via `new SomeLogic(...)` with no scene, `GameObject`, or PlayMode required.
- The split does not, by itself, guarantee the *wrapper* is well-tested - see the tradeoff below. The benefit is specifically that the underlying rules are testable, independent of the wrapper's own coverage.
- The static-analysis pipeline (`static-analysis/UnityStubs.cs`, referenced in `docs/development-process.md`'s CI Process section) can run Roslyn analyzers against the plain-C# logic classes using lightweight stub types instead of the full Unity API surface, which is only practical because the logic classes don't depend on real `UnityEngine` behavior.
- Business rules are easier to reason about and modify independent of scene setup, prefab wiring, or Inspector configuration - a designer changing drop-table probabilities in `BlockBehaviourLogic.CalculateDrops()` doesn't risk breaking sprite/animation wiring in `BlockBehaviour`.

**Negative / tradeoffs:**

- **Duplication of state/indirection.** Every wrapper class needs to forward calls and often duplicate small amounts of state (e.g. `BlockBehaviour.BlockData` just proxies to internal logic-class state), which adds a layer of indirection a reader must follow to understand full behavior.
- **The split helps the logic class, not necessarily the wrapper.** `PlayerMovement` does have a `PlayerMovementLogic` companion (50% coverage), and `PlayerDig` has `PlayerDigLogic` (36.3%) - the split is applied consistently in the table above. But the wrappers themselves remain comparatively under-tested (`PlayerMovement` 48.5%, `PlayerDig` 34.7%, `BlockBehaviour` only 39.7% despite its logic class being 100%), because the wrapper still depends on live input, physics, or scene wiring that the split does not remove. The pattern makes *rules* testable; it does not automatically make the `MonoBehaviour` itself easy to test.
- **Discipline-dependent.** Nothing in the language or Unity enforces this split; it depends on the team consistently choosing to add new business logic to the plain C# class rather than the `MonoBehaviour`. A future contributor unfamiliar with this convention could easily add rule logic directly to a `MonoBehaviour` and erode the pattern's testability benefit over time.

## Quality Requirements Addressed

- [QR-002](../../quality-requirements.md#qr-002-block-initialization-fault-tolerance) (Fault tolerance) - this pattern is what makes [QRT-002](../../quality-requirement-tests.md#qrt-002) possible: the test adds a `BlockBehaviour` with no `BlockTypeData` and asserts an error is logged without a crash. Because `BlockBehaviourLogic` is a separate, simply-constructed object, this edge case can be exercised directly rather than requiring a fully scene-wired reproduction.
