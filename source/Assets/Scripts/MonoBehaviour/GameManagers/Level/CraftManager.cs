using System;
using System.Collections.Generic;
using System.Text;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class CraftManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _craftDescriptionField;
    [SerializeField] private Image _imageField;

    private static Queue<Instrument> _craftingQueue;
    private static Instrument _currentCraft;

    public static event UnityAction<Instrument> OnItemCrafted;
    
    public void Init()
    {
        _craftingQueue = new Queue<Instrument>();
        _craftingQueue.Enqueue(new Shovel());
        _craftingQueue.Enqueue(new Pickaxe());

        Equipment.Equip(new Broom());

        SetNextCraft();
    }
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q)) {
            bool isCrafted = TryCraft();
            if (isCrafted)
            {
                OnItemCrafted?.Invoke(_currentCraft);
                SetNextCraft();
            }
        }
        if (_currentCraft == null)
        {
            Destroy(_craftDescriptionField.gameObject);
            Destroy(_imageField.gameObject);
            Destroy(this);
        }
    }

    private void SetNextCraft()
    {
        try
        {
            _currentCraft = _craftingQueue.Dequeue();
            DrawDescription();
            DrawImage();
        }
        catch (Exception e)
        {
            _currentCraft = null;
            Debug.Log(e.Message);
        }
    }

    private bool TryCraft()
    {
        bool isCrafted = _currentCraft.TryCraft();
        if (!isCrafted) {
            Debug.Log("Not enough resources to craft " + _currentCraft.GetType().ToString());
        }
        return isCrafted;
    }

    private void DrawDescription()
    {
        StringBuilder description = new StringBuilder(_currentCraft.GetType().ToString());
        description.AppendLine();
        description.Append(_currentCraft.GetCraftingString());
        description.Append("Press Q to craft");

        _craftDescriptionField.SetText(description.ToString());
    }

    private void DrawImage()
    {
        _imageField.sprite = _currentCraft.InstrumentSprite;
    }
}
