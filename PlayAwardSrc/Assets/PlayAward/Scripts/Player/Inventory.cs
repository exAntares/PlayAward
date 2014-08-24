using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour
{
    public List<InventoryItem> Items;

    public void AddItem(InventoryItem Item)
    {
        Items.Add(Item);
    }

    public void RemoveItem(InventoryItem Item)
    {
        Items.Remove(Item);
    }
}

public static class InventoryExtensionMethods
{
    public static Inventory GetInventory(this GameObject go)
    {
        return go.GetComponent<Inventory>();
    }
}