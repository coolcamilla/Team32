## Purpose
Establish a runnable technical foundation for the game and validate the core gameplay loop: `move` -> `dig` -> `collect` -> `craft/upgrade`. 
## Description
- The mole (player character) can move
- The game world consists of blocks that player can destroy
- Destroyed blocks produce resources that player can collect
- Resources are collected and tracked in the inventory
- A basic crafting/upgrade interaction consumes resources and changes the player's tools
## Relationship to the prototype
MVP v.0 supports prototype from the technical aspect. While prototype defines UI and UX for core mechanics (movement, digging, inventory, crafting), MVP v.0 directly implements these mechanics but omits user-friendly interface.

## Relationship to the proposed MVP v1 stories
- **[US-02 (Digging)](user-stories.md#us-02-digging)** Partially implemented. The mole can dig through two layers (dirt, rock) using three tools (broom, shovel, pickaxe). However, the mole can't reach Earth's core and complete the game. In MVP v.1 number of layers will be increased.
- **[US-09 (Tools crafting)](user-stories.md#us-09-tools-crafting)** Partially implemented. Player can create two tools sequentially (shovel, pickaxe). Initially, the mole has a broom. Then, he crafts a shovel (10 sticks are needed). Finally, the mole crafts a pickaxe (5 sticks and 5 stones are needed). In MVP v.1 new tools will be presented.
- **[US-10 (Inventory)](user-stories.md#us-10-inventory)** Partially implemented. Two types of resources (sticks, stones) drop from blocks (dirt, rock). The mole can collect them. Amount of each resource is tracked in the inventory. In MVP v.1 number of resourcers' types will be increased.

## Current limitations
- Placeholder graphics are used for blocks and the broom
- Inventory is replaced with counters for sticks and stones
- Crafting interface doesn't notify player that some tool can be created
- Progress is not saved between sessions
- No main menu, pause menu, and settings
- Game level is manually created without procedural generation

## Links
Builds: [Windows](../../releases/Windows), [Linux](../../releases/Linux)  
[Video demonstration](https://drive.google.com/file/d/1L3zD3pNKFaFOtnZbXPWiMy1xdTY_O0un/view?usp=sharing)  
[Local setup instructions](../../README.md#local-setup-instructions)  

## Smoke-check scenario

### 1) Access
 - Go through [local setup instructions](../../README.md#local-setup-instructions) and download `MVP v.0.zip`
### 2) Steps
1. Press **A** or **D**  
2. Press **Space**  
3. **Left-click** on any dirt block (the brown one)  
4. Click two more times on the same block  
5. Walk over the dropped resource (if resource doesn't drop, destroy another dirt block)  
6. Press **Q** **before** collecting 10 sticks  
7. **Double Left-click** on any rock block (the grey one, located under all dirt blocks)  
8. Destroy dirt blocks and collect resources dropped from them until you have **at least 10 sticks**  
9. Press **Q**  
10. Press **Q**  
11. **Double Left-click** on any rock block  
12. Destroy blocks until you have **at least 5 sticks and 5 stones**  
13. Press **Q**  
14. **Double Left-click** on any rock block (the cursor is the center of the pickaxe)  
15. Press **Alt** + **F4**

### 3) Expected results
1. The mole moves left or right accordingly  
2. The mole jumps  
3. The dirt block's endurance decreases, that is, its transparency increases  
4. The dirt block is destroyed; a resource drops with the following probabilities: nothing (50%), stick (30%), stone (20%)  
5. The dropped resource is added to the inventory  
6. Nothing happens (the mole still holds the broom)  
7. Nothing happens (the rock block is not destroyed with the broom)  
8. Stick and stone counts in the inventory increase correctly  
9. The mole receives the shovel  
10. Nothing happens if you don't have at least 5 sticks and 5 stones (the mole still holds the shovel). In other case, the mole receives the pickaxe, and you should go to the step 14 immediately  
11. Nothing happens (the rock block is not destroyed with the shovel)  
12. Stick and stone counts in the inventory increase correctly  
13. The mole receives the pickaxe  
14. Rock block is destroyed; a resource drops with the following probabilities: nothing (30%), stone (70%)  
15. The game closes

