using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InventoryState : PlayerStateBase
{
    public Inventory Inventario;
    public InventoryItem SelectedItem;

    override protected void InitState()
    {
        base.InitState();
        Inventario = gameObject.GetInventory();
    }

    public virtual void BeginState()
    {
        //gameObject.
    }

    public virtual void EndState()
    {
        //Debug.Log ("StateBase EndState");
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

    void SelectItem(InventoryItem item)
    {
        SelectedItem = item;
    }

}