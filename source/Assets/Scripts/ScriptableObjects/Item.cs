using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Scriptable Objects/Item")]
public class Item : ScriptableObject
{
    [SerializeField] private ItemType _type;
    [SerializeField] private Sprite _sprite;
    [SerializeField] private bool _isStackable = true;
    [SerializeField] private float _damage = 1f;
    [SerializeField] private float _diggingCooldown = 0.45f;
    [SerializeField] private CraftRecipe _recipe;
    
    public ItemType Type => _type;
    public Sprite GetSprite => _sprite;
    public bool IsStackable => _isStackable;
    public float Damage => _damage;
    public float Cooldown => _diggingCooldown;

    public CraftRecipe Recipe => _recipe;
}
