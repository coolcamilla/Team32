using UnityEngine;

[CreateAssetMenu(fileName = "Fuel", menuName = "Scriptable Objects/Fuel")]
public class Fuel : ScriptableObject
{
    [SerializeField] private ItemType _type;
    [SerializeField] private float _energy;

    public ItemType Type => _type;
    public float Energy => _energy;
}
