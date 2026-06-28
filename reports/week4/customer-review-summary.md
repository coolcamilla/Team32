# Sprint Review Summary - Operation EarthCore

## Date

**27.06.2026**

## Participants / roles

- **Customer**
- **coolcamilla** - Interviewer
- **WazzuRunaway** - Interviewer
- **SunrisEe41** - Note Taker
- **Lilia-Shagidullina** - Note Taker
- **Pro100Vorona** - Moderator

## Sprint Goal reviewed

**Improve game quality/testability and complete the core game loop**, anchored by a new drill mechanic, while increasing automated test coverage and visibility.

## Delivered increment discussed

- **New drill mechanic**: drill has three stats - fuel tank capacity, drill bit durability, engine power. It autonomously digs, can be refueled, shows depth changing as it digs, and supports an upgrade selection (which increase speed/fuel capacity).
- **Mole movement fix**: mole can no longer fly off the map; wall-climb interaction fixed
- **Climbing mode** (key `C`): new this Sprint, lets the mole crawl along background walls.
- **Inventory, crafting, and pause features** refactored/re-tested; new crafting flow confirmed working correctly, including insufficient-resource handling.
- **Drag-and-drop** intentionally kept (not removed) - earmarked for future drill-refueling use, despite earlier feedback suggesting removal.
- **Risk/survival mechanic concept**: mole overheats while digging deeper and must return to the surface to cool off and drink (currently "beer," alternative "Tatar tea").
  - Drill-dropped item example shown (rings/upgrade-item drops not yet implemented; only sticks drop currently).
- **Testing**: three test types - Quality Requirement tests, Edit Mode tests, Play Mode tests - were added this Sprint. Reported coverage: **52%** overall (all critical modules achieve almost 100% coverage)
- Underlying refactor in progress: separating game logic out of `MonoBehaviour` classes so logic is unit-testable.
- **Saves**, **resource-harvesting stations**, **map layers**, and **visibility limit** are explicitly **not yet implemented** - planned for a future Sprint.

## UAT Summary

| UAT ID | Description | Status | Result | Notes |
| --- | --- | --- | --- | --- |
| UAT-001 | Mole movement / no fly-out | Active | Passed | Wall-corner jump boost is intended; pause-state force buildup flagged as a separate bug |
| UAT-002 | Climbing mode | Active | Passed | Entry/exit and 4-directional climb worked as expected |
| UAT-003 | Craft a tool | Active | Passed | Craft succeeded/blocked correctly; 10 vs. 12 stick cost inconsistency in spec to reconcile |
| UAT-004 | Inventory management | Active | Passed | Stacking/deduction correct; 16-item cap flagged as too low |
| UAT-005 | Refuel & upgrade drill | Active | Passed | Fuel/upgrade flow correct; upgrade list exhausted quickly (balance note) |

### Key Feedback Points

- Drill should be the central mechanic. Combine the drill station with a workbench for crafting and upgrades.
- Replace separate shovel/pickaxe tools with a single leveling tool.
- Add coins as a collectible currency.
- Add limited visibility and a helmet flashlight mechanic.
- Simplify key bindings. Remove dedicated climbing button (C) and auto-trigger climbing when pressing W against a wall, with stamina drain.
- Add stamina to movement overall.
- Inventory UI is too complex. Increase stack size.
- Bug, Pause + Space causes force accumulation, and mole launches into the sky on unpause.

### Resulting PBIs

- [#168](https://github.com/coolcamilla/Team32/issues/168)
- [#170](https://github.com/coolcamilla/Team32/issues/170)
- [#167](https://github.com/coolcamilla/Team32/issues/167)
- [#171](https://github.com/coolcamilla/Team32/issues/171)
- [#172](https://github.com/coolcamilla/Team32/issues/172)
- [#173](https://github.com/coolcamilla/Team32/issues/173)
- [#174](https://github.com/coolcamilla/Team32/issues/174)
- [#83](https://github.com/coolcamilla/Team32/issues/83)

## Quality evidence discussed

ISO/IEC 25010-based Quality Requirements, each with an associated automated check:

- **Time behaviour** - grid generator must spawn the world grid within 3 seconds of scene load.
- **Fault tolerance** - "block behavior" script must not crash on an unknown block; it must log an error instead.
- **Operability** - game must start unpaused; one frame after launch, timescale must be 1 (game must not start in a paused state).

Three critical modules identified: **inventory, crafting, world generation** (movement was raised by the customer as a candidate but the team noted it is currently very difficult to isolate/split for testing).

- Integration/unit test coverage on these three modules: **~80–100%**.
- **Additional QA check**: Roslyn NetAnalyzers enforced on every pull request.

## Feedback received (customer)

| # | Feedback point | Notes |
| --- | --- | --- |
| 1 | Simplify the control scheme; tie climbing to a stamina mechanic instead of a dedicated button | Customer wants fewer buttons; mechanics don't currently justify the complexity |
| 2 | Drill must remain the central/key mechanic | Reaffirmation of existing direction |
| 3 | Simplify the inventory UI; consider a single workbench near the drill instead of full inventory/crafting menu | Customer felt current UI is unnecessarily complex |
| 4 | Merge shovel and pickaxe into a single tool that levels up, rather than separate tools | Customer compared to Stardew Valley-style tool tiers; current single-purpose tools add little value |
| 5 | Movement should feel "bouncy" / fun to use; roll animation work is lower priority than movement feel | Polish requested |
| 6 | Add **coins** as a currency - buried in the ground, collected, used to buy beer / unlock upgrades | New mechanic suggestion, tied to the beer/survival loop |
| 7 | Add uncertainty about nearby blocks (e.g., a flashlight permanently attached to the mole, limited visibility) - lanterns optional/not necessary | Customer's biggest concern is the game "feels boring"; movement/exploration need to be redesigned with reference to SteamWorld Dig and Forager |
| 8 | Drill should be centrally placed on the map "if there's time" | Lower-priority placement change |

## Approvals or requested changes

- **Approved as-is / keep going**: drill-centric design, climbing mode direction, current Quality Requirement/testing approach, keeping ore-deposit generation manual for the demo.
- **Requested changes**: simplify movement and inventory/crafting UI, merge tools into one progressive tool, add coins + beer survival loop, add a flashlight/limited-visibility mechanic, investigate the **mole-flying-into-the-sky bug** (forces from input accumulate while the game is paused), increase stack size.

## Risks

- **Scope-creep risk**: team is generating more ideas than it can build; saplings were already cut as an example of trimming scope.
- **Known bugs surfaced live during UAT**: "New Game" button non-functional; mole can be launched into the sky if jump/movement input is given while the game is paused (forces keep accumulating); jump near a wall corner can launch the mole much higher than intended (not caught by existing tests; found by Pro100Vorona).
- **Engagement/fun risk (customer's top concern)**: explicit warning that "the biggest risk is that the game will turn out to be boring." Movement and exploration feel need to be validated against reference games before more content is added.
- **Save system risk**: none exists yet; deferred, but explicitly flagged as still needed.
- **Layer-count feasibility risk**: team is unsure 6 layers are achievable; customer suggested scoping down to 3 well-developed layers instead.

## Action points (next Sprint, per customer's explicit request)

1. Simplify movement controls (stamina-based climbing, fewer dedicated buttons) and make movement feel more fun ("bouncy").
2. Simplify the inventory/crafting UI.
3. Merge the shovel/pickaxe into one progressively-leveled tool.
4. Begin exploring the "uncertainty about nearby blocks" direction, e.g., a mole-mounted flashlight.
5. **Finish in-progress work rather than starting new systems** - customer explicitly asked the team not to start anything completely new next Sprint.
6. Hold off on procedural ore-deposit generation; manual placement is acceptable for the demo.

## Resulting Product Backlog / scope changes

The following look like new or updated PBI candidates based on this conversation (team should confirm exact issue numbers/links once created):

- Simplify movement input scheme (stamina-driven climbing).
- Simplify/redesign inventory & crafting UI.
- Merge shovel + pickaxe into a single progressive tool.
- Survival / economy mechanic.
- Flashlight / limited-visibility mechanic on the mole.
- Bug fix: "New Game" button non-functional.
- Bug fix: forces accumulate during pause, causing the mole to fly off-screen on resume.
- Drill centered on map (lower priority).
