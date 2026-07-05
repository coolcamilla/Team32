using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private PlayerManagerLogic _logic;
    private PlayerInput _input;
    public PlayerManagerLogic Logic => _logic;
    public Item EquippedItem => _logic.EquippedItem;
    public PlayerInput Input
    {
        get
        {
            if (_input == null) _input = new PlayerInput();
            return _input;
        }
    }
    private void Initialize()
    {
        _logic = new PlayerManagerLogic();
    }

    public void ChangeItem(Item item)
    {
        if (_logic == null) Initialize();
        _logic.ChangeItem(item);
    }
}
