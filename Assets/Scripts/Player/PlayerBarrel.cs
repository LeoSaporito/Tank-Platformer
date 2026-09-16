using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBarrel : MonoBehaviour
{
    public Vector2 mousePosition;
    public Transform player;
    public Vector2 direction;
    public float maxDistanceFromPlayer;
    public float distanceFromPlayer;

    private Rigidbody2D rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        direction = mousePosition - (Vector2)player.position;
        float rotationZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotationZ);

        mousePosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        distanceFromPlayer = Vector2.Distance(mousePosition, player.position);

        if (distanceFromPlayer <= maxDistanceFromPlayer)
        {
            rb.MovePosition(mousePosition);
        }
        else
        {
            rb.MovePosition((Vector2)player.position + (mousePosition - (Vector2)player.position).normalized * maxDistanceFromPlayer);
        }
    }
}
