using System;
using System.Threading;
using UnityEngine;
public class InventoryEntry
{
    public Item StoredItem;
    public int Count;
}

public class InventoryLogic
{
    private readonly InventoryEntry[] _slots;
    private readonly int _maxStackSize;

    public InventoryEntry[] Slots => _slots;

    public event Action OnInventoryChanged;

    public InventoryLogic(int slotCount, int maxStackSize)
    {
        _slots = new InventoryEntry[slotCount];
        _maxStackSize = maxStackSize;
    }

    public bool Spend(Item item, int countToRemove)
    {
        if (!IsEnough(item, countToRemove)) return false;

        for (int i = 0; i < _slots.Length; i++)
        {
            if (IsSlotSuitable(i, item))
            {
                int toSubtract = Math.Min(_slots[i].Count, countToRemove);

                _slots[i].Count -= toSubtract;
                countToRemove -= toSubtract;

                if (_slots[i].Count <= 0)
                {
                    _slots[i] = null;
                }

                if (countToRemove <= 0)
                {
                    OnInventoryChanged?.Invoke();
                    return true;
                }
            }
        }

        return false;
    }

    public bool IsEnough(Item item, int requiredCount)
    {
        int foundCount = 0;
        for (int i = 0; i < _slots.Length; i++)
        {
            if (IsSlotSuitable(i, item))
            {
                foundCount += _slots[i].Count;
                if (foundCount >= requiredCount) return true;
            }
        }
        return false;
    }

    public int TryAddItem(Item item)
    {
        //Item is instrument or service type
        if ((int)item.Type < 300) return -1;

        if (item.IsStackable)
        {
            int slotWithItem = FindSlotWithItem(item);
            if (slotWithItem != -1 && _slots[slotWithItem].Count < _maxStackSize) {
                _slots[slotWithItem].Count++;
                OnInventoryChanged?.Invoke();
                return slotWithItem;
            } 
        }

        int emptySlotIndex = FindEmptySlot();
        if (emptySlotIndex != -1)
        {
            _slots[emptySlotIndex] = new InventoryEntry { StoredItem = item, Count = 1 };
            OnInventoryChanged?.Invoke();
            return emptySlotIndex;
        }

        return -1;
    }

    private int FindSlotWithItem(Item item)
    {
        for (int i = 0; i < _slots.Length; i++)
        {
            if (IsSlotSuitable(i, item) && _slots[i].Count < _maxStackSize)
            {
                return i;
            }
        }
        return -1;
    }
    private bool IsSlotSuitable(int index, Item item) 
    {
        return _slots[index] != null && _slots[index].StoredItem == item;
    }

    private int FindEmptySlot()
    {
        for (int i = 0; i < _slots.Length; i++)
        {
            if (IsSlotEmpty(i))
            {
                return i;
            }
        }

        return -1;
    }
    private bool IsSlotEmpty(int index)
    {
        return _slots[index] == null || _slots[index].Count <= 0;
    }

    public void MoveOrSwap(int from, int to)
    {
        if (from < 0 || to < 0 || from >= _slots.Length || to >= _slots.Length) return;
        if (_slots[from] == null) return;

        if (_slots[to] != null && _slots[to].StoredItem == _slots[from].StoredItem && _slots[to].StoredItem.IsStackable)
        {
            ProcessStacking(from, to);
        }
        else
        {
            Swap(from, to);
        }

        OnInventoryChanged?.Invoke();
    }

    private void Swap(int from, int to)
    {
        InventoryEntry entry = _slots[from];
        _slots[from] = _slots[to];
        _slots[to] = entry;
    }

    private void ProcessStacking(int from, int to)
    {
        InventoryEntry fromEntry = _slots[from];
        InventoryEntry toEntry = _slots[to];

        if (toEntry.Count < _maxStackSize)
        {
            int toMove = Math.Min(_maxStackSize - toEntry.Count, fromEntry.Count);
            fromEntry.Count -= toMove;
            toEntry.Count += toMove;
        }

        if (fromEntry.Count <= 0)
        {
            _slots[from] = null;
        }
    }
}