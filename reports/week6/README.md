# Operation: EarthCore

Is a 2D PC game where the player character is a mole. The mole tries to reach Earth's Core by digging a deep burrow with different tools and a massive drill.

### [Product Backlog view](https://github.com/users/coolcamilla/projects/2/views/1)

### [Sprint 4 Backlog view](https://github.com/users/coolcamilla/projects/2/views/7)

### [Sprint 4 milestone](https://github.com/coolcamilla/Team32/milestone/4)

### Sprint 4 Summary

**Goal:** Deliver a stable trial release for Windows and Linux which finalizes gameplay with new mechanics and addresses customer UI feedback, and prepare customer-facing handover documentation to demonstrate transition readiness.

**Start:** Monday, July 6, 2026  

**End:** Sunday, July 12, 2026  

**Scope**: `TODO`
Gameplay improvements based on customer feedback: reworked Climbing Mode with stamina, limited underground visibility, depth tracking, simplified inventory and crafting flow. The Sprint also introduces audio, new art assets and animations, and strengthens the technical foundation through unit, integration, QRT tests, and architecture documentation.

### Total Sprint 4 size

`TODO` Story Points

## Summary of delivered Trial Release Changes

`TODO`

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

**Testing and Documentation**
- Static, Dynamic, Deployment views created
- Development process artifact maintained
- New Unit and Integration tests introduced
- Two new user acceptance tests introduced

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
| Limited visibility mechanic for exploration | [#154](https://github.com/coolcamilla/Team32/issues/154) | Done | Added a lighting system so that only blocks within a 3-block radius of the mole are visible and distinguishable |
| Save system is missing | [#65](https://github.com/coolcamilla/Team32/issues/65)   | Not planned for this Sprint | Deferred because core gameplay was not implemented yet |
| Corner-Grab Jump | [#170](https://github.com/coolcamilla/Team32/issues/170) | Not planned for this Sprint | Deferred because the team prioritize  more valuable mechanics |
| Add Stamina  | [#167](https://github.com/coolcamilla/Team32/issues/167) | Done in Sprint 3 | Added stamina stat to the mole which limits its movement in the climbing mode |
| Make climbing mode more intuitive | [#171](https://github.com/coolcamilla/Team32/issues/171) | Done in Sprint 3 | Created roation-based Climbing Mode, digging is prohibited |
| Single-tool crafting workflow | [#172](https://github.com/coolcamilla/Team32/issues/172) | Done in Sprint 3 | Tools Crafting UI moved from inventory to workbench, and owning multiple tools simultaneously is prohibited |
| Simplify inventory | [#174](https://github.com/coolcamilla/Team32/issues/174) | Done in Sprint 3 | Updated inventory to be purely visual without any interaction (such as drag-and-drop mechanic), made the hotbar equipment-only |
| Simplify tool information panel opening | [#201](https://github.com/coolcamilla/Team32/issues/201) | Done | Tool information panels opens when hovering a mouse over the tool icon instead of clicking on it | 
| Drill UI is overly complex | [#203](https://github.com/coolcamilla/Team32/issues/203) and [#224](https://github.com/coolcamilla/Team32/issues/224) | Done | Intuitive Drill UI was investigated via analog analysis and implemented |
| Improve block destruction feel | [#205](https://github.com/coolcamilla/Team32/issues/205) | Done | Added sound effects, particles and animations |
| Introduce beer as a stamina booster | [#206](https://github.com/coolcamilla/Team32/issues/206) | Done | Added beer vending machine which sells beer, beer increases maximum stamina |
| Make discovered block temporary | [#207](https://github.com/coolcamilla/Team32/issues/207) | Not planned for this Sprint | Deferred because the team prioritize  more valuable mechanics |
| Place drill in the center of the map | [#204](https://github.com/coolcamilla/Team32/issues/204) | Not planned for this Sprint | Deferred because not gameplay mechanics should be implemented first |

### Explanation of feedback not addressed

Find explanations in [customer feedback response table](#customer-feedback-response-table) in Response column

### [Roadmap](../../docs/roadmap.md)

### Link to the maintained quality, testing, architecture, development-process, and other customer-relevant documentation updated during Sprint 4.

`TODO`

### UAT results summary

`TODO`

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

`TODO`

The game is a playable Windows and Linux build delivering the core "collect -> craft -> progress" loop across the surface layer. The mole can explore underground, collect resources, craft tools at the workbench, and fuel and upgrade the drill. Sprint 3 improved immersion through reworked climbing mechanic, stamina, limited visibility, depth tracking, simplified inventory and crafting flow based on customer feedback. The codebase is covered by unit, integration, and QRT tests with a CI pipeline enforcing quality gates on every PR. Architecture documentation and ADRs are in place and reflect the current system structure.

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
