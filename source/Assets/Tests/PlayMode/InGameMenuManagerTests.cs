using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

/// <summary>
/// PlayMode integration tests for InGameMenuManager.
///
/// InGameMenuManager.Awake() does
/// GameObject.FindGameObjectWithTag("Player").GetComponent&lt;PlayerManager&gt;().Input,
/// which only resolves correctly once the real Player GameObject exists in a
/// loaded scene. Tests therefore use the already-initialized instance found in
/// the Level scene rather than an isolated GameObject.
///
/// _pauseMenu, _inventoryMenu, _menuesList, and _hotbar are private SerializeField
/// references assigned in the Inspector and are not accessible from a test without
/// reflection. Toggle(GameObject) is reference-equality based internally
/// (`toggledMenu == _previousMenu`), so these tests exercise the pause/resume
/// state machine using arbitrary throwaway GameObjects rather than the real menu
/// references - this is sufficient to verify Toggle()'s actual branching behavior
/// without needing access to the private fields.
/// </summary>
public class InGameMenuManagerTests
{
    private InGameMenuManager _menuManager;

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

        _menuManager = GameObject.FindObjectOfType<InGameMenuManager>();
        Assert.IsNotNull(_menuManager,
            "Setup FAIL: InGameMenuManager not found in the Level scene.");

        // Ensure a known, unpaused starting state before each test, since the scene
        // (and this component instance) is loaded once per session.
        Time.timeScale = 1f;
    }

    [UnityTest]
    public IEnumerator Toggle_FirstCall_PausesGame()
    {
        var dummyMenu = new GameObject("Test_DummyMenu");

        _menuManager.Toggle(dummyMenu);
        yield return null;

        Assert.AreEqual(0f, Time.timeScale,
            "Time.timeScale should be 0 after the first Toggle() call opens a menu.");

        // Cleanup: resume so state doesn't leak into later tests.
        _menuManager.Toggle(dummyMenu);
        Object.Destroy(dummyMenu);
    }

    [UnityTest]
    public IEnumerator Toggle_SameMenuTwice_ResumesGame()
    {
        var dummyMenu = new GameObject("Test_DummyMenu");

        _menuManager.Toggle(dummyMenu); // open
        yield return null;
        _menuManager.Toggle(dummyMenu); // close (same reference)
        yield return null;

        Assert.AreEqual(1f, Time.timeScale,
            "Time.timeScale should return to 1 after toggling the same menu a second time.");

        Object.Destroy(dummyMenu);
    }

    [UnityTest]
    public IEnumerator Toggle_DummyMenu_ActivatesPassedGameObject()
    {
        var dummyMenu = new GameObject("Test_DummyMenu");
        dummyMenu.SetActive(false);

        _menuManager.Toggle(dummyMenu);
        yield return null;

        Assert.IsTrue(dummyMenu.activeSelf,
            "Toggle() should SetActive(true) on the GameObject passed to it.");

        // Cleanup: resume via the same reference.
        _menuManager.Toggle(dummyMenu);
        Object.Destroy(dummyMenu);
    }

    [UnityTest]
    public IEnumerator Toggle_SwitchingBetweenTwoMenus_DeactivatesPrevious()
    {
        var menuA = new GameObject("Test_MenuA");
        var menuB = new GameObject("Test_MenuB");
        menuA.SetActive(false);
        menuB.SetActive(false);

        _menuManager.Toggle(menuA); // open A
        yield return null;
        _menuManager.Toggle(menuB); // switch to B (different reference, so this opens B rather than resuming)
        yield return null;

        Assert.IsFalse(menuA.activeSelf,
            "Previous menu should be deactivated when switching to a different menu.");
        Assert.IsTrue(menuB.activeSelf,
            "Newly toggled menu should be activated.");
        Assert.AreEqual(0f, Time.timeScale,
            "Game should remain paused while switching between two open menus.");

        // Cleanup: resume via B, the currently-open menu.
        _menuManager.Toggle(menuB);
        Object.Destroy(menuA);
        Object.Destroy(menuB);
    }
}
