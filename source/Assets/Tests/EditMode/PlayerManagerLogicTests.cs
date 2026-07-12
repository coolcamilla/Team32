using NUnit.Framework;

/// <summary>
/// EditMode unit tests for PlayerManagerLogic - plain C#, no scene dependency
/// FOR THE METHODS TESTED HERE SPECIFICALLY.
///
/// IMPORTANT, found while writing these tests: PlayerManagerLogic.ChangeItem()
/// calls `PlayerAnimator.ChangeInstrument(EquippedItem.Type)` as a static call
/// (not through an .Instance reference visible in this file). If that static
/// method internally touches PlayerAnimator.Instance (a MonoBehaviour singleton,
/// per ADR-002), calling ChangeItem() here with no scene loaded could throw a
/// NullReferenceException in headless EditMode CI. ChangeItem() is deliberately
/// NOT tested in this file to avoid a flaky/crashing test - it would need a
/// PlayMode test with a real scene instead. AddCoin and TrySpend have no such
/// dependency and are safely tested here.
/// </summary>
public class PlayerManagerLogicTests
{
    [Test]
    public void Constructor_StartsWithZeroCoins()
    {
        var logic = new PlayerManagerLogic();

        Assert.AreEqual(0, logic.Coins);
    }

    [Test]
    public void AddCoin_IncrementsCoinsByOne()
    {
        var logic = new PlayerManagerLogic();

        logic.AddCoin();

        Assert.AreEqual(1, logic.Coins);
    }

    [Test]
    public void AddCoin_CalledMultipleTimes_AccumulatesCorrectly()
    {
        var logic = new PlayerManagerLogic();

        logic.AddCoin();
        logic.AddCoin();
        logic.AddCoin();

        Assert.AreEqual(3, logic.Coins);
    }

    [Test]
    public void TrySpend_SucceedsAndDeductsCoins_WhenEnoughAvailable()
    {
        var logic = new PlayerManagerLogic();
        logic.AddCoin();
        logic.AddCoin();
        logic.AddCoin();
        logic.AddCoin();
        logic.AddCoin(); // 5 coins

        bool result = logic.TrySpend(5);

        Assert.IsTrue(result);
        Assert.AreEqual(0, logic.Coins);
    }

    [Test]
    public void TrySpend_FailsAndLeavesCoinsUnchanged_WhenInsufficientCoins()
    {
        var logic = new PlayerManagerLogic();
        logic.AddCoin();
        logic.AddCoin(); // 2 coins

        bool result = logic.TrySpend(5);

        Assert.IsFalse(result);
        Assert.AreEqual(2, logic.Coins,
            "A failed TrySpend should not deduct any coins.");
    }

    [Test]
    public void TrySpend_ExactAmount_SucceedsAndLeavesZero()
    {
        var logic = new PlayerManagerLogic();
        logic.AddCoin();
        logic.AddCoin();

        bool result = logic.TrySpend(2);

        Assert.IsTrue(result);
        Assert.AreEqual(0, logic.Coins);
    }

    [Test]
    public void TrySpend_PartialAmount_LeavesRemainder()
    {
        var logic = new PlayerManagerLogic();
        for (int i = 0; i < 10; i++) logic.AddCoin();

        bool result = logic.TrySpend(5);

        Assert.IsTrue(result);
        Assert.AreEqual(5, logic.Coins);
    }

    [Test]
    public void TrySpend_ZeroCoinsAvailable_Fails()
    {
        var logic = new PlayerManagerLogic();

        bool result = logic.TrySpend(1);

        Assert.IsFalse(result);
    }
}