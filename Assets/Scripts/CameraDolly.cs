using UnityEngine;

[RequireComponent(typeof(Transform))]
public class Dolly : MonoBehaviour
{
    [SerializeField] private Transform player = null;

    void Update()
    {
        if(player)
        {
            transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);
        }
    }
}
