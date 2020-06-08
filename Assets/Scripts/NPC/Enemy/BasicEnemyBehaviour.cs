using UnityEngine;

public class BasicEnemyBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject target = null;
    [SerializeField] private float speed = 4;

    private void FixedUpdate()
    {
        if(target)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
        }
    }
}
