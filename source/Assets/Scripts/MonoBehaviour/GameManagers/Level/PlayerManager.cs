using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    public Item EquippedItem;
   
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        EquippedItem = Item.CreateInstance<Item>();
    }

    public void ChangeItem(Item newItem)
    {
        EquippedItem = newItem;
        UpdateAnimation();
    }

    private void UpdateAnimation()
    {
        switch(EquippedItem.Type)
        {
            case ItemType.Shovel:
                _animator.SetInteger("ToolKey", 1);
                break;
            case ItemType.Pickaxe:
                _animator.SetInteger("ToolKey", 2);
                break;
            default:
                _animator.SetInteger("ToolKey", 0);
                break;
        }
    }
}
