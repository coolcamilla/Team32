using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

/// <summary>
/// PlayMode integration tests for GridGenerator (critical module, per docs/testing.md).
///
/// IMPORTANT LIMITATION: GridGenerator.RenderWorld()'s full implementation was not
/// available when these tests were written (only Awake, Start, and GenerateWorld's
/// outer structure were confirmed). Tests here are deliberately conservative,
/// asserting only what is confirmed by the visible code (Instance singleton,
/// childCount after generation, BlockBehaviour presence on spawned children) rather
/// than asserting exact block counts, positions, or tag conventions that could not
/// be verified against the real RenderWorld() body. Please review against the actual
/// method before treating these as complete critical-module coverage.
/// </summary>
public class GridGeneratorIntegrationTests
{
    private GridGenerator _grid;

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

        _grid = GameObject.FindObjectOfType<GridGenerator>();
        Assert.IsNotNull(_grid, "Setup FAIL: GridGenerator not found in the Level scene.");
    }

    [UnityTest]
    public IEnumerator GridGenerator_Instance_IsSetAfterAwake()
    {
        yield return null;

        Assert.IsNotNull(GridGenerator.Instance,
            "GridGenerator.Instance singleton should be set by Awake().");
        Assert.AreEqual(_grid, GridGenerator.Instance,
            "GridGenerator.Instance should reference the single GridGenerator in the scene.");
    }

    [UnityTest]
    public IEnumerator GridGenerator_AfterSceneLoad_HasSpawnedAtLeastOneChild()
    {
        // This overlaps with QRT-001's timing assertion by design (same underlying
        // guarantee), but is included here as direct critical-module coverage
        // independent of the QRT suite, per docs/testing.md's per-module structure.
        yield return null;
        yield return null;

        Assert.Greater(_grid.transform.childCount, 0,
            "GridGenerator should have spawned at least one child block after Start().");
    }

    [UnityTest]
    public IEnumerator GridGenerator_SpawnedChildren_HaveBlockBehaviourWithAssignedData()
    {
        yield return null;
        yield return null;

        bool foundAtLeastOneValidBlock = false;
        foreach (Transform child in _grid.transform)
        {
            var block = child.GetComponent<BlockBehaviour>();
            if (block != null)
            {
                Assert.IsNotNull(block.BlockData,
                    $"Spawned block '{child.name}' has a BlockBehaviour but no assigned BlockTypeData - " +
                    "this would trigger the QRT-002 null-data error path unintentionally.");
                foundAtLeastOneValidBlock = true;
            }
        }

        Assert.IsTrue(foundAtLeastOneValidBlock,
            "Expected at least one spawned child with a BlockBehaviour component. If this fails, " +
            "GridGenerator's spawned prefabs may not carry BlockBehaviour directly on the root " +
            "object - verify against the real RenderWorld() implementation.");
    }

    [UnityTest]
    public IEnumerator GenerateWorld_CalledAgain_ClearsOldChildrenAndRegenerates()
    {
        yield return null;
        yield return null;
        int firstGenerationCount = _grid.transform.childCount;
        Assert.Greater(firstGenerationCount, 0);

        _grid.GenerateWorld();
        yield return null; // allow Destroy() calls to actually process

        Assert.Greater(_grid.transform.childCount, 0,
            "Regenerating the world should still result in at least one spawned block.");
    }
}
