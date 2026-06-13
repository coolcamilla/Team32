## User roles
**Player** - the primary user of the game, who controls the mole, digs through layers of the Earth, collects resources, crafts and upgrades tools, and progresses toward the Earth's core.  
**Streamer** - the player, who broadcasts gameplay or publishes playthrough video on streaming platforms (e.g. YouTube, Twitch). Has additional needs related to the content publishing.

## US-01: Saving
**Requirement status:** Active  
**MoSCoW priority:** Should Have  
As a player,  
I want to (auto)save my progress,  
so that I won't lose it when exiting.
### Notes and constraints
- auto-save should trigger on key events (layer transition, tool craft, etc.)
- save data must persist between game sessions
- visual confirmation while saving (e.g. small gear wheel icon)
- is manual save also available? are several save slots needed?

## US-02: Digging
**Requirement status:** Active  
**MoSCoW priority:** Must Have  
As a player,  
I want to dig through different layers (e.g. dirt, rock),  
so that I can reach the Earth's core and complete the game.
### Notes and constraints
- core game mechanic
- number of layers is TBD (for MVP v0 is 2)
- each layer requires different tools to dig through (e.g. shovel for dirt, pickaxe for rock)
- reaching the Earth's core is the win condition
- the mole digs tile-by-tile

## US-03: Leaderboard
**Requirement status:** Active  
**MoSCoW priority:** Could Have  
As a player,  
I want a leaderboard,  
so that I can compare my progress with other players.
### Notes and constraints
- requires backend to store user's scores
- metrics: burrow depth, total resources collected, time to reach Earth's core (other metrics?)
- depends on US-02 and US-10

## US-04: Streamer mode
**Requirement status:** Active  
**MoSCoW priority:** Won't Have  
As a streamer,  
I want to turn on streamer mode,  
so that YouTube doesn't block my playthrough video.
### Notes and constraints
This story is excluded because we prioritize core gameplay mechanics. Streamers is too narrow of a group of players. This feature will be added post-launch if the game gains popularity.

## US-05: Keys remapping
**Requirement status:** Active  
**MoSCoW priority:** Could Have  
As a player,  
I want to remap keys,  
so that I can change the layout to what I am comfortable with.
### Notes and constraints
- remapped keys must persist between game sessions
- must include "reset to default" option
- which actions are remappable (movement, dig, etc.)?
- will the joystick buttons be added?

## US-06: Burrow depth
**Requirement status:** Active  
**MoSCoW priority:** Should Have  
As a player,  
I want to see my progress toward the core (burrow depth),  
so that I understand how far I've gone and what remains.
### Notes and constraints
- must display current depth (in meters?)
- must display distance to the next layer or/and core
- related to US-02

## US-07: Custom character
**Requirement status:** Active  
**MoSCoW priority:** Could Have  
As a player,  
I want to customize my character,  
so that my mole feels personal and I stay engaged longer.
### Notes and constraints
- cosmetics only, doesn't affect gameplay
- customization must persist between game sessions
- is customization available from the beginning?
- how is customization limited (e.g. 3–5 mole skins or colour variants)?

## US-08: Tools upgrading
**Requirement status:** Active  
**MoSCoW priority:** Should Have  
As a player,  
I want to upgrade my tools,  
so that I can dig through the blocks faster.
### Notes and constraints
- upgrading uses resources collected via US-10
- depends on US-09 (tools creation) and US-10 (resource collection)
- each upgrade level must have a cost (e.g. 10 sticks) and an effect (e.g. dig speed +5%)
- separate upgrade trees for each tool or single general upgrade tree?

## US-09: Tools crafting
**Requirement status:** Active  
**MoSCoW priority:** Must Have  
As a player,  
I want to craft different tools (e.g. shovel, pickaxe),  
so that I can dig more types of dirt and rock.
### Notes and constraints
- depends on US-10
- number of tools is TBD, (for MVP v0 is 2: shovel, pickaxe)
- crafting UI must show required resources and whether the player currently has enough
- are tools available simultaneously?

## US-10: Inventory
**Requirement status:** Active  
**MoSCoW priority:** Must Have  
As a player,  
I want to collect resources that drop from blocks,  
so that I can use them later for crafting.
### Notes and constraints
- depends on US-02 (resources drop from blocks)
- number of slots is 5
- must display resource name, icon and current quantity
- will there be a warehouse?

## Initial proposed MVP v1 scope 
[US-02](#us-02-digging), [US-09](#us-09-tools-crafting), [US-10](#us-10-inventory)
