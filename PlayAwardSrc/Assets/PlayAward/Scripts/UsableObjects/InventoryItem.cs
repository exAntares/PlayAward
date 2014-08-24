using UnityEngine;
using System.Collections;

public class InventoryItem : UsableObject
{
    public string Name;
    public Inventory currentIventory;

    override public void OnUse(GameObject User)
    {
        print(User.name + " OnUse " + gameObject.name);
        Inventory userInventory = User.GetInventory();
        Equip(userInventory);
    }

    public void Equip(Inventory inventario)
    {
        if (inventario && currentIventory != inventario)
        {
            currentIventory = inventario;

            currentIventory.AddItem(this);

            Vector3 newPos = transform.position;
            newPos.y = -10000;
            transform.position = newPos;
        }
    }

    public void UnEquip()
    {
    }
}
