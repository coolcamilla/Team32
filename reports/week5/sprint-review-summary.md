# Sprint Review Summary

## Date

**03.07.2026**

## Participants / Roles

- **Customer**
- **coolcamilla** - Interviewer
- **WazzuRunaway** - Moderator
- **SunrisEe41** - Interviewer
- **Lilia-Shagidullina** - Note Taker

## Artifacts Demonstrated

- Playable Windows/Linux build ([MVP v2](https://github.com/coolcamilla/Team32/releases/tag/v0.3.0))
- [Sprint 3 backlog](https://github.com/users/coolcamilla/projects/2/views/6)
- Static view ([component diagram](../../docs/architecture/static-view/component-diagram.svg))
- Dynamic view ([sequence diagram](../../docs/architecture/static-view/sequence-diagram.svg))
- Deployment view ([deployment diagram](../../docs/architecture/static-view/sequence-diagram.svg))
- [Arhitecture Desicions](../../docs/architecture/README.md#architecture-decisions)

## Sprint Goal Reviewed

Address customer feedback by simplifying the inventory and crafting flow and introducing immersive mechanics (stamina-based climbing, limited underground visibility, depth tracking) to make the dirt layer feel more engaging, while strengthening product quality through automated tests and architecture documentation.

## Delivered Increment Discussed

- **Reworked Climbing Mode:** Entry and exit via `C` key. `W`/`S` move the mole forward/backward along the background wall, `A`/`D` rotate the mole counter-clockwise/clockwise. Digging disabled in Climbing Mode.
- **Stamina system:** Stamina depletes while moving in Climbing Mode and recovers when mole is in normal mode. Mole slows significantly when stamina reaches zero.
- **Limited underground visibility:** Only blocks within a 3-blocks radius of the mole are visible; everything beyond is dark.
- **Depth counter:** Single counter in the top-left corner showing the mole's current depth in meters, updating in real time.
- **Simplified crafting:** Tools are now crafted at the workbench via `F`. Tools appear in a fixed horizontal chain; each new tool replaces the previous one. Re-crafting is disabled.
- **Simplified inventory:** Hotbar moved to the bottom of the screen showing equipment only. Resource inventory is view-only, opened by pressing `E`. Digit key selection removed.
- **Bug fixes:** Infinite jump via `Space` spam fixed. Jump force accumulation during pause fixed.
- **Stone layer content:** New sprites for blocks, resources, tools, and deposits. Deposit spawning implemented for layers 1 and 2.
- **Audio:** Music created for main menu and surface layer. Sound effects selected for digging, crafting, mole actions, and drill operation.
- **Architecture documentation:** Static view (component diagram), dynamic view (sequence diagram for digging flow), and deployment view created. Three ADRs documented: Unity as engine, singletons without MonoBehaviour, game logic separated from MonoBehaviour into pure C# classes.

## UAT Summary

| UAT ID                                                                                      | Title                                | Status | Result       | Notes                                                                                                                                           |
| ------------------------------------------------------------------------------------------- | ------------------------------------ | ------ | ------------ | ----------------------------------------------------------------------------------------------------------------------------------------------- |
| [UAT-001](../../docs/user-acceptance-tests.md#uat-001-mole-movement-fix)                    | Mole Movement Fix                    | Active | Passed       | Corner-grab mechanic noted positively; needs visual indicator                                                                                   |
| [UAT-002](../../docs/user-acceptance-tests.md#uat-002-climbing-mode)                        | Climbing Mode                        | Active | Passed       | Entry/exit and movement in all directions worked correctly; digging disabled confirmed                                                          |
| [UAT-003](../../docs/user-acceptance-tests.md#uat-003-craft-a-tool-using-the-crafting-menu) | Craft a tool using the crafting menu | Active | Passed       | Fixed crafting chain worked correctly; re-crafting correctly blocked. Show info panels on hover and craft tools on click                        |
| [UAT-004](../../docs/user-acceptance-tests.md#uat-004-inventory-management)                 | Inventory management                 | Active | Not executed | Not executed                                                                                                                                    |
| [UAT-005](../../docs/user-acceptance-tests.md#uat-005-refuel-and-upgrade-the-drill)         | Refuel and upgrade the drill         | Active | Passed       | Drill UI functional but overcomplicated and hard to use. Move drill to the center                                                               |
| [UAT-006](../../docs/user-acceptance-tests.md#uat-006-stamina-depletion-and-recovery)       | Stamina depletion and recovery       | Active | Passed       | Stamina depleted during movement, mole slowed at zero, recovered on exit. If stamina reaches 0, automatically return to surface (die condition) |
| [UAT-007](../../docs/user-acceptance-tests.md#uat-007-jump-bug-fixes)                       | Jump bug fixes                       | Active | Passed       | No jump stacking or pause accumulation observed                                                                                                 |

## Architecture Evidence Discussed

Presented architecture documentation:

- **Static view ([component diagram](../../docs/architecture/static-view/component-diagram.svg)):** Shows all major Unity scripts, their dependencies, and interactions.
- **Dynamic view ([sequence diagram](../../docs/architecture/static-view/sequence-diagram.svg)):** Documents the digging flow - what gets checked and calculated when the player digs. Customer asked why digging was chosen as the scenario; team explained it is the most fundamental mechanic the game is built around.
- **Deployment view ([deployment diagram](../../docs/architecture/static-view/sequence-diagram.svg)):** Shows the development machine -> CI pipeline -> player download path. Customer acknowledged it as straightforward for this type of product.
- **ADRs presented:**
    - [ADR-001](../../docs/architecture/adr/ADR-001-unity-as-the-game-engine.md): Unity chosen as the game engine
    - [ADR-002](../../docs/architecture/adr/ADR-002-singleton-access-for-cross-cutting-player-state.md): Singletons used without MonoBehaviour to enable testing and debugging
    - [ADR-003](../../docs/architecture/adr/ADR-003-separate-logic-classes-from-monobehaviour-wrappers.md): Game logic separated from MonoBehaviour into pure C# classes for testability

## Feedback Received

|     | Feedback point                                              | Notes                                                                                                                                          |
| --- | ----------------------------------------------------------- | ---------------------------------------------------------------------------------------------------------------------------------------------- |
| 1   | UI needs significant improvement                            | Customer repeatedly asked the team to research how similar games (Forager, SteamWorld Dig) handle their interfaces and use that as a reference |
| 2   | Corner-grab mechanic needs a visual indicator               | Customer noted the mechanic is fun but invisible to the player; block corner should be highlighted                                             |
| 3   | Block destruction needs more visual feedback                | Customer requested particles or shrink animations when blocks break, referencing SteamWorld Dig, Forager, and Stardew Valley                   |
| 4   | Stamina initial value should be small                       | So that upgrading stamina feels meaningful and rewarding                                                                                       |
| 5   | Explore a risk mechanic tied to stamina                     | Customer suggested that running out of stamina underground should have consequences for the mole                                               |
| 6   | Inventory limits could create meaningful resource decisions | Referenced Forager as an example where slot limits force interesting choices                                                                   |
| 7   | Beer could act as a stamina booster                         | Suggested as a consumable item tied to the existing beer concept                                                                               |
| 8   | Tile edge glow at visibility boundary needs fixing          | Visible artifact at the edge of the 3-block radius; transition should be smooth                                                                |
| 9   | Drill interface should be simpler                           | Fewer panels, ideally one button where possible                                                                                                |
| 10  | Consider 2.5D surface with 2D underground                   | Customer reacted very positively to the idea of switching visual style when the mole exits the pit                                             |
| 11  | Add coins buried in blocks                                  | Gives the player a sense of purpose and ties into the economy loop                                                                             |

## Approvals or Requested Changes

**Approved as-is:**

- Climbing Mode direction and controls
- Single-tool crafting chain at the workbench
- Simplified inventory approach
- Stamina system concept
- Architecture documentation and ADR approach
- Drill as the central mechanic

**Requested changes:**

- Improve UI readability and layout (reference Forager and SteamWorld Dig)
- Add visual indicator for corner-grab mechanic
- Add particle effects or animations for block destruction
- Make stamina bar start small so upgrading feels rewarding
- Fix tile edge glow artifact at visibility boundary
- Explore risk mechanic tied to stamina depletion underground
- Add coins as a collectible buried in blocks

## Risks

- **UI polish risk:** Customer repeatedly flagged that the interface is not intuitive. Without significant UI improvements, the game may feel unplayable to new users.
- **Engagement risk:** Customer noted that block destruction currently feels flat. Without visual feedback (particles, animations), the core digging loop lacks satisfaction.
- **Scope risk:** Many new ideas were discussed (2.5D surface, narrator, coins, beer economy, gravity boots). The team must prioritise carefully to avoid scope creep before the deadline.
- **Art style consistency risk:** Customer noted a mismatch between the mole's outline style and the block art style. Cohesion needs to be addressed.

## Action Points

1. Research UI patterns from Forager and SteamWorld Dig and apply them to the crafting and drill interfaces
2. Add a visual indicator for the corner-grab mechanic
3. Add particle effects or a shrink animation for block destruction
4. Differentiate block sprites visually so valuable blocks are recognisable at a glance
5. Fix the tile edge glow artifact at the visibility boundary
6. Explore a risk mechanic tied to stamina - define what happens when stamina runs out underground
7. Add coins as collectibles buried in blocks

## Resulting Product Backlog / Scope Changes

New PBIs are added to the Product Backlog. They will be clarified and estimated later.

- [Corner-grab Jump](https://github.com/coolcamilla/Team32/issues/170)
- [Interactive Game Tutorial](https://github.com/coolcamilla/Team32/issues/200)
- [Mouse-based Navigation in Crafting UI](https://github.com/coolcamilla/Team32/issues/201)
- [Improve Drill UI](https://github.com/coolcamilla/Team32/issues/203)
- [Change World Layout](https://github.com/coolcamilla/Team32/issues/204)
- [Death Mechanic](https://github.com/coolcamilla/Team32/issues/153)
- [Block Destruction](https://github.com/coolcamilla/Team32/issues/205)
- [Beer](https://github.com/coolcamilla/Team32/issues/206)
- [Make Discovered Block Temporary](https://github.com/coolcamilla/Team32/issues/207)
