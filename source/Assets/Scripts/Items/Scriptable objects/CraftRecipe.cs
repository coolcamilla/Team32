using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CraftRecipe", menuName = "Scriptable Objects/CraftRecipe")]
public class CraftRecipe : ScriptableObject
{
    [SerializeField] private string _name = "Name";
    [SerializeField] private string _description = "Description";
    [SerializeField] private Sprite _sprite;
    [SerializeField] private List<MaterialAndQuantity> _materials;

    #region Getters
    public string Name => _name;
    public string Description => _description;
    public Sprite GetSprite => _sprite;
    public List<MaterialAndQuantity> Materials => _materials;

    #endregion

    public void ConfigureForCraftTest()
    {
        _materials = new();
        _materials.Add(new MaterialAndQuantity(ItemType.Stick, 2));
    }
}

[Serializable]
public struct MaterialAndQuantity
{
    [SerializeField] private ItemType _type;
    [SerializeField] private int _quantity;

    public MaterialAndQuantity(ItemType type, int quantity)
    {
        _type = type;
        _quantity = quantity;
    }
    
    public ItemType Type => _type;
    public int Quantity => _quantity;
}