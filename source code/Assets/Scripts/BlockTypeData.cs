using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewBlockType", menuName = "MoleDigger/Block Type")]
public class BlockTypeData : ScriptableObject
{
    [Header("Main parameters")]
    public string blockName = "Dirt";
    public float maxHp = 3;
    public float minDamage = 1; //min instrument damage to break it
    public Color color = Color.white;

    [Header("Drop")]
    public List<DropChance> dropTable = new List<DropChance>();

}

[Serializable]
public class DropChance
{
    public CraftMaterial material;
    [Range(0f, 1f)] public float chance;
}