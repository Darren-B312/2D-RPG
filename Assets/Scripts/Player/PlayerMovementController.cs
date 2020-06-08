using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovementController : MonoBehaviour
{
    [SerializeField] private float speed = 5;

    private Rigidbody2D rb;
    private Vector2 movement;
    private float x;
    private float y;
    private int oldX;
    private int oldY;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        ReadInput();
        //LogPosition((int)transform.position.x, (int)transform.position.y);
    }

    void FixedUpdate()
    {
        movement = new Vector2(x * speed, y * speed);
        rb.velocity = movement;
    }

    private void ReadInput()
    {
        x = Input.GetAxisRaw("Horizontal");
        y = Input.GetAxisRaw("Vertical");
    }

    private void LogPosition(int x, int y)
    {
        if(x != oldX || y != oldY)
        {
            Debug.Log($"({(int)transform.position.x},{(int)transform.position.y})");
            oldX = x;
            oldY = y;
        }
    }
}
