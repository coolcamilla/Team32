# Operation: EarthCore

Is a 2D PC game where the player character is a mole. The mole tries to reach Earth's Core by digging a deep burrow with different tools and a massive drill.

### [Product Backlog view](https://github.com/users/coolcamilla/projects/2/views/1)

### [Sprint 4 Backlog view](https://github.com/users/coolcamilla/projects/2/views/7)

### [Sprint 4 milestone](https://github.com/coolcamilla/Team32/milestone/4)

### Sprint 4 Summary

**Goal:** Deliver a stable trial release for Windows and Linux which finalizes gameplay with new mechanics and addresses customer UI feedback, and prepare customer-facing handover documentation to demonstrate transition readiness.

**Start:** Monday, July 6, 2026  

**End:** Sunday, July 12, 2026  

**Scope**: Sprint 4 completes the core gameplay loop through layer transition and mining stations, adds risk and player engagement mechanics (death on stamina depletion, coins, and a beer vending machine), and improves game feel with block destruction visual feedback. The Sprint also introduces customer-facing handover documentation, updated contributor and agent guidance.

### Total Sprint 4 size

36 Story Points

## Summary of delivered Trial Release Changes

**Gameplay**
- Layer transition implemented: when the drill reaches the stone layer, it drops the resources required to craft the stone pickaxe and the drill UI background updates to reflect the new layer
- Mining stations added: when the mole discovers a deposit, a hint card appears with the station recipe and a BUILD button; once built, the station autonomously extracts resources and drops them near the deposit
- Death mechanic added: when the mole's stamina runs out underground, a death screen displays "The mole is exhausted :("; after 10 seconds the mole respawns at the drill with an empty inventory but keeps its equipped tool
- Coins added as a collectible currency: coins drop from blocks and are displayed as a separate counter in the UI
- Beer vending machine added on the surface: spending 5 coins permanently increases the mole's maximum stamina
- Block destruction feedback improved: particles fly out, cracks appear and become more prominent as the block loses HP

**Art**
- Mining station sprites added for dirt and stone layer deposit types
- Coin and beer vending machine sprites added
- UI button and icon sprites added (Start, Exit, Resume, Main Menu, backpack, pause)

**Audio**
- Hit sound effects selected for dirt and stone blocks

**Documentation and Handover**
- `README.md` updated as the main public entry point with links to all maintained documentation
- `CONTRIBUTING.md` created with contributor guidance
- `AGENTS.md` created with agent guidance and safety constraints
- `docs/customer-handover.md` created describing the current handover state of the product
- Roadmap and user story index updated to reflect Sprint 4 scope
- UAT scenarios updated and two new scenarios added for trial release

### Link to product access artifact

Go to the [`releases`](https://github.com/coolcamilla/Team32/tree/main/releases) folder and download `MVP_v0.4.0.zip` appropriate to your OS  
**OR**  
Go to the [v0.4.0 release](https://github.com/coolcamilla/Team32/releases/tag/v0.4.0) and download attached ZIP archive appropriate to your OS  

### Link to the run instructions

Follow [local setup instructions](https://github.com/coolcamilla/Team32#local-setup-instructions) and download `MVP_v0.4.0.zip`  
**OR**  
Follow installation instructions from [v0.4.0 release](https://github.com/coolcamilla/Team32/releases/tag/v0.4.0) 

### [Root README](../../README.md)

### [CONTRIBUTING](../../CONTRIBUTING.md)

### [AGENTS](../../AGENTS.md)

### [Customer handover](../../docs/customer-handover.md)

### [Documentation site](https://coolcamilla.github.io/Team32/)

### Summary of the customer-facing documentation review

### Transition-readiness summary

### Customer feedback response table

| Feedback point | Resulting PBI or issue | Status | Response |
| ---| --- | --- | --- |
| Movement needs to feel more natural and engaging | [#136](https://github.com/coolcamilla/Team32/issues/136) | Done in Sprint 2 | Fixed infinite jump bug near a white wall |
| Unique movement mechanic for the mole | [#88](https://github.com/coolcamilla/Team32/issues/88) | Done in Sprint 2 | Added climbing mode to climb background walls |
| No risk or pressure element | [#153](https://github.com/coolcamilla/Team32/issues/153) | Done | Added death mechanic: when mole's stamina runs out, death screen appears, all resources are removed from the inventory, and the mole respawn on the surface |
| Missing surface-return loop | [#144](https://github.com/coolcamilla/Team32/issues/144) | Done in Sprint 2 | The player needs to climb to the surface to refuel and upgrade the drill |
| Limited visibility mechanic for exploration | [#154](https://github.com/coolcamilla/Team32/issues/154) | Done in Sprint 3 | Added a lighting system so that only blocks within a 3-block radius of the mole are visible and distinguishable |
| Save system is missing | [#65](https://github.com/coolcamilla/Team32/issues/65)   | Not planned for this Sprint | Deferred because core gameplay was not implemented yet |
| Corner-Grab Jump | [#170](https://github.com/coolcamilla/Team32/issues/170) | Not planned for this Sprint | Deferred because the team prioritize  more valuable mechanics |
| Add Stamina  | [#167](https://github.com/coolcamilla/Team32/issues/167) | Done in Sprint 3 | Added stamina stat to the mole which limits its movement in the climbing mode |
| Make climbing mode more intuitive | [#171](https://github.com/coolcamilla/Team32/issues/171) | Done in Sprint 3 | Created roation-based Climbing Mode, digging is prohibited |
| Single-tool crafting workflow | [#172](https://github.com/coolcamilla/Team32/issues/172) | Done in Sprint 3 | Tools Crafting UI moved from inventory to workbench, and owning multiple tools simultaneously is prohibited |
| Simplify inventory | [#174](https://github.com/coolcamilla/Team32/issues/174) | Done in Sprint 3 | Updated inventory to be purely visual without any interaction (such as drag-and-drop mechanic), made the hotbar equipment-only |
| Simplify tool information panel opening | [#201](https://github.com/coolcamilla/Team32/issues/201) | Not planned for this Sprint | Deferred because the team prioritize more valuable mechanics | 
| Drill UI is overly complex | [#203](https://github.com/coolcamilla/Team32/issues/203) and [#224](https://github.com/coolcamilla/Team32/issues/224) | Partially Done | Intuitive Drill UI was investigated via analog analysis and presented to the customer. They approved mock-up |
| Improve block destruction feel | [#205](https://github.com/coolcamilla/Team32/issues/205) | Done | Added sound effects, particles and animations |
| Introduce beer as a stamina booster | [#206](https://github.com/coolcamilla/Team32/issues/206) | Done | Added beer vending machine which sells beer, beer increases maximum stamina |
| Make discovered block temporary | [#207](https://github.com/coolcamilla/Team32/issues/207) | Not planned for this Sprint | Deferred because the team prioritize more valuable mechanics |
| Place drill in the center of the map | [#204](https://github.com/coolcamilla/Team32/issues/204) | Not planned for this Sprint | Deferred because core gameplay mechanics should be implemented first |

### Explanation of feedback not addressed

Find explanations in [customer feedback response table](#customer-feedback-response-table) in Response column

### [Roadmap](../../docs/roadmap.md)

### Link to the maintained quality, testing, architecture, development-process, and other customer-relevant documentation updated during Sprint 4.

`TODO`

### UAT results summary

Before session with the customer [UAT-003](../../docs/user-acceptance-tests.md#uat-003-craft-a-tool-using-the-crafting-menu), [UAT-005](../../docs/user-acceptance-tests.md#uat-005-refuel-and-upgrade-the-drill), and [UAT-006](../../docs/user-acceptance-tests.md#uat-006-stamina-depletion-and-recovery) were updated to align with current implementation. [UAT-008](../../docs/user-acceptance-tests.md#uat-008-mining-stations-construction-and-operation) and [UAT-009](../../docs/user-acceptance-tests.md#uat-009-layer-transition) were created.

[UAT-006](../../docs/user-acceptance-tests.md#uat-006-stamina-depletion-and-recovery), [UAT-008](../../docs/user-acceptance-tests.md#uat-008-mining-stations-construction-and-operation) and [UAT-009](../../docs/user-acceptance-tests.md#uat-009-layer-transition) were executed.  
[UAT-006](../../docs/user-acceptance-tests.md#uat-006-stamina-depletion-and-recovery), [UAT-008](../../docs/user-acceptance-tests.md#uat-008-mining-stations-construction-and-operation) and [UAT-009](../../docs/user-acceptance-tests.md#uat-009-layer-transition) are passed.  
No UATs require immediate product changes, but several balance and UX issues were identified.

#### Need to be fixed

- **Stamina warning indicator:** The player receives no warning before the mole dies from stamina depletion; a visual or audio warning should appear when stamina is critically low
- **Drill progression speed:** Without upgrades, the drill takes approximately 7.5 minutes to reach the stone layer; the depth or drill speed should be rebalanced to make early progression feel less slow
- **Clay resource utility:** Clay currently accumulates without meaningful use; additional drill upgrades or recipes consuming clay should be added

#### Key Feedback Points

- Add a stamina warning before the mole dies so players can react
- Rebalance stamina so it depletes faster, making beer upgrades feel more necessary
- Beer vending machine should show a visible capacity increase when purchased - consider using cells or segments for the stamina bar
- Add a clear win condition - a screen or event when the mole reaches the bottom of the final layer
- Deploy the game to itch.io as part of the final handover
- Focus next Sprint on UI improvements, game balance, and visual polish rather than new mechanics

#### Resulting PBIs

- [Stamina warning indicator](https://github.com/coolcamilla/Team32/issues/236)
- [Improve Game Balance](https://github.com/coolcamilla/Team32/issues/237)
- [Start and End Cutscenes](https://github.com/coolcamilla/Team32/issues/238)
- [Publish Game](https://github.com/coolcamilla/Team32/issues/239)

### Customer-trial results

`TODO`

### [SemVer release](https://github.com/coolcamilla/Team32/releases/tag/v0.4.0) mapped to Trial Release (Sprint 4 Increment)

### [CHANGELOG](../../CHANGELOG.md)

### [Sprint review transcript](sprint-review-transcript.md)

### [Sprint review summary](sprint-review-summary.md)

### [Week 6 reflection](reflection.md)

### [Sprint 4 retrospective](retrospective.md)

### [LLM report](llm-report.md)

### Summary of the current product status

The game is a playable Windows and Linux build delivering the complete core gameplay loop across two layers (surface and stone). The mole can explore underground, collect resources, craft tools at the workbench, build mining stations, fuel and upgrade the drill, and progress to the stone layer once the drill breaks through. Sprint 4 completed the core loop through layer transition and mining stations, added risk mechanics (death on stamina depletion, coins, and a beer vending machine), and improved game feel with block destruction visual feedback. Customer-facing handover documentation is in place, including `README.md`, `CONTRIBUTING.md`, `AGENTS.md`, and `docs/customer-handover.md`. The codebase is covered by unit, integration, and QRT tests with a CI pipeline enforcing quality gates on every PR.

### Week 7 follow-up work

`TODO`

The next Sprint will extend the game world to three layers and introduce layer transition logic, allowing the mole to progress beyond the surface layer for the first time. Following that, the team plans to implement autonomous mining stations that collect resources from deposits automatically, mole upgrades that grant unique abilities (such as gravity reversal), and an overheating mechanic as a risk system to create urgency and meaningful decision-making in the gameplay loop. Throughout all future Sprints, the team will continue extending test coverage, improving architecture and maintainability as new systems are introduced, and keeping documentation current so the product remains understandable, usable, and verifiable.

### Contribution traceability table

`TODO`

Main implementation process was in Unity Version Control, that is why we merged several PBIs in one PR.

| Team member | Assigned issues | PRs created | PRs reviewed | Testing Work | Documentation Work | Transition work | Deployment work |
|---|---|---|---|---|---|---|---|
| **WazzuRunaway** | | | | | | | |
| **Pro100Vorona** | | | | | | | |
| **Lilia-Shagidullina** | | | | | | | |
| **MarikSH** | | | | | | | |
| **coolcamilla** | | | | | | | |
| **SunrisEe41** | | | | | | | |

Empty cells means that team member did not work on this area

### Screenshots

`TODO`
- Sprint milestone
- Week 6 release
- example reviewed issue-linked PR or MR
- other inspectable Week 6 evidence where public links may not be reliably inspectable. (???)
