# Definition of Done

This Definition of Done applies to all User Stories and Product Backlog Items (PBIs).
A User Story or PBI may be marked **Done** only when both its issue-specific acceptance criteria and every applicable criterion below are satisfied.

---

## Work Status Reference

Work Status values used across all issues:

| Status | Meaning |
|---|---|
| `To Do` | In the Product Backlog, not yet ready to start |
| `Ready` | Selected for the current Sprint, assigned, estimated, has acceptance criteria, can be started |
| `In Progress` | Work has started |
| `Review` | Implementation is ready for review; linked PR is open |
| `Done` | All acceptance criteria and this DoD are satisfied (see sections below) |

---

## User Stories

A user story is `Done` when:

- [ ] All acceptance criteria listed in the story issue are satisfied.
- [ ] All linked supporting PBIs required to satisfy the story's acceptance criteria are individually `Done` (reviewed, merged, verified).
- [ ] The supporting PBIs together provide the required implementation, review, and verification evidence.
- [ ] The implemented behavior has been manually verified in Unity (Editor Play Mode or a build) and matches the acceptance criteria.
- [ ] No regressions are introduced to previously working functionality.
- [ ] The story issue is closed with links to the relevant supporting PBIs.

---

## Supporting and Implementation PBIs (All Types)

A PBI is `Done` when:

- [ ] All acceptance criteria listed in the issue are satisfied and checked off in the linked PR.
- [ ] The change is submitted via a PR from a branch named `<issue-number>-short-description`.
- [ ] The PR is reviewed and approved by at least one other team member (not the author).
- [ ] All configured CI checks pass on the PR (including Lychee link checking where applicable).
- [ ] Any new or changed Markdown links pass Lychee link checking.
- [ ] Testing performed is documented in the PR description (automated and/or manual, as applicable).
- [ ] The PR is merged into the protected default branch using a merge commit (no squash or rebase).
- [ ] If the change is user-visible, `CHANGELOG.md` has been updated with an issue-linked entry under `[Unreleased]`.
- [ ] No sensitive data, credentials, or PII are included in the change.
- [ ] No large binaries are committed to Git history.
- [ ] The issue is closed and linked to the merged PR.

---

## Evidence Preservation

All of the following must be visible in the normal repository workflow artifacts and must not be deleted:

- The issue with its acceptance criteria.
- The PR/MR with its description, review comments, and approval.
- CI check results on the PR/MR.
- The merge commit on the default branch.

---
