using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb = null;

    public float speed = 5.0f;

    // int = 1, 2, 3, 4, 5
    // float = 1.0f, 1.5f, 3.2f, 4.0f, 5.0f
    // double = biig number

    void Start()
    {
        if (rb == null)
        {
            rb = GetComponent<Rigidbody2D>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // FixedUpdate is called at a fixed interval and is independent of frame rate
    private void FixedUpdate()
    {
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        Vector2 moveVelocity = moveInput.normalized * speed;
        rb.linearVelocity = new Vector2(moveVelocity.x, moveVelocity.y);
    }

    // GetAxis = 0, 0.1, 0.2 -> 1.0
    // GetAxisRaw = -1, 0, 1

    // rb.linearVelocity = (x, y)

    // Vector2 = (x, y)
    // Vector3 = (x, y, z)

    // vertical = 1
    // vertical = -1

    // Vector2 * float
    // (x, y) * 2.0f = (x * 2.0f, y * 2.0f)
}