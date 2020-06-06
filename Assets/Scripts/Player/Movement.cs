using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Movement : MonoBehaviour
{
    [SerializeField] private float speed = 1;

    private Rigidbody2D rb;
    private Vector2 movement;
    private float x;
    private float y;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        x = Input.GetAxisRaw("Horizontal");
        y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        movement = new Vector2(x * speed, y * speed);
        rb.velocity = movement;
    }
}
