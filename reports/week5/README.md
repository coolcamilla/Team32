# Operation: EarthCore

Is a 2D PC game where the player character is a mole. The mole tries to reach Earth's Core by digging a deep burrow with different tools and a massive drill.

### [Product Backlog view](https://github.com/users/coolcamilla/projects/2/views/1)

### [Sprint 3 Backlog view](https://github.com/users/coolcamilla/projects/2/views/6)

### [Sprint 3 milestone](https://github.com/coolcamilla/Team32/milestone/3)

### Sprint 3 Summary

**Goal:** Deliver a playable Windows and Linux build that addresses cutomer feedback by simplifying the inventory/crafting flow and improving game feel with immersive mechanics, while strengthening product quality and stability through refactoring, automated tests and architecture documentation.

**Start:** Monday, June 29, 2026  

**End:** Sunday, July 5, 2026  

**Scope**: Gameplay improvements based on customer feedback: reworked Climbing Mode with stamina, limited underground visibility, depth tracking, simplified inventory and crafting flow. The Sprint also introduces audio, new art assets and animations, and strengthens the technical foundation through unit, integration, QRT tests, and architecture documentation.

### Total current Sprint size

TODO Story Points

## Summary of Delivered MVP v2 Changes

**Gameplay**
- Climbing Mode reworked: movement in climbing uses `W`/`S` for up/down and `A`/`D` for rotation
- Stamina bar added: depletes while moving in Climbing Mode and recovers when the mole is in normal mode
- Underground visibility limited to a 3-blocks radius around the mole, creating a sense of exploration and risk
- The depth counter added in the top-left corner showing the mole's current depth in meters
- Jump stacking bug fixed: repeated spacebar presses mid-jump no longer increase jump height
- Pause menu jump bug fixed: spacebar presses while paused no longer accumulate and apply on resume

**Inventory and Crafting**
- Crafting moved from the inventory to a dedicated workbench on the surface, accessible by pressing `F`
- The mole now holds a single tool at a time; crafting a new tool replaces the previous one
- Hotbar moved to the bottom of the screen and now displays equipment only (tool, upgrades)
- Resource inventory opened in the center of the screen by pressing `E`
- Stack size increased to 99
- Digit key slot selection in horbar removed

**Art and Audio**
- Climbing animation added for all directions via rotation
- Workbench and Drill sign sprites added
- New animations integrated into Unity
- Music and sound effects are written for the main menu and surface layer

### Link to product access artifact

TODO

### Link to the run instructions

TODO

### Customer feedback response table
| Feedback point | Resulting PBI or issue | Status |Response |
| ---| --- | --- | --- |
| Movement needs to feel more natural and engaging | [#136](https://github.com/coolcamilla/Team32/issues/136) | Done in the previous sprint | Fixed infinite jump bug near a white wall |
| Unique movement mechanic for the mole | [#88](https://github.com/coolcamilla/Team32/issues/88) | Done in the previous sprint | Added climbing mode to climb background walls |
| No risk or pressure element | [#153](https://github.com/coolcamilla/Team32/issues/153) | Not planned for this Sprint | Deferred because the team concentrates on improving existing mechanics, not adding new ones |
| Missing surface-return loop | [#144](https://github.com/coolcamilla/Team32/issues/144) | Done in the previous sprint | The player needs to climb to the surface to refuel and upgrade the drill |
| Limited visibility mechanic for exploration | [#154](https://github.com/coolcamilla/Team32/issues/154) | Done | Added a lighting system so that only blocks within a 3-block radius of the mole are visible and distinguishable |
| Save system is missing | [#65](https://github.com/coolcamilla/Team32/issues/65)   | Not planned for this Sprint | Deferred because current gameplay is too small and not finished |
| Corner-Grab Jump | [#170](https://github.com/coolcamilla/Team32/issues/170) | Not planned for this Sprint | Deferred because the team concentrates on improving existing mechanics, not adding new ones |
| Add Stamina  | [#167](https://github.com/coolcamilla/Team32/issues/167) | Done | Added stamina stat to the mole which limits its movement in the climbing mode |
| Make climbing mode more intuitive | [#171](https://github.com/coolcamilla/Team32/issues/171) | Done | Created roation-based Climbing Mode, digging is prohibited |
| Single-tool crafting workflow | [#172](https://github.com/coolcamilla/Team32/issues/172) | Done | Tools Crafting UI moved from inventory to workbench, and owning multiple tools simultaneously is prohibited |
| Simplify inventory | [#174](https://github.com/coolcamilla/Team32/issues/174) | Done | Updated inventory to be purely visual without any interaction (such as drag-and-drop mechanic), made the hotbar equipment-only |

### Explanation of feedback not addressed
Find explanations in [customer feedback response table](#customer-feedback-response-table) in Response column

### [Roadmap](../../docs/roadmap.md)

### [Definition of Done](../../docs/definition-of-done.md)

### [Testing](../../docs/testing.md)

### [Quality Requirements](../../docs/quality-requirements.md)

### [Quality Requirement Tests](../../docs/quality-requirement-tests.md)

### [User Acceptance Tests](../../docs/user-acceptance-tests.md)

### [Development Process](../../docs/development-process.md)

### [Architecture README](../../docs/architecture/README.md)

### Links view artifacts

static, dynamic, and deployment 
TODO

### Link to the ADR directory/index

TODO

### Summary of the architecture and how it supports the current product

TODO

### Short explanation of how quality requirements are linked to the architecture decisions.

TODO

### Testing and CI status summary for the delivered increment.

TODO

### [CI pipeline](https://github.com/coolcamilla/Team32/actions)

### [SemVer](https://github.com/coolcamilla/Team32/releases/tag/v0.3.0) release mapped to MVP v2

### [CHANGELOG](../../CHANGELOG.md)

### Video demonstration

TODO

### UAT results summary

Before session with the customer [UAT-002](../../docs/user-acceptance-tests.md#uat-002-climbing-mode), [UAT-003](../../docs/user-acceptance-tests.md#uat-003-craft-a-tool-using-the-crafting-menu) were updated to align with current implementation. [UAT-006](../../docs/user-acceptance-tests.md#uat-006-stamina-depletion-and-recovery), [UAT-007](../../docs/user-acceptance-tests.md#uat-007-jump-bug-fixes) were created.

[UAT-001](../../docs/user-acceptance-tests.md#uat-001-mole-movement-fix), [UAT-002](../../docs/user-acceptance-tests.md#uat-002-climbing-mode), [UAT-003](../../docs/user-acceptance-tests.md#uat-003-craft-a-tool-using-the-crafting-menu), [UAT-005](../../docs/user-acceptance-tests.md#uat-005-refuel-and-upgrade-the-drill), [UAT-006](../../docs/user-acceptance-tests.md#uat-006-stamina-depletion-and-recovery), [UAT-007](../../docs/user-acceptance-tests.md#uat-007-jump-bug-fixes) were executed.  
[UAT-001](../../docs/user-acceptance-tests.md#uat-001-mole-movement-fix), [UAT-002](../../docs/user-acceptance-tests.md#uat-002-climbing-mode), [UAT-003](../../docs/user-acceptance-tests.md#uat-003-craft-a-tool-using-the-crafting-menu), [UAT-005](../../docs/user-acceptance-tests.md#uat-005-refuel-and-upgrade-the-drill), [UAT-006](../../docs/user-acceptance-tests.md#uat-006-stamina-depletion-and-recovery), [UAT-007](../../docs/user-acceptance-tests.md#uat-007-jump-bug-fixes) are passed.  
[UAT-005](../../docs/user-acceptance-tests.md#uat-005-refuel-and-upgrade-the-drill) and [UAT-006](../../docs/user-acceptance-tests.md#uat-006-stamina-depletion-and-recovery) need product changes.  

#### Need to be fixed

- The corner-grab mechanic is functional but invisible to the player: the corner of the block should be visually highlighted.
- The current crafting interface requires opening a separate panel to view required resources: required resources should be visible inline without additional clicks.
- The drill UI should be simplified: it has too many separate panels and buttons.
- The transition between visible areas should be smooth with no edge artifacts.
- The seen blocks should become undiscovered again after some time.
- Replace interface placeholders with art assests.
- Make the block destructoin engaging (add particles, sound effect, animation).

#### Key Feedback Points

- Crafting UI needs improvement - show required resources inline without a separate panel
- Drill should remain the central mechanic; place it in the center of the level
- Simplify the drill interface to fewer buttons where possible
- Make initial stamina bar small so upgrading feels rewarding
- Explore a risk mechanic tied to stamina depletion underground
- Improve block destruction feel - add particles or visual effects (reference: SteamWorld Dig, Forager)
- Beer could act as a stamina booster item

#### Resulting PBIs

- [Corner-grab Jump](https://github.com/coolcamilla/Team32/issues/170)
- [Interactive Game Tutorial](https://github.com/coolcamilla/Team32/issues/200)
- [Mouse-based Navigation in Crafting UI](https://github.com/coolcamilla/Team32/issues/201)
- [Improve Drill UI](https://github.com/coolcamilla/Team32/issues/203)
- [Change World Layout](https://github.com/coolcamilla/Team32/issues/204)
- [Death Mechanic](https://github.com/coolcamilla/Team32/issues/153)
- [Block Destruction](https://github.com/coolcamilla/Team32/issues/205)
- [Beer](https://github.com/coolcamilla/Team32/issues/206)
- [Make Discovered Block Temporary](https://github.com/coolcamilla/Team32/issues/207)

### Link to the hosted documentation site

TODO

### [Customer review summary](customer-review-summary.md)

### [Week 5 reflection](reflection.md)

### [Sprint 3 retrospective](retrospective.md)

### [LLM report](llm-report.md)

### Summary of the current product status

The game is a playable Windows and Linux build delivering the core "collect → craft → progress" loop across the surface layer. The mole can explore underground, collect resources, craft tools at the workbench, and fuel and upgrade the drill. Sprint 3 improved immersion through reworked climbing mechanic, stamina, limited visibility, depth tracking, simplified inventory and crafting flow based on customer feedback. The codebase is covered by unit, integration, and QRT tests with a CI pipeline enforcing quality gates on every PR. Architecture documentation and ADRs are in place and reflect the current system structure.

### Summary of the next steps

The next Sprint will extend the game world to three layers and introduce layer transition logic, allowing the mole to progress beyond the surface layer for the first time. Following that, the team plans to implement autonomous mining stations that collect resources from deposits automatically, mole upgrades that grant unique abilities (such as gravity reversal), and an overheating mechanic as a risk system to create urgency and meaningful decision-making in the gameplay loop. Throughout all future Sprints, the team will continue extending test coverage, improving architecture and maintainability as new systems are introduced, and keeping documentation current so the product remains understandable, usable, and verifiable.

### Contribution traceability table

Main implementation process was in Unity Version Control, that is why we merged several PBIs in one PR.

| Team member | Assigned issues | PRs created | PRs reviewed | Testing Work | Quality Work | Automation Work | Documentation Work |
|---|---|---|---|---|---|---|---|
| **WazzuRunaway** | | | | | | | |
| **Pro100Vorona** | | | | | | | |
| **Lilia-Shagidullina** | | | | | | | |
| **MarikSH** | | | | | | | |
| **coolcamilla** | | | | | | | |
| **SunrisEe41** | | | | | | | |

Empty cells means that team member did not work on this area

### Screenshots

TODO

Sprint milestone
Board or project workflow view
Latest protected-default-branch CI run
SemVer release
Example reviewed issue-linked PR or MR
Hosted docs site
