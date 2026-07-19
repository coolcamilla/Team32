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

48 Story Points

## Summary of Week 7 follow-up maintenance and final MVP v3 changes

**Gameplay**
- Auto-save system added: the game state is saved automatically when the player exits the game, quits to the main menu, or the application closes. 
- Temporary block visibility added: blocks return to darkness as soon as they leave the screen, creating a sense that the mole forgets areas it has not recently visited
- Stamina rebalanced: the initial stamina pool is small (only 1 section), regeneration is very slow in normal mode; drinking beer fully restores stamina, adds a new stamina section, and increases the regeneration rate
- Stamina bar redesigned: replaced with a sectioned display where each section represents one unit of stamina capacity
- Stamina warning added: a red vignette pulses at the edges of the screen when stamina is critically low
- Music and sound effects fully integrated: main menu and surface layer music, hit sounds for dirt and stone blocks, digging, crafting, mole actions, and drill operation

**UI and World**
- Drill UI redesigned: left panel shows depth, fuel bar, and stats; right panel shows three upgrade cards with effect descriptions and resource costs
- Crafting menu updated: the tool information panel now appears on mouse hover rather than on click
- World layout updated: white boundary walls replaced with transparent barriers; workbench, drill, and beer vending machine relocated to the center of the map
- Blocks beneath the workbench, drill, and beer vending machine can no longer be dug

**Art**
- Sky background with clouds added for the surface layer
- Block destruction animations added for clay, coal, silicon, and copper
- Mole falling animation added showing the mole flailing its arms and legs
- New drill UI panel assets added

**Cutscenes and Tutorial**
- Introductory cutscene added: a picture presenting the mole's backstory plays when a new game starts
- Tutorial added: a set of navigable pages explaining basic mechanics follows the introductory cutscene
- Ending cutscene added: a video plays when the drill completes the stone layer, followed by team credits

**Game Design**
- Recipes rebalanced for tools, drill upgrades, and mining stations to ensure all resources are consumed evenly across progression

**Deployment**
- Game deployed to [itch.io](https://itch.io) as part of the final customer handover
- MVP v3 release published with SemVer tag

**Documentation and Handover**
- [`docs/customer-handover.md`](../../docs/customer-handover.md) updated to reflect the final handover state including [itch.io](https://itch.io) deployment and transition arrangements
- [`README.md`](../../README.md) updated with links to the [itch.io](https://itch.io) page and final documentation
- [`CONTRIBUTING.md`](../../CONTRIBUTING.md) and [`AGENTS.md`](../../AGENTS.md) kept current
- [Roadmap](../../docs/roadmap.md) and [user story index](../../docs/user-stories.md) updated to reflect Sprint 5 scope
- [UAT scenarios](../../docs/user-acceptance-tests.md) updated and executed for MVP v3
- [`docs/architecture/README.md`](../../docs/architecture/README.md) updated to reflect Sprint 5 system changes
- [`docs/testing.md`](../../docs/testing.md) updated with new and modified test coverage for Sprint 5 systems

### Link to product access artifact

Go to the [itch.io page](https://wazzurunaway.itch.io/operation-earthcore) and click `Download Now` button
**OR**  
Go to the [`releases`](https://github.com/coolcamilla/Team32/tree/main/releases) folder and download `MVP_v1.0.0.zip` appropriate to your OS  
**OR**  
Go to the [v1.0.0 release](https://github.com/coolcamilla/Team32/releases/tag/v1.0.0) and download attached ZIP archive appropriate to your OS  

### Link to the run instructions

Go to the [itch.io page](https://wazzurunaway.itch.io/operation-earthcore) and click `Download Now` button
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

Handover level reached: **Ready for independent use.**
The customer can download, run, and play MVP v3 without team assistance via [itch.io](https://wazzurunaway.itch.io/operation-earthcore), GitHub Releases, or the repository source.

Customer-confirmation status: **Accepted with follow-up items.**
The customer confirmed that itch.io deployment plus the GitHub repository plus Unity Version Control access satisfies the handover scope. GitHub contributor access and Unity Version Control access were requested from the customer but have not been completed as of submission — the customer has not yet provided the required account details. This is a customer-side blocker, not a team-side one. Remaining follow-up items (UI polish, animation fixes, content variety) were acknowledged as desirable improvements, not blockers to acceptance.

### Summary of what was transferred, delegated, or made available during the transition

- **GitHub repository** — contributor access was requested from the customer; the customer has not yet provided account details as of submission. This is a customer-side blocker, not a team-side one
- **Unity Version Control** — contributor access was requested from the customer; the customer has not yet provided account details as of submission. This is a customer-side blocker, not a team-side one
- **itch.io** — a public game page was created at [wazzurunaway.itch.io/operation-earthcore](https://wazzurunaway.itch.io/operation-earthcore) with Windows and Linux builds available for download; the page is currently team-managed
- **Hosted [documentation site](https://coolcamilla.github.io/Team32/)** — publicly accessible
- **Windows and Linux builds** — attached to the MVP v3 release on GitHub and available via itch.io
- **No accounts, credentials, secrets, or external services were transferred because none exist** — the product is a fully offline standalone build with no backend

### Remaining transition blockers, limitations, support expectations, or follow-up items

No items currently block the reached handover level. The following are acknowledged limitations, not blockers:

- No save-system edge-case hardening - the local `.json` save file can be freely edited or corrupted by the user; the customer explicitly accepted this tradeoff
- Content variety - the customer identified block/resource diversity as the single biggest gap affecting long-term engagement, but confirmed this is a post-course improvement, not a handover condition
- No ongoing support obligation exists after course end; the customer is aware of this

### Summary of customer-independent use, customer-side deployment or operation

The customer is not currently using, deploying, or operating the product independently. When asked directly, the customer framed the project's primary value as a learning and portfolio experience for the team rather than something they intend to actively operate themselves. The customer confirmed they would play the game once published to [itch.io](https://itch.io) and expressed interest in the team continuing to refine it post-course, but did not indicate plans for independent development, redistribution, or customer-side hosting.  
The product is fully playable without team involvement - no backend, no login, no ongoing infrastructure - so independent use is technically possible at any time. Whether it occurs depends on customer engagement after delivery, not on any remaining technical barrier.

### Customer feedback response table for Sprint 5 follow-up work

| Feedback point | Resulting PBI or issue | Status | Response |
| ---| --- | --- | --- |
| Save system is missing | [#65](https://github.com/coolcamilla/Team32/issues/65) | Done | Implemented auto-save system that writes game state to a local `save.json` file on exit, quit to menu, or application close |
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

Before session with the customer [UAT-003](../../docs/user-acceptance-tests.md#uat-003-craft-a-tool-using-the-crafting-menu), [UAT-005](../../docs/user-acceptance-tests.md#uat-005-refuel-and-upgrade-the-drill) and [UAT-006](../../docs/user-acceptance-tests.md#uat-006-stamina-depletion-and-recovery) were updated to align with current implementation. [UAT-010](../../docs/user-acceptance-tests.md#uat-010-cutscenes) was created.

[UAT-003](../../docs/user-acceptance-tests.md#uat-003-craft-a-tool-using-the-crafting-menu), [UAT-005](../../docs/user-acceptance-tests.md#uat-005-refuel-and-upgrade-the-drill), [UAT-006](../../docs/user-acceptance-tests.md#uat-006-stamina-depletion-and-recovery), and [UAT-010](../../docs/user-acceptance-tests.md#uat-010-cutscenes) were executed.  
[UAT-003](../../docs/user-acceptance-tests.md#uat-003-craft-a-tool-using-the-crafting-menu), [UAT-005](../../docs/user-acceptance-tests.md#uat-005-refuel-and-upgrade-the-drill), [UAT-006](../../docs/user-acceptance-tests.md#uat-006-stamina-depletion-and-recovery), and [UAT-010](../../docs/user-acceptance-tests.md#uat-010-cutscenes) passed.  
No UATs require immediate product changes, but several UX and polish issues were identified.

#### Need to be fixed

- **No resource collection feedback:** The player has no visual indication of what has been collected or crafted; a resource collection banner or status indicator is needed
- **Tutorial arrows not visually indicated as clickable:** The navigation arrows in the tutorial are not highlighted or styled as interactive elements
- **Tutorial content overload:** Too many mechanics are explained at once; players are unlikely to retain everything; the tutorial should be simplified or condensed
- **Drill UI button padding and font:** Text inside buttons is too close to the edges; buttons need more internal padding and smaller text to look polished
- **Upgrade button not highlighted when unaffordable:** The Upgrade button should be visually distinct (e.g. red) when the player cannot afford the upgrade
- **Digging animation loops incorrectly:** Two attacks play per button press and the animation runs bottom-to-top instead of top-to-bottom, breaking immersion
- **Mole clips through air in Climbing Mode:** The mole sometimes crawls through air tiles; Climbing Mode should exit automatically when no wall is detected

#### Key Feedback Points

- New drill UI is noticeably better than the previous version
- Tutorial cutscene was well received emotionally but contains too many mechanics at once
- The game is already addictive in its core loop
- Exploration is not yet interesting because all blocks look similar
- The drill's progress is not readable to the player

#### Resulting PBIs

_None_  
Note: identified small polish fixes will be done during Sprint 5

### Customer-trial results

The customer explored the build freely after the structured UAT session, covering digging, climbing, crafting, the drill UI, and stamina.

**What worked well:**
- The core digging loop felt engaging and addictive. The customer noted the game is already fun to play in short bursts
- The new drill UI was approved as a clear improvement over the previous version
- The introductory cutscene was well received - "enough to bring tears to your eyes"
- The red stamina warning vignette was noticed and accepted positively
- The death and respawn mechanic worked correctly and felt fair

**What needs improvement:**
- The digging animation loops incorrectly: two attacks play per button press and the animation runs bottom-to-top instead of top-to-bottom, breaking immersion
- The mole clips through air tiles in Climbing Mode, it should exit climbing automatically when no wall is detected
- The drill's progress underground is not readable: no visual feedback indicates it is drilling deeper; the customer suggested a visual such as the drill vibrating when it reaches the target depth
- Resource collection is invisible to the player
- Upgrade buttons are not visually disabled when the player cannot afford them
- All blocks look visually similar underground, making exploration feel unrewarding
- The F key for digging felt unintuitive to the customer

**Customer's overall impression:**
The game is already enjoyable and has a solid core loop. The customer confirmed that with further polish — particularly animations, UI feedback, and visual block variety — it would be a strong portfolio piece. The handover via itch.io, GitHub, and Unity Version Control was confirmed as sufficient to complete the course transition.

### [Final SemVer release](https://github.com/coolcamilla/Team32/releases/tag/v1.0.0) mapped to MVP v3 (Sprint 5 Increment)

### [CHANGELOG](../../CHANGELOG.md)

### [Demo Video](https://drive.google.com/file/d/1miXkwoKkn6B0D6NS5IAK6G6VgOMRmrI6/view?usp=sharing)

### Demo Day preparation summary

The team updated the presentation slides to reflect the final product state and prepared a 2-minute demo video with voiceover covering the core gameplay loop. A full rehearsal was conducted to fit the presentation within the 5-minute time limit. The team also discussed likely questions from the audience and prepared responses in advance. 

### [Sprint 5 review transcript](sprint-review-transcript.md)

### [Sprint 5 review summary](sprint-review-summary.md)

### [Week 7 reflection](reflection.md)

### [Sprint 5 retrospective](retrospective.md)

### [LLM report](llm-report.md)

### Summary of the final product status

Operation: EarthCore is a complete two-layer 2D game deployed to [itch.io](https://itch.io), with Windows and Linux builds available on GitHub Releases. The full core gameplay loop is implemented: the mole digs through dirt and stone layers, collects resources, crafts tools at the workbench, builds mining stations on deposits, and fuels and upgrades the drill to progress deeper. Risk mechanics (stamina depletion, death, coins, and the beer vending machine) create meaningful pressure and progression incentives. The game includes an auto-save system, an introductory cutscene, a tutorial, and an ending cutscene triggered when the drill completes the stone layer. Audio is fully integrated across all major game events. The stamina bar is sectioned and rebalanced, block destruction is visually and audibly satisfying, and the drill UI has been redesigned based on customer feedback.

The codebase is covered by unit, integration, and QRT tests with a CI pipeline enforcing quality gates on every PR. Architecture documentation (static, dynamic, and deployment views and ADRs) is maintained and up to date. The full documentation set is publicly accessible in the repository, including [`README.md`](../../README.md), [`CONTRIBUTING.md`](../../CONTRIBUTING.md), [`AGENTS.md`](../../AGENTS.md), [`docs/customer-handover.md`](../../docs/customer-handover.md), and all maintained [quality](../../docs/quality-requirements.md), [testing](../../docs/testing.md), [UAT](../../docs/user-acceptance-tests.md), [roadmap](../../docs/roadmap.md), and [architecture](../../docs/architecture/) artifacts. The product has been handed over to the customer via [itch.io](https://itch.io), GitHub, and Unity Version Control.

### Contribution traceability table

Main implementation process was in Unity Version Control, that is why we merged several PBIs in one PR.

| Team member | Assigned issues | PRs created | PRs reviewed | Testing Work | Documentation Work | Transition work | Deployment work | Demo Day preparation |
|---|---|---|---|---|---|---|---|---|
| **WazzuRunaway** | [#201](https://github.com/coolcamilla/Team32/issues/201) [#203](https://github.com/coolcamilla/Team32/issues/203) [#207](https://github.com/coolcamilla/Team32/issues/207) [#227](https://github.com/coolcamilla/Team32/issues/227) [#236](https://github.com/coolcamilla/Team32/issues/236) [#239](https://github.com/coolcamilla/Team32/issues/239) [#256](https://github.com/coolcamilla/Team32/issues/256) [#263](https://github.com/coolcamilla/Team32/issues/263) | [#277](https://github.com/coolcamilla/Team32/pull/277) [#284](https://github.com/coolcamilla/Team32/pull/284) | [#276](https://github.com/coolcamilla/Team32/pull/276) | | Maintain [`CHANGELOG.md`](https://github.com/coolcamilla/Team32/pull/277/changes/d03765ff999ac56110bdb66b1fc7e347c50fa86f) | Request contributor access for the customer in Unity Version Control (pending customer response). Customize the background of the [game page](https://wazzurunaway.itch.io/operation-earthcore) to be meaningful and attractive on itch.io | [Publish game](https://github.com/coolcamilla/Team32/pull/284) on itch.io | Participate in rehearsal |
| **Pro100Vorona** | [#204](https://github.com/coolcamilla/Team32/issues/204) [#262](https://github.com/coolcamilla/Team32/issues/204) | [#276](https://github.com/coolcamilla/Team32/pull/276) | [#277](https://github.com/coolcamilla/Team32/pull/277) | | Maintain [`CHANGELOG.md`](https://github.com/coolcamilla/Team32/pull/276/changes/0aec4a0538883ba39a816bdd58d8fa8b1bb16e6b) | | | Participated in rehearsal |
| **Lilia-Shagidullina** | [#257](https://github.com/coolcamilla/Team32/issues/257) [#258](https://github.com/coolcamilla/Team32/issues/258) [#259](https://github.com/coolcamilla/Team32/issues/259) [#260](https://github.com/coolcamilla/Team32/issues/260) | [#275](https://github.com/coolcamilla/Team32/pull/275) | [#285](https://github.com/coolcamilla/Team32/pull/285) | | | | | Participate in rehearsal |
| **MarikSH** | [#261](https://github.com/coolcamilla/Team32/issues/261) | [#285](https://github.com/coolcamilla/Team32/pull/285) | [#275](https://github.com/coolcamilla/Team32/pull/275) | | | | | Participate in rehearsal | 
| **coolcamilla** | [#200](https://github.com/coolcamilla/Team32/issues/200) [#237](https://github.com/coolcamilla/Team32/issues/237) [#238](https://github.com/coolcamilla/Team32/issues/238) [#264](https://github.com/coolcamilla/Team32/issues/264) [#265](https://github.com/coolcamilla/Team32/issues/265) [#266](https://github.com/coolcamilla/Team32/issues/266) [#267](https://github.com/coolcamilla/Team32/issues/267) | [#272](https://github.com/coolcamilla/Team32/pull/272) [#273](https://github.com/coolcamilla/Team32/pull/273) [#274](https://github.com/coolcamilla/Team32/pull/274) [#282](https://github.com/coolcamilla/Team32/pull/282) [#286](https://github.com/coolcamilla/Team32/pull/286) [#287](https://github.com/coolcamilla/Team32/pull/287) | [#278](https://github.com/coolcamilla/Team32/pull/278) [#279](https://github.com/coolcamilla/Team32/pull/279) [#280](https://github.com/coolcamilla/Team32/pull/280) [#281](https://github.com/coolcamilla/Team32/pull/281) [#283](https://github.com/coolcamilla/Team32/pull/283) [#284](https://github.com/coolcamilla/Team32/pull/284) | [Add UAT-010](https://github.com/coolcamilla/Team32/pull/274/changes/e8f7b4f36cc76eb89df0d70153e338bec8eb8046) | Maintain [`roadmap.md`, `user-stories.md`](https://github.com/coolcamilla/Team32/pull/282), [`user-acceptance-tests.md`](https://github.com/coolcamilla/Team32/pull/274/commits), [`CHANGELOG.md`](https://github.com/coolcamilla/Team32/pull/286/changes/f8940ec7f39a0335cf7d69797665f4dc06aae3c0), root [`README.md`](https://github.com/coolcamilla/Team32/pull/286/changes/7c7ce61c4d8c3a421e75007120ecb7b59b20a123) | Request contributor access for the customer in the GitHub repository (pending customer response) | [Publish v1.0.0 release](https://github.com/coolcamilla/Team32/pull/286) (mapped to MVP v3) on GitHub | Prepare presentation slides and script, record and dub the demo video, conduct a rehearsal |
| **SunrisEe41** | [#65](https://github.com/coolcamilla/Team32/issues/65) [#268](https://github.com/coolcamilla/Team32/issues/268) [#269](https://github.com/coolcamilla/Team32/issues/269) [#270](https://github.com/coolcamilla/Team32/issues/270) [#271](https://github.com/coolcamilla/Team32/issues/271) | [#278](https://github.com/coolcamilla/Team32/pull/278) [#279](https://github.com/coolcamilla/Team32/pull/279) [#280](https://github.com/coolcamilla/Team32/pull/280) [#281](https://github.com/coolcamilla/Team32/pull/281) [#283](https://github.com/coolcamilla/Team32/pull/283) | [#272](https://github.com/coolcamilla/Team32/pull/272) [#273](https://github.com/coolcamilla/Team32/pull/273) [#274](https://github.com/coolcamilla/Team32/pull/274) [#282](https://github.com/coolcamilla/Team32/pull/282) [#286](https://github.com/coolcamilla/Team32/pull/286) [#287](https://github.com/coolcamilla/Team32/pull/287) | Update testing documentation (no new tests intoduced because changes were minor) | Maintain [`docs/architecture/`](https://github.com/coolcamilla/Team32/pull/279/changes/74a9ad1ed35910063bff17b4de0bd5e422b402b2), [`testing.md`](https://github.com/coolcamilla/Team32/pull/281/changes/d8067fd33804eb77ff2eeedcb6d377452bf35d50), [`customer-handover.md`](https://github.com/coolcamilla/Team32/pull/280/changes/511c279e29c22489b3089c176155ea0ba216b981) | | | Participate in rehearsal |  

Empty cells means that team member did not work on this area

### Screenshots

- Sprint milestone  
![alt](images/sprint_milestone_1.png)
![alt](images/sprint_milestone_2.png)

- Sprint Backlog  
![alt](images/sprint_backlog_1.png)
![alt](images/sprint_backlog_2.png)

- Final release  
![alt](images/release_1.png)
![alt](images/release_2.png)

- Game page on itch.io  
![alt](images/itch-io.png)

- Reviewed issue-linked PR or MR  
![alt](images/example_pr_1.png)
![alt](images/example_pr_2.png)
![alt](images/example_pr_3.png)
![alt](images/example_pr_4.png)

- Code coverage  
![alt](images/code_coverage.png)

- Hosted documentation site  
![alt](images/documentation_site.png)

- Latest protected-default-branch CI run  
![alt](images/CI_run.png)
