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

| Feedback point | Resulting PBI or issue | Status | Response |
| ---| --- | --- | --- |
| Save system is missing | [#65](https://github.com/coolcamilla/Team32/issues/65)   | Done | Implemented simple save system through local `.txt` file |
| Corner-Grab Jump | [#170](https://github.com/coolcamilla/Team32/issues/170) | Not planned | Deferred because the team focuses on polish work rather than new mechanics. This decision was confirmed by the customer |
| Simplify tool information panel opening | [#201](https://github.com/coolcamilla/Team32/issues/201) | Done | Tool recipe opens on hovering over the tool icon instead of clicking on it | 
| Drill UI is overly complex | [#203](https://github.com/coolcamilla/Team32/issues/203) [#224](https://github.com/coolcamilla/Team32/issues/224) [#260](https://github.com/coolcamilla/Team32/issues/260) | Done | Approved Drill UI mockup was drawn and integrated into the game |
| Make discovered block temporary | [#207](https://github.com/coolcamilla/Team32/issues/207) | Done | Discovered blocks become undiscovered when they leave the screen |
| Place drill in the center of the map | [#204](https://github.com/coolcamilla/Team32/issues/204) | Done | World layout was updated: white boundary walls were replaced with transparent ones and drill sign, workbench, and vending machine were placed in the center of the map |
| The mole's death takes the players by surprise | [#236](https://github.com/coolcamilla/Team32/issues/236) | Done | Added red vignette that pulses at the edges of the screen when stamina is low |
| Clear goal and win condition are missing | [#238](https://github.com/coolcamilla/Team32/issues/238) [#256](https://github.com/coolcamilla/Team32/issues/256) | Done | Added introductory cutscene, explaining the goal of the game, and ending cutscene with congratulations |
| Game controls need explanation | [#200](https://github.com/coolcamilla/Team32/issues/200) | Done | After the introductory cutscene, added tutorial pages explaining base mechanics: digging, tools crafting, mining stations building, drill upgrading, climbing, and stamina recovering |
| Initial stamina is too high and it regenerates too quickly | [#262](https://github.com/coolcamilla/Team32/issues/262) | Done | Rebalanced stamina system: initial stamina pool is small and it regenerates slowly, beer increases maximum stamina pool and regeneration rate |
| Clay accumulates without any meaning | [#237](https://github.com/coolcamilla/Team32/issues/237) | Done | Recipes were refined so that all resources are equally used |
| Publish game | [#239](https://github.com/coolcamilla/Team32/issues/239) | Done | Game was published on [itch.io](https://itch.io) |

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
