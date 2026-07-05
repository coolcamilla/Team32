using UnityEngine;

public class PlayerManagerLogic
{
    public Item EquippedItem;
    
    public PlayerManagerLogic()
    {
        EquippedItem = Item.CreateInstance<Item>();
    }

    public void ChangeItem(Item newItem)
    {
        EquippedItem = newItem;
        PlayerAnimator.ChangeInstrument(EquippedItem.Type);
    }
}
