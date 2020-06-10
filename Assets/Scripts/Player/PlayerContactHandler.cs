using UnityEngine;

public class PlayerContactHandler : MonoBehaviour
{
    private InventoryScriptableObject inventory;
    
    void Start()
    {
        inventory = GetComponent<PlayerInventoryManager>().Inventory;
    }

    void Update()
    {
        
    }

    private void FixedUpdate()
    {

    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log($"<color=green>Enter: {collider.tag}</color>");

        var item = collider.GetComponent<Item>();
        if (item)
        {
            inventory.AddItem(item.ItemScriptableObject, 1);
            Destroy(collider.gameObject);
        }

    }

    void OnTriggerExit2D(Collider2D collider)
    {
        Debug.Log($"<color=red>Exit: {collider.tag}</color>");
        
        if(collider.tag == "Terrain") // TODO: Figure out a more robust means of checking collider type.
        {
            Destroy(gameObject);
            Debug.Log("You fell...");
        }
    }
}
