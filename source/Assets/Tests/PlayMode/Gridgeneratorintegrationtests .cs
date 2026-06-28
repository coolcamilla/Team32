using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

/// <summary>
/// PlayMode integration tests for GridGenerator.
/// Scene loaded once to avoid NullReferenceException on repeated reloads.
/// </summary>
public class GridGeneratorIntegrationTests
{
    private GridGenerator _gridGenerator;

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

        _gridGenerator = GameObject.FindObjectOfType<GridGenerator>();
        Assert.IsNotNull(_gridGenerator, "GridGenerator not found in scene.");
    }

    [UnityTest]
    public IEnumerator GridGenerator_AfterStart_HasChildren()
    {
        yield return null;
        Assert.Greater(_gridGenerator.transform.childCount, 0,
            "GridGenerator should have spawned at least one block.");
    }

    [UnityTest]
    public IEnumerator GridGenerator_AfterStart_BlockCountMatchesExpectedMinimum()
    {
        yield return null;
        int minColumns = _gridGenerator.width - _gridGenerator.initX;
        Assert.GreaterOrEqual(_gridGenerator.transform.childCount, minColumns,
            $"Expected at least {minColumns} children (one per column).");
    }

    [UnityTest]
    public IEnumerator GridGenerator_SpawnedBlocks_AllHaveBlockTag()
    {
        yield return null;
        foreach (Transform child in _gridGenerator.transform)
        {
            if (child.GetComponent<BlockBehaviour>() == null) continue;
            Assert.AreEqual("Block", child.tag,
                $"'{child.name}' should have tag 'Block'.");
        }
    }

    [UnityTest]
    public IEnumerator GridGenerator_SpawnedBlocks_AllHaveBlockTypeDataAssigned()
    {
        yield return null;
        var blocks = _gridGenerator.GetComponentsInChildren<BlockBehaviour>();
        Assert.Greater(blocks.Length, 0, "No BlockBehaviour found under GridGenerator.");
        foreach (var block in blocks)
        {
            Assert.IsNotNull(block.BlockData,
                $"'{block.name}' is missing BlockTypeData.");
        }
    }
}