## What went well

1. **Sprint Planning was held on Monday**, allowing the team to start work earlier. Starting the Sprint with a clear plan at the beginning of the week gave developers more time to implement and reduced last-minute pressure.
2. **PBIs were reasonably estimated and evenly distributed across team members.** The workload was more balanced than in previous Sprints, which prevented dependency on a few individuals and kept the team moving at a consistent pace.
3. **MVP v2 was completed by Friday, leaving sufficient time for documentation and testing.** Finishing implementation early allowed the team to write quality architecture documentation, tests, and UAT scenarios without rushing.

## What did not go well

1. **Developers occasionally deviated from the agreed mechanic descriptions without informing the team.** Some implementation decisions were made unilaterally, which caused misalignment between what was built and what other team members expected, requiring additional clarification and rework.
2. **Merge conflicts caused significant delays.** A single error in the main branch required corrections across six branches, which slowed down the review and merge process considerably.
3. **One team member was largely absent from the development process.** Limited availability and infrequent communication made it difficult to rely on that member's contributions and created additional workload for the rest of the team.

## What changed compared to Sprint 2

1. **Planning Poker was conducted collaboratively.** The team estimated all PBIs together during Sprint Planning, which improved consistency and helped identify complex or ambiguous tasks before work began.
2. **A shared task table was introduced as the authoritative reference for developers.** The table included detailed mechanic descriptions, Work Status tracking, and a space to adjust task complexity. Developers used it throughout the Sprint to stay aligned on expected behaviour without needing to ask the team lead for clarification.

## Action points

1. **Require developers to flag any deviation from the agreed mechanic description before implementing it.** If a developer identifies a reason to change the specified behaviour, they must first discuss it in the team chat and get confirmation before proceeding.
2. **Establish a shared branching discipline to prevent cascading merge conflicts.** The team will agree on a merging order and verify the main branch is stable before opening new branches from it, reducing the risk of one error propagating across multiple branches.
