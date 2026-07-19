using UnityEngine;

[CreateAssetMenu(fileName = "Bit", menuName = "Scriptable Objects/Bit")]
public class Bit : ScriptableObject
{
    [SerializeField] private string _name;
    [SerializeField] private float _speed;
    [SerializeField] private CraftRecipe _recipe;
    [SerializeField] private int _level;

    public string Name => _name;
    public float Speed => _speed;
    public CraftRecipe Recipe => _recipe;
    public int Level => _level;

    public void SetBasic()
    {
        _name = "Basic Drill";
        _speed = 0.2f;
        _level = 0;
    }
}
