using UnityEngine;

[CreateAssetMenu(fileName = "Engine", menuName = "Scriptable Objects/Engine")]
public class Engine : ScriptableObject
{
    [SerializeField] private string _name;
    [SerializeField] private float _speed;
    [SerializeField] private float _power;
    [SerializeField] private CraftRecipe _recipe;
    [SerializeField] private int _level;

    public string Name => _name;
    public float Speed => _speed;
    public float Power => _power;
    public CraftRecipe Recipe => _recipe;
    public int Level => _level;

    public void SetBasic()
    {
        _name = "Basic Engine";
        _speed = 0.2f;
        _power = 5f;
        _level = 0;
    }
}
