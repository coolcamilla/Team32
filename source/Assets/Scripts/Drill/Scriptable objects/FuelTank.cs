using UnityEngine;

[CreateAssetMenu(fileName = "FuelTank", menuName = "Scriptable Objects/FuelTank")]
public class FuelTank : ScriptableObject
{
    [SerializeField] private string _name;
    [SerializeField] private int _capacity;
    [SerializeField] private CraftRecipe _recipe;

    public string Name => _name;
    public int Capacity => _capacity;
    public CraftRecipe Recipe => _recipe;

    public void SetBasic()
    {
        _name = "Basic Fuel Tank";
        _capacity = 5;
    }
}
