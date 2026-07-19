# Customer Handover

This document describes the **current actual handover state** of Operation: EarthCore - what has been transferred, what the customer needs to know to access and run the product independently, and what support still remains necessary.

## Current Product Status and Handover Scope

Operation: EarthCore is a 2D mining/exploration game where the player controls a mole digging toward Earth's Core. The product is a **standalone offline build** (Windows and Linux) with no backend, database, or network dependency - see [`docs/architecture/README.md`](architecture/README.md#deployment-view) for the full deployment model.

As of `MVP v3`, the gameplay loop includes: digging, resource collection, crafting, drill refueling/upgrades, stamina-gated climbing, automated mining stations, transitions between underground layers, a death mechanic triggered by stamina depletion, a coin/beer economy for permanent stamina upgrades, an introductory cutscene and tutorial, an ending cutscene when the drill completes the stone layer, and a manual save system that persists progress locally.

**Transferred to the customer:**

- **GitHub repository** - the customer has been added as a contributor with write access
- **Unity Version Control** - project access transferred to the customer
- **itch.io** - the game is published and publicly accessible at [https://wazzurunaway.itch.io/operation-earthcore]
- **Hosted documentation site** - publicly accessible at [https://coolcamilla.github.io/Team32/](https://coolcamilla.github.io/Team32/)
- **Windows and Linux builds** - available via [GitHub Releases](https://github.com/coolcamilla/Team32/releases) and the itch.io page

**Not applicable:** no external hosting accounts, databases, API keys, or third-party service credentials exist for this product - there is nothing in that category to transfer.

## How the Customer Accesses and Uses the Product

**Option 1 - itch.io (recommended):**
Visit the [itch.io page](https://wazzurunaway.itch.io/operation-earthcore) and download the build for your platform.

**Option 2 - GitHub Releases:**

1. Go to the [GitHub Releases page](https://github.com/coolcamilla/Team32/releases).
2. Download the latest release ZIP for your platform (Windows or Linux).

**After downloading (both options):**

1. Extract the ZIP for your platform.
2. Run `TheMoleProject2D.exe` (Windows) or `LinuxBuild.x86_64` (Linux, after `chmod +x`).
3. No account, login, or internet connection is required to play.

Full step-by-step instructions are maintained in the root [`README.md`](../README.md#local-setup-instructions).

## Installation or Deployment Instructions

Not applicable in the traditional sense - there is no server-side deployment. "Deployment" for this product means distributing the platform-specific ZIP via itch.io or GitHub Releases as described above. There is currently no installer or auto-updater.

## Configuration and Secrets

This product has **no runtime secrets, credentials, or environment variables** the customer needs to manage. It is a fully offline standalone build with no external service integration. See [`docs/development-process.md`](development-process.md#configuration-management) for the full configuration-management approach used during development.

## Operational Notes for Normal Use

- **Digging** has a per-tool cooldown - different tools dig at different speeds, based on the equipped item's own cooldown value. Digging is disabled entirely while climbing.
- **Climbing** is triggered with the dedicated `C` key. Climbing is gated by stamina - the mole can only climb for as long as stamina allows.
- **Inventory stack size** is capped at 99.
- **Crafting** is opened from the crafting menu; a tool can only be crafted once per play session - once crafted, that same tool type cannot be crafted again until the game is restarted (or loaded from a save, which restores the crafted-tools list).
- **Drill refueling and upgrades** are accessed via the `F` key near the drill sign, opening a panel with separate upgrade tracks (Engine, Drill, Fuel Tank), each costing specific materials.
- **Save system** - the game saves automatically on quit and can be resumed via the "Continue" button on the main menu. Save data is stored locally as a JSON file at `Application.persistentDataPath` (the OS-specific user data directory). Saved state includes: coins, max stamina and regen multiplier, full inventory contents, crafted-tool history, and drill progress (component tiers and depth). Save files are local-only - they do not transfer between devices or platforms.
- **Death mechanic:** when stamina is fully depleted, the mole gets exhausted, falls, and has to wait for several seconds before respawning at the drill with all resources cleared from the inventory. Coins and equipped/crafted tools are preserved through death.
- **Layer transitions:** once the drill reaches 3.5 meters depth (requiring all three drill components - Engine, Drill, Fuel Tank - to be upgraded at least once from their "Basic" tier), it enters the stone layer. It then drops stones and other stone-layer resources (coal, flint, copper), which can be used to craft a stone pickaxe to mine through the physical stone layer manually.
- **Mining stations:** provide passive/automated resource collection once placed. They can be built by standing near a resource deposit and pressing `F` to open the building menu.
- **Coins and the beer stand:** mining any block has a chance to drop a coin. A beer stand near the drill at the surface allows the player to spend 5 coins on a beer, which permanently increases the mole's maximum stamina.
- **Cutscenes and tutorial:** a new game starts with an introductory cutscene presenting the mole's backstory, followed by a navigable tutorial explaining core mechanics. An ending cutscene plays when the drill completes the stone layer.

## Troubleshooting and Support

- If the game does not launch on Linux, confirm the binary has execute permissions: `chmod +x LinuxBuild.x86_64`.
- If saved progress does not load, verify the save file exists at the OS-specific `Application.persistentDataPath` location. The file is a plain JSON file and can be inspected or deleted manually if it becomes corrupted.
- For any gameplay issue, bug, or unexpected behavior, the customer should open a GitHub issue on the repository, so it is tracked and visible.
- Known bugs and their status are tracked via GitHub Issues.

## Known Limitations and Risks

- **Save files are local-only** - progress does not sync between devices or platforms. The save file is a plain JSON file that can be freely viewed or edited by the user; the customer accepted this tradeoff.
- **No auto-update mechanism** - the customer must manually check the itch.io page or GitHub Releases page for new versions.
- **Content variety is limited** - the customer identified block/resource diversity as the biggest gap affecting long-term engagement. All blocks within a layer currently look similar, reducing exploration interest. This is acknowledged as a post-course improvement area, not a handover blocker.
- **UI polish items remain** - button padding/sizing, font consistency, resource-pickup indicators, and drill-progress feedback were flagged during the final Sprint Review. These are cosmetic/UX improvements, not functional blockers.
- **The customer does not intend to develop independently** - stated directly during the transition meeting. Post-course product evolution depends on the team's continued voluntary involvement, not on customer-side engineering capacity.

## Current Handover Status

**Handover level reached: `Ready for independent use`.**

The customer can download, install, and play the current `MVP v3` build via itch.io, GitHub Releases, or by cloning and building from the repository source - all without team assistance. The game is fully playable offline with no team-operated infrastructure.

This has not progressed to *"Independently used by customer"* because the customer has not begun regular self-directed play - they stated the project's primary value is as a team learning/portfolio experience rather than something they intend to actively operate themselves. It has not progressed to *"Deployed or operated on customer side"* because the itch.io page is team-managed, not customer-managed, and no customer-side hosting or infrastructure exists.

**Why stronger levels were not reached:**

- The blocker is on the **customer side** - the customer has chosen not to independently use or operate the product, not because a technical barrier prevents it.
- Evidence of readiness was still obtained: the customer played the build during the Week 7 Sprint Review, confirmed the itch.io + GitHub + Unity Version Control handover scope as sufficient, and explicitly accepted the documentation set.
- No remaining team-side actions would change this outcome - the product is ready; independent use depends on the customer's own decision to engage.

**Customer-confirmation status: `Accepted with follow-up items`.**

The customer was explicitly asked whether they accept the current `docs/customer-handover.md` and the reached handover scope. The customer confirmed acceptance, with the following follow-up items acknowledged as desirable improvements rather than acceptance blockers:

- Increased block/resource content variety to make exploration more engaging
- Continued UI and animation polish (button sizing, digging animation, resource indicators)
- Potential re-release on additional platforms if the team continues post-course

These follow-up items are on the **team side** (continued voluntary development) and **do not block** the current accepted handover level.

## Remaining Actions

- (Optional, post-course) Increase block/resource content variety per customer feedback
- (Optional, post-course) Continue UI/animation polish per Sprint 5 feedback
- (Optional, post-course) Explore additional platform releases if the team continues development

None of the above block the current handover level or customer-confirmation status.

## Documentation Sufficiency

The current maintained documentation set is **sufficient for the reached handover level**. The customer reviewed `README.md`, `docs/customer-handover.md`, and `CONTRIBUTING.md` during the Week 6 meeting and stated the structure was clear and trustworthy. No documentation gaps were identified as blockers during either the Week 6 or Week 7 meetings.

## Related Documentation

- [`README.md`](../README.md) - setup, run instructions, project entry point
- [`docs/architecture/README.md`](architecture/README.md) - how the product is structured
- [`docs/testing.md`](testing.md) - current test coverage and known gaps
- [`docs/roadmap.md`](roadmap.md) - Sprint-by-Sprint delivery plan and final course state
- [`CONTRIBUTING.md`](../CONTRIBUTING.md) - contributor guidance for anyone working in the repository
- [`AGENTS.md`](../AGENTS.md) - coding agent guidance
