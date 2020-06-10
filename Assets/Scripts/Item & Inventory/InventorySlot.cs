using UnityEngine;

[System.Serializable]
public class InventorySlot
{
    [SerializeField] private BaseItemScriptableObject item;
    [SerializeField] private int count;

    public BaseItemScriptableObject Item
    {
        get => item;
        set => item = value;
    }
    public int Count
    {
        get => count;
        set => count = value;
    }

    public InventorySlot(BaseItemScriptableObject item, int count)
    {
        this.item = item;
        this.count = count;
    }

    public void AddAmount(int x)
    {
        count += x;
    }
}
