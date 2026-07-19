using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Scriptable Objects/Item")]
public class Item : ScriptableObject
{
    [SerializeField] private ItemType _type = ItemType.None;
    [SerializeField] private Sprite _sprite;
    [SerializeField] private bool _isStackable = true;
    [SerializeField] private float _damage = 1f;
    [SerializeField] private float _diggingCooldown = 0.6f;
    [SerializeField] private CraftRecipe _recipe;

    #region Getters
    public ItemType Type => _type;
    public Sprite GetSprite => _sprite;
    public bool IsStackable => _isStackable;
    public float Damage => _damage;
    public float Cooldown => _diggingCooldown;

    public CraftRecipe Recipe => _recipe;

    #endregion

    public void ConfigureToNotDefaultForTesting()
    {
        _type = ItemType.Test;
        _damage = 15f;
        _diggingCooldown = 1f;
    }

    public void ConfigureNonStackableForInventoryTest()
    {
        _isStackable = false;
    }
    
    public void ConfigureItemForCraftTestMaterial()
    {
        _type = ItemType.Stick;
    }

    public void ConfigureItemForCraftTestResult()
    {
        _type = ItemType.Test;
        _isStackable = false;
        _recipe = CraftRecipe.CreateInstance<CraftRecipe>();
        _recipe.ConfigureForCraftTest();
    }

}
