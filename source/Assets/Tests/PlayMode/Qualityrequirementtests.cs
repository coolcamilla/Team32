using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

/// <summary>
/// Automated Quality Requirement Tests (QRTs).
/// Scene loaded once per session to avoid NullReferenceException
/// in OnDisable/OnEnable caused by repeated scene reloads.
///
/// QRT-001 | QR-001 | Time behaviour
/// QRT-002 | QR-002 | Fault tolerance
/// QRT-003 | QR-003 | Operability
/// </summary>
public class QualityRequirementTests
{
    [UnitySetUp]
    public IEnumerator SetUp()
    {
        if (SceneManager.GetActiveScene().name != "Level")
        {
            SceneManager.LoadScene("Level", LoadSceneMode.Single);
            yield return null;
            yield return null;
        }
        else
        {
            yield return null;
        }
    }

    // ------------------------------------------------------------------
    // QRT-001 | QR-001 | Time behaviour
    // ------------------------------------------------------------------

    [UnityTest]
    public IEnumerator QRT_001_GridGenerator_SpawnsBlocksWithin3Seconds()
    {
        float elapsed = 0f;
        const float timeout = 3f;
        GridGenerator grid = null;

        while (elapsed < timeout)
        {
            yield return null;
            elapsed += Time.deltaTime;
            grid = GameObject.FindObjectOfType<GridGenerator>();
            if (grid != null && grid.transform.childCount > 0) break;
        }

        Assert.IsNotNull(grid, "QRT-001 FAIL: GridGenerator not found in scene.");
        Assert.Greater(grid.transform.childCount, 0,
            $"QRT-001 FAIL: No blocks spawned after {elapsed:F2}s, threshold is 3s.");
    }

    // ------------------------------------------------------------------
    // QRT-002 | QR-002 | Fault tolerance
    // ------------------------------------------------------------------

    [UnityTest]
    public IEnumerator QRT_002_BlockBehaviour_NullBlockTypeData_LogsErrorWithoutCrash()
    {
        var go = new GameObject("TestBlock_NoData");
        go.tag = "Block";
        go.AddComponent<SpriteRenderer>();

        LogAssert.Expect(LogType.Error,
            new System.Text.RegularExpressions.Regex("doesnt have BlockTypeData"));

        go.AddComponent<BlockBehaviour>();
        yield return null;

        Assert.IsTrue(true, "QRT-002 PASS: BlockBehaviour handled null data without crashing.");
        Object.Destroy(go);
    }

    // ------------------------------------------------------------------
    // QRT-003 | QR-003 | Operability
    // ------------------------------------------------------------------

    [UnityTest]
    public IEnumerator QRT_003_InGameMenuManager_SceneLoad_StartsUnpaused()
    {
        yield return null;
 
        InGameMenuManager menuManager = GameObject.FindObjectOfType<InGameMenuManager>();
        Assert.IsNotNull(menuManager,
            "QRT-003 FAIL: InGameMenuManager not found in scene.");
 
        Assert.AreEqual(1f, Time.timeScale,
            "QRT-003 FAIL: Time.timeScale should be 1 on scene load.");
    }

}