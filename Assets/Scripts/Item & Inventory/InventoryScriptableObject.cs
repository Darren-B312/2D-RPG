using System.Collections.Generic;
using UnityEngine;

// Inventory scriptable object, the PlayerInventoryManager component has an instnace of this class as a property
// This is where methods for adding and removing inventory items will be.

[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory System/Inventory")]
public class InventoryScriptableObject : ScriptableObject
{
    public List<InventorySlot> Inventory = new List<InventorySlot>();

    public void AddItem(BaseItemScriptableObject item, int amount)
    {
        bool hasItem = false;

        foreach(InventorySlot inventorySlot in Inventory)
        {
            if(inventorySlot.Item == item)
            {
                inventorySlot.AddAmount(amount);
                hasItem = true;
                break;
            }
        }

        if(!hasItem)
        {
            Inventory.Add(new InventorySlot(item, amount));
        }
    }
}


