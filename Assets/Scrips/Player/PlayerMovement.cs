using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb = null;
    public Animator animator;

    public float speed = 5.0f;
    private bool isRunning = false;

    // int = 1, 2, 3, 4, 5
    // float = 1.0f, 1.5f, 3.2f, 4.0f, 5.0f
    // double = biig number

    void Start()
    {
        if (rb == null)
        {
            rb = GetComponent<Rigidbody2D>();
        }

        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }

        animator.SetFloat("Speed", 0.0f);
        animator.SetFloat("Direction", 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && !isRunning)
        {
            isRunning = true;
            speed *= 1.5f;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift) && isRunning)
        {
            isRunning = false;
            speed /= 1.5f;
        }
    }

    // FixedUpdate is called at a fixed interval and is independent of frame rate
    private void FixedUpdate()
    {
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        Vector2 moveVelocity = moveInput.normalized * speed;
        rb.linearVelocity = new Vector2(moveVelocity.x, moveVelocity.y);

        animator.SetFloat("Speed", moveVelocity.magnitude);
        if (moveInput.x > 0.1)
        {
            animator.SetFloat("Direction", 1.0f);
        }
        else if (moveInput.x < -0.1)
        {
            animator.SetFloat("Direction", -1.0f);
        }
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