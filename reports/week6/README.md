# Operation: EarthCore

Is a 2D PC game where the player character is a mole. The mole tries to reach Earth's Core by digging a deep burrow with different tools and a massive drill.

### [Product Backlog view](https://github.com/users/coolcamilla/projects/2/views/1)

### [Sprint 4 Backlog view](https://github.com/users/coolcamilla/projects/2/views/7)

### [Sprint 4 milestone](https://github.com/coolcamilla/Team32/milestone/4)

### Sprint 4 Summary

**Goal:** Deliver a stable trial release for Windows and Linux which finalizes gameplay with new mechanics and addresses customer UI feedback, and prepare customer-facing handover documentation to demonstrate transition readiness.

**Start:** Monday, July 6, 2026  

**End:** Sunday, July 12, 2026  

**Scope**: Sprint 4 completes the core gameplay loop through layer transition and mining stations, adds risk and player engagement mechanics (death on stamina depletion, coins, and a beer vending machine), and improves game feel with block destruction visual feedback. The Sprint also introduces customer-facing handover documentation, updated contributor and agent guidance. Existing documentation (testing, architecture, UAT scenarios, roadmap, etc.) is kept current throughout the Sprint.

### Total Sprint 4 size

37 Story Points

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
- [`README.md`](../../README.md) updated as the main public entry point with links to all maintained documentation
- [`CONTRIBUTING.md`](../../CONTRIBUTING.md) created with contributor guidance
- [`AGENTS.md`](../../AGENTS.md) created with agent guidance and safety constraints
- [`docs/customer-handover.md`](../../docs/customer-handover.md) created describing the current handover state of the product
- [Roadmap](../../docs/roadmap.md) and [user story index](../../docs/user-stories.md) updated to reflect Sprint 4 scope
- [UAT scenarios](../../docs/user-acceptance-tests.md) updated and two new scenarios added for trial release
- [`docs/testing.md`](../../docs/testing.md) updated with new unit tests for the mining station, drill/layer transition, and stamina death/respawn systems, and refreshed coverage and manual evidence data
- [`docs/architecture/README.md`](../../docs/architecture/README.md) and the component diagram updated to document the mining station, drill/layer transition, death/respawn, and beer/coin subsystems
- [`docs/quality-requirements.md`](../../docs/quality-requirements.md) and [`docs/quality-requirement-tests.md`](../../docs/quality-requirement-tests.md) updated to reference the current pause and inventory menu system

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

The customer reviewed [`docs/customer-handover.md`](../../docs/customer-handover.md) live during the Sprint Review, reading it directly rather than being walked through it. Feedback was strongly positive: the customer called it important, and said that it is in order

[`CONTRIBUTING.md`](../../CONTRIBUTING.md) was also reviewed; the customer specifically praised its structure as *"very cohesive"*

The customer's one follow-up question was about locating the actual project source - clarified that it lives in the repository's source code, not as a separate clean-build folder. No unclear or missing content was flagged in either document during this review.

### Transition-readiness summary

The customer confirmed the product is **not yet ready for full transition** when asked directly. The stated blockers are:
- The game currently lacks a clear player goal or ending state - the customer specifically requested an ending/completion state be added when the player reaches the bottom.
- General polish is needed across the areas already identified in this Sprint's feedback (see the [feedback response table](#customer-feedback-response-table)), prioritized by importance given limited remaining time.

The customer confirmed they are **not currently using the product**, primarily because it has not yet been deployed anywhere ([itch.io](https://itch.io), web, or otherwise) - no build has been uploaded to any platform as of this meeting. The customer framed the project's primary value so far as a learning experience for the team rather than something they intend to actively use pre-release.

When asked what would satisfy a completed handover, the customer confirmed that transferring the GitHub repository, Unity Version Control access, and an [itch.io](https://itch.io) upload would be sufficient - no additional platform or infrastructure requirement was raised.

**What must happen in Week 7 to complete transition:** deploy the build to [itch.io](https://itch.io) (the customer's explicit primary request), address the prioritized feedback from this Sprint's review (see [Action Points](sprint-review-summary.md#action-points) in [`sprint-review-summary.md`](sprint-review-summary.md)), and add the missing goal/ending state. No further transition-blocking requirements were raised beyond these.

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

### Documentation updated during Sprint 4.

- [docs/testing.md](../../docs/testing.md) - test suite and coverage status, updated for the new mining station, layer transition, death, and coin/beer mechanics
- [docs/architecture/README.md](../../docs/architecture/README.md) (and updated views/ADRs) - architecture documentation reflecting Sprint 4's new systems
- [docs/development-process.md](../../docs/development-process.md) - development process and CI documentation
- [docs/roadmap.md](../../docs/roadmap.md) - updated to reflect Sprint 4 delivery and Sprint 5 planning

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

The customer explored the build freely during the session, covering digging, climbing, mining stations, the coin/beer mechanic, the death mechanic, and the drill upgrade UI mockup.

**What worked well:**
- Block destruction particles and animations were immediately noticed and praised - the game already feels more engaging than previous builds
- The death mechanic was accepted positively; losing resources on death felt fair and thematic but the customer requested to save inventory partially
- Mining stations functioned correctly - the customer observed clay dropping near the deposit and reacted positively
- The coin/beer stamina upgrade worked as expected - the customer confirmed the permanent increase was visible

**What needs improvement:**
- No stamina warning before death. The customer was caught off guard when the mole died and suggested adding a low-stamina indicator
- Clay has no meaningful use beyond the station recipe - it accumulates without purpose
- The mole's on-screen size while climbing felt too large. The customer suggested reducing it so the mole fits more naturally in tight spaces
- The drill takes too long to reach the stone layer without upgrades. The customer implicitly flagged this when the team noted it takes 7.5 minutes without upgrades
- The beer effect design was disputed. The customer suggested a temporary speed boost rather than a permanent stamina increase, contradicting the current implementation

**Customer's overall impression:**
The customer confirmed the product already has a tangible game feel and that the core mechanics are in place. The focus for the final Sprint should be polish, balance, and deployment rather than new features.

### [SemVer release](https://github.com/coolcamilla/Team32/releases/tag/v0.4.0) mapped to Trial Release (Sprint 4 Increment)

### [CHANGELOG](../../CHANGELOG.md)

### [Sprint review transcript](sprint-review-transcript.md)

### [Sprint review summary](sprint-review-summary.md)

### [Week 6 reflection](reflection.md)

### [Sprint 4 retrospective](retrospective.md)

### [LLM report](llm-report.md)

### Summary of the current product status

The game is a playable Windows and Linux build delivering the complete core gameplay loop across two layers (surface and stone). The mole can explore underground, collect resources, craft tools at the workbench, build mining stations, fuel and upgrade the drill, and progress to the stone layer once the drill breaks through. Sprint 4 completed the core loop through layer transition and mining stations, added risk mechanics (death on stamina depletion, coins, and a beer vending machine), and improved game feel with block destruction visual feedback. Customer-facing handover documentation is in place, including [`README.md`](../../README.md), [`CONTRIBUTING.md`](../../CONTRIBUTING.md), [`AGENTS.md`](../../AGENTS.md), and [`docs/customer-handover.md`](../../docs/customer-handover.md). The codebase is covered by unit, integration, and QRT tests with a CI pipeline enforcing quality gates on every PR.

### Week 7 follow-up work

Sprint 5 focuses on polish, balance, and final handover rather than new mechanics. The team will resolve the beer-effect design ambiguity, rebalance stamina depletion and the coin economy, add a stamina warning indicator, and implement a win condition screen when the mole reaches the bottom of the final layer. The world will be looped to remove boundary walls, the drill-upgrade UI will be redesigned based on the approved mockup, and a minimal local-file save system will be added. The build will be deployed to [itch.io](https://itch.io) as the primary public access point for the final handover. Remaining art - general backgrounds, wall sprites, and animation polish - will be completed to bring the visual quality to a consistent level across the game. Throughout Sprint 5, the team will keep [`docs/customer-handover.md`](../../docs/customer-handover.md), [`README.md`](../../README.md), and all maintained documentation current to reflect the final product state and transition status.

### Contribution traceability table

Main implementation process was in Unity Version Control, that is why we merged several PBIs in one PR.

| Team member | Assigned issues | PRs created | PRs reviewed | Testing Work | Documentation Work | Transition work | Deployment work |
|---|---|---|---|---|---|---|---| 
| **WazzuRunaway** | [#83](https://github.com/coolcamilla/Team32/issues/83) [#205](https://github.com/coolcamilla/Team32/issues/205) [#206](https://github.com/coolcamilla/Team32/issues/206) | [#241](https://github.com/coolcamilla/Team32/pull/241) | [#240](https://github.com/coolcamilla/Team32/pull/240) | | Maintain [`CHANGELOG.md`](https://github.com/coolcamilla/Team32/pull/241/changes/1df55b18f223b961d6084dc92009083a0274a5b4) | | |
| **Pro100Vorona** | [#85](https://github.com/coolcamilla/Team32/issues/85) [#139](https://github.com/coolcamilla/Team32/issues/139) [#145](https://github.com/coolcamilla/Team32/issues/145) [#153](https://github.com/coolcamilla/Team32/issues/153) | [#240](https://github.com/coolcamilla/Team32/pull/240) | [#241](https://github.com/coolcamilla/Team32/pull/241) | | Maintain [`CHANGELOG.md`](https://github.com/coolcamilla/Team32/pull/240/changes/a358ecf717b56e8198d16936f0b57a93d296422d) | | |
| **Lilia-Shagidullina** | [#140](https://github.com/coolcamilla/Team32/issues/140) [#222](https://github.com/coolcamilla/Team32/issues/222) [#223](https://github.com/coolcamilla/Team32/issues/223) | [#242](https://github.com/coolcamilla/Team32/pull/242) | [#253](https://github.com/coolcamilla/Team32/pull/253)| | | | |
| **MarikSH** | [#226](https://github.com/coolcamilla/Team32/issues/226) | [#253](https://github.com/coolcamilla/Team32/pull/253) | [#242](https://github.com/coolcamilla/Team32/pull/242) | | | | |
| **coolcamilla** | [#228](https://github.com/coolcamilla/Team32/issues/228) [#229](https://github.com/coolcamilla/Team32/issues/229) [#230](https://github.com/coolcamilla/Team32/issues/230) [#235](https://github.com/coolcamilla/Team32/issues/235) | [#251](https://github.com/coolcamilla/Team32/issues/251) [#252](https://github.com/coolcamilla/Team32/issues/252) [#254](https://github.com/coolcamilla/Team32/issues/254) [#255](https://github.com/coolcamilla/Team32/issues/255) | [#244](https://github.com/coolcamilla/Team32/pull/244) [#245](https://github.com/coolcamilla/Team32/pull/245) [#246](https://github.com/coolcamilla/Team32/pull/246) [#247](https://github.com/coolcamilla/Team32/pull/247) [#248](https://github.com/coolcamilla/Team32/pull/248) [#249](https://github.com/coolcamilla/Team32/pull/249) [#250](https://github.com/coolcamilla/Team32/pull/250) | [Add UAT-008 and UAT-009](https://github.com/coolcamilla/Team32/pull/252/changes/fd7b35dbf4dd6fd3707470f7d4d6283f89c0d248) | Maintain [`roadmap.md`, `user-stories.md`](https://github.com/coolcamilla/Team32/pull/251/commits), [`user-acceptance-tests.md`](https://github.com/coolcamilla/Team32/pull/252/commits), [`CHANGELOG.md`](https://github.com/coolcamilla/Team32/pull/254/changes/f26019791c104f00a1dbd46e328c25a8678afa65), root [`README.md`](https://github.com/coolcamilla/Team32/pull/254/changes/282c7918e4ebda6faf3aa7b5b27a147a688c773f) | | Publish v0.4.0 release (trial release) on GitHub |
| **SunrisEe41** | [#224](https://github.com/coolcamilla/Team32/issues/224) [#231](https://github.com/coolcamilla/Team32/issues/231) [#232](https://github.com/coolcamilla/Team32/issues/232) [#233](https://github.com/coolcamilla/Team32/issues/233) [#234](https://github.com/coolcamilla/Team32/issues/234) [#243](https://github.com/coolcamilla/Team32/issues/243) | [#244](https://github.com/coolcamilla/Team32/pull/244) [#245](https://github.com/coolcamilla/Team32/pull/245) [#246](https://github.com/coolcamilla/Team32/pull/246) [#247](https://github.com/coolcamilla/Team32/pull/247) [#248](https://github.com/coolcamilla/Team32/pull/248) [#249](https://github.com/coolcamilla/Team32/pull/249) [#250](https://github.com/coolcamilla/Team32/pull/250) | [#251](https://github.com/coolcamilla/Team32/issues/251) [#252](https://github.com/coolcamilla/Team32/issues/252) [#254](https://github.com/coolcamilla/Team32/issues/254) [#255](https://github.com/coolcamilla/Team32/issues/255) | [Add 30 unit tests](https://github.com/coolcamilla/Team32/pull/244/changes/cf4a5e094e457514625c7b4105759442c543d8e0) | Maintain [`docs/architecture/`](https://github.com/coolcamilla/Team32/pull/249/changes/a14e87039a54783a1a365d7898ee9bdff589370d), [`testing.md`](https://github.com/coolcamilla/Team32/pull/244/changes/d069f5724675633df3f5d9d7896ee4ab2a534993), root [`README.md`, `CONTRIBUTING.md`, `AGENTS.md`](https://github.com/coolcamilla/Team32/pull/246/commits) | Create [`customer-handover.md`](https://github.com/coolcamilla/Team32/pull/248/changes/d4b8a2d32cafbcf6d660f25e05b9b52227e2f359) | |

Empty cells means that team member did not work on this area

### Screenshots

- Sprint milestone  
![alt](images/sprint_milestone.png)

- Sprint Backlog  
![alt](images/sprint_backlog.png)

- SemVer release  
![alt](images/release_1.png)
![alt](images/release_2.png)

- Reviewed issue-linked PR or MR  
![alt](images/example_pr_1.png)
![alt](images/example_pr_2.png)
![alt](images/example_pr_3.png)

- Code coverage  
![alt](images/code_coverage_1.png)
![alt](images/code_coverage_2.png)
![alt](images/code_coverage_3.png)

- Hosted documentation site  
![alt](images/documentation_site.png)

- Latest protected-default-branch CI run  
![alt](images/CI_run.png)
