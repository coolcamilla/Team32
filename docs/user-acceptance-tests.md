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

**Resulting PBIs:** [Infinite jump](https://github.com/coolcamilla/Team32/issues/168), [Corner-grab Jump](https://github.com/coolcamilla/Team32/issues/170)

#### Sprint 3 - 2026-07-03

**Execution results:** PASSED. The mole jumped once along white wall with standard height. Additional Space presses mid-jump had no effect. The mole landed normally without height stacking.

**Customer comments:** Noted the corner-grab mechanic positively - when the mole grabs a corner it can make a higher jump. Suggested highlighting the corner visually so the player recognizes it as an intentional mechanic.

**Resulting PBIs:** [Corner-grab Jump](https://github.com/coolcamilla/Team32/issues/170)

#### Sprint 4 - 2026-07-10

_Not executed._

## UAT-002: Climbing Mode

**Status:** Active

**Linked to:** [Mole's Movement and Climb Mode](https://github.com/coolcamilla/Team32/issues/88), [Rotation-based Climbing Mode](https://github.com/coolcamilla/Team32/issues/171)

**User goal:** Verify that the mole can enter climbing mode and climb the background walls.

**Preconditions:**
- New game session started
- Mole is on solid ground
- There is a climbing zone (background wall) with at least 4 blocks width and 4 blocks depth (e.g., a wide pit)

**Step-by-step instructions:**
1. Move the mole to the climbing zone
2. Press `C`
3. Press `W`
4. Press `S`
5. Hold `S` and press `LMB`
6. Press `A`
7. Press `D`
8. Press `C`

**Expected outcome:**
1. The mole is positioned in front of the climbing wall
2. The mole enters Climbing Mode
3. The mole moves forward along the background wall
4. The mole moves backward along the background wall
5. The mole moves backward along the background wall and does not dig
6. The mole rotates counter-clockwise
7. The mole rotates clockwise
8. The mole exits Climbing Mode and lands on the nearest physical block below it

### Execution History

#### Sprint 2 - 2026-06-27

**Execution results:** PASSED. The mole entered and exited climbing mode correctly using C. WASD movement along background walls worked in all four directions. Pressing C again exited climbing mode and the mole fell and landed normally. Climbing mode also appeared to activate on the surface (outside the pit), which the team acknowledged as a debug artifact for now.

**Customer comments:** The mole cannot dig while in climbing mode (neither up nor down). Suggested making climbing mode more intuitive — either strictly up/down only, or always-on with stamina drain (like Zelda). Recommended removing the dedicated C button and tying climbing to W automatically when against a wall.

**Resulting PBIs:** [Stamina](https://github.com/coolcamilla/Team32/issues/167), [Rotation-based Climbing Mode](https://github.com/coolcamilla/Team32/issues/171)

#### Sprint 3 - 2026-07-03

**Execution results:** PASSED. The mole entered Climbing Mode by pressing C. W moved the mole forward, S moved it backward. A rotated counter-clockwise, D rotated clockwise. Pressing C again exited Climbing Mode and the mole landed on the nearest physical block. Digging while in Climbing Mode was confirmed to be disabled.

**Customer comments:** No functional objections to the new controls. Suggested explaining the climbing system to the player more clearly before they try it.

**Resulting PBIs:** [Interactive Game Tutorial](https://github.com/coolcamilla/Team32/issues/200)

#### Sprint 4 - 2026-07-10

_Not executed._

## UAT-003: Craft a Tool Using the Crafting Menu

**Status:** Active

**Linked to:** [US-016: Tools Crafting UI](https://github.com/coolcamilla/Team32/issues/80), [US-017: Tools Crafting Action](https://github.com/coolcamilla/Team32/issues/81), [Update Tools Crafting Workflow](https://github.com/coolcamilla/Team32/issues/172), [Mouse-based Navigation in Crafting UI](https://github.com/coolcamilla/Team32/issues/201)

**User goal:** Verify that the crafting system works correctly, and the player can craft a tool when he or she has sufficient resources.

**Preconditions:**
- New game session started
- Player does not have any tool yet
- Player has collected enough resources for a wooden shovel (10 sticks)
- Player has not collected enough resources for a stone pickaxe (10 sticks and 5 pebbles)
- Mole is near the workbench on the surface

**Step-by-step instructions:**
1. Move the mole to the workbench
2. Press `F`
3. Hover the mouse over stone shovel icon
4. Click the `Craft` button
5. Hover the mouse over wooden shovel icon
6. Click the `Craft` button
7. Press `F`
8. Collect 10 sticks and 5 pebbles
9. Move the mole to the workbench
10. Press `F`
11. Hover the mouse over stone shovel icon
12. Click the `Craft` button

**Expected outcome:**
1. Hint `Press F to open craft menu` is highlighted
2. The crafting menu opens
3. The stone shovel recipe is displayed with required resources, description and the `Craft` button
4. Nothing happens (the button is disabled, no resources are removed, no tool is crafted)
5. The wooden shovel recipe is displayed with required resources, description and the `Craft` button
6. 10 sticks are removed from the inventory, the wooden shovel appears in the equipment hotbar
7. The crafting menu closes
8. Collected resources are added to the inventory
9. Hint `Press F to open craft menu` is highlighted
10. The crafting menu opens
11. The stone shovel recipe is displayed with required resources, description and the `Craft` button
12. 10 sticks and 5 pebbles are removed from the inventory, the stone shovel replaces the wooden shovel in the equipment hotbar

### Execution History

#### Sprint 2 - 2026-06-27

**Execution results:** PASSED. The crafting menu opened correctly via E. The customer navigated the catalog, selected the wooden shovel, and crafted it successfully. Resources were deducted from the inventory. New digging animations (with shovel) were noted positively. During the session the customer happened to already have a shovel and crafted a pickaxe instead to demonstrate the system - behavior was identical and correct.

**Customer comments:** Praised the new craft animations. No blockers reported. Suggested simplifying the inventory and crafting flow. Restrict multiple crafting of one tool. Replace the creation of multiple tools with the improvement of a single tool

**Resulting PBIs:** [Update Tools Crafting Workflow](https://github.com/coolcamilla/Team32/issues/172), [Single leveling tool workflow](https://github.com/coolcamilla/Team32/issues/173)

#### Sprint 3 - 2026-07-03

**Execution results:** PASSED. The workbench hint appeared on approach. The crafting menu opened via F and displayed tools in a fixed horizontal chain. Clicking a tool showed its recipe. Crafting was blocked when resources were insufficient. After collecting enough resources, crafting succeeded and the new tool replaced the previous one in the equipment hotbar.

**Customer comments:** Suggested improving the crafting UI - ideally showing required resources inline without needing to open a separate panel. Requested mouse cursor support for navigating the interface.

**Resulting PBIs:** [Mouse-based Navigation in Crafting UI](https://github.com/coolcamilla/Team32/issues/201)

#### Sprint 4 - 2026-07-10

_Not executed._

## UAT-004: Inventory Management

**Status:** Active

**Linked to:** [US-010: Inventory](https://github.com/coolcamilla/Team32/issues/70), [Simplify Inventory](https://github.com/coolcamilla/Team32/issues/174)

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

**Resulting PBIs:** [Simplify Inventory](https://github.com/coolcamilla/Team32/issues/174)

#### Sprint 3 - 2026-07-03

_Not executed._

#### Sprint 4 - 2026-07-10

_Not executed._

## UAT-005: Refuel and Upgrade the Drill 

**Status:** Active

**Linked to:** [US-018: Drill Upgrading](https://github.com/coolcamilla/Team32/issues/82), [Improve Drill UI](https://github.com/coolcamilla/Team32/issues/203)

**User goal:** Verify that the player can refuel the drill and apply an upgrade to improve its performance.

**Preconditions:**

- New game session started
- The drill's fuel tank is empty
- Player has sufficient at least 5 sticks and 5 pebbles

**Step-by-step instructions:**

1. Go next to the drill sign on the left side of the map
2. Press `F`
3. Check the current fuel level on the left
4. Add one stick to the fuel tank
5. Look to the right side and find one available upgrade (e.g., increased fuel capacity or faster digging speed)
6. Click `Upgrade` button on the bottom of the "Drill Drill" upgrade panel

**Expected outcome:**

1. Hint `Press F to interact` is highlighted
2. The drill UI is opened
3. The fuel tank is empty, and the drill is not active
4. Fuel tank now has a litle bit fuel and speed is 0.40 m/min and power is 5 W, drill is active
5. Three information panels on the right demonstrate three improvement areas: Drill Engine, Drill Drill, Fuel Tank
6. The upgrade disappears from the upgrade table, and drill stats are updated

### Execution History

#### Sprint 2 - 2026-06-27

**Execution results:** PASSED. The customer found the drill, pressed F to open the UI, confirmed the fuel tank was empty and the drill was inactive. Adding one stick activated the drill and the depth counter began changing. Upgrade options were displayed in the right panel. The customer had run out of resources to apply an upgrade, but the upgrade UI was verified as functional.

**Customer comments:** The drill's role in the core game loop was clarified during the session: the drill digs to new layers and supplies the mole with materials, rather than the mole digging directly. Customer responded very positively to this design. Recommended making the drill the central key mechanic. Suggested combining the drill UI with a workbench for crafting and upgrades.

**Resulting PBIs:** [Update Tools Crafting Workflow](https://github.com/coolcamilla/Team32/issues/172), [US-019: Layer Transition](https://github.com/coolcamilla/Team32/issues/83)

#### Sprint 3 - 2026-07-03

**Execution results:** PASSED. The drill UI opened via F near the sign. Fuel was added successfully and the drill activated. Upgrade panels were displayed correctly.

**Customer comments:** Suggested placing the drill in the center of the level as the central element. Recommended reallocate drill interface elements. Noted that the overall drill concept is strong and should remain the core mechanic.

**Resulting PBIs:** [Improve Drill UI](https://github.com/coolcamilla/Team32/issues/203), [Change World Layout](https://github.com/coolcamilla/Team32/issues/204)

#### Sprint 4 - 2026-07-10

_Not executed._

## UAT-006: Stamina Depletion and Recovery

**Status:** Active

**Linked to:** [Stamina](https://github.com/coolcamilla/Team32/issues/167), [Death Mechanic](https://github.com/coolcamilla/Team32/issues/153)

**User goal:** Verify that stamina depletes while the mole moves in Climbing Mode and recovers when the mole in normal mode.

**Preconditions:**
- New game session started
- Mole is on solid ground adjacent to a background wall
- Stamina bar is fully charged
- Player has at least 5 coins

**Step-by-step instructions:**
1. Press `C`
2. Hold `W` continuously
3. Stop pressing any movement key while remaining in Climbing Mode
4. Press `C`
5. Press `C` again
6. Move in Climbing Mode until stamina reaches zero
7. Move the mole to the beer vending machine on the surface
8. Press `F`


**Expected outcome:**
1. The mole enters Climbing Mode and the stamina bar is visible in the bottom of the screen
2. The stamina bar visibly decreases while the mole moves forward
3. The stamina bar does not recover while the mole is stationary in Climbing Mode
4. The mole lands on the nearest physical block below it and stamina bar recovers
5. The mole enters Climbing Mode
6. Stamina descreases as mole moves. When stamina is zero, the mole dies: death screen appears for 10 seconds, then the mole respawns near the drill sign with full stamina and empty inventory
7. Hint `Press F to become happier` is highlighted
8. Stamina capacity is increased and 5 coins are deducted

### Execution History

#### Sprint 3 - 2026-07-03

**Execution results:** PASSED. Stamina bar was visible upon entering Climbing Mode. Stamina depleted while moving and the mole slowed down significantly when it reached zero. Stamina recovered after exiting Climbing Mode.

**Customer comments:** Suggested making the initial stamina bar small so upgrading it feels meaningful. Proposed that beer could act as a stamina booster item. Suggested exploring a risk mechanic where stamina depletion underground has consequences for the mole.

**Resulting PBIs:** [Death Mechanic](https://github.com/coolcamilla/Team32/issues/153) (actually it was overheating mechanic but the customer asked us to replace it)

#### Sprint 4 - 2026-07-10

**Execution results:** `TODO`

**Execution results:** `TODO`

**Resulting PBIs:** `TODO`

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

**Execution results:** PASSED. Pressing Space repeatedly mid-jump had no effect on jump height. Pressing spacebar multiple times while paused and then resuming caused no unintended jump or upward force.

**Customer comments:** No issues reported.

**Resulting PBIs:** _None_

#### Sprint 4 - 2026-07-10

_Not executed._

## UAT-008: Mining Stations Construction and Operation

**Status:** Active

**Linked to:** [US-020: Deposit Discovery](https://github.com/coolcamilla/Team32/issues/84), [US-021: Mining Stations Placement](https://github.com/coolcamilla/Team32/issues/85)

**User goal:** Verify that the player can discover a deposit, build a mining station on it, and that the station autonomously collects resources into the inventory.

**Preconditions:** 
- New game session started
- Player has enough resources to build a clay station (8 sticks and 5 pebbles)

**Step-by-step instructions:**
1. Dig into the surface layer until you find clay deposit
2. Move mole to the discovered deposit
3. Press `F`
4. Click `Build` button
5. Wait and observe the inventory

**Expected outcome:**
1. Clay deposit is distinguishable on background layer
2. Hint `Press F to interact` appears
3. Information panel appears with station type, its recipe, extraction rate, and a `Build` button
4. The station is placed on the deposit and the required resources (8 sticks and 5 pebbles) are deducted from the inventory
5. Clay is falling near station

### Execution History

#### Sprint 4 - 2026-07-10

**Execution results:** `TODO`

**Execution results:** `TODO`

**Resulting PBIs:** `TODO`

## UAT-009: Layer transition

**Status:** Active

**Linked to:** [US-019: Layer Transition](https://github.com/coolcamilla/Team32/issues/83)

**User goal:** Verify that the drill correctly triggers a layer transition, drops the required resources, and allows the mole to access and dig in the new layer.

**Preconditions:**
- New game session started
- Drill is fuelled and actively drilling
- Mole is in the surface layer near to the rock blocks
- Player has 5 sticks
- Mole is equiped with stone shovel

**Step-by-step instructions:**
1. Try to dig rock block with the stone shovel
2. Fuel the drill and let it operate until it reaches the depth of 3 meters
3. Observe the drill behavior at the moment of transition
4. Walk through the dropped resources
5. Open the drill UI
6. Go to the workbench and press `F`
7. Hover the mouse over stone pickaxe icon
8. Click the `Craft` button
9. Go to the stone layer and try to dig rock block with the stone pickaxe

**Expected outcome:**
1. Rock block is not destroyed
2. The drill continues operating without stopping when it reaches the stone layer
3. The drill drops the resources (5 stones) required to craft the stone pickaxe
4. The dropped resources are automatically collected into the inventory
5. The drill UI background changes to reflect the stone layer
6. The crafting menu opens and shows stone pickaxe in the chain
7. The stone pickaxe recipe is displayed with required resources, description and the `Craft` button
8. 5 sticks and 5 stones are removed from the inventory, the stone pickaxe replaces the stone shovel in the equipment hotbar
9. Rock block is destroyed

### Execution History

#### Sprint 4 - 2026-07-10

**Execution results:** `TODO`

**Execution results:** `TODO`

**Resulting PBIs:** `TODO`

---

## Execution History Summary

### Sprint 2 - 2026-06-27

[UAT-001](#uat-001-mole-movement-fix), [UAT-002](#uat-002-climbing-mode), [UAT-003](#uat-003-craft-a-tool-using-the-crafting-menu), [UAT-004](#uat-004-inventory-management), and [UAT-005](#uat-005-refuel-and-upgrade-the-drill) were executed.  
[UAT-001](#uat-001-mole-movement-fix), [UAT-002](#uat-002-climbing-mode), [UAT-003](#uat-003-craft-a-tool-using-the-crafting-menu), [UAT-004](#uat-004-inventory-management), and [UAT-005](#uat-005-refuel-and-upgrade-the-drill) are passed.  
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
- [Rotation-based Climbing Mode](https://github.com/coolcamilla/Team32/issues/171)
- [Update Tools Crafting Workflow](https://github.com/coolcamilla/Team32/issues/172)
- [Single leveling tool workflow](https://github.com/coolcamilla/Team32/issues/173)
- [Simplify Inventory](https://github.com/coolcamilla/Team32/issues/174)
- [US-019: Layer Transition](https://github.com/coolcamilla/Team32/issues/83)

### Sprint 3 - 2026-07-03

Before session with the customer [UAT-002](#uat-002-climbing-mode), [UAT-003](#uat-003-craft-a-tool-using-the-crafting-menu) were updated to align with current implementation. [UAT-006](#uat-006-stamina-depletion-and-recovery), [UAT-007](#uat-007-jump-bug-fixes) were created.

[UAT-001](#uat-001-mole-movement-fix), [UAT-002](#uat-002-climbing-mode), [UAT-003](#uat-003-craft-a-tool-using-the-crafting-menu), [UAT-005](#uat-005-refuel-and-upgrade-the-drill), [UAT-006](#uat-006-stamina-depletion-and-recovery), [UAT-007](#uat-007-jump-bug-fixes) were executed.  
[UAT-001](#uat-001-mole-movement-fix), [UAT-002](#uat-002-climbing-mode), [UAT-003](#uat-003-craft-a-tool-using-the-crafting-menu), [UAT-005](#uat-005-refuel-and-upgrade-the-drill), [UAT-006](#uat-006-stamina-depletion-and-recovery), [UAT-007](#uat-007-jump-bug-fixes) are passed.  
[UAT-005](#uat-005-refuel-and-upgrade-the-drill) and [UAT-006](#uat-006-stamina-depletion-and-recovery) need product changes.  

#### Need to be fixed

- The corner-grab mechanic is functional but invisible to the player: the corner of the block should be visually highlighted.
- The current crafting interface requires opening a separate panel to view required resources: required resources should be visible inline without additional clicks.
- The drill UI should be simplified: it has too many separate panels and buttons.
- The transition between visible areas should be smooth with no edge artifacts.
- The seen blocks should become undiscovered again after some time.
- Replace interface placeholders with art assests.
- Make the block destructoin engaging (add particles, sound effect, animation).


#### Key Feedback Points

- Crafting UI needs improvement - show required resources inline without a separate panel
- Drill should remain the central mechanic; place it in the center of the level
- Simplify the drill interface to fewer buttons where possible
- Make initial stamina bar small so upgrading feels rewarding
- Explore a risk mechanic tied to stamina depletion underground
- Improve block destruction feel - add particles or visual effects (reference: SteamWorld Dig, Forager)
- Beer could act as a stamina booster item

#### Resulting PBIs

- [Corner-grab Jump](https://github.com/coolcamilla/Team32/issues/170)
- [Interactive Game Tutorial](https://github.com/coolcamilla/Team32/issues/200)
- [Mouse-based Navigation in Crafting UI](https://github.com/coolcamilla/Team32/issues/201)
- [Improve Drill UI](https://github.com/coolcamilla/Team32/issues/203)
- [Change World Layout](https://github.com/coolcamilla/Team32/issues/204)
- [Death Mechanic](https://github.com/coolcamilla/Team32/issues/153)
- [Block Destruction](https://github.com/coolcamilla/Team32/issues/205)
- [Beer](https://github.com/coolcamilla/Team32/issues/206)
- [Make Discovered Block Temporary](https://github.com/coolcamilla/Team32/issues/207)

### Sprint 4 - 2026-07-10

Before session with the customer [UAT-003](#uat-003-craft-a-tool-using-the-crafting-menu), [UAT-005](#uat-005-refuel-and-upgrade-the-drill), and [UAT-006](#uat-006-stamina-depletion-and-recovery) were updated to align with current implementation. [UAT-008](#uat-008-mining-stations-construction-and-operation) and [UAT-009](#uat-009-layer-transition) were created.

[UAT-006](#uat-006-stamina-depletion-and-recovery), [UAT-008](#uat-008-mining-stations-construction-and-operation) and [UAT-009](#uat-009-layer-transition) were executed.  
`TODO` are passed.  
`TODO` need product changes.