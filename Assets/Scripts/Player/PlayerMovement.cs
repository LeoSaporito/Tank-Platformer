using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public Vector2 directionalInput;
    public Vector2 position;
    public float moveSpeed;
    public float jumpForce;
    public float currentSpeed;
    public float maxSpeed;
    private Rigidbody2D rb;
    public bool isGrounded;
    public bool goalReached;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        if(goalReached) { return;  }

        SpeedController();

        rb.linearVelocity = new Vector2(currentSpeed, rb.linearVelocity.y);
    }
    public void SpeedController()
    {
        currentSpeed = rb.linearVelocity.x + directionalInput.x * moveSpeed * Time.fixedDeltaTime;

        if (Mathf.Abs(currentSpeed) > maxSpeed)
        {
            currentSpeed = maxSpeed * Mathf.Sign(currentSpeed);
        }

        if(currentSpeed <= 0.1f && currentSpeed >= -0.1f)
        {
            currentSpeed = 0f;
        }
    }
    public void Jump()
    {
        if (goalReached) { return; }
        if (!isGrounded) { return; }

        isGrounded = false;
        rb.linearVelocity = new Vector2(currentSpeed, jumpForce);
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground") || other.gameObject.CompareTag("Interactable"))
        {
            isGrounded = true;
        }
    }
}
