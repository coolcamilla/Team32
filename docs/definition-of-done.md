# Definition of Done

A User Story is one type of Product Backlog Item (PBI), not a separate category that merely "consists of" PBIs. Every User Story must therefore satisfy the same baseline Definition of Done as any other PBI (**Section 1**).  

Some User Stories are simple enough to be implemented directly against their own linked PR/MR, exactly like any other PBI — Section 1 alone applies to these. Other User Stories are too large or too cross-cutting to implement directly and are instead decomposed into separate linked supporting PBIs (implementation, design, testing, deployment, etc.). For these **complex User Stories**, the additional requirements in **Section 2** apply on top of Section 1.  

A PBI (including a User Story) may be marked `Done` only when its issue-specific acceptance criteria and every applicable criterion below are satisfied.  


## Work Status Reference

| Status | Meaning |
|---|---|
| `To Do` | In the Product Backlog, not yet ready to start |
| `Ready` | Selected for the current Sprint, assigned, estimated, has acceptance criteria, can be started |
| `In Progress` | Work has started |
| `Review` | Implementation is ready for review; the relevant linked PR(s)/MR(s) are open |
| `Done` | Satisfies Section 1, and Section 2 as well if the PBI is a complex User Story |


## Section 1 - Definition of Done for All PBIs

This section applies to every PBI: user stories, bugs, technical work, infrastructure, design, testing, deployment, and documentation/workflow PBIs alike.

- [ ] All acceptance criteria listed in the issue are satisfied.
- [ ] The implementation evidence - the issue's own linked PR/MR, or, for a complex User Story, its linked supporting PBIs (see Section 2) - is reviewed and approved by at least one team member other than the author.
- [ ] All configured CI checks pass on the relevant PR/MR(s), including Lychee link checking where applicable.
- [ ] Testing performed (automated and/or manual, as applicable) is documented in the relevant PR/MR description(s).
- [ ] Any relevant PR/MR is submitted from a branch named `<issue-number>-short-description` and is merged into the protected default branch using a merge commit (no squash or rebase).
- [ ] If the change is user-visible, `CHANGELOG.md` has been updated with an issue-linked entry under `[Unreleased]`; otherwise the PR/MR changelog checklist is marked "Not applicable."
- [ ] No sensitive data, credentials, or PII are included in the change, and no large binaries are committed to Git history.
- [ ] Verification evidence (issue, PR/MR description, review comments, approval, CI results, merge commit) is preserved in the normal workflow artifacts and is not deleted.
- [ ] The issue is closed and linked to its implementation evidence.

A non-complex User Story (one implemented directly, without separate supporting PBIs) is `Done` once it satisfies Section 1 in full. A complex User Story must also satisfy Section 2.  


## Section 2 — Additional Requirements for Complex User Stories

Apply this section only to User Stories that needed one or more separately linked supporting PBIs to satisfy their acceptance criteria. A User Story issue is never used as the container for implementation subtasks, and it does not require its own dedicated implementation PR/MR — its evidence comes from its supporting PBIs.

- [ ] Every linked supporting PBI required to satisfy the User Story's acceptance criteria is itself `Done` per Section 1 (reviewed, merged, and verified).
- [ ] Together, those supporting PBIs provide the implementation, review, and verification evidence required by the story's acceptance criteria.
- [ ] The implemented behavior has been manually verified end-to-end in Unity (Editor Play Mode or a build) and matches the story's acceptance criteria.
- [ ] No regressions are introduced to previously working functionality.
- [ ] The User Story issue is closed and linked to all of its supporting PBIs.  
  
## Evidence Preservation

The following must remain visible in the normal repository workflow artifacts and must not be deleted before the relevant assignment has been graded:

- The issue, with its acceptance criteria and (for complex User Stories) links to its supporting PBIs.
- Each relevant PR/MR, with its description, review comments, and approval.
- CI check results on each relevant PR/MR.
- The merge commit(s) on the default branch.
