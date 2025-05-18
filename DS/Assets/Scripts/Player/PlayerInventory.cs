using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory
{
    private Dictionary<ItemType, int> items = new();

    public static event Action OnPlankChanged;

    public void AddItem(ItemType type, int amount)
    {
        if (items.ContainsKey(type))
            items[type] += amount;
        else
            items[type] = amount;

        OnPlankChanged?.Invoke();
    }

    public bool TryUseItem(ItemType type, int amount)
    {
        if (items.TryGetValue(type, out int count) && count >= amount)
        {
            items[type] -= amount;
            return true;
        }
        else
            return false;
    }

    public int GetItemCount(ItemType type)
    {
        return items.TryGetValue(type, out int count) ? count : 0;
    }
}