# Operation: EarthCore
Is a 2D PC game where the player character is a mole. The mole tries to reach Earth's Core by digging a deep burrow with different tools and a massive drill.

### [License](../../LICENSE)
### [User stories](user-stories.md)

### [Prototype](https://www.figma.com/proto/1k5Nq73tM32LlkQ1JE7mtg/Mole-Prototype?node-id=0-1&t=aM2hmkN2RIzBq2JA-1)
P.S. Open the prototype in the editor mode to familiarize with the transitions between states.

### [MVP v0 report](mvp-v0-report.md)
Build: [Windows](../../releases/Windows), [Linux](../../releases/Linux)  
Run instructions: go through [local setup instructions](../../README.md#local_setup_instructions) and download `MVP v.0.zip`  
[Video demonstration](https://drive.google.com/file/d/1L3zD3pNKFaFOtnZbXPWiMy1xdTY_O0un/view?usp=drive_link)  

### [PR Template](../../.github/pull_request_template.md)
[Checked PRs](https://github.com/coolcamilla/Team32/pulls?q=is%3Apr+is%3Aclosed)

### [Lychee configuration](../../.github/workflows/links.yml)

### Screenshots
#### *Protected branch settings*
![](images/branch_settings_1.png)
![](images/branch_settings_2.png)
![](images/branch_settings_3.png)
![](images/branch_settings_4.png)

#### *PR made by SunrisEe41 and reviewed by coolcamilla*
![](images/checked_pr_1.png)
![](images/checked_pr_2.png)

#### *Overview of all prototype screens*
![](images/prototype_1.png)
#### *Main menu*
![](images/prototype_2.png)
#### *Gameplay screen with inventory and crafting overlays*
![](images/prototype_3.png)
#### *Gameplay screen showing digging mechanic*
![](images/prototype_4.png)
#### *Load game menu with saving slots*
![](images/prototype_5.png)

#### *Deployed MVP v0*
![](images/mvp_1.png)
![](images/mvp_2.png)
![](images/mvp_3.png)

### Coverage 
The interactive Figma prototype covers [US-02](user-stories.md#us-02-digging), [US-09](user-stories.md#us-09-tools-crafting), [US-10](user-stories.md#us-10-inventory) (and actually it also covers [US-01](user-stories.md#us-01-saving))
- **[US-02 (Digging)](user-stories.md#us-02-digging)** Represented by the main gameplay screen showing the mole in the cave with two layers (dirt, rock). The mole uses pickaxe to destroy rock blocks.
- **[US-09 (Tools crafting)](user-stories.md#us-09-tools-crafting)** Represented by the crafting interface overlay on the left showing recipes (e.g., 10 sticks → Shovel, 10 stones + 5 sticks → Pickaxe).
- **[US-10 (Inventory)](user-stories.md#us-10-inventory)** Represented by the inventory bar at the top-left corner of the screen, displaying collected resources with icons and quantities and currently equipped tools.
- [US-01 (Saving)](user-stories.md#us-01-saving) Represented by the `Save Game` button when exiting and `Load Game` button in the main menu. Five save slots are presented.

[MVP v0 report](mvp-v0-report.md)

The MVP v0 covers [US-02](user-stories.md#us-02-digging), [US-09](user-stories.md#us-09-tools-crafting), [US-10](user-stories.md#us-10-inventory)
- **[US-02 (Digging)](user-stories.md#us-02-digging)** Partially implemented. The mole can dig through two layers (dirt, rock) using three tools (broom, shovel, pickaxe). However, the mole can't reach Earth's core and complete the game. In MVP v.1 number of layers will be increased.
- **[US-09 (Tools crafting)](user-stories.md#us-09-tools-crafting)** Partially implemented. Player can create two tools sequentially (shovel, pickaxe). Initially, the mole has a broom. Then, he crafts a shovel (10 sticks are needed). Finally, the mole crafts a pickaxe (5 sticks and 5 stones are needed). In MVP v.1 new tools will be presented.
- **[US-10 (Inventory)](user-stories.md#us-10-inventory)** Partially implemented. Two types of resources (sticks, stones) drop from blocks (dirt, rock). The mole can collect them. Amount of each resource is tracked in the inventory. In MVP v.1 number of resourcers' types will be increased.

### [Transcript](customer-meeting-transcript.md)

### [Customer meeting summary](customer-meeting-summary.md)

### [Week 2 analysis](analysis.md)

### [LLm report](llm-report.md)

