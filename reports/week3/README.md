# Operation: EarthCore
Is a 2D PC game where the player character is a mole. The mole tries to reach Earth's Core by digging a deep burrow with different tools and a massive drill.
### [License](../../LICENSE)
### Summary of the current user-story and PBI scope
Since Assignment 2, the Product Backlog has been migrated to the issue tracker and refined. Key changes:
- Removed stories: [US-003](https://github.com/coolcamilla/Team32/issues/75), [US-004](https://github.com/coolcamilla/Team32/issues/76), [US-007](https://github.com/coolcamilla/Team32/issues/77), [US-008](https://github.com/coolcamilla/Team32/issues/71)
- Added stories: [US-011](https://github.com/coolcamilla/Team32/issues/72), [US-012](https://github.com/coolcamilla/Team32/issues/73), [US-013](https://github.com/coolcamilla/Team32/issues/74)
- Split stories: [US-002](https://github.com/coolcamilla/Team32/issues/66) split into [US-014](https://github.com/coolcamilla/Team32/issues/78) and [US-015](https://github.com/coolcamilla/Team32/issues/79), [US-009](https://github.com/coolcamilla/Team32/issues/69) split into [US-016](https://github.com/coolcamilla/Team32/issues/80) and [US-017](https://github.com/coolcamilla/Team32/issues/81), [US-011](https://github.com/coolcamilla/Team32/issues/72) split into [US-018](https://github.com/coolcamilla/Team32/issues/82) and [US-019](https://github.com/coolcamilla/Team32/issues/83), [US-013](https://github.com/coolcamilla/Team32/issues/74) split into [US-020](https://github.com/coolcamilla/Team32/issues/84) and [US-021](https://github.com/coolcamilla/Team32/issues/85)
- Added PBIs: [Mole's Movement and Climb Mode](https://github.com/coolcamilla/Team32/issues/88), [Background and Physical layers](https://github.com/coolcamilla/Team32/issues/91), [Base Menu](https://github.com/coolcamilla/Team32/issues/87), [Description of the Surface Layer](https://github.com/coolcamilla/Team32/issues/99), [Music and Sound Effects](https://github.com/coolcamilla/Team32/issues/86)
### Addressed customer feedback points
- MVP v1 includes new directional digging mechanic involving WASD and LBM (reference SteamWorld Dig)
- Forager (similar game) was researched for simplicity of the inventory system, and the overall game feel
### [Historical user stories](../week2/user-stories.md)

### [Current user stories](../../docs/user-stories.md)

### [Product Backlog view](https://github.com/users/coolcamilla/projects/2/views/1)

### [Sprint Backlog view](https://github.com/users/coolcamilla/projects/2/views/3)

### [Current Sprint milestone (Sprint 1)](https://github.com/coolcamilla/Team32/milestone/1)

### Total Product Backlog size
62 Story Points
### Total current Sprint size
24 Story Points
### [MVP v1 scope view](https://github.com/users/coolcamilla/projects/2/views/4)
### Description of the selected MVP v1 scope
- surface layer including 2 block types (dirt, rock) and 4 initial resources (sticks, stones, seedlings and clay)
- WASD + Space movement with jumping and climbing
- tile-by-tile directional digging
- tool crafting UI
- hotbar/full inventory system

### PBI Management Approach
We follow the shared definitions from [Process Requirements](../../Process_Requirements.md) for all PBI-related concepts. Below we explain how we applied these definitions in practice.
#### PBI Types
A Product Backlog Item (PBI) is a tracked issue representing product work that improves the product. PBIs may include:
- **User stories:** functionality described from the player's perspective (e.g., [US-010: Inventory](https://github.com/coolcamilla/Team32/issues/70), [US-014: Tile-by-tile Digging](https://github.com/coolcamilla/Team32/issues/87)).
- **Technical Task:** implementation work that supports User Stories but is not directly visible to the player (e.g.,  [Mole's Movement and Climb Mode](https://github.com/coolcamilla/Team32/issues/88), [Background and Physical layers](https://github.com/coolcamilla/Team32/issues/91)).
- **Design:** art and animation, game design work (e.g., [Animation of mining](https://github.com/coolcamilla/Team32/issues/92), [Animation of block breaking](https://github.com/coolcamilla/Team32/issues/93)).
- **Course Task:** assignment-related work that does not improve the product (e.g., [Submit interview transcript and summary](https://github.com/coolcamilla/Team32/issues/116)).
All PBIs are tracked in GitHub Issues with appropriate [templates](../../.github/ISSUE_TEMPLATE/).
#### Work Status
The following Work Status values are used consistently on all issues:
- **To Do**: PBI is in the Product Backlog and is not currently ready to start.
- **Ready**: PBI is selected for the current Sprint, assigned, estimated, has the required description and acceptance criteria, and can be started.
- **In Progress** : work has started on the PBI. 
- **Review**:  implementation is ready for review; linked PR is open
- **Done**: All acceptance criteria and the team Definition of Done are satisfied; PR is merged into `main` branch
#### Priority
We use MoSCoW priority to communicate the relative importance of PBIs:
- **Must** Required for the current MVP or Sprint Goal. The deliverable fails without it. 
- **Should**  High value and expected, but the deliverable can work without it if necessary. 
- **Could**  Desirable but not critical. Included only when time and capacity allow. 
- **Won't**  Explicitly out of scope for now. 

MoSCoW labels indicate importance but do not replace backlog ordering. The Product Backlog must remain ordered so the most valuable or important work is considered first, consistent with the DEEP principle.

MVP v1 includes only **Must Have** PBIs and their supporting Technical or Design Tasks
#### Sprint Milestone Usage
We use GitHub Milestones to track Sprint scope. Each Sprint has a corresponding milestone in the issue tracker. All PBIs selected for that Sprint are assigned to its milestone so the Sprint Backlog remains inspectable.

Every Sprint milestone includes:
- The Sprint number
- The Sprint start and end dates (Monday to Sunday)
- The Sprint Goal
- The Sprint Scope

[Sprint 1 Milestone](https://github.com/coolcamilla/Team32/milestone/1), all PBIs selected for Sprint 1 are assigned to this Milestone.
The [Sprint 1 Backlog view](https://github.com/users/coolcamilla/projects/2/views/2) shows only PBIs assigned to this Milestone, grouped by Work Status.
#### MVP Version Tracking
MVP versions are tracked separately from Sprint Milestones using 2 approaches:
1. Labels: each PBI is tagged with the MVP version it belongs to (e.g. `MVP v1`, `MVP v2`). Labels allow filtering the full backlog by release target at any point.
2. The `MVP Version` field in the issue template: every new issue includes an explicit `MVP Version` field so version assignment is captured at creation and stays visible in the issue body even when labels are not immediately shown.

When an MVP version assignment changes, we update both: the label and the issue template field.  
**MVP v1** includes Must Have User Stories ([US-010](https://github.com/coolcamilla/Team32/issues/70), [US-014](https://github.com/coolcamilla/Team32/issues/78), [US-015](https://github.com/coolcamilla/Team32/issues/79), [US-016](https://github.com/coolcamilla/Team32/issues/80), [US-017](https://github.com/coolcamilla/Team32/issues/81)) and supporting Technical Tasks ( [Mole's Movement and Climb Mode](https://github.com/coolcamilla/Team32/issues/88),  [Description of the Surface Layer](https://github.com/coolcamilla/Team32/issues/99))
The [MVP v1 Scope view](https://github.com/users/coolcamilla/projects/2/views/3) shows only PBIs marked as `MVP v1`.
### Task Decomposition
We decomposed large User Stories into smaller linked Technical PBIs to enable parallel work and Example: US-010 (Inventory) decomposition
- [US-010: Inventory](https://github.com/coolcamilla/Team32/issues/70)
  - [#93](https://github.com/coolcamilla/Team32/issues/93): Switching between inventory modes (Technical Task, 1 SP)
  - [#94](https://github.com/coolcamilla/Team32/issues/94): Dragging an item across the inventory (Technical Task, 3 SP)
  - [#95](https://github.com/coolcamilla/Team32/issues/95): Idle animation with a tool in hand (Design, 2 SP)
  - [#96](https://github.com/coolcamilla/Team32/issues/96): Draw a slot (Design, 1 SP)
  
**Estimation approach**: When a User Story is decomposed into supporting PBIs, we estimate only the supporting PBIs (not the parent User Story) to avoid double-counting. The total Product Backlog size is the sum of all estimated PBIs (User Stories without decomposition + all supporting PBIs).
**Traceability**: Supporting PBIs are linked to their parent User Story via GitHub's "Linked issues" feature and referenced in the parent's description. A User Story is marked `Done` only when all linked supporting PBIs are completed.

This approach ensures that:
- Each PBI is small enough to estimate accurately (3-8 Story Points)
- Team members can work in parallel on different aspects (e.g., UI vs. logic)
- Progress is trackable
- The Definition of Done is verifiable for each component
### Direction for the current sprint 1
The goal this sprint is to deliver the first playable build for Windows and Linux. The focus is on the core surface-layer experience: tile-by-tile digging, resource collection (stick, stone, seedling, clay), a 20-slot inventory with hotbar, and a basic crafting UI for the wooden shovel and stone pickaxe. Supporting work includes the mole's movement and climb mode, base menus, art and animation, and a description of the surface layer.
### Direction for the next sprint
For the next sprint, we will be working on completing the game cycle by adding the drill. Other features that will be prioritized are mining stations and risk mechanics
### References to the verification evidence
PRs closing the MVP v1 issues:
- [#108 (closes Animation of mining in every direction, Animation of block breaking, Idle animation with a tool in hand, Draw a slot and Draw a Tool information panel)](https://github.com/coolcamilla/Team32/pull/108)
- [#109 (closes Background and Physical layers, Mole's Movement and Climb Mode and US-014: Tile-by-tile Digging)](https://github.com/coolcamilla/Team32/pull/109)
### Summary of the current product status
- The player can walk, jump and climb
- The player can mine blocks by holding a specific direction and pressing the left mouse button
- The player has a hotbar in the top-left corner of the screen, where the resources dropped from blocks and other items can be held
- By pressing 'E', the player can open the full inventory (which has 15 additional slots) and a crafting UI, which has a list of possible recipes, and a tool info panel with the tool's name, information about it, its recipe and the craft button.
### Summary of the next steps
- Add the drill to complete the game cycle
- Add mining stations and deposits, on which the mining stations can be placed
- Add procedurely generating terrain and deposit spots
- Add some risk mechanic, which will motivate the player to move forward in the game
### Contribution traceability table
Main implementation process was in Unity Version Control, that is why we merged several PBIs in one PR.
| Team member | Assigned issues | PRs created | PRs reviewed |
| --- | --- | --- | --- |
| WazzuRunaway | [#70](https://github.com/coolcamilla/Team32/issues/70), [#79](https://github.com/coolcamilla/Team32/issues/79), [#80](https://github.com/coolcamilla/Team32/issues/80), [#81](https://github.com/coolcamilla/Team32/issues/81), [#87](https://github.com/coolcamilla/Team32/issues/87), [#94](https://github.com/coolcamilla/Team32/issues/94), [#97](https://github.com/coolcamilla/Team32/issues/97), [#124](https://github.com/coolcamilla/Team32/issues/124) | [#123](https://github.com/coolcamilla/Team32/pull/123), [#125](https://github.com/coolcamilla/Team32/pull/125) | [#109](https://github.com/coolcamilla/Team32/pull/109) |
| Pro100Vorona | [#78](https://github.com/coolcamilla/Team32/issues/78), [#88](https://github.com/coolcamilla/Team32/issues/88), [#91](https://github.com/coolcamilla/Team32/issues/91) | [#109](https://github.com/coolcamilla/Team32/pull/109) | [#123](https://github.com/coolcamilla/Team32/pull/123) |
| Lilia-Shagidullina | [#92](https://github.com/coolcamilla/Team32/issues/92), [#93](https://github.com/coolcamilla/Team32/issues/93), [#95](https://github.com/coolcamilla/Team32/issues/95), [#96](https://github.com/coolcamilla/Team32/issues/96), [#98](https://github.com/coolcamilla/Team32/issues/98) | [#108](https://github.com/coolcamilla/Team32/pull/108) | [#120](https://github.com/coolcamilla/Team32/pull/120) |
| MarikSH | [#99](https://github.com/coolcamilla/Team32/issues/99) | [#120](https://github.com/coolcamilla/Team32/pull/120) | [#125](https://github.com/coolcamilla/Team32/pull/125) |
| coolcamilla | [#100](https://github.com/coolcamilla/Team32/issues/100), [#102](https://github.com/coolcamilla/Team32/issues/102), [#104](https://github.com/coolcamilla/Team32/issues/104), [#114](https://github.com/coolcamilla/Team32/issues/114), [#118](https://github.com/coolcamilla/Team32/issues/118), [#130](https://github.com/coolcamilla/Team32/issues/130), [#132](https://github.com/coolcamilla/Team32/issues/132) | [#101](https://github.com/coolcamilla/Team32/pull/101), [#103](https://github.com/coolcamilla/Team32/pull/103), [#105](https://github.com/coolcamilla/Team32/pull/105), [#115](https://github.com/coolcamilla/Team32/pull/115), [#119](https://github.com/coolcamilla/Team32/pull/119). [#121](https://github.com/coolcamilla/Team32/pull/121), [#122](https://github.com/coolcamilla/Team32/pull/122), [#126](https://github.com/coolcamilla/Team32/pull/126), [#129](https://github.com/coolcamilla/Team32/pull/129), [#131](https://github.com/coolcamilla/Team32/pull/131), [#133](https://github.com/coolcamilla/Team32/pull/133) | [#62](https://github.com/coolcamilla/Team32/pull/62), [#64](https://github.com/coolcamilla/Team32/pull/64), [#90](https://github.com/coolcamilla/Team32/pull/90), [#107](https://github.com/coolcamilla/Team32/pull/107), [#110](https://github.com/coolcamilla/Team32/pull/110), [#111](https://github.com/coolcamilla/Team32/pull/111), [#113](https://github.com/coolcamilla/Team32/pull/113), [#117](https://github.com/coolcamilla/Team32/pull/117), [#128](https://github.com/coolcamilla/Team32/pull/128), [#135](https://github.com/coolcamilla/Team32/pull/135) |
| SunrisEe41 | [#61](https://github.com/coolcamilla/Team32/issues/61), [#63](https://github.com/coolcamilla/Team32/issues/63), [#89](https://github.com/coolcamilla/Team32/issues/89), [#106](https://github.com/coolcamilla/Team32/issues/106), [#112](https://github.com/coolcamilla/Team32/issues/112), [#116](https://github.com/coolcamilla/Team32/issues/116), [#127](https://github.com/coolcamilla/Team32/issues/127). [#134](https://github.com/coolcamilla/Team32/issues/134) | [#62](https://github.com/coolcamilla/Team32/pull/62), [#64](https://github.com/coolcamilla/Team32/pull/64), [#90](https://github.com/coolcamilla/Team32/pull/90), [#107](https://github.com/coolcamilla/Team32/pull/107), [#110](https://github.com/coolcamilla/Team32/pull/110), [#111](https://github.com/coolcamilla/Team32/pull/111), [#113](https://github.com/coolcamilla/Team32/pull/113), [#117](https://github.com/coolcamilla/Team32/pull/117), [#128](https://github.com/coolcamilla/Team32/pull/128), [#135](https://github.com/coolcamilla/Team32/pull/135) | [#101](https://github.com/coolcamilla/Team32/pull/101), [#103](https://github.com/coolcamilla/Team32/pull/103), [#105](https://github.com/coolcamilla/Team32/pull/105), [#108](https://github.com/coolcamilla/Team32/pull/108), [#115](https://github.com/coolcamilla/Team32/pull/115), [#119](https://github.com/coolcamilla/Team32/pull/119), [#121](https://github.com/coolcamilla/Team32/pull/121), [#122](https://github.com/coolcamilla/Team32/pull/122), [#126](https://github.com/coolcamilla/Team32/pull/126), [#129](https://github.com/coolcamilla/Team32/pull/129), [#131](https://github.com/coolcamilla/Team32/pull/131), [#133](https://github.com/coolcamilla/Team32/pull/133) |

### [SemVer release](https://github.com/coolcamilla/Team32/releases/tag/v0.1.0) mapped to MVP v1
### [Changelog](../../CHANGELOG.md)
### [Process Requirements](../../Process_Requirements.md)
### [Roadmap](../../docs/roadmap.md)
### [Definition of Done](../../docs/definition-of-done.md)
### Links to the issue and PR/MR template
Issue templates for [bug reports](../../.github/ISSUE_TEMPLATE/bug_report.yml), [course tasks](../../.github/ISSUE_TEMPLATE/course_task.yml), [PBI](../../.github/ISSUE_TEMPLATE/other_pbi.yml), and [user story](../../.github/ISSUE_TEMPLATE/user_story.yml)
Extended [PR/MR template](../../.github/pull_request_template.md)
### [Link to reviewed issue-linked PRs/MRs](https://github.com/coolcamilla/Team32/pulls?q=is%3Apr+label%3A%22Assignment+3%22)

### Delivered MVP v1
For [Windows](../../releases/Windows/MVP_v0.1.0.zip) and [Linux](../../releases/Linux/MVP_v0.1.0.zip)
### Run instructions
Follow [local setup instructions](../../README.md#local_setup_instructions) and download `MVP_v0.1.0.zip`
### [Video demonstration](https://drive.google.com/file/d/1vub-tJ8MOOzawFUzS0pSMAEqkFZxukHv/view?usp=sharing)
### Screenshots

- Product Backlog view
![Product Backlog view](images/product_backlog.png)

- Sprint Backlog view
![Sprint Backlog view](images/sprint_backlog.png)

- Sprint Milestone
![Sprint milestone](images/sprint_milestone.png)

- MVP filtered view
![MVP version field, grouped view, or filtered view](images/mvp_filtered.png)

- SemVer release
![SemVer release](images/release1.png)
![alt](images/release2.png)

- Delivered MVP v1  
![Shovel digging animation preview](images/MVPv1_1.png "Shovel digging animation preview")
![Full inventory + crafting UI preview](images/MVPv1_2.png "Full inventory + crafting UI preview")
![Crafting info panel preview](images/MVPv1_3.png "Crafting info panel preview")
![Climbing mode preview](images/MVPv1_4.png "Climbing mode preview")

- Example reviewed issue-linked PR
![Example reviewed issue-linked PR/MR](images/reviewedPR_1.png)
![alt](images/reviewedPR_2.png)
![alt](images/reviewedPR_3.png)
![alt](images/reviewedPR_4.png)
![alt](images/reviewedPR_5.png)
![alt](images/reviewedPR_6.png)
![alt](images/reviewedPR_7.png)

### [Transcript](customer-review-transcript.md)
### [Customer review summary](customer-review-summary.md)
### [Week 3 reflection](reflection.md)
### [Retrospective](retrospective.md)
### [LLm report](llm-report.md)
