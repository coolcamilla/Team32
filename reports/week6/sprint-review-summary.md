# Sprint Review Summary - Week 6 (Sprint 4)

**Date:** 10.07.2026

**Participants:**

- `coolcamilla` - Interviewer
- `WazzuRunaway` - Moderator
- `SunrisEe41` - Interviewer
- `Lilia-Shagidullina` - Note Taker
- Customer

**Recording and transcript status:** Recording was permitted (consent obtained before recording started, off-recording - the request itself cannot appear in the recording by definition). Public transcript publication was permitted. See [`sprint-review-transcript.md`](sprint-review-transcript.md) for the full sanitized transcript.

This single meeting combined the Sprint Review, customer-executed UAT, and the Week 6 transition-readiness discussion, per `Artifact_Requirements.md`'s allowance for one recording/transcript/summary to cover all three when they occur in the same session.

---

## Artifacts Demonstrated

- The Sprint Backlog board
- `docs/customer-handover.md` (read live by the customer during the meeting)
- `CONTRIBUTING.md` (read live by the customer during the meeting)
- The current build, covering: mining stations, layer transition (stone layer at ~3m depth), the coin/beer stamina-upgrade mechanic, the death mechanic, new digging animations/particles, and hit sounds
- The drill-upgrade UI redesign mockup

## Scope / Goal Reviewed

Sprint 4's goal was to implement mechanics the team had planned earlier in the project: mining stations, layer-transition logic, and the coin/beer stamina-upgrade system, plus a death mechanic triggered by stamina depletion, and general "feel" improvements (digging animations, particles, hit sounds).

## Feedback

**Positive:**

- The customer confirmed the current mechanics already feel good ("already good," "it already has a feel to it")
- `docs/customer-handover.md` was specifically praised as clear, trustworthy, and well-structured
- Digging with the new animations/particles was well received

**Requested changes (see Action Points below for the resulting scope):**

- Remove mouse-click as the digging input; move it to a keyboard key instead
- Warn the player when stamina is running low
- Rebalance stamina so it can fully deplete more readily, tuned against the coin/beer economy
- Reconsider the beer's effect - discussion moved between "permanent max-stamina increase" (confirmed earlier in the meeting) and "temporary movement/climb speed boost" (suggested later) - **needs team clarification on final intended design**
- Redesign the drill-upgrade UI per the mockup already shown
- Add a clear player goal and an ending state when the player reaches the bottom (a completion screen or short backstory text)
- Add a simple save system - customer explicitly approved a minimal local-file approach ("if it can be done quickly, it's better to do it")
- Complete remaining background/world art (general backgrounds, walls)
- Loop the digging animation to match the action rather than playing once
- Reduce decal size and the mole's on-screen size while climbing
- Highlight/emphasize interactive prompts (e.g. the `F` button); consider icon-based UI over text
- Clay currently has no real use and accumulates without purpose - needs a use case or more drill upgrade tiers
- (Raised as an idea, not committed scope) a placeable/purchasable stamina recovery station

## Approvals / Requested-Change Decisions

- Customer explicitly descoped full key-remapping settings down to just the digging-key change
- No price scaling for repeated beer purchases - confirmed as the team's existing design, approved by the customer
- Simple local-file save system approved as sufficient, including accepting the risk that it could be user-edited/"hacked"
- Confirmed that itch.io + the GitHub repository + Unity Version Control access would satisfy the customer's definition of a completed handover, when asked directly

## Risks

- **The product is not yet ready for full/independent handover** - stated explicitly by the customer when asked directly.
- **Nothing has been deployed anywhere yet** - confirmed directly.
- **Scope risk for the final week:** the combined list of requested changes (UI overhaul, world looping, background art completion, stamina rebalance, ending state, save system, itch.io deployment, animation polish) is broad for one remaining Sprint. The customer's own guidance to avoid new/unnecessary work is the primary mitigation the team has committed to.
- The beer-effect design ambiguity (permanent stamina increase vs. temporary speed boost) needs resolving early in Sprint 5 to avoid rework.

## Action Points (Sprint 5 / Week 7)

1. Remove mouse-click digging input; assign it to a keyboard key.
2. Add a low-stamina warning indicator.
3. Rebalance stamina to fully deplete more readily.
4. Resolve and implement the final beer-effect design (stamina increase vs. speed boost).
5. Implement world looping and remove the boundary walls.
6. Implement the drill-upgrade UI redesign from the existing mockup.
7. Add an ending/goal state at the bottom of the map.
8. Implement a simple local-file save system.
9. Complete remaining background and wall art.
10. Loop the digging animation to match player action.
11. Reduce decal and climbing-mole visual size.
12. Deploy the build to itch.io; evaluate web-build feasibility.
13. Highlight interactive prompts (`F` button) and evaluate icon-based UI.
14. Investigate additional drill upgrade tiers and/or a use case for clay.

## Resulting Backlog / Scope Changes

- [Stamina Warning Indicator](https://github.com/coolcamilla/Team32/issues/236)
- [Improve Game Balance](https://github.com/coolcamilla/Team32/issues/237)
- [Start and End Cutscenes](https://github.com/coolcamilla/Team32/issues/238)
- [Publish Game](https://github.com/coolcamilla/Team32/issues/239)

## Links

- [Sprint 4 Milestone](https://github.com/coolcamilla/Team32/milestone/4)
- [Product Backlog board](https://github.com/users/coolcamilla/projects/2/views/1)
- [`docs/customer-handover.md`](../../docs/customer-handover.md)
- [Week 6 trial release](https://github.com/coolcamilla/Team32/releases/tag/v0.4.0)
