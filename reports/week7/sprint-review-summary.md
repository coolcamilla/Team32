# Sprint Review Summary - Week 7 (Sprint 5)

**Date: 17.07.2026**

**Participants:**

- `coolcamilla` - Interviewer
- `WazzuRunaway` - Moderator
- `Pro100Vorona` - Note Taker
- `SunrisEe41` - Interviewer
- `Lilia-Shagidullina` - Note Taker
- Customer

**Recording and transcript status:** Recording was permitted (consent obtained before recording started, off-recording). Public transcript publication was permitted. See [`sprint-review-transcript.md`](sprint-review-transcript.md) for the full sanitized transcript.

This single meeting combined the Sprint Review, customer-executed UAT, and the customer trial/transition-status discussion, per `Artifact_Requirements.md`'s allowance for one recording/transcript/summary to cover all three when they occur in the same session.

## Artifacts Demonstrated

- The Sprint 5 Backlog board
- The introductory cutscene and tutorial
- The redesigned drill-upgrade UI (implemented from the previously reviewed [mockup](../../game_design/ui/drill-ui-mockup.jpg))
- The current build, covering: sectioned stamina bar with slow passive regeneration, redrawn buttons, updated recipes, transparent boundary walls, centered world objects, keyboard+mouse digging, low-stamina warning

## Scope / Goal Reviewed

Sprint 5's goal was to polish the product toward `MVP v3`: cutscenes and tutorial, stamina system redesign, UI redraw, recipe updates, world-edge visual changes, control simplification (removing mouse-only digging), and a low-stamina warning. Not yet complete at meeting time: save system, hover-to-open crafting recipes, remaining recipe integration, construction menu redraw, and itch.io deployment.

## Feedback

- Digging animation double-triggers per input and plays in the wrong direction
- Mole gets stuck on ground tiles
- No pickup confirmation, resource-count, or crafting/upgrade affordability indicators anywhere in the UI
- Tutorial arrows not visually indicated as clickable; tutorial introduces too much at once
- Drill UI direction approved, but padding, button sizing, and font execution need work
- Drill has no visual mining-progress feedback (depth, distance to next layer)
- Coin-bearing blocks are visually indistinguishable from regular blocks
- Requested world looping/circular map - assessed live as unclear/difficult to implement in remaining time, not committed

## Approvals / Requested-Change Decisions

- Keyboard+mouse digging: approved, no further complaints
- itch.io + GitHub repository + Unity Version Control handover confirmed sufficient for transition, when asked directly
- Customer explicit instruction: prioritize remaining fixes by importance; do not start new work

## Risks

- Save system, itch.io deployment, and several UI/feedback gaps remain outstanding with limited Sprint time left
- The mole-stuck-on-ground movement bug is a known, unresolved issue. If it isn't resolved before final submission, a visible movement bug ships in MVP v3

## Action Points

1. Fix digging animation double-trigger and playback direction
2. Fix mole getting stuck on the ground
3. Add pickup confirmation, resource-count, and affordability indicators
4. Clarify tutorial clickable-elements
5. Polish drill UI padding, button sizing, and fonts
6. Add drill mining-progress feedback
7. Integrate remaining crafting recipes
8. Switch crafting recipe details to hover-to-open
9. Redraw construction menu panel
10. Visually distinguish coin-bearing blocks
11. Reposition pickaxe icon and show item counts
12. Ship the local `.txt` save system
13. Deploy the build to itch.io

## Resulting Backlog / Scope Changes

No PBIs, only small polish fixes, addressed in [Action Points](#action-points)

## Links

- [Sprint 5 Milestone](https://github.com/coolcamilla/Team32/milestone/5)
- [Product Backlog board](https://github.com/users/coolcamilla/projects/2)
- [`docs/customer-handover.md`](../../docs/customer-handover.md)
