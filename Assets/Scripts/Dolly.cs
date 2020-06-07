using UnityEngine;

[RequireComponent(typeof(Transform))]
public class Dolly : MonoBehaviour
{
    [SerializeField] private Transform player;

    void Update()
    {
        transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);
    }
}
