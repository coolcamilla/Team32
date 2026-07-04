# ADR-002: Use Singleton Access for Cross-Cutting Player State

**Status:** Accepted

## Context

Several pieces of player state need to be readable from multiple, otherwise-unrelated subsystems without those subsystems holding a direct object reference to each other:

- `PlayerAnimator` needs to react to events raised by `PlayerDig` (`OnAnyDig`, `OnVerticalDirectionChange`) and to instrument changes forwarded through `PlayerManagerLogic.ChangeItem`, without `PlayerDig` needing to know an `Animator` exists.
- `PlayerDigLogic` holds digging timer/direction state and is used by `PlayerDig`.

Unity's `MonoBehaviour` component model does not provide built-in dependency injection. The idiomatic Unity alternatives are: (a) wire every cross-subsystem reference manually via the Inspector (`[SerializeField]` references) or `GetComponent`/`Find` calls, or (b) expose shared state through static `Instance` singleton accessors.

**Correction from an earlier version of this ADR:** a prior draft included `PlayerManager` as a third singleton in this pattern. Checking the real `PlayerManager.cs` directly (rather than the `static-analysis/UnityStubs.cs` mirror, which turned out to declare a `public static PlayerManager Instance` field that does not exist on the real class — the same stub file was already found to misrepresent `BlockTypeData` elsewhere) shows `PlayerManager` has **no static `Instance` field at all**. It is a plain `MonoBehaviour` reached exclusively via `GetComponent<PlayerManager>()` (same `GameObject`) or `GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>()` (cross-`GameObject`, used by `InGameMenuManager` and `ToggleUI`). `PlayerManager` is discussed below for contrast, not as an example of this ADR's decision.

## Decision

Use singletons accessed via a static `Instance` property for the two classes that actually implement this pattern:

- **`PlayerAnimator`** is a `MonoBehaviour` singleton — `public static PlayerAnimator Instance { get; private set; }`, assigned in `Awake()` (`if (Instance == null) { Instance = this; ... } else { Destroy(gameObject); }` — the same duplicate-guard pattern `GridGenerator` uses). It needs to live on a `GameObject` because it holds an `Animator` component reference.
- **`PlayerDigLogic`** is a plain C# (non-`MonoBehaviour`) lazily-initialized singleton — `if (_instance == null) _instance = new PlayerDigLogic(); return _instance;` — with no Unity API dependency, consistent with the Logic/MonoBehaviour split in [ADR-003](ADR-003-separate-logic-classes-from-monobehaviour-wrappers.md).

`PlayerManager` solves the same underlying problem (cross-subsystem access to player state) through a **different** mechanism: `GetComponent`/tag lookup rather than a static singleton. This ADR's decision applies to `PlayerAnimator` and `PlayerDigLogic` specifically, not to every cross-cutting access pattern in the Player subsystem.

Concretely, as shown in the codebase:

```csharp
// PlayerAnimator.cs — MonoBehaviour singleton
public static PlayerAnimator Instance { get; private set; }
private void Awake()
{
    if (Instance == null) { Instance = this; _animator = GetComponent<Animator>(); }
    else { Destroy(gameObject); }
    GetComponent<PlayerDig>().OnAnyDig += SetMiningTrigger;
}
```

```csharp
// PlayerDigLogic.cs — plain C# lazy singleton
public static PlayerDigLogic Instance
{
    get { if (_instance == null) _instance = new PlayerDigLogic(); return _instance; }
}
```

```csharp
// PlayerDig.cs — consumes both: a true singleton (PlayerDigLogic) and a
// GetComponent-based reference (PlayerManager) side by side
_playerManager = GetComponent<PlayerManager>();
_logic = PlayerDigLogic.Instance;
```

## Consequences and Tradeoffs

**Positive:**

- For the two classes that do use this pattern, it removes the need for manual Inspector wiring — any class can reach `PlayerAnimator.Instance` or `PlayerDigLogic.Instance` without a scene-graph reference.
- Keeps `PlayerDigLogic` as plain C# (not `MonoBehaviour`), which — combined with [ADR-003](ADR-003-separate-logic-classes-from-monobehaviour-wrappers.md) — is part of why that specific class is unit-testable via `new PlayerDigLogic()`-style construction without a Unity scene. `PlayerAnimator` does not get this same benefit, since it is itself a `MonoBehaviour` and still requires a `GameObject`/scene context.

**Negative / tradeoffs:**

- **Implicit global state.** Any class in the codebase can read or mutate `PlayerDigLogic.Instance`'s timer/direction state, or trigger `PlayerAnimator.Instance`'s animation calls, without that dependency being visible in a constructor signature or `[SerializeField]` reference. As the codebase grows, it becomes harder to answer "what can change this value and when?" purely by reading a class's own file.
- **Single-player-only assumption baked in.** The singleton pattern implicitly assumes exactly one player exists per running instance. This is true today and matches the product's single-player scope, but it would need to be revisited if any future multiplayer or split-screen feature were ever considered.
- **`MonoBehaviour` singleton lifecycle risk.** `PlayerAnimator.Instance` is only valid after its `Awake()` has run — a consumer reaching `Instance` earlier (e.g. from another script's own `Awake()`, where Unity does not guarantee execution order across components) could get a `null` reference. `PlayerDigLogic.Instance`, being lazily constructed on first access, does not share this specific risk.
- **Two different cross-cutting access styles exist side by side in the same subsystem, which is easy to misread.** `PlayerDig.Awake()` reaches `PlayerManager` via `GetComponent` and `PlayerDigLogic` via `Instance` in adjacent lines — a reader has to know which classes actually implement the singleton pattern and which don't, since the calling code doesn't visually distinguish them. This ADR exists partly to make that distinction explicit after an earlier documentation pass got it wrong.
- **Testability constraint acknowledged in `docs/testing.md`:** `PlayerDig` and `PlayerMovement` have only partial automated coverage (34.7% and 48.5% respectively) since they are input-driven `MonoBehaviour` classes that require simulated input hardware to test fully in headless CI.

## Quality Requirements Addressed

- [QR-003](../../quality-requirements.md#qr-003-initial-game-state-operability) (Operability) — the singleton pattern is directly implicated in ensuring cross-cutting state (e.g. animation triggers reacting to dig/movement events) is consistently available immediately on scene load without requiring every consumer to be wired through the Inspector, at the cost of the implicit-coupling tradeoffs above. Note: QR-003's actual scenario concerns `Time.timeScale`, now owned by `InGameMenuManager` — this ADR's connection to QR-003 is about the general operability pattern of singleton-based state availability, not `InGameMenuManager` specifically.
