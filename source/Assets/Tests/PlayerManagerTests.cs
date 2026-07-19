using NUnit.Framework;

public class PlayerManagerTests
{
    [Test]
    public void PlayerManagerChangesItem()
    {
        PlayerManagerLogic _manager;
        _manager = new PlayerManagerLogic();
        Item testItem = Item.CreateInstance<Item>();
        testItem.ConfigureToNotDefaultForTesting();

        _manager.ChangeItem(testItem);

        Assert.AreEqual(testItem, _manager.EquippedItem, "Asserting that the equipped item is set correctly");
    }
}
