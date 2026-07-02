# User Acceptance Tests

## UAT-001: Mole Movement Fix

**Status:** Active

**Linked to:** [Fix Mole's Movement](https://github.com/coolcamilla/Team32/issues/136)

**User goal:** Verify that the mole cannot fly out of the gameplay zone by pressing Space repeatedly.

**Preconditions:**
- New game session started
- Mole stands near to the white wall on the right
- Mole is on solid ground

**Step-by-step instructions:**
1. Press `Space`
2. Hold `D` and press Space
3. While the mole is in the air, hold `D` and press `Space` rapidly 3-5 times
4. Observe the mole's behavior
5. Let the mole land on the ground
6. Press `A/D`

**Expected outcome:**
1. The mole jumps vertically once
2. The mole jumps to the right once 
3. Additional Space presses in the air do not increase jump height or reset vertical velocity
4. The mole does not escape the gameplay zone
5. The mole is standing still
6. The mole goes to the left/right and horizontal movement is not affected

### Execution History

#### Sprint 2 - 2026-06-27

**Execution results:** PASSED. The mole could no longer jump over the white wall. Additional Space presses in mid-air did not launch the mole out of bounds. After landing, A/D horizontal movement functioned normally with no side effects. 

**Customer comments:** A corner-grab mechanic was observed - when the mole grabs a corner it can make a higher jump. Customer reacted positively. Suggested adding a special move or animation for the corner-jump mechanic. Investigate the pause-accumulation bug: when the game is paused and Space is pressed repeatedly, forces accumulate and the mole launches into the sky on unpause.

**Resulting PBIs:** [#168](https://github.com/coolcamilla/Team32/issues/168), [#170](https://github.com/coolcamilla/Team32/issues/170)

#### Sprint 3 - 2026-07-03

**Execution results:**

**Customer comments:** 

**Resulting PBIs:** 

## UAT-002: Climbing Mode

**Status:** Active

**Linked to:** [Mole's Movement and Climb Mode](https://github.com/coolcamilla/Team32/issues/88), [Timer-based Climbing Mode](https://github.com/coolcamilla/Team32/issues/171)

**User goal:** Verify that the mole can enter climbing mode and climb the background walls.

**Preconditions:**
- New game session started
- Mole is on solid ground
- There is a climbing zone (background wall) with at least 4 blocks width and 4 blocks depth (e.g., a wide pit)

**Step-by-step instructions:**
1. Move the mole to the climbing zone
2. Hold `W` for 3 seconds
3. Press `W`
4. Press `S`
5. Hold `S` and press `LMB`
6. Press `A` 
7. Press `D`
8. Return the mole to an upright position using `A` or `D`
9. Hold `S` until the mole collides with the bottom
10. Hold `S` for 3 seconds
11. Hold `W` for 3 seconds
12. Using `W`, `A`, and `D` approach any block on the side column that has open air above it
13. Rotate the mole using `A` and `D` so that its head collides with this block
14. Hold `W` for 3 seconds

**Expected outcome:**
1. The mole is positioned in front of the climbing wall
2. The mole enters Climbing Mode
3. The mole moves upward along the background wall
4. The mole moves downward along the background wall
5. The mole moves downward along the background wall and do not dig
6. The mole rotetes counter clockwise
7. The mole rotetes clockwise
8. The mole returnes to a straight vertical position
9. The mole moves downward along the background wall
10. The mole exits Climbing Mode and stands on the physical block below
11. The mole enters Climbing Mode
12. The mole moves and rotates accordingly
13. The mole rotates to face the side column
14. The mole exits Climbing Mode and appears standing on top of the adjacent block

### Execution History

#### Sprint 2 - 2026-06-27

**Execution results:** PASSED. The mole entered and exited climbing mode correctly using C. WASD movement along background walls worked in all four directions. Pressing C again exited climbing mode and the mole fell and landed normally. Climbing mode also appeared to activate on the surface (outside the pit), which the team acknowledged as a debug artifact for now.

**Customer comments:** The mole cannot dig while in climbing mode (neither up nor down). Suggested making climbing mode more intuitive — either strictly up/down only, or always-on with stamina drain (like Zelda). Recommended removing the dedicated C button and tying climbing to W automatically when against a wall.

**Resulting PBIs:** [#167](https://github.com/coolcamilla/Team32/issues/167), [#171](https://github.com/coolcamilla/Team32/issues/171)

#### Sprint 3 - 2026-07-03

**Execution results:**

**Customer comments:** 

**Resulting PBIs:** 

## UAT-003: Craft a Tool Using the Crafting Menu

**Status:** Active

**Linked to:** [US-016: Tools Crafting UI](https://github.com/coolcamilla/Team32/issues/80), [US-017: Tools Crafting Action](https://github.com/coolcamilla/Team32/issues/81)

**User goal:** Verify that the crafting system works correctly, and the player can craft a tool when he or she has sufficient resources.

**Preconditions:**
- New game session started
- Player do not have any tool yet
- Player has collected enough resources for one wooden shovel (12 sticks)
- Player does not collect enough resources for the stone pickaxe (5 sticks and 5 stones)
- Mole is near the workbench on the surface

**Step-by-step instructions:**
1. Move the mole to the workbench
2. Press `F` to open the crafting menu
3. View the available recipe in the crafting menu
4. Click the `Craft` button
5. Click the `Craft` button again

**Expected outcome:**
1. Hint "Press F to interact with workbench" is highlighted
2. The crafting menu opens
3. The wooden shovel recipe is displayed with required resources and stats
4. 12 sticks are removed from the inventory, the wooden shovel appears in the euipment hotbar, and the next tool is displayed in the crafting menu
5. Nothing happens (the button is disabled, no resources are removed, no second tool is crafted)

### Execution History

#### Sprint 2 - 2026-06-27

**Execution results:** PASSED. The crafting menu opened correctly via E. The customer navigated the catalog, selected the wooden shovel, and crafted it successfully. Resources were deducted from the inventory. New digging animations (with shovel) were noted positively. During the session the customer happened to already have a shovel and crafted a pickaxe instead to demonstrate the system - behavior was identical and correct.

**Customer comments:** Praised the new craft animations. No blockers reported. Suggested simplifying the inventory and crafting flow. Restrict multiple crafting of one tool. Replace the creation of multiple tools with the improvement of a single tool

**Resulting PBIs:** [#172](https://github.com/coolcamilla/Team32/issues/172), [#173](https://github.com/coolcamilla/Team32/issues/173)

#### Sprint 3 - 2026-07-03

**Execution results:**

**Customer comments:** 

**Resulting PBIs:** 

## UAT-004: Inventory Management

**Status:** Active

**Linked to:** [US-010: Inventory](https://github.com/coolcamilla/Team32/issues/70)

**User goal:** Verify that the inventory correctly tracks resources, allows adding and spending items.

**Preconditions:**
- New game session started
- Player has an empty inventory
- Resources are available in the world
- Mole is on solid ground

**Step-by-step instructions:**
1. Destroy any dirt block (hold direction button `WASD` and click `LMB` 3 times)
2. Walk through the dropped resources
3. Collect more resources of the same and different types
4. Use resources for crafting (e.g., craft a wooden shovel from [UAT-003](#uat-003-craft-a-tool-using-the-crafting-menu))
5. Try to craft a tool for which you do not have enough resources

**Expected outcome:**
1. The desired block is destroyed, and resources drop from it onto the ground
2. Resources are added to the inventory, and the UI displays the correct resource count
3. Same resources stack together (up to the 16), and different resources occupy new slots
4. Resources used for crafting are correctly deducted, and the UI count updates instantly
5. The system prevents crafting, no resources are deducted, and an error message or indicator appears

### Execution History

#### Sprint 2 - 2026-06-27

**Execution results:** Blocks were destroyed and resources dropped correctly. Walking through resources added them to the inventory with correct counts displayed. Crafting deducted resources accurately and the UI updated immediately. Attempting to craft without sufficient resources was blocked correctly.

**Customer comments:** No functional objections. Noted that the current stack size of 16 felt limiting during extended play. Suggested simplifying the overall inventory UI and considering slot-based limits tied to drill upgrades.

**Resulting PBIs:** [#174](https://github.com/coolcamilla/Team32/issues/174)

#### Sprint 3 - 2026-07-03

_Not executed._

## UAT-005: Refuel and Upgrade the Drill 

**Status:** Active

**Linked to:** [US-018: Drill Upgrading](https://github.com/coolcamilla/Team32/issues/82)

**User goal:** Verify that the player can refuel the drill and apply an upgrade to improve its performance.

**Preconditions:**

- New game session started
- The drill's fuel tank is empty
- Player has sufficient at least 6 sticks and 5 pebbles

**Step-by-step instructions:**

1. Go next to the sign on the left side of the map
2. Press `F`
3. Check the current fuel level on the left
4. Add one stick to the fuel tank
5. Look to the right side and find one available upgrade (e.g., increased fuel capacity or faster digging speed)
6. Click `Upgrade` button on the bottom of the upgrade panel

**Expected outcome:**

1. Hint `Press F` is highlighted
2. The drill UI is opened
3. The fuel tank is empty, and the drill is not active
4. Fuel tank now has a litle bit fuel and speed is 0.2 m/min and power is 5 W, drill is active
5. Three information panels on the right demonstrate three improvement areas: Drill Engine, Boer Drill, Fuel Tank
6. The upgrade disappears from the upgrade table, and drill stats are updated

### Execution History

#### Sprint 2 - 2026-06-27

**Execution results:** PASSED. The customer found the drill, pressed F to open the UI, confirmed the fuel tank was empty and the drill was inactive. Adding one stick activated the drill and the depth counter began changing. Upgrade options were displayed in the right panel. The customer had run out of resources to apply an upgrade, but the upgrade UI was verified as functional.

**Customer comments:** The drill's role in the core game loop was clarified during the session: the drill digs to new layers and supplies the mole with materials, rather than the mole digging directly. Customer responded very positively to this design. Recommended making the drill the central key mechanic. Suggested combining the drill UI with a workbench for crafting and upgrades.

**Resulting PBIs:** [#172](https://github.com/coolcamilla/Team32/issues/172), [#83](https://github.com/coolcamilla/Team32/issues/83)

#### Sprint 3 - 2026-07-03

_Not executed._

## UAT-006: Stamina Depletion and Recovery

**Status:** Active

**Linked to:** [Stamina](https://github.com/coolcamilla/Team32/issues/167)

**User goal:** Verify that stamina depletes while the mole moves in Climbing Mode and recovers when the mole in normal mode.

**Preconditions:**
- New game session started
- Mole is on solid ground adjacent to a background wall
- Stamina bar is fully charged

**Step-by-step instructions:**
1. Hold `W` for 3 seconds
2. Hold `W` continuously to move upward along the background wall
3. Hold `W` again until stamina reaches zero
4. Exit Climbing Mode (as in [UAT-002](#uat-002-climbing-mode))

**Expected outcome:**
1. The mole enters Climbing Mode and the stamina bar is visible
2. The stamina bar visibly decreases while the mole moves upward
3. The stamina bar reaches zero and the mole starts moving very slow
4. The stamina bar recovers

### Execution History

#### Sprint 3 - 2026-07-03

**Execution results:**

**Customer comments:** 

**Resulting PBIs:** 

## UAT-007: Jump Bug Fixes

**Status:** Active

**Linked to:** [Infinite jump](https://github.com/coolcamilla/Team32/issues/168), [Jump Force Accumulation](https://github.com/coolcamilla/Team32/issues/182)

**User goal:** Verify that jump stacking via repeated spacebar presses and jump force accumulation during pause have been fixed.

**Preconditions:**
- New game session started
- Mole is on solid ground

**Step-by-step instructions:**
1. Press `Space`
2. Press `Space` repeatedly while the mole is mid-jump
3. Land and observe the mole's position
4. Press `Esc`
5. Press `Space` multiple times while the pause menu is open
6. Click `Resume` to return to the game

**Expected outcome:**
1. The mole jumps once with the standard jump height
2. Additional spacebar presses have no effect and the mole does not jump higher
3. The mole lands at the same height as a normal jump
4. The pause menu opens and the game is paused
5. The mole does not react to spacebar presses
6. The mole remains in the same position as before pausing with no unintended jump or upward force applied

### Execution History

#### Sprint 3 - 2026-07-03

**Execution results:**

**Customer comments:** 

**Resulting PBIs:** 


---

## Execution History Summary

### Sprint 2 - 2026-06-27

All UATs were executed.  
All UATs are passed.  
[UAT-002](#uat-002-climbing-mode) and [UAT-005](#uat-005-refuel-and-upgrade-the-drill) need product changes.  

#### Key Feedback Points

- Drill should be the central mechanic. Combine the drill station with a workbench for crafting and upgrades.
- Replace separate shovel/pickaxe tools with a single leveling tool. 
- Add coins as a collectible currency. 
- Add limited visibility and a helmet flashlight mechanic.
- Simplify key bindings. Remove dedicated climbing button (C) and auto-trigger climbing when pressing W against a wall, with stamina drain.
- Add stamina to movement overall.
- Inventory UI is too complex. Increase stack size.
- Bug, Pause + Space causes force accumulation, and mole launches into the sky on unpause.

#### Resulting PBIs

- [Infinite jump](https://github.com/coolcamilla/Team32/issues/168)
- [Corner-Grab Jump](https://github.com/coolcamilla/Team32/issues/170)
- [Stamina](https://github.com/coolcamilla/Team32/issues/167)
- [Timer-based Climbing Mode](https://github.com/coolcamilla/Team32/issues/171)
- [Update Tools Crafting Workflow](https://github.com/coolcamilla/Team32/issues/172)
- [Single leveling tool workflow](https://github.com/coolcamilla/Team32/issues/173)
- [Simplify Inventory](https://github.com/coolcamilla/Team32/issues/174)
- [US-019: Layer Transition](https://github.com/coolcamilla/Team32/issues/83)

### Sprint 3 - 2026-07-03

Before session with the customer [UAT-002](#uat-002-climbing-mode), [UAT-003](#uat-003-craft-a-tool-using-the-crafting-menu) were updated to align with current implementation. [UAT-006](#uat-006-stamina-depletion-and-recovery), [UAT-007](#uat-007-jump-bug-fixes) were created.

[UAT-001](#uat-001-mole-movement-fix), [UAT-002](#uat-002-climbing-mode), [UAT-003](#uat-003-craft-a-tool-using-the-crafting-menu), [UAT-006](#uat-006-stamina-depletion-and-recovery), [UAT-007](#uat-007-jump-bug-fixes) were executed.  
`list UATs` are passed.  
`list UATS` need product changes.  

#### Need to be fixed

#### Key Feedback Points

#### Resulting PBIs
