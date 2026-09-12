using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public Vector2 directionalInput;
    public Vector2 position;
    public float moveSpeed;
    public float jumpForce;

    private Rigidbody2D rb;

    public bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, rb.linearVelocity.y);
    }
    private void Update()
    {
        position = transform.position;
        position += Time.deltaTime * moveSpeed * directionalInput;
        transform.position = position;
    }
    public void Jump()
    {
        if(!isGrounded) { return; }

        isGrounded = false;
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground") || other.gameObject.CompareTag("Interactable"))
        {
            isGrounded = true;
        }
    }
}
