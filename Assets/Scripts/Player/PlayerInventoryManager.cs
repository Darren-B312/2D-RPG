using UnityEngine;

// The player has 1 of this class as a component for managing inventory

public class PlayerInventoryManager : MonoBehaviour
{
    [SerializeField] private InventoryScriptableObject inventory;
    public InventoryScriptableObject Inventory
    {
        get => inventory;
        set => inventory = value;
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnApplicationQuit()
    {
        inventory.Inventory.Clear(); // Reset the players inventory.
    }
}
