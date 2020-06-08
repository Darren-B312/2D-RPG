using System.Collections.Generic;
using UnityEngine;

// Inventory scriptable object, the PlayerInventoryManager component has an instnace of this class as a property
// This is where methods for adding and removing inventory items will be.

[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory System/Inventory")]
public class InventoryObject : ScriptableObject
{
    public List<InventorySlot> Inventory = new List<InventorySlot>();

    public void AddItem(ItemObject _item, int x)
    {
        bool hasItem = false;

        foreach(InventorySlot inventorySlot in Inventory)
        {
            if(inventorySlot.item == _item)
            {
                inventorySlot.AddAmount(x);
                hasItem = true;
                break;
            }
        }

        if(!hasItem)
        {
            Inventory.Add(new InventorySlot(_item, x));
        }
    }
}

[System.Serializable]
public class InventorySlot
{
    public ItemObject item;
    public int count;
    
    public InventorySlot(ItemObject _item, int _count)
    {
        item = _item;
        count = _count;
    }

    public void AddAmount(int x)
    {
        count += x;
    }
}
