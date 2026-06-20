# Sprint Review Summary - Operation EarthCore

**Date:** 20.06.2026  
**Participants:** coolcamilla (Interviewer), WazzuRunaway (Interviewer), Lilia-Shagidullina (Note Taker), SunrisEe41 (Moderator), Customer 

## Artifact Demonstrated

Playable build of an MVP increment for Operation EarthCore 
List of user stories in the scope of MVP v1 and MVP increment

## Implemented Increment

The following was shown and discussed during the demo:

- **First soil layer** with four resources: sticks, stones, saplings, and clay.
- **Digging mechanic** inspired by SteamWorld Dig - hold WASD for direction plus left mouse button to dig; upward movement by clinging to cave backgrounds will also be implemented for MVP v1.
- **Two craftable tools:** wooden shovel and stone pickaxe.
- **Inventory system:** hotbar and full inventory panel.
- **Crafting menu:** opens alongside the full inventory, displays all craftable items regardless of available resources, and shows a per-item popup with requirements and a Craft button.
- **Main menu:** "New Game" and "Load Game" buttons present but currently both behave identically as placeholders.
- **Physical item drops:** mined resources interact physically with the mole character in the world.
- **Game title:** Operation EarthCore.

## Scope Reviewed

The team presented their planned full game loop: the mole starts near a surface drill, manually digs through underground layers at first, discovers ore deposits, and places mining stations to automate resource extraction. Resources fuel and upgrade the drill to break through to deeper layers. The mole itself also levels up via craftable or discoverable items (e.g., gloves granting a digging speed bonus). Saplings planted on the surface are intended as a renewable fuel source for the drill.

## Approvals

- **MVP v1 as demonstrated was formally approved** by the Customer. The team was praised for the pace of delivery.
- The choice of core mechanics and the MVP v1 feature set were also approved.

## Requested Changes

**Inventory & UI**
- Simplify the inventory significantly - for now it is inconvenient and buggy.
- Assign tools to fixed, dedicated slots (e. g. shovel always in slot 1, pickaxe always in slot 2) rather than allowing free arrangement.
- Drag-and-drop functionality is not needed and should be removed.

**Game Feel & Cycle**
- Creating a surface-return loop similar to SteamWorld Dig's crawl-out cycle is essential for establishing rhythm and the dopamine loop.
- A risk or pressure element is missing entirely - the player currently just wanders with no stakes. A health resource, timer, or similar constraint should be added.
- Movement needs to feel more natural and engaging; a jump mechanic was strongly recommended, along with mole-specific abilities that are actually meaningful to gameplay (the mole currently moves like a generic platformer character).

**Exploration**
- Consider adding limited visibility to introduce an element of the unknown. A lantern mechanic could serve this purpose and also makes thematic sense given the mole's underground context. The unseen creates curiosity and forward momentum.

## Risks

- **Scope creep** is the primary risk. Combat weapons, lanterns, room building, a backpack for inventory expansion, and conveyor systems were already proposed.
- The **inventory system is acknowledged as buggy** and needs a rework before the end of the week.
- The game currently **lacks a core tension loop** - there is no risk, no return cycle, and no element of the unknown, which undermines player engagement even in early testing.
- Without a clear game cycle, **mechanics are at risk of accumulating** (4 resource types, free crafting, non-stacking tools) without serving a coherent experience.

## Action Points

- WazzuRunaway: Overhaul inventory - fix bugs, simplify layout, add fixed tool slots
- Team: Implement save system
- Team: Add burrow depth display ("You are at −100 m")
- Team: Implement drill mechanics (upgrade system + layer transition)
- Team: Investigate limited-visibility / flashlight exploration mechanic
- Team: Add mole-specific movement (jump + at least one unique ability)
- Team: Add a risk mechanic (health, oxygen, or timer)

## Resulting Product Backlog / Scope Changes

The following items were added or elevated in priority as a result of this review:

- **Risk/pressure mechanic** - health, fuel consumption, or a countdown of some kind to create stakes.
- **Limited visibility + flashlight** - to add exploration and a sense of the unknown.
- **Mole movement upgrade** - jump and at least one mole-specific traversal ability.
- **Inventory overhaul** - fixed tool slots, no drag-and-drop, cleaned-up UI.
