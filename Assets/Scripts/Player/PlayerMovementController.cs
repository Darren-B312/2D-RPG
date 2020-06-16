using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovementController : MonoBehaviour
{
    [SerializeField] private float speed = 5;

    private Rigidbody2D rb;
    private Vector3 movement;
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

        //if(Input.GetKey(KeyCode.Space) || Input.GetButton())
        //{
        //    Debug.Log("holding space..");
        //}

        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    Debug.Log("Tapped Spacebar");
        //}
    }

    void FixedUpdate()
    {
        movement = new Vector3(x * speed, y * speed);
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
