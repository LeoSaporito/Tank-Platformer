using UnityEngine;
using UnityEngine.InputSystem;

public class BulletMovement : MonoBehaviour
{
    public float power;
    private Rigidbody2D rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());

        Vector2 direction = mousePosition - (Vector2)transform.position;
        float distance = Vector2.Distance(transform.position, mousePosition);
        rb.linearVelocity = new Vector2(direction.x, direction.y).normalized * power;

        Vector3 rotation = (Vector2)transform.position - mousePosition;

        float rotationZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotationZ + 180);
    }
}
