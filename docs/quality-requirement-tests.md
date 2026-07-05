# Quality Requirement Tests

This document lists all automated Quality Requirement Tests (QRTs) for Operation: EarthCore.
Each QRT is linked to a Quality Requirement (QR) defined in [`docs/quality-requirements.md`](quality-requirements.md).

---

## QRT-001

| Field | Value |
| --- | --- |
| **ID** | QRT-001 |
| **Linked QR** | QR-001 (Time behaviour) |
| **Verification method** | PlayMode test that polls `GridGenerator.transform.childCount` with a 3-second timeout |
| **Test data / setup** | Real Level scene loaded via `SceneManager.LoadScene("Level")` |
| **Automated command** | Unity Test Runner -> PlayMode -> `QRT_001_GridGenerator_SpawnsBlocksWithin3Seconds` |
| **Expected result** | `GridGenerator` has at least one child block within 3 seconds of scene load |
| **Evidence location** | [`Assets/Tests/PlayMode/Qualityrequirementtests.cs`](../source/Assets/Tests/PlayMode/Qualityrequirementtests.cs) |

---

## QRT-002

| Field | Value |
| --- | --- |
| **ID** | QRT-002 |
| **Linked QR** | QR-002 (Fault tolerance) |
| **Verification method** | PlayMode test using `LogAssert.Expect` to verify error is logged without an exception |
| **Test data / setup** | `BlockBehaviour` added to a `GameObject` with no `BlockTypeData` assigned |
| **Automated command** | Unity Test Runner -> PlayMode -> `QRT_002_BlockBehaviour_NullBlockTypeData_LogsErrorWithoutCrash` |
| **Expected result** | Unity logs an error containing "doesnt have BlockTypeData"; no exception is thrown |
| **Evidence location** | [`Assets/Tests/PlayMode/Qualityrequirementtests.cs`](../source/Assets/Tests/PlayMode/Qualityrequirementtests.cs) |

---

## QRT-003

| Field | Value |
| --- | --- |
| **ID** | QRT-003 |
| **Linked QR** | QR-003 (Operability) |
| **Verification method** | PlayMode test asserting `Time.timeScale == 1` after scene load. `InGameMenuManager` exposes no public pause-state accessor, so only the global `Time.timeScale` field is verified, not an internal "IsPaused" flag. |
| **Test data / setup** | Real Level scene loaded via `SceneManager.LoadScene("Level")` |
| **Automated command** | Unity Test Runner -> PlayMode -> `QRT_003_InGameMenuManager_SceneLoad_StartsUnpaused` |
| **Expected result** | `Time.timeScale` is `1.0` |
| **Evidence location** | [`Assets/Tests/PlayMode/Qualityrequirementtests.cs`](../source/Assets/Tests/PlayMode/Qualityrequirementtests.cs) |
