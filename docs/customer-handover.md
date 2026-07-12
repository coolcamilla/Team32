# Customer Handover

This document describes the **current actual handover state** of Operation: EarthCore - what has been transferred, what the customer needs to know to use and operate the product independently, and what remains before transition is complete. It is not a description of a future or planned state.

## Current Product Status and Handover Scope

Operation: EarthCore is a 2D mining/exploration game where the player controls a mole digging toward Earth's Core. The product is a **standalone offline build** (Windows and Linux) with no backend, database, or network dependency - see [`docs/architecture/README.md`](architecture/README.md#deployment-view) for the full deployment model.

As of this increment, the gameplay loop includes: digging, resource collection, crafting, drill refueling/upgrades, stamina-gated climbing, **automated mining stations** (passive resource collection at fixed points), **transitions between underground layers**, and a **death mechanic** triggered when stamina is fully depleted.

**Transferred to the customer:** the public GitHub repository (read access at minimum), the maintained documentation set under `docs/`, and the hosted documentation site.
**Retained by the team through the end of the course:** repository write access and release/deployment execution, since grading requires the team's own CI and release history to remain intact and unmodified until the assignment is graded.
**Not yet applicable:** no external hosting account, database, or third-party service exists for this product - there is nothing to transfer in that category.

## How the Customer Accesses and Uses the Product

1. Download the latest release build from the [GitHub Releases page](https://github.com/coolcamilla/Team32/releases) or the repository's `releases/` folder.
2. Extract the ZIP for your platform (Windows or Linux).
3. Run `TheMoleProject2D.exe` (Windows) or `LinuxBuild.x86_64` (Linux, after `chmod +x`).
4. No account, login, or internet connection is required to play.

Full step-by-step instructions are maintained in the root [`README.md`](../README.md#local-setup-instructions) - this document intentionally does not duplicate them; if setup steps change, update `README.md` and this document will remain accurate by reference.

## Installation or Deployment Instructions

Not applicable in the traditional sense - there is no server-side deployment. "Deployment" for this product means distributing the platform-specific ZIP, which is handled entirely through GitHub Releases as described above. There is currently no installer, auto-updater, or app-store-style distribution channel.

## Configuration and Secrets

This product has **no runtime secrets, credentials, or environment variables** the customer needs to manage. It is a fully offline standalone build with no external service integration. See [`docs/development-process.md`](development-process.md#configuration-management) for the full configuration-management approach used during development (which is not customer-relevant, but is linked here for completeness).

## Operational Notes for Normal Use

- **Digging** has a per-tool cooldown - different tools dig at different speeds, based on the equipped item's own cooldown value. Digging is disabled entirely while climbing.
- **Climbing** is triggered with the dedicated C key. Climbing is gated by stamina - the mole can only climb for the time the stamina allows them to
- **Inventory stack size** was increased earlier in development based on customer feedback that the original limit felt too restrictive. The exact current cap is 99
- **Crafting** is opened from the crafting menu; a tool can only be crafted once per play session - once crafted, that same tool type cannot be crafted again until the game is restarted.
- **Drill refueling and upgrades** are accessed via the F key near the drill sign, opening a panel with separate upgrade tracks (Engine, Drill, Fuel Tank), each costing specific materials.
- **No save system exists.** Progress (including layer position, resources, and crafted tools) does not persist between play sessions - closing the game or dying resets progress to the start of the session. This is a known limitation, not a bug; see below.
- **Death mechanic:** when stamina is fully depleted, the mole gets exhausted, so he falls and has to wait for several seconds before respawning at the drill with all his resources disappearing from the inventory. Because there is no save system, death currently has a meaningful progress-loss consequence the customer should be aware of before extended play sessions.
- **Layer transitions:** once the drill reaches 3 meters, it starts to mine into the stone layer. There it drops stones, which can be used to craft a basic pickaxe to mine through the stone layer by oneself. The drill also starts to drop other stone layer resources, like coal, flint and copper.
- **Mining stations:** provide passive/automated resource collection once placed. They can be placed by going over to a deposit and pressing F to see a building menu with the recipe and the build button.
- **Coins and the beer stand:** mining any block now has a chance to drop a coin. A beer stand near the drill, at the surface, allows the player to spend 5 coins on a beer, which permanently increases the mole's maximum stamina.

## Troubleshooting and Support

- If the game does not launch on Linux, confirm the binary has execute permissions: `chmod +x LinuxBuild.x86_64`.
- For any gameplay issue, bug, or unexpected behavior, the customer should open a GitHub issue on the repository rather than contacting the team directly, so it's tracked and visible to the whole team.
- Known bugs and their status are tracked via GitHub Issues; there is no separate customer-facing bug tracker.

## Known Limitations and Risks

- **No save system** - the most significant current limitation. Any death or session close loses progress. This is a known, tracked gap (see the Product Backlog), not an oversight.
- **No auto-update mechanism** - the customer must manually check the Releases page for new versions; the game does not notify them.

## Current Handover Status

**Ready for independent use.**

The customer can download, install, and play the current build without team assistance. This has not yet progressed to *"Independently used by customer"* (regular self-directed play observed) or *"Deployed or operated on customer side"* (not applicable to this product's offline distribution model) - those levels depend on customer engagement and feedback still to be gathered during the Week 6 transition-readiness meeting.

## Remaining Actions

- [ ] Gather customer feedback on whether the lack of a save system is an acceptable limitation for this handover level, or a blocker.
- [ ] Update this document based on the outcome of the Week 6 transition-readiness meeting.

None of the above currently block **"Ready for independent use"** - they block progression to a stronger handover level.

## Related Documentation

- [`README.md`](../README.md) - setup, run instructions, project entry point
- [`docs/architecture/README.md`](architecture/README.md) - how the product is structured
- [`docs/testing.md`](testing.md) - current test coverage and known gaps
- [`docs/roadmap.md`](roadmap.md) - planned work beyond this increment
- [`CONTRIBUTING.md`](../CONTRIBUTING.md) - for any customer team member who might contribute code
