# Team32 - Operation: EarthCore

Operation: EarthCore is a 2D mining and exploration game where you dig a mole toward the center of the Earth, gathering resources, crafting tools, and upgrading your drill along the way.  

This repo includes Operation: EarthCore game source code, documentation, reports, interface artifacts, and setup instructions  

You can visit our [itch.io page](https://wazzurunaway.itch.io/operation-earthcore)

## About

Operation: EarthCore is a 2D exploration and resource-management game. The player digs downward from the surface, collecting resources along the way, crafting progressively better tools, and refueling/upgrading a drill that enables deeper exploration. Reaching 3 meters of depth opens the stone layer, requiring a crafted pickaxe to continue digging and unlocking new resources like coal, flint, and copper. The core loop is built around risk and reward: stamina limits how long the mole can climb and explore, and running out entirely causes a fall, a respawn delay, and loss of the current inventory. Mining stations, built on resource deposits, provide passive resource collection, and coins earned from digging can be spent at a surface-level beer stand to permanently boost maximum stamina.

## Current Status

[MVP v3](https://github.com/coolcamilla/Team32/releases/tag/v1.0.0) includes:

- Digging, resource collection, and inventory management
- Crafting progressively better tools (one craft per tool type per session)
- Drill refueling and upgrades (Engine, Drill, Fuel Tank tracks)
- Stamina-gated climbing
- Underground layer transitions - reaching 3.5m depth enters the stone layer, requiring a crafted pickaxe to mine further, with new resources (coal, flint, copper)
- Automated mining stations, built near resource deposits
- A death mechanic - exhausted stamina causes a fall, a respawn delay at the drill, and loss of current inventory
- Coins (dropped from mining) spendable at a surface beer stand to permanently increase max stamina
- Auto-saving system via local `.json` file

## Download

Get the latest build from the [v1.0.0 release](https://github.com/coolcamilla/Team32/releases/tag/v1.0.0). See [**Local Setup Instructions**](#local-setup-instructions) below for platform-specific run steps.  
You can also check out the [game on itch.io](https://wazzurunaway.itch.io/operation-earthcore)

## How to Play

- **Move:** `WASD`
- **Dig:** left mouse button, aimed at block
- **Climb:** press `C` to toggle the climbing mode (requires stamina to move)
- **Open inventory:** `E`
- **Pause:** `Esc`
- **Craft:** press `F` near a work bench to open the crafting menu and select a tool, press `Craft` to craft the tool
- **Refuel / upgrade the drill:** press `F` near the drill
- **Build a mining station:** stand near a resource deposit and press `F` to open the building menu

For full mechanics, see [`docs/customer-handover.md`](docs/customer-handover.md).

## Local Setup Instructions

 1. Open the [`releases`](releases) folder on GitHub
 2. Download the desired build corresponding to your OS

For Windows
 1. Unzip the archive with any file-archiver program (e.g. 7-Zip, WinRAR)
 2. Open a folder with unzipped files
 3. Run `TheMoleProject2D.exe` to start the game

For Linux
 1. Extract files `unzip MVP_v0.4.0.zip` (instead of `MVP_v0.4.0` write filename of the build archive you want)
 2. Make executable: `chmod +x LinuxBuild.x86_64`
 3. Run `./LinuxBuild.x86_64` to start the game

_Note_: Folders and runnable files names may differ

## [Development Process & Configuration Management](docs/development-process.md)

## [Documentation site](https://coolcamilla.github.io/Team32/)

## [Contributing Guide](CONTRIBUTING.md)

## [AGENTS.md](AGENTS.md)

## [Roadmap](docs/roadmap.md)

## [Architecture Overview](docs/architecture/README.md)

## [Testing Status](docs/testing.md)

## [Customer Handover Documentation](docs/customer-handover.md)

## License

This project is licensed under the [MIT License](LICENSE)
