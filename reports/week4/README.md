# Operation: EarthCore
Is a 2D PC game where the player character is a mole. The mole tries to reach Earth's Core by digging a deep burrow with different tools and a massive drill.
### [Product Backlog view](https://github.com/users/coolcamilla/projects/2/views/1)

### [Sprint 2 Backlog view](https://github.com/users/coolcamilla/projects/2/views/5)

### [Assignment 4 Sprint milestone (Sprint 2)](https://github.com/coolcamilla/Team32/milestone/2)

### Sprint 2 Summary
**Goal:** Deliver a playable Windows/Linux build with finalized core gameplay loop, including drill mechanics, improved game feel and resource-gathering experience. Verify product quality and stability by applying tests.  

**Start:** Monday, June 22, 2026  

**End:** Sunday, June 28, 2026  

**Scope**: Sprint 2 focuses on implementing the drill mechanic ([US-018](https://github.com/coolcamilla/Team32/issues/82)), improving code quality ([#136](https://github.com/coolcamilla/Team32/issues/136), [#149](https://github.com/coolcamilla/Team32/issues/149), [#150](https://github.com/coolcamilla/Team32/issues/150), [#151](https://github.com/coolcamilla/Team32/issues/151)) and establishing automated testing infrastructure ([#152](https://github.com/coolcamilla/Team32/issues/152)). It also involves design ([#143](https://github.com/coolcamilla/Team32/issues/143), [#141](https://github.com/coolcamilla/Team32/issues/141), [#142](https://github.com/coolcamilla/Team32/issues/142), [#146](https://github.com/coolcamilla/Team32/issues/146), [#147](https://github.com/coolcamilla/Team32/issues/147);) and documentational ([#155](https://github.com/coolcamilla/Team32/issues/155), [#156](https://github.com/coolcamilla/Team32/issues/156), [#157](https://github.com/coolcamilla/Team32/issues/157)) tasks.

### Total current Sprint size
33 Story Points

### Summary of delivered product changes
Sprint 2 delivered a working drill system with fuel and durability mechanics, fixed jumping and established automated quality gates to ensure stable future development. We also start refactoring process to make EditMode tests (unit tests) applicable.

### Link to the deployed product
Go to the [releases](https://github.com/coolcamilla/Team32/tree/main/releases) folder and download `MVP_v0.2.0.zip` appropriate to your OS **OR** go to the [v0.2.0 release](https://github.com/coolcamilla/Team32/releases/tag/v0.2.0) and download attached ZIP archive appropriate to your OS

### Link to the run instructions
Follow [local setup instructions](https://github.com/coolcamilla/Team32#local-setup-instructions) and download `MVP_v0.2.0.zip` **OR** follow installation instructions from [v0.2.0 release](https://github.com/coolcamilla/Team32/releases/tag/v0.2.0) 

### Customer feedback response table
| Feedback point                                   | Resulting PBI or issue                                   | Status                      | Response                                                                                                     |
| ------------------------------------------------ | -------------------------------------------------------- | --------------------------- | ------------------------------------------------------------------------------------------------------------ |
| Remove drag-and-drop mechanic                    | Not created                                              | Rejected                    | This mechanic is needed in [#144](https://github.com/coolcamilla/Team32/issues/144) to add fuel to the tank  |
| Movement needs to feel more natural and engaging | [#136](https://github.com/coolcamilla/Team32/issues/136) | Done                        | Fixed infinite jump bug neat a white wall                                                                    |
| Unique movement mechanic for the mole            | [#88](https://github.com/coolcamilla/Team32/issues/88)   | Done                        | Added climbing mode to climb background walls                                                                |
| No risk or pressure element                      | [#153](https://github.com/coolcamilla/Team32/issues/153) | Not planned for this Sprint | Deferred because quality risks were higher priority. Team also need to coordinate the idea with the customer |
| Missing surface-return loop                      | [#144](https://github.com/coolcamilla/Team32/issues/144) | Done                        | The player needs to climb to the surface to refuel and upgrade the drill                                     |
| Limited visibility mechanic for exploration      | [#153](https://github.com/coolcamilla/Team32/issues/153) | Not planned for this Sprint | Deferred because quality risks were higher priority                                                          |
| Save system is missing                           | [#65](https://github.com/coolcamilla/Team32/issues/65)   | Not planned for this Sprint | Deferred because quality risks were higher priority and core gameplay loop was not finished                  |

### Explanation of feedback not addressed
Find explanations in [customer feedback response table](#customer-feedback-response-table) in Response column

### [Roadmap](../../docs/roadmap.md)

### [Definition of Done](../../docs/definition-of-done.md)

### [Quality Requirements](../../docs/quality-requirements.md)

### [Quality Requirement Tests](../../docs/quality-requirement-tests.md)

### [Testing](../../docs/testing.md)

### [User Acceptance Tests](../../docs/user-acceptance-tests.md)

### Summary of the quality model used

This project uses **ISO/IEC 25010** as the quality model to structure quality requirements.
Each quality requirement is specified as a measurable scenario and verified by at least one
automated Quality Requirement Test (QRT) run via the Unity Test Runner.

| QR ID | ISO/IEC 25010 Sub-characteristic | Summary |
| ------- | ---------------------------------- | --------- |
| QR-001 | Time behaviour | `GridGenerator` spawns the initial grid within 3 seconds of scene load |
| QR-002 | Fault tolerance | `BlockBehaviour` logs an error and prevents a crash when block type data is missing |
| QR-003 | Operability | `PauseManager` ensures the game starts fully unpaused (`Time.timeScale = 1`) within 1 frame |

See [`docs/quality-requirements.md`](../../docs/quality-requirements.md) and
[`docs/quality-requirement-tests.md`](../../docs/quality-requirement-tests.md) for full
scenarios and automated test details.

### Testing status summary

| Module | Test type | Tests | Line coverage | Status |
| -------- | ----------- | ------- | --------------- | -------- |
| BlockBehaviourLogic | EditMode unit | 3 | `97.2%` | Pass |
| InventoryManager | PlayMode integration | 4 | `68%` | Pass |
| CraftManager | PlayMode integration | 4 | `100%` | Pass |
| GridGenerator | PlayMode integration | 4 | `88.8%` | Pass |

[Full coverage report](../../docs/CodeCoverageReport.htm)

### Links to unit tests

- [EditMode unit tests — Block Logic](https://github.com/coolcamilla/Team32/blob/main/source/Assets/Tests/EditMode/)

### Links to integration tests

- [PlayMode integration tests — InventoryManager, CraftManager, GridGenerator](https://github.com/coolcamilla/Team32/blob/main/source/Assets/Tests/PlayMode/)

### Links to automated quality requirement tests

- [QRT-001, QRT-002, QRT-003 — `Qualityrequirementtests.cs`](../../source/Assets/Tests/PlayMode/)

### [CI pipeline](https://github.com/coolcamilla/Team32/actions)

### [Latest CI run on main](https://github.com/coolcamilla/Team32/actions/runs/28335656963)

### [Branch protection rules](https://github.com/coolcamilla/Team32/rules/17516535?ref=refs%2Fheads%2Fmain)

### Screenshots or report links for linting, coverage, tests, and the additional QA check

[linting + additional QA check](https://github.com/coolcamilla/Team32/actions/runs/28336191613)
[coverage report](../../docs/CodeCoverageReport.htm)
[automated tests](https://github.com/coolcamilla/Team32/actions/runs/28336191608)

### Short explanation of how the Assignment 4 tests, CI checks, quality requirement tests, and Definition of Done will continue to govern later project work

The tests, CI checks, quality requirement tests, and Definition of Done introduced in
Assignment 4 are maintained project assets. All future PBIs must satisfy the same gates:

- **Unit and integration tests** in `Assets/Tests/` must continue to pass on every PR
  targeting the protected default branch. New modules are expected to have corresponding tests.
- **Quality requirement tests** QRT-001, QRT-002, and QRT-003 remain active and must pass
  in CI. If a future change affects `GridGenerator`, `BlockBehaviour`, or `PauseManager`,
  the relevant QRT must be updated to match the new measurable scenario rather than removed.
- **CI pipeline** enforces test execution, coverage measurement, linting, and the additional
  QA check on every push to the protected default branch. These gates must not be disabled
  or bypassed in later Sprints.
- **Definition of Done** in `docs/definition-of-done.md` requires all CI gates to pass
  before a PBI can be marked Done. Later Sprints must maintain or extend this standard;
  weakening it requires an explicit team decision documented in the Definition of Done itself.

### [SemVer](https://github.com/coolcamilla/Team32/releases/tag/v0.2.0) release mapped to MVP v2 (Sprint 2 Increment)

### [CHANGELOG](../../CHANGELOG.md)

### [Video demonstration](https://drive.google.com/file/d/1H31lleI1gIsuKKGnUnVXEf5jqQMlnDnV/view?usp=sharing)

### [Presentation](https://drive.google.com/file/d/1iazEYzcEOubU39pbIdog0kET_Y7K_dea/view?usp=sharing)

### [UAT results summary](customer-review-summary.md#uat-results-summary)

### [Customer review summary](customer-review-summary.md)

### [Week 4 reflection](reflection.md)

### [Sprint retrospective](retrospective.md)

### [LLM report](llm-report.md)

### Summary of the current product status
Now, core gameplay loop, including digging, inventory, crafting, and drill, is implemented. Moreover, we introduce climbing mode, menus, and procedural surface generation. We have also covered the key system components (procedural generation, inventory, and crafting) with tests to ensure product reliability.

### Summary of the next steps
We plan to add 2 underground layers. All three layers (including surface layer) will have deposits from which players will be able to collect resources autonomously using mining stations. To improve game feel we want to add some exploration by introducing limited visibility and overheating mechanics. To respond to the customer's feedback we plan to add more movement features (e.g. double jump, bunny hopping) using mole's accessories. Moreover, we will simplify UI and game controls.

On the technical side we will continue refactoring and testing work (write QRTs, EditMode and PlayMode tests for critical components).

### Contribution traceability table

Main implementation process was in Unity Version Control, that is why we merged several PBIs in one PR.

| Team member | Assigned issues | PRs created | PRs reviewed | Testing Work | Quality Work | Automation Work | Documentation Work |
|---|---|---|---|---|---|---|---|
| **WazzuRunaway** | [#82](https://github.com/coolcamilla/Team32/issues/82), [#136](https://github.com/coolcamilla/Team32/issues/136), [#150](https://github.com/coolcamilla/Team32/issues/150) | [#165](https://github.com/coolcamilla/Team32/pull/165) | [#164](https://github.com/coolcamilla/Team32/pull/164) | EditMode unit tests for Block Logic (30 tests) | Refactored Crafting System, fixed jump bug ([#165](https://github.com/coolcamilla/Team32/pull/165/commits/502d5ddad7e878efe7125f06663064245751f824)) | | Maintain `CHANGELOG.md` |
| **Pro100Vorona** | [#84](https://github.com/coolcamilla/Team32/issues/84), [#149](https://github.com/coolcamilla/Team32/issues/149), [#151](https://github.com/coolcamilla/Team32/issues/151) | [#164](https://github.com/coolcamilla/Team32/pull/164) | [#165](https://github.com/coolcamilla/Team32/pull/165) | EditMode unit tests for Pause Menu Logic (6 tests, [#164](https://github.com/coolcamilla/Team32/pull/164)) | Refactored Inventory System and Pause Menu ([#164](https://github.com/coolcamilla/Team32/pull/164)) | | |
| **Lilia-Shagidullina** | [#138](https://github.com/coolcamilla/Team32/issues/138), [#146](https://github.com/coolcamilla/Team32/issues/146), [#147](https://github.com/coolcamilla/Team32/issues/147) | [#163](https://github.com/coolcamilla/Team32/pull/163) | [#175](https://github.com/coolcamilla/Team32/pull/175) | | | | |
| **MarikSH** | [#141](https://github.com/coolcamilla/Team32/issues/141), [#142](https://github.com/coolcamilla/Team32/issues/142) | [#162](https://github.com/coolcamilla/Team32/pull/162) | [#159](https://github.com/coolcamilla/Team32/pull/159) | | | | |
| **coolcamilla** | [#143](https://github.com/coolcamilla/Team32/issues/143), [#156](https://github.com/coolcamilla/Team32/issues/156), [#157](https://github.com/coolcamilla/Team32/issues/157) | [#158](https://github.com/coolcamilla/Team32/pull/158), [#159](https://github.com/coolcamilla/Team32/pull/159), [#160](https://github.com/coolcamilla/Team32/pull/160), [#161](https://github.com/coolcamilla/Team32/pull/161), [#175](https://github.com/coolcamilla/Team32/pull/175) | [#162](https://github.com/coolcamilla/Team32/pull/162), [#169](https://github.com/coolcamilla/Team32/pull/169) | | | | Maintain `roadmap.md`, `user-stories.md`, `user-acceptance-tests.md`, `CHANGELOG.md` |
| **SunrisEe41** | [#152](https://github.com/coolcamilla/Team32/issues/152), [#155](https://github.com/coolcamilla/Team32/issues/155) | [#169](https://github.com/coolcamilla/Team32/pull/169) | [#158](https://github.com/coolcamilla/Team32/pull/158), [#160](https://github.com/coolcamilla/Team32/pull/160), [#161](https://github.com/coolcamilla/Team32/pull/161), [#163](https://github.com/coolcamilla/Team32/pull/163) | PlayMode integration tests for InventoryManager, NewCraftManager, GridGenerator (20 tests) | Defined QRs in `docs/quality-requirements.md` | GitHub Actions CI setup, OpenCover + ReportGenerator configuration | Maintain `quality-requirement-tests.md`, `definition-of-done.md` |

Empty cells means that team member did not work on this area

### Screenshots

- Sprint milestone ![alt](images/milestone.png)
- Latest protected-default-branch CI run ![alt](images/CI_run.png)
- Branch protection or rules evidence ![alt](images/rules_1.jpg)
![alt](images/rules_2.jpg)
- Coverage or test report ![alt](images/coverage_report_1.png)
![alt](images/coverage_report_2.png)
- Additional QA check result ![alt](images/qa_check_result.png)
- SemVer release ![alt](images/release.jpg)
![alt](images/release_2.jpg)
- Example reviewed issue-linked PR/MR ![alt](images/example_pr_1.png)
![alt](images/example_pr_2.png)
![alt](images/example_pr_3.png)
![alt](images/example_pr_4.png)
