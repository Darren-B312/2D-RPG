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

public abstract class BaseItemScriptableObject : ScriptableObject
{
    protected GameObject prefab;
    protected int id;
    protected ItemType type;
    protected new string name;
    [TextArea(0,5)] protected string description; // TODO: Work out some reasonable limit on the max length of an item description.
}
