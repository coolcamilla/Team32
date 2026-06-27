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

**Execution results:** _TBD during customer session_

**Customer comments:** _TBD_

**Resulting PBIs:** _TBD_

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

**Execution results:** _TBD during customer session_

**Customer comments:** _TBD_

**Resulting PBIs:** _TBD_

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

**Execution results:** _TBD during customer session_

**Customer comments:** _TBD_

**Resulting PBIs:** _TBD_

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
4. Use resources for crafting (e.g., craft a wooden shovel from [UAT-003](#uat-003-craft-a-tool-using-the-crafting-menu))
5. Try to craft a tool for which you do not have enough resources

**Expected outcome:**
1. The desired block is destroyed, and resources drop from it onto the ground
2. Resources are added to the inventory, and the UI displays the correct resource count
3. Same resources stack together (up to the 16), and different resources occupy new slots
4. Resources used for crafting are correctly deducted, and the UI count updates instantly
5. The system prevents crafting, no resources are deducted, and an error message or indicator appears

**Execution results:** _TBD during customer session_

**Customer comments:** _TBD_

**Resulting PBIs:** _TBD_

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

**Execution results:** _TBD during customer session_

**Customer comments:** _TBD_

**Resulting PBIs:** _TBD_
