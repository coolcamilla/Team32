# ADR-001: Use Unity as the Game Engine

**Status:** Accepted

## Context

Operation: EarthCore is a 2D PC game requiring tile/grid-based procedural world generation, 2D physics (raycasting for digging, trigger colliders for item pickup), sprite animation, and a UI layer for inventory and crafting. The team needed an engine that could support rapid MVP iteration within course timelines while remaining approachable for a team without professional game-engine experience.

**This decision predates the team's ADR practice** (ADRs were introduced as a maintained artifact starting in Assignment 5), but it was discussed directly with the customer during the Week 1 discovery interview, before any code was written. When asked directly whether there were engine restrictions ("can we use Unity or Unreal, for example?"), the customer confirmed no hard restriction existed but recommended Unity specifically, citing faster access to third-party assets as the reason: *"It's better to choose Unity. Of course Unity is better because it's a direct path to assets."* Our own response in the interview: calling Unity "probably the simplest platform", reflects that we weighed approachability for a non-specialist team as consistent with the customer's recommendation, not just deferred to it.

## Decision

Use **Unity** (currently pinned to Editor version 6000.4.10f1, per [`docs/development-process.md`](../../development-process.md)) as the game engine for the entire product, including 2D physics, the Input System (action-based), the Animator system, and `ScriptableObject`-based data assets for items, blocks, and drill components. This follows the customer's Week 1 recommendation and the team's own assessment that Unity was the most approachable option for a team without professional game-engine experience.

## Consequences and Tradeoffs

**Positive:**

- Unity's 2D physics (`Physics2D.Raycast`, trigger colliders) directly supports the core dig and pickup interactions with minimal custom code, as shown in `PlayerDig` and `CollectableBehaviour`.
- `ScriptableObject` assets (`Item`, `BlockTypeData`, `Engine`, `FuelTank`, `Drill`) give the team a data-driven design workflow - new items, blocks, or drill parts can be added without code changes, which matters given the team's non-programmer contributors (e.g. game design/UX roles noted in customer meeting transcripts).
- The Unity Test Runner (EditMode/PlayMode) integrates with the team's CI pipeline and is the basis for the entire automated test suite in [`docs/testing.md`](../../testing.md).
- Large ecosystem and documentation lower onboarding cost for a student team.

**Negative / tradeoffs:**

- Unity project files (scenes, prefabs) are YAML-serialized and merge poorly in Git; the team has had to work around this. This is reflected in [`reports/week4/reflection.md`](../../../reports/week4/reflection.md): *"Setting up CI for a Unity project was significantly harder than for a typical web app. Industry best practices often need adaptation for game engines."*
- Headless CI requires installing and licensing a full Unity Editor on the CI runner rather than a lightweight interpreter/compiler, which is more expensive in CI minutes and setup complexity than a typical non-game project.
- The customer's stated rationale ("direct path to assets") optimizes for build speed and content velocity, not for the specific pain points the team hit later (Git-unfriendly serialized scene files, difficulty unit-testing `MonoBehaviour`-heavy code). Those tradeoffs weren't part of the original Week 1 discussion and only became visible once the team was deep into implementation - a risk worth naming explicitly for future teams evaluating the same advice.

## Quality Requirements Addressed

- [QR-001](../../quality-requirements.md#qr-001-grid-generation-performance) (Time behaviour) - Unity's `Physics2D`/`GameObject` instantiation pipeline is what `GridGenerator` relies on to spawn the grid within the 3-second budget; the engine's instantiation performance directly bounds this requirement.
