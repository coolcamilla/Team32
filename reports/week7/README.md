# Operation: EarthCore

### [Week 6 public report](../week6/README.md)

### [Product Backlog view](https://github.com/users/coolcamilla/projects/2/views/1)

### [Sprint 5 Backlog view](https://github.com/users/coolcamilla/projects/2/views/8)

### [Sprint 5 milestone](https://github.com/coolcamilla/Team32/milestone/5)

### Sprint 5 Summary

**Goal:** Deliver MVP v3 for Windows and Linux with polished UI and game feel improvements. Deploy it to [itch.io](https://itch.io) and hand over to the customer with complete transition documentation.

**Start:** Monday, July 13, 2026  

**End:** Sunday, July 19, 2026  

**Scope**: **Scope**: Sprint 5 delivers MVP v3 (the final release), focusing on polish, balance, and handover rather than new mechanics. Key additions include saving, cutscenes, full audio integration, a game tutorial, and new art assets. Existing features are improved through stamina rebalancing, drill UI redesign, crafting hover navigation, and temporary block visibility. The game is deployed to [itch.io](https://itch.io) as part of the final customer handover. Existing documentation is kept current and updated to reflect the final product state.

### Total Sprint 5 size

`TODO` Story Points

## Summary of Week 7 follow-up maintenance and final MVP v3 changes

`TODO`

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

`TODO itch.io`  
**OR**  
Go to the [`releases`](https://github.com/coolcamilla/Team32/tree/main/releases) folder and download `MVP_v1.0.0.zip` appropriate to your OS  
**OR**  
Go to the [v1.0.0 release](https://github.com/coolcamilla/Team32/releases/tag/v1.0.0) and download attached ZIP archive appropriate to your OS  

### Link to the run instructions

`TODO itch.io`  
**OR**  
Follow [local setup instructions](https://github.com/coolcamilla/Team32#local-setup-instructions) and download `MVP_v1.0.0.zip`  
**OR**  
Follow installation instructions from [v1.0.0 release](https://github.com/coolcamilla/Team32/releases/tag/v1.0.0) 

### [Root README](../../README.md)

### [CONTRIBUTING](../../CONTRIBUTING.md)

### [AGENTS](../../AGENTS.md)

### [Customer handover](../../docs/customer-handover.md)

### [Documentation site](https://coolcamilla.github.io/Team32/)

### Final transition outcome summary
`TODO`
(stating which handover level was reached and which customer-confirmation status was received.)

### Summary of what was transferred, delegated, or made available during the transition
`TODO`

### Remaining transition blockers, limitations, support expectations, or follow-up items
`TODO`

### Summary of customer-independent use, customer-side deployment or operation
`TODO`

### Customer feedback response table for Sprint 5 follow-up work
`TODO`

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

### UAT results summary
`TODO`

### Customer-trial results
`TODO`

### [Final SemVer release](https://github.com/coolcamilla/Team32/releases/tag/v1.0.0) mapped to MVP v3 (Sprint 5 Increment)

### [CHANGELOG](../../CHANGELOG.md)

### [Demo Video]()
`TODO`

### Demo Day preparation summary
`TODO`
including a brief note that the required Week 7 rehearsal preparation was completed.

### [Sprint 5 review transcript](sprint-review-transcript.md)

### [Sprint 5 review summary](sprint-review-summary.md)

### [Week 7 reflection](reflection.md)

### [Sprint 5 retrospective](retrospective.md)

### [LLM report](llm-report.md)

### Summary of the final product status

`TODO`

The game is a playable Windows and Linux build delivering the complete core gameplay loop across two layers (surface and stone). The mole can explore underground, collect resources, craft tools at the workbench, build mining stations, fuel and upgrade the drill, and progress to the stone layer once the drill breaks through. Sprint 4 completed the core loop through layer transition and mining stations, added risk mechanics (death on stamina depletion, coins, and a beer vending machine), and improved game feel with block destruction visual feedback. Customer-facing handover documentation is in place, including [`README.md`](../../README.md), [`CONTRIBUTING.md`](../../CONTRIBUTING.md), [`AGENTS.md`](../../AGENTS.md), and [`docs/customer-handover.md`](../../docs/customer-handover.md). The codebase is covered by unit, integration, and QRT tests with a CI pipeline enforcing quality gates on every PR.

### Contribution traceability table

`TODO`

Main implementation process was in Unity Version Control, that is why we merged several PBIs in one PR.

| Team member | Assigned issues | PRs created | PRs reviewed | Testing Work | Documentation Work | Transition work | Deployment work | Demo Day preparation |
|---|---|---|---|---|---|---|---| 
| **WazzuRunaway** | | | | | | | | |
| **Pro100Vorona** | | | | | | | | |
| **Lilia-Shagidullina** | | | | | | | | |
| **MarikSH** | | | | | | | | |
| **coolcamilla** | | | | | | | | |
| **SunrisEe41** | | | | | | | | |

Empty cells means that team member did not work on this area

### Screenshots
`TODO`

- Sprint milestone  
![alt](images/sprint_milestone.png)

- Sprint Backlog  
![alt](images/sprint_backlog.png)

- Final release  
![alt](images/release_1.png)
![alt](images/release_2.png)

- Game page on itch.io

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
