using NUnit.Framework;

public class PlayerManagerTests
{
    [Test]
    public void PlayerManagerIsNotNull()
    {
        var playerManager = PlayerManager.Instance;
        Assert.NotNull(playerManager, "Player manager instance must be initialized");
    }

    [Test]
    public void PlayerManagerChangesItem()
    {
        Item testItem = Item.CreateInstance<Item>();
        testItem.ConfigureToNotDefaultForTesting();

        PlayerManager.Instance.EquippedItem = testItem;

        Assert.AreEqual(testItem, PlayerManager.Instance.EquippedItem, "Asserting that the equipped item is set correctly");
    }
}
