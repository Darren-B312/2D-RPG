using UnityEngine;

public class PlayerContactHandler : MonoBehaviour
{
    private InventoryObject inventoryObject;
    
    void Start()
    {
        inventoryObject = GetComponent<PlayerInventoryManager>().inventory;
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
            inventoryObject.AddItem(item.item, 1);
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
