using UnityEngine;

public class PlayerContactHandler : MonoBehaviour
{
    void Start()
    {
        
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
