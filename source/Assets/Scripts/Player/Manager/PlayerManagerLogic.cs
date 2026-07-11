using UnityEngine;

public class PlayerManagerLogic
{
    private int _coins;
    public Item EquippedItem;

    public int Coins => _coins;
    public PlayerManagerLogic()
    {
        _coins = 0;
        EquippedItem = Item.CreateInstance<Item>();
    }

    public void ChangeItem(Item newItem)
    {
        EquippedItem = newItem;
        PlayerAnimator.ChangeInstrument(EquippedItem.Type);
    }

    public void AddCoin()
    {
        _coins++;
    }

    public bool TrySpend(int coinsToSpend)
    {
        if (_coins < coinsToSpend) return false;

        _coins -= coinsToSpend;

        return true;
    }
}
