using UnityEngine;

[CreateAssetMenu(fileName = "FuelTank", menuName = "Scriptable Objects/FuelTank")]
public class FuelTank : ScriptableObject
{
    [SerializeField] private string _name;
    [SerializeField] private int _capacity;
    [SerializeField] private CraftRecipe _recipe;
    [SerializeField] private int _level;

    public string Name => _name;
    public int Capacity => _capacity;
    public CraftRecipe Recipe => _recipe;
    public int Level => _level;

    public void SetBasic()
    {
        _name = "Basic Fuel Tank";
        _capacity = 5;
        _level = 0;
    }
}
