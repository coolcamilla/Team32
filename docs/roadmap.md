# Roadmap

## Product Goal

Deliver a 2D mining exploration game where the player character is a mole. The mole tries to reach Earth's Core by digging a deep burrow with different tools and a massive drill.

## Current Status

**Completed Sprints:** Sprint 1, Sprint 2, Sprint 3  
**Current Sprint:** Sprint 4  
**Next Sprint:** Sprint 5  

## Current Direction

The current sprint delivers new gameplay mechanics (layer transition, mining stations, death mechanic, and coins), responds to customer UI feedback, and prepares customer-facing handover documentation ahead of the final course delivery. The next sprint will use customer trial feedback to produce the final release, MVP v3, and will introduce mole upgrades, key remapping, and a save system.

---

# Sprint 1

### [Milestone](https://github.com/coolcamilla/Team32/milestone/1)  

### Start

Moday, June 15, 2026  

### End

Sunday, June 21, 2026  

### Goal  

Deliver a playable Windows and Linux build in which players can explore the dirt layer, collect resources, and craft tools to progress deeper.

### Planned items

- [US-010: Inventory](https://github.com/coolcamilla/Team32/issues/70)
- [US-014: Tile-by-tile Digging](https://github.com/coolcamilla/Team32/issues/78)  
- [US-015: Resource Drop](https://github.com/coolcamilla/Team32/issues/79)
- [US-016: Tools Crafting UI](https://github.com/coolcamilla/Team32/issues/80)  
- [US-017: Tools Crafting Action](https://github.com/coolcamilla/Team32/issues/81)  
- [Base Menu](https://github.com/coolcamilla/Team32/issues/87)  
- [Mole's Movement and Climb Mode](https://github.com/coolcamilla/Team32/issues/88)  
- [Description of the dirt layer](https://github.com/coolcamilla/Team32/issues/99)  

### Outcome

Playable build released for Windows and Linux, in which
- Players can dig through dirt blocks tile-by-tile using appropriate tools
- Four resource types (stick, stone, seedling, clay) drop from dirt blocks according to defined probabilities
- Players can collect resources into a 10-slot inventory with hotbar
- Player can browse the crafting catalog and craft two tools (wooden shovel, stone pickaxe)
- Items can be reallocated in the inventory via drag-and-drop
- Main menu and pause menu are functional for starting and exiting the game

# Sprint 2

### [Milestone](https://github.com/coolcamilla/Team32/milestone/2)  

### Start

Moday, June 22, 2026  

### End

Sunday, June 28, 2026  

### Goal  

Finalize core gameplay loop and improve game feel by adding a drill system with fuel and durability mechanics. Refactor core modules (inventory, crafting, world generation) for testability. Deliver a playable Windows and Linux build in which players can explore the surface and stone layer with resource deposits.

### Planned items

- [US-018](https://github.com/coolcamilla/Team32/issues/82)
- [Fix Mole's Movement](https://github.com/coolcamilla/Team32/issues/136)
- [Layer Description Template](https://github.com/coolcamilla/Team32/issues/143)
- [Improve Surface Layer Description](https://github.com/coolcamilla/Team32/issues/141)
- [Stone Layer Description](https://github.com/coolcamilla/Team32/issues/142)
- [Draw Items for the Stone Layer](https://github.com/coolcamilla/Team32/issues/146)
- [Mining Animation Stone Layer](https://github.com/coolcamilla/Team32/issues/147)
- [Refactor Block Logic](https://github.com/coolcamilla/Team32/issues/149)
- [Refactor Inventory System](https://github.com/coolcamilla/Team32/issues/150)
- [Refactor Pause Menu](https://github.com/coolcamilla/Team32/issues/151);
- [Quality Requirement, Unit, Integration Tests and QA check](https://github.com/coolcamilla/Team32/issues/152)
- [Testing Documentation](https://github.com/coolcamilla/Team32/issues/155)
- [Write UATs](https://github.com/coolcamilla/Team32/issues/156)
- [Add Sprint 2 to the Roadmap](https://github.com/coolcamilla/Team32/issues/157)

### Outcome

Playable build released for Windows and Linux, in which
- Players can upgrade the drill in drill upgrading UI
- Drill drops resources near itself from time to time
- Known bugs fixed

Non user-visible outcomes:
- Refactored system of inventory, block logic and pause menu
- Automated unit, integration and quality requirement tests
- Added the additional QA roslyn analyzers check
- Procedural generation enhanced, which now can spawn deposits

# Sprint 3

### [Milestone](https://github.com/coolcamilla/Team32/milestone/3)  

### Start

Moday, June 29, 2026  

### End

Sunday, July 5, 2026  

### Goal  

Deliver a playable Windows and Linux build that addresses customer feedback by simplifying the inventory/crafting flow and improving game feel with immersive mechanics, while strengthening product quality and stability through automated tests and architecture documentation.

### Planned items

- [US-006: Burrow depth](https://github.com/coolcamilla/Team32/issues/68)
- [US-020: Deposit Discovery](https://github.com/coolcamilla/Team32/issues/84)
- [Rotation-based Climbing Mode](https://github.com/coolcamilla/Team32/issues/171)
- [Stamina](https://github.com/coolcamilla/Team32/issues/167)
- [Update Tools Crafting Workflow](https://github.com/coolcamilla/Team32/issues/172)
- [Simplify Inventory](https://github.com/coolcamilla/Team32/issues/174)
- [Limited Visibility Mechanic](https://github.com/coolcamilla/Team32/issues/154)
- [Infinite jump](https://github.com/coolcamilla/Team32/issues/168)
- [Jump Force Accumulation](https://github.com/coolcamilla/Team32/issues/182)
- [Climbing Animation](https://github.com/coolcamilla/Team32/issues/148)
- [Draw Workbench](https://github.com/coolcamilla/Team32/issues/183)
- [Draw Drill Sign](https://github.com/coolcamilla/Team32/issues/184)
- [Draw Environment Tilesets](https://github.com/coolcamilla/Team32/issues/186)
- [Integrate Sprites and Animations into Unity](https://github.com/coolcamilla/Team32/issues/185)
- [Music and Sound Effects](https://github.com/coolcamilla/Team32/issues/86)
- [Update Tests week 5](https://github.com/coolcamilla/Team32/issues/192)
- [Maintain Architecture directory and ADRs](https://github.com/coolcamilla/Team32/issues/191)
- [Maintain Development Process](https://github.com/coolcamilla/Team32/issues/189)
- [Update Roadmap for Sprint 3](https://github.com/coolcamilla/Team32/issues/190)
- [Update and Execute UATs for MVP v2](https://github.com/coolcamilla/Team32/issues/188)
- [Create Release for MVP v2](https://github.com/coolcamilla/Team32/issues/187)

### Outcome

MVP v2 as a playable build released for Windows and Linux, in which:
- The mole can explore the surface layer with limited underground visibility (3-block radius)
- Resources drop from broken blocks and are collected automatically into the inventory
- The mole can craft tools at the workbench by pressing F; each new tool replaces the previous one in a fixed crafting order
- The drill can be fuelled and upgraded at the drill interface to progress deeper through layers
- Deposits of various resource types spawn across surface layer and can be discovered by digging
- The mole can climb background walls using a rotation-based Climbing Mode, with stamina that depletes while moving and regenerates when in normal mode
- Depth counter in the top-left corner show the mole's current depth in meters
- The hotbar at the bottom of the screen displays the mole's equipped tool
- The resource inventory can be viewed by pressing E, inventory stack size is 99
- New sprites added for the stone layer blocks, resources, tools, deposits, workbench, and drill sign

Non user-visible outcomes:
- Refactored tests, PauseManager, PlayerMovement, PlayerManager and GridGenerator
- Added automated unit and integration tests for the Stamina Logic, Stamina Behaviour, In Game Menu Manager
- Updated the testing documentation to reflect changes
- Added architecture documentation, static, dynamic and deployment views, ADRs
- Added development-process.md as the maintained artifact for the development and version control practices

# Sprint 4

### [Milestone](https://github.com/coolcamilla/Team32/milestone/4)  

### Start

Moday, July 6, 2026  

### End

Sunday, July 12, 2026  

### Goal  

Deliver a stable trial release for Windows and Linux which finalizes gameplay with new mechanics and addresses customer UI feedback, and prepare customer-facing handover documentation to demonstrate transition readiness.

### Planned items

- [US-019: Layer Transition](https://github.com/coolcamilla/Team32/issues/83)
- [US-021: Mining Stations Placement](https://github.com/coolcamilla/Team32/issues/85)
  - [Construction of Stations](https://github.com/coolcamilla/Team32/issues/139)
  - [Resource Extraction](https://github.com/coolcamilla/Team32/issues/145)
- [Coins and Beer](https://github.com/coolcamilla/Team32/issues/206)
- [Death Mechanic](https://github.com/coolcamilla/Team32/issues/153)
- [Update Drill UI](https://github.com/coolcamilla/Team32/issues/203)
- [Block Destruction](https://github.com/coolcamilla/Team32/issues/225)
- [Mouse-based Navigation in Crafting UI](https://github.com/coolcamilla/Team32/issues/201)
- [Edge Glow Artifact](https://github.com/coolcamilla/Team32/issues/227)
- [Construction Sprites](https://github.com/coolcamilla/Team32/issues/140)
- [Draw Coin and Vending Machine](https://github.com/coolcamilla/Team32/issues/222)
- [Draw UI Buttons and Icons](https://github.com/coolcamilla/Team32/issues/223)
- [Hit Sounds](https://github.com/coolcamilla/Team32/issues/226)
- [Define New Drill UI](https://github.com/coolcamilla/Team32/issues/224)
- [Update the Testing Suite and Documentation Week 6](https://github.com/coolcamilla/Team32/issues/233)
- [Maintain Roadmap and User Stories for Sprint 4](https://github.com/coolcamilla/Team32/issues/228)
- [Update and Execute UATs for trial release](https://github.com/coolcamilla/Team32/issues/229)
- [Create Trial Release](https://github.com/coolcamilla/Team32/issues/230)
- [Update Root README, create AGENTS, CONTRIBUTING](https://github.com/coolcamilla/Team32/issues/231)
- [Maintain Customer Handover Documentation](https://github.com/coolcamilla/Team32/issues/232)

### Outcome

Trial release as a playable build for Windows and Linux, in which:
`TODO`
- The drill triggers a layer transition when it reaches the stone layer, drops the resources required to craft the stone pickaxe, and updates the drill UI background to reflect the new layer
- Mining stations can be built on deposits; each station autonomously extracts resources into the mole's inventory
- The mole dies when stamina runs out, losing all resources and respawning at the drill on the surface
- Coins drop from blocks during digging and are displayed as a separate counter in the UI; the beer vending machine on the surface permanently increases maximum stamina for 5 coins
- The tool information panel in the crafting menu now appears on mouse hover rather than on click
- Block destruction now shows progressive crack animation and emits particles and a hit sound effect on every strike
- New sprites added for mining stations, coins, beer vending machine, UI buttons, and icons
- Hit sound effects added for dirt and stone blocks
- Edge glow artifact between block sprites is fixed

Non user-visible outcomes:
`TODO`
- Drill UI redesigned based on customer feedback and approved mockup
- `README.md` updated as the main public entry point with links to all maintained documentation
- `CONTRIBUTING.md` and `AGENTS.md` created with contributor and agent guidance
- `docs/customer-handover.md` created describing the current handover state of the product
- Testing suite and documentation updated to reflect Sprint 4 changes

# Sprint 5

This sprint will introduce MVP v3 which includes mole's upgrades, keys remapping, saving system and cometic improvements of the game.

# State reached by the end of the course

`TODO` in the end of the Sprint 5

---

# Work that must continue later

The following practices must continue throughout all future project work:

### Documentation
- **docs/testing.md:** Must be updated when critical modules change or new quality gates are added
- **docs/definition-of-done.md:** Must reflect current CI requirements and coverage expectations
- **docs/quality-requirements.md:** Must be updated when new quality requirements are identified, and each relevant quality requirement must link to at least one related ADR
- **docs/quality-requirement-tests.md:** Must be updated when QRTs are added or modified
- **docs/architecture/README.md:** Must be updated as new systems (mining stations, layer transitions, save system) are introduced, including updated static, dynamic, and deployment view diagrams
- **docs/architecture/adr/:** Each significant architecture decision must be recorded as an ADR and linked from `docs/architecture/README.md`
- **docs/development-process.md:** Must reflect the current git workflow, Sprint cadence, and configuration management practices, illustrated with a Mermaid `gitGraph` diagram
- **docs/user-acceptance-tests.md:** Must be kept current with all active UAT scenarios, each linked to relevant acceptance criteria, user story, or supporting PBI
- **Layer design documents:** Each new layer must have a corresponding design document following `game_design/layers/layer-template.md` before implementation begins
- **CHANGELOG.md:** Every user-visible change must be recorded under `Unreleased` as part of the PR workflow

### Automated Testing
- **Unit tests (EditMode):** All critical game-logic modules must maintain ≥30% line coverage
- **Integration tests (PlayMode):** Component interactions must be verified through automated tests
- **Quality Requirement Tests (QRT):** Each quality requirement must have at least one automated test verifying the measurable scenario

### CI Pipeline
- **Automated checks:** Linting, formatting, type-checking, build verification must pass on every PR
- **Test execution:** All unit, integration, and QRT tests must pass before merge
- **Coverage reporting:** Coverage reports must be generated and archived for each CI run

### Code Quality Standards
- **Testability pattern:** New features must follow the Model/Service + MonoBehaviour wrapper pattern to enable EditMode unit testing
- **Deterministic generation:** Procedural systems must use seed-based randomness for reproducibility
- **Atomic operations:** Resource transactions (crafting, building, refueling) must be atomic to prevent data loss
- **Configuration management:** Game constants and tunable parameters must remain in centralised configuration files rather than hardcoded in game logic

These practices ensure that the codebase remains maintainable, testable, and reliable.
