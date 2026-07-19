using NUnit.Framework;
using UnityEngine;

public class PlayerDigTests
{
    [Test]
    public void PlayerDigIsNotNull()
    {
        var playerDig = PlayerDigLogic.Instance;
        Assert.NotNull(playerDig, "Player dig logicc instance must be initialized");
    }

    [Test]
    public void PlayerDigChangesDirection()
    {
        PlayerDigLogic testDig = PlayerDigLogic.Instance;

        testDig.ChangeHorizontalDirection(1f);
        testDig.ChangeVerticalDirection(1f);


        Assert.AreEqual(1f, testDig.HorizontalDirection, "Horizontal direction should be 1f");
        Assert.AreEqual(1f, testDig.VerticalDirection, "Vertical direction should be 1f");
    }

    [Test]
    public void PlayerDigClampsDirectionValues()
    {
        PlayerDigLogic testDig = PlayerDigLogic.Instance;

        testDig.ChangeHorizontalDirection(2f);
        testDig.ChangeVerticalDirection(2f);

        Assert.AreEqual(1f, testDig.HorizontalDirection, "Horizontal direction should be clamped to 1f");
        Assert.AreEqual(1f, testDig.VerticalDirection, "Vertical direction should be clamped to 1f");
    }

    [Test]
    public void PlayerDigBlockHitReturnsTrueWhenConditionsMet()
    {
        PlayerDigLogic testDig = PlayerDigLogic.Instance;

        GameObject block = new GameObject();
        block.tag = "Block";

        Item equippedItem = Item.CreateInstance<Item>();
        equippedItem.ConfigureToNotDefaultForTesting();
        
        //Assuming 5 seconds last after last block hit
        testDig.UpdateTimer(5f);


        bool resultWithFiveSeconds = testDig.BlockHit(block, equippedItem);

        //After first BlockHit timer is 0

        bool resultWithZeroSeconds = testDig.BlockHit(block, equippedItem);

        // Reset timer to 5 seconds for the next test
        testDig.UpdateTimer(5f);

        bool resultWithWrongBLock = testDig.BlockHit(new GameObject(), equippedItem);

        // Reset timer to 5 seconds for the next test
        testDig.UpdateTimer(5f);

        bool resultWithNullBlock = testDig.BlockHit(null, equippedItem);

        Assert.IsTrue(resultWithFiveSeconds, "BlockHit should return true when conditions are met");
        Assert.IsFalse(resultWithZeroSeconds, "BlockHit should return false when timer is less than cooldown");
        Assert.IsFalse(resultWithWrongBLock, "BlockHit should return false when game object is not a block");
        Assert.IsFalse(resultWithNullBlock, "BlockHit should return false when hitting nothing");
    }

    [Test]
    public void PlayerDigComputeRaycastDirectionReturnsCorrectDirection()
    {
        PlayerDigLogic testDig = PlayerDigLogic.Instance;
        testDig.ChangeHorizontalDirection(1f);
        testDig.ChangeVerticalDirection(1f);

        Vector2 climbingDirection = testDig.ComputeRaycastDirection(IsClimbing: true);
        Assert.AreEqual(new Vector2(testDig.HorizontalDirection, 0), climbingDirection, "Digging direction should be horizontal only while climbing");

        Vector2 walkingVerticalDirection = testDig.ComputeRaycastDirection(IsClimbing: false);
        Assert.AreEqual(new Vector2(0, testDig.VerticalDirection), walkingVerticalDirection, "Digging direction should be vertical only while player looks up or down");

        testDig.ChangeVerticalDirection(0);
        Vector2 walkingHorizontalDirection = testDig.ComputeRaycastDirection(IsClimbing: false);
        Assert.AreEqual(new Vector2(testDig.HorizontalDirection, 0), walkingHorizontalDirection, "Digging direction should be horizontal only while player looks left or right only");

    }
}
