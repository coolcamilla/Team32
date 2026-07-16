# Roadmap

## Product Goal

Deliver a 2D mining exploration game where the player character is a mole. The mole tries to reach Earth's Core by digging a deep burrow with different tools and a massive drill.

## Current Status

**Completed Sprints:** Sprint 1, Sprint 2, Sprint 3, Sprint 4  
**Current Sprint:** Sprint 5  
**Next Sprint:** _Not planned_

## Current Direction

The current sprint delivers the final course version, MVP v3, focusing on polish, balance, and handover rather than new mechanics. Key work includes saving, cutscenes, audio integration, UI improvements, stamina rebalancing, and deployment to itch.io. The product is being transitioned to the customer with complete handover documentation, and no further Sprints are planned after this one.

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

Deliver a stable trial release for Windows and Linux which finalizes gameplay with new mechanics and addresses customer UI and game feel feedback, and prepare customer-facing handover documentation to demonstrate transition readiness.

### Planned items

- [US-019: Layer Transition](https://github.com/coolcamilla/Team32/issues/83)
- [US-021: Mining Stations Placement](https://github.com/coolcamilla/Team32/issues/85)
  - [Construction of Stations](https://github.com/coolcamilla/Team32/issues/139)
  - [Resource Extraction](https://github.com/coolcamilla/Team32/issues/145)
- [Coins and Beer](https://github.com/coolcamilla/Team32/issues/206)
- [Death Mechanic](https://github.com/coolcamilla/Team32/issues/153)
- [Block Destruction](https://github.com/coolcamilla/Team32/issues/225)
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
- [Maintain Architecture and Views Sprint 4](https://github.com/coolcamilla/Team32/issues/243)

### Outcome

Trial release as a playable build for Windows and Linux, in which:
- The drill triggers a layer transition when it reaches the stone layer, drops the resources required to craft the stone pickaxe, and updates the drill UI background to reflect the new layer
- Mining stations can be built on deposits; each station autonomously extracts resources and drops them near the deposit
- The mole dies when stamina runs out, losing all resources and respawning at the drill on the surface
- Coins drop from blocks during digging and are displayed as a separate counter in the UI; the beer vending machine on the surface permanently increases maximum stamina for 5 coins
- Block destruction now shows progressive crack animation and emits particles on every strike
- New sprites added for mining stations, coins, and beer vending machine

Non user-visible outcomes:
- Updated the testing suite to cover the new mechanics.
- Updated the `testing.md` to cover the changes to testing
- Created and `maintained customer-handover.md` as the "current-state description" document
- Updated the `architecture/` directory to represent the current structure of the project

# Sprint 5

### [Milestone](https://github.com/coolcamilla/Team32/milestone/5)  

### Start

Moday, July 13, 2026  

### End

Sunday, July 19, 2026  

### Goal  

Deliver MVP v3 for Windows and Linux with polished UI and game feel improvements. Deploy it to [itch.io](https://itch.io) and hand over to the customer with complete transition documentation.

### Planned items

- [US-001: Saving](https://github.com/coolcamilla/Team32/issues/65)
- [Make Discovered Block Temporary](https://github.com/coolcamilla/Team32/issues/207)
- [Add Cutscences](https://github.com/coolcamilla/Team32/issues/256)
- [Integrate Music and Sound Effects](https://github.com/coolcamilla/Team32/issues/263)
- [Mouse-based Navigation in Crafting UI](https://github.com/coolcamilla/Team32/issues/201)
- [Improve Drill UI](https://github.com/coolcamilla/Team32/issues/203)
- [Change World Layout](https://github.com/coolcamilla/Team32/issues/204)
- [Stamina Warning Indicator](https://github.com/coolcamilla/Team32/issues/236)
- [Rebalance Stamina](https://github.com/coolcamilla/Team32/issues/262)
- [Edge Glow Artifact](https://github.com/coolcamilla/Team32/issues/227)
- [Improve Game Balance](https://github.com/coolcamilla/Team32/issues/237) 
- [Start and End Cutscenes](https://github.com/coolcamilla/Team32/issues/238)
- [Make the Game Tutorial](https://github.com/coolcamilla/Team32/issues/200)
- [Draw Background](https://github.com/coolcamilla/Team32/issues/257)
- [Animate Block Destruction](https://github.com/coolcamilla/Team32/issues/258)
- [Animate Falling Mole](https://github.com/coolcamilla/Team32/issues/259)
- [Draw New Drill UI](https://github.com/coolcamilla/Team32/issues/260)
- [Music And Sounds for MVP v3](https://github.com/coolcamilla/Team32/issues/261)
- [Update and Execute UATs for MVP v3](https://github.com/coolcamilla/Team32/issues/265)
- [Update the Testing Suite and Documentation Week 7](https://github.com/coolcamilla/Team32/issues/270)
- [Maintain Roadmap and User Stories for Sprint 5](https://github.com/coolcamilla/Team32/issues/267)
- [Maintain Architecture and Views Sprint 5](https://github.com/coolcamilla/Team32/issues/269)
- [Maintain Customer Handover Documentation Week 7](https://github.com/coolcamilla/Team32/issues/271)
- [Create MVP v3 Release](https://github.com/coolcamilla/Team32/issues/266)
- [Publish Game](https://github.com/coolcamilla/Team32/issues/239)

### Outcome

MVP v3 as a playable build for Windows and Linux, in which:
- The player can manually save the game state to a local `.txt` file and load it from the main menu
- An introductory cutscene plays on new game start, presenting the mole's backstory and the game tutorial; an ending cutscene plays when the drill completes the stone layer
- Music and sound effects are integrated
- The stamina bar is divided into sections; the initial stamina pool is small, regeneration is slow, and drinking beer fully restores stamina, adds a new section, and increases regeneration rate
- A red vignette pulses at the edges of the screen when stamina is critically low
- The drill UI is redesigned
- The crafting menu information panel appears on mouse hover rather than on click
- Previously discovered blocks remain visible for a fixed duration after leaving the visibility radius, then return to darkness
- Boundary walls replaced with transparent barriers; workbench, drill, and beer vending machine relocated to the center of the map
- New art assets added: sky background, block destruction animations, mole death animation, and drill UI elements
- Edge glow artifact between block sprites fixed
- Game balance updated: recipes are rebalanced to ensure all resources are consumed evenly

Non user-visible outcomes:
- [Architecture](architecture) documentation updated to reflect Sprint 5 changes
- [UAT scenarios](user-acceptance-tests.md) updated and executed for MVP v3
- [Testing](testing.md) suite and documentation updated
- [Roadmap](roadmap.md) and [user story](user-stories.md) index updated to reflect Sprint 5 scope
- [Customer handover](customer-handover.md) documentation updated to reflect final transition state

---

# State reached by the end of the course

Operation: EarthCore is a complete two-layer 2D game deployed to [itch.io](https://itch.io), with Windows and Linux builds available on GitHub Releases.

## Gameplay

The core gameplay loop is fully implemented: the mole digs through the dirt and stone layers tile by tile, collects resources from broken blocks, and crafts tools at the workbench. The drill operates autonomously, consuming fuel and boring downward until it reaches the stone layer, at which point it drops the resources needed to craft the stone pickaxe and unlocks access to the new layer. Mining stations can be built on discovered deposits and autonomously extract resources.

Risk is introduced through the stamina system: the stamina bar is divided into sections and depletes while climbing; when it reaches zero, the mole dies, losing all inventory resources and respawning at the drill. The beer vending machine on the surface allows the player to spend coins to fully restore stamina and permanently increase the stamina pool and regeneration rate. Coins drop from blocks during digging.

The game has an introductory cutscene presenting the mole's backstory and a tutorial explaining basic mechanics, and an ending cutscene triggered when the drill completes the stone layer. A manual save system allows the player to save and resume progress via a local `.txt` file.

## Documentation

The repository contains a maintained documentation set:

- [**README.md**](../README.md) — main public entry point with links to all maintained documentation and access instructions
- [**customer-handover.md**](customer-handover.md) — describes the final handover state, access arrangements, and what the customer needs to operate the product
- [**roadmap.md**](roadmap.md) — Sprint-by-Sprint delivery plan covering all five Sprints
- [**user-stories.md**](user-stories.md) — authoritative registry of all stable user story IDs and their current status
- [**user-acceptance-tests.md**](user-acceptance-tests.md) — all active UAT scenarios with execution history across all Sprints
- [**definition-of-done.md**](definition-of-done.md) — shared minimum completion standard for all PBIs
- [**testing.md**](testing.md) — testing strategy, coverage expectations, and quality gates
- [**quality-requirements.md**](quality-requirements.md) — ISO/IEC 25010-based quality requirements
- [**quality-requirement-tests.md**](quality-requirement-tests.md) — automated tests verifying each quality requirement
- [**development-process.md**](development-process.md) — git workflow, branching conventions, Sprint cadence, and configuration management practices
- [**architecture/**](architecture/) — static view (component diagram), dynamic view (sequence diagram for the digging flow), deployment view, and ADRs covering key architectural decisions

Root-level maintained artifacts include [`CONTRIBUTING.md`](../CONTRIBUTING.md) for contributor guidance, [`AGENTS.md`](../AGENTS.md) for AI agent guidance, and [`CHANGELOG.md`](../CHANGELOG.md) tracking all user-visible changes across all releases.

---

# Work that must continue later

The following practices must continue throughout all future project work:

### Documentation
- **README.md:** Must remain the main public entry point; update whenever product access, documentation links, setup steps, or handover status change
- **docs/customer-handover.md:** Must describe the current actual handover state; update whenever access details, deployment steps, limitations, or transition status change
- **CONTRIBUTING.md:** Must reflect the current git workflow, branching conventions, PR process, and review expectations; update when workflow or tooling changes
- **AGENTS.md:** Must reflect current scope boundaries, verification commands, safety constraints, and documentation links; update when workflow, setup steps, or documentation links change
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
