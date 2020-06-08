using UnityEngine;

// Scriptable Object abstract base class

public enum ItemType
{
    Default,
    Weapon,
    Armour,
    Consumeable,
    Misc
}

public abstract class ItemObject : ScriptableObject
{
    public GameObject prefab;
    public int id;
    public ItemType type;
    public new string name;
    [TextArea(0,5)]public string description; // TODO: Work out some reasonable limit on the max length of an item description.
}
