# Quality Requirements

## QR-001: Grid generation performance

- **Sub-characteristic:** Time behaviour
- **Rationale:** Players expect the game world to load and be ready for interaction quickly. If the grid takes too long to spawn, it causes a noticeable delay, degrading the initial user experience and perceived performance of the game.
- **Scenario:** When the system loads the game scene under standard production-like conditions, the [`GridGenerator`](../source/Assets/Scripts/Game%20management/Level/GridGenerator.cs) component shall spawn the initial grid of blocks within 3 seconds.
- **Linked QRTs:** [QRT-001](quality-requirement-tests.md#qrt-001)

## QR-002: Block initialization fault tolerance

- **Sub-characteristic:** Fault tolerance
- **Rationale:** Missing data or misconfigured prefabs can occur during development or due to corrupted data. The game must handle these edge cases gracefully to prevent frustrating crashes for players and to allow developers to easily diagnose configuration issues via error logs.
- **Scenario:** When the system instantiates a block GameObject without required block type data under the standard Unity runtime environment, the [`BlockBehaviour`](../source/Assets/Scripts/Blocks/BlockBehaviour/BlockBehaviour.cs) component shall log an error and prevent an application crash within 1 frame.
- **Linked QRTs:** [QRT-002](quality-requirement-tests.md#qrt-002)

## QR-003: Initial game state operability

- **Sub-characteristic:** Operability
- **Rationale:** Players expect the game to be immediately playable upon loading or restarting a level. If the game starts in a paused state, it confuses users, makes the game appear broken, and severely impacts the initial operability and user experience.
- **Scenario:** When the system loads the game scene under standard conditions, the [`InGameMenuManager`](../source/Assets/Scripts/Game%20management/Level/InGameMenuManager.cs) artifact shall ensure the game state is fully unpaused (`Time.timeScale = 1`) within 1 frame.
- **Linked QRTs:** [QRT-003](quality-requirement-tests.md#qrt-003)
