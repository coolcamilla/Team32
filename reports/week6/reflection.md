## Learning Points

- A trial release with a live customer session is significantly more effective at surfacing blockers than internal testing. The customer identified the missing win condition, the clay resource dead end, and the stamina bypass bug within minutes of free play
- Customer handover documentation that is read live during the meeting provides immediate, unambiguous feedback on whether it is actually usable.The customer's positive reaction to `docs/customer-handover.md` confirmed that maintaining it as a first-class artifact rather than a last-minute addition was the right approach
- Transition readiness cannot be assessed accurately without asking the customer directly. The explicit question "is the product ready for handover?" produced a clear "not yet" that the team would not have obtained otherwise
- Design decisions that affect multiple systems should be explicitly locked down in the PBI description before implementation begins. A concrete specification prevents late-stage disputes and eliminates the risk of rework in subsequent Sprints
- Deployment target should be agreed with the customer early in the project. Knowing the platform in advance (e.g. [itch.io](https://itch.io), web, desktop) allows the team to configure the build pipeline and test on the correct target from the start, rather than treating deployment as a last-minute handover step

## Validated assumptions

- We assumed that the death mechanic with equipment and coins preserved would feel fair - rejected during UAT session
- We assumed that block destruction particles and animations would noticeably improve game feel - confirmed during trial release
- We assumed that `docs/customer-handover.md` would be useful to the customer - confirmed during Transition Meeting
- We assumed that the beer vending machine's effect (permanent stamina increase) was clearly defined - rejected during UAT session
- We assumed that the drill UI mockup would be sufficient to communicate the redesign - confirmed during Sprint Review
- We assumed that the current scope for Sprint 5 was achievable - rejected during Sprint Review
- We assumed that minimal save system within a `.txt` file would be sufficient - confirmed during Sprint Review
- We assumed that full keys remapping system is needed - rejected during UAT customer-trial (just change dig key)

## Friction and gaps

- The beer-effect design is ambiguous and unresolved. The team must decide between permanent stamina increase and temporary speed boost before Sprint 5 work begins to avoid rework
- The product has no win condition or ending state. The customer flagged this explicitly; without it the game has no closure for the player
- Clay has no meaningful use beyond the mining station placement cost. It accumulates without purpose and the customer noticed this during free play
- Nothing has been deployed to [itch.io](https://itch.io) or any public platform. This is now a handover blocker for Sprint 5
- Interactive prompts (e.g. the F button) are not visually prominent enough. The customer suggested icon-based UI over text labels

## Planned response

- Resolve the beer-effect design decision at the start of Sprint 5 before any implementation begins
- Add a win condition and ending screen when the mole reaches the bottom of the final layer [#238]https://github.com/coolcamilla/Team32/issues/238
- Add a stamina warning indicator so the player can react before the mole dies [#236](https://github.com/coolcamilla/Team32/issues/236)
- Rebalance stamina depletion rate and the coin/beer economy [#237](https://github.com/coolcamilla/Team32/issues/237)
- Deploy the build to itch.io as part of the final handover [#239](https://github.com/coolcamilla/Team32/issues/239)
- Implement world looping and remove boundary walls [#204](https://github.com/coolcamilla/Team32/issues/204)
- Implement the drill-upgrade UI redesign from the approved mockup [#203](https://github.com/coolcamilla/Team32/issues/203)
- Implement a minimal local-file save system as approved by the customer [#65](https://github.com/coolcamilla/Team32/issues/65)
- Investigate additional drill upgrade tiers that consume clay [#237](https://github.com/coolcamilla/Team32/issues/237)
- Change dig key
