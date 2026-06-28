using UnityEngine;

public class PlayerManager
{
    private static PlayerManager _instance;
    
    public Item EquippedItem;
    
    public static PlayerManager Instance
    {
        get
        {
            if (_instance == null) new PlayerManager();
            return _instance;
        }
    }
    
    private PlayerManager()
    {
        _instance = this;
        EquippedItem = Item.CreateInstance<Item>();
    }

    public void ChangeItem(Item newItem)
    {
        EquippedItem = newItem;
        PlayerAnimator.ChangeInstrument(EquippedItem.Type);
    }
}
