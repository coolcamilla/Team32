using UnityEngine;

[CreateAssetMenu(fileName = "Drill", menuName = "Scriptable Objects/Drill")]
public class Drill : ScriptableObject
{
    [SerializeField] private string _name;
    [SerializeField] private float _speed;
    [SerializeField] private CraftRecipe _recipe;

    public string Name => _name;
    public float Speed => _speed;
    public CraftRecipe Recipe => _recipe;

    public void SetBasic()
    {
        _name = "Basic Drill";
        _speed = 0.2f;
    }
}
