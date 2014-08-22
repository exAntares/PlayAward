using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InventoryState : PlayerStateBase
{
    public Inventory Inventario;

    override protected void InitState()
    {
        base.InitState();
        Inventario = gameObject.GetInventory();
    }

    void ShowInventory()
    {
        if (!enabled) return;

        foreach (InventoryItem item in Inventario.Items)
        {
            print(item.name);
        }
    }

    void HideInventory()
    {
        if (!enabled) return;

        foreach (InventoryItem item in Inventario.Items)
        {

        }
    }
}