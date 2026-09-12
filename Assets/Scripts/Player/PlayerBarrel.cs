using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBarrel : MonoBehaviour
{
    public Vector3 mousePosition;
    public Transform barrel;
    public Vector2 direction;

    // Update is called once per frame
    void Update()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());

        direction = mousePosition - transform.position;

        float rotationZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        
        transform.rotation = Quaternion.Euler(0, 0, rotationZ);
    }
}
