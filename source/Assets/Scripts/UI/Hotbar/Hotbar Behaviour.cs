using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.UI;
public class HotbarBehaviour : MonoBehaviour
{
    private GameObject _hotbarGrid;
    private List<HotbarSlot> _slotsUI;
    private PlayerManager _player;
    private PlayerInput _input;

    private int _selectedSlot;

    private void Awake()
    {
        _slotsUI = new List<HotbarSlot>();

        _hotbarGrid = GetComponentInChildren<GridLayoutGroup>().gameObject;
        InitializeSlots();

        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>();
        _input = _player.Input;

        _selectedSlot = 0;
        _slotsUI[0].Select();

        _input.UI.Switchinventoryslot.performed += TryChangeSlot;
    }

    private void InitializeSlots()
    {
        foreach(HotbarSlot go in _hotbarGrid.GetComponentsInChildren<HotbarSlot>())
        {
            _slotsUI.Add(go);
            go.gameObject.SetActive(false);
        }
    }
    private void TryChangeSlot(InputAction.CallbackContext context)
    {
        int index = Mathf.RoundToInt(context.ReadValue<float>());
        if (_slotsUI[index].gameObject.activeSelf)
        {
            ChangeSlot(index);
        }
    }

    private void ChangeSlot(int index)
    {
        _slotsUI[_selectedSlot].Deselect();
        _selectedSlot = index;
        _slotsUI[_selectedSlot].Select();
        _player.ChangeItem(_slotsUI[_selectedSlot].GetItem);
    }

    public void ChangeItem(Item newItem)
    {
        int suitableSlotIndex = ((int)newItem.Type - 100) / 40; 
        if (_slotsUI[suitableSlotIndex].TrySetNewItem(newItem))
        {
            _player.ChangeItem(newItem);
            _slotsUI[suitableSlotIndex].gameObject.SetActive(true);
        }
    }
}
