using UnityEngine;

public class GameInitializer : MonoBehaviour
{
    private CraftManager _crafter;
    void Start()
    {
        InventoryManager.Init();
        _crafter = GetComponent<CraftManager>();
        _crafter.Init();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
