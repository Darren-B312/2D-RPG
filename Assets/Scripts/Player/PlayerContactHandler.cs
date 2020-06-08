using UnityEngine;

public class PlayerContactHandler : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("Enter Collision: " + collision.gameObject.name);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        //Debug.Log("Enter Collider: " + collider.gameObject.name);
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        //Debug.Log("Exit Collider: " + collider.gameObject.name);
        if(collider.gameObject.name == "Terrain")
        {
            Destroy(this.gameObject);
            //Debug.Log($"Destroyed: {this.tag}");
        }

    }
}
