# Summary of Changes

**Scenes / areas affected:**

**What changed:**

**Why it changed:**

**Related issues:** Closes #

---

**Skip all the following sections if the changes are only assignment-related (reports, transcripts, etc.)**

## Testing Performed

**Test types:**

- [ ] Tested in Unity Editor (Play Mode)
- [ ] Tested in a built player
- [ ] No testing required (explain below)

**Manual testing steps:**
1. 
2. 
3. 

---

## Reviewer Checklist

**Code quality**

- [ ] Code follows project conventions (naming, namespaces, access modifiers)
- [ ] No unnecessary `public` fields - serialized fields use `[SerializeField]`
- [ ] No magic numbers or hardcoded strings - constants or ScriptableObjects used where appropriate
- [ ] Code is readable, no unnecessary complexity or duplication

**Unity-specific**

- [ ] No expensive calls in `Update()` that could be event-driven
- [ ] Coroutines and async operations are properly cancelled / cleaned up
- [ ] No missing script references or broken prefab connections
- [ ] Physics interactions use `FixedUpdate()` where appropriate

**Assets & scenes**

- [ ] No unintended scene changes checked in
- [ ] Prefab overrides are intentional and clean
- [ ] New assets are in the correct folders and follow naming conventions
- [ ] No large uncompressed textures / audio files committed unnecessarily

**Correctness**

- [ ] Logic handles edge cases (null refs, empty collections, scene transitions)
- [ ] No obvious regressions in related gameplay systems
- [ ] Error handling / null checks are appropriate

---

## Notes for Reviewers

**Optional: specific areas to focus on, known issues, or anything left for a follow-up. Submit the notes here:**
