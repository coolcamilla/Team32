# Roadmap

## Product Goal

Deliver a 2D mining exploration game where the player character is a mole. The mole tries to reach Earth's Core by digging a deep burrow with different tools and a massive drill.

## Current Status

**Completed Sprints:** Sprint 1  
**Current Sprint:** Sprint 2  
**Next Sprint:** Sprint 3  

The current sprint prioritizes code quality, testability, and core drill mechanics over new feature volume. Future sprints will introduce mining stations, layer transitions, mole's upgrading and risk mechanics.

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

---

# Quality and Automation Work

The following quality and automation practices established in Sprint 2 must continue throughout all future project work:

### Automated Testing
- **Unit tests (EditMode):** All critical game-logic modules must maintain ≥30% line coverage
- **Integration tests (PlayMode):** Component interactions must be verified through automated tests
- **Quality Requirement Tests (QRT):** Each quality requirement must have at least one automated test verifying the measurable scenario  

### CI Pipeline
- **Automated checks:** Linting, formatting, type-checking, build verification must pass on every PR
- **Test execution:** All unit, integration, and QRT tests must pass before merge
- **Coverage reporting:** Coverage reports must be generated and archived for each CI run

### Documentation Maintenance
- **docs/testing.md:** Must be updated when critical modules change or new quality gates are added
- **docs/definition-of-done.md:** Must reflect current CI requirements and coverage expectations
- **docs/quality-requirements.md:** Must be updated when new quality requirements are identified
- **docs/quality-requirement-tests.md:** Must be updated when QRTs are added or modified

### Code Quality Standards
- **Testability pattern:** New features must follow the Model/Service + MonoBehaviour wrapper pattern to enable EditMode unit testing
- **Deterministic generation:** Procedural systems must use seed-based randomness for reproducibility
- **Atomic operations:** Resource transactions (crafting, building, refueling) must be atomic to prevent data loss

These practices ensure that the codebase remains maintainable, testable, and reliable.
