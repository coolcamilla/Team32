# User Acceptance Tests

## UAT-001: Mole Movement Fix

**Status:** Active

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

**Execution results:** PASSED. The mole could no longer jump over the white wall. Additional Space presses in mid-air did not launch the mole out of bounds. After landing, A/D horizontal movement functioned normally with no side effects. 

**Customer comments:** A corner-grab mechanic was observed - when the mole grabs a corner it can make a higher jump. Customer reacted positively. Suggested adding a special move or animation for the corner-jump mechanic. Investigate the pause-accumulation bug: when the game is paused and Space is pressed repeatedly, forces accumulate and the mole launches into the sky on unpause.

**Resulting PBIs:** [#168](https://github.com/coolcamilla/Team32/issues/168), [#170](https://github.com/coolcamilla/Team32/issues/170)

## UAT-002: Climbing Mode

**Status:** Active

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
5. Press `A`
6. Press `D`
7. Press `C`

**Expected outcome:**
1. The mole is positioned in front of the climbing wall
2. The mole enters climbimg mode
3. The mole moves vertically up along the background
4. The mole moves vertically down along the background
5. The mole moves horizontally left along the background
6. The mole moves horizontally right along the background
7. The mole exits climbimg mode and falls/lands on physical ground

**Execution results:** PASSED. The mole entered and exited climbing mode correctly using C. WASD movement along background walls worked in all four directions. Pressing C again exited climbing mode and the mole fell and landed normally. Climbing mode also appeared to activate on the surface (outside the pit), which the team acknowledged as a debug artifact for now.

**Customer comments:** The mole cannot dig while in climbing mode (neither up nor down). Suggested making climbing mode more intuitive — either strictly up/down only, or always-on with stamina drain (like Zelda). Recommended removing the dedicated C button and tying climbing to W automatically when against a wall.

**Resulting PBIs:** [#167](https://github.com/coolcamilla/Team32/issues/167), [#171](https://github.com/coolcamilla/Team32/issues/171)

## UAT-003: Craft a Tool Using the Crafting Menu

**Status:** Active

**User goal:** Verify that the crafting system works correctly, and the player can craft a tool when he or she has sufficient resources.

**Preconditions:**
- New game session started
- Player has collected enough resources for one wooden shovel (12 sticks)

**Step-by-step instructions:**
1. Press `E` to open the crafting menu
2. Browse the catalog to find the wooden shovel recipe
3. Click the wooden shovel icon
4. Click the `Craft` button on the information panel
5. Click the `Craft` button again

**Expected outcome:**
1. The crafting menu appears on the left, under the inventory
2. The catalog can be scrolled through
3. The wooden shovel information panel opens, showing the recipe and stats
4. 12 sticks are removed from the inventory, and wooden shovel is added to the empty inventory slot
5. Nothing happens (the button is disabled, no resources are removed, no second tool is crafted)

**Execution results:** PASSED. The crafting menu opened correctly via E. The customer navigated the catalog, selected the wooden shovel, and crafted it successfully. Resources were deducted from the inventory. New digging animations (with shovel) were noted positively. During the session the customer happened to already have a shovel and crafted a pickaxe instead to demonstrate the system - behavior was identical and correct.

**Customer comments:** Praised the new craft animations. No blockers reported. Suggested simplifying the inventory and crafting flow. Restrict multiple crafting of one tool. Replace the creation of multiple tools with the improvement of a single tool

**Resulting PBIs:** [#172](https://github.com/coolcamilla/Team32/issues/172), [#173](https://github.com/coolcamilla/Team32/issues/173)

---

## UAT-004: Inventory Management

**Status:** Active

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
4. Use resources for crafting (e.g., craft a wooden shovel from UAT-003)
5. Try to craft a tool for which you do not have enough resources

**Expected outcome:**
1. The desired block is destroyed, and resources drop from it onto the ground
2. Resources are added to the inventory, and the UI displays the correct resource count
3. Same resources stack together (up to the 16), and different resources occupy new slots
4. Resources used for crafting are correctly deducted, and the UI count updates instantly
5. The system prevents crafting, no resources are deducted, and an error message or indicator appears

**Execution results:** Blocks were destroyed and resources dropped correctly. Walking through resources added them to the inventory with correct counts displayed. Crafting deducted resources accurately and the UI updated immediately. Attempting to craft without sufficient resources was blocked correctly.

**Customer comments:** No functional objections. Noted that the current stack size of 16 felt limiting during extended play. Suggested simplifying the overall inventory UI and considering slot-based limits tied to drill upgrades.

**Resulting PBIs:** [#174](https://github.com/coolcamilla/Team32/issues/174)

---
## UAT-005: Refuel and Upgrade the Drill 

**Status:** Active

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

**Execution results:** PASSED. The customer found the drill, pressed F to open the UI, confirmed the fuel tank was empty and the drill was inactive. Adding one stick activated the drill and the depth counter began changing. Upgrade options were displayed in the right panel. The customer had run out of resources to apply an upgrade, but the upgrade UI was verified as functional.

**Customer comments:** The drill's role in the core game loop was clarified during the session: the drill digs to new layers and supplies the mole with materials, rather than the mole digging directly. Customer responded very positively to this design. Recommended making the drill the central key mechanic. Suggested combining the drill UI with a workbench for crafting and upgrades.

**Resulting PBIs:** [#172](https://github.com/coolcamilla/Team32/issues/172), [#83](https://github.com/coolcamilla/Team32/issues/83)

---
## Summary
All UATs are passed
[UAT-002](#uat-002-climbing-mode) and [UAT-005](#uat-005-refuel-and-upgrade-the-drill) need product changes
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
