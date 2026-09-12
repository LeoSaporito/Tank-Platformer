using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public PlayerManager _playerManager;
    public PlayerMovement _playerMovement;
    public PlayerShooting _playerShooting;
    private void Start()
    {
        _playerMovement = GetComponent<PlayerMovement>();
        _playerShooting = GetComponent<PlayerShooting>();
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        _playerMovement.directionalInput = context.ReadValue<Vector2>();
    }
    public void OnLeftClick(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            _playerShooting.SpawnBullet(_playerShooting.fastBullet);
        }
    }
    public void OnRightClick(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            _playerShooting.SpawnBullet(_playerShooting.slowBullet);
        }
    }
    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            _playerMovement.Jump();
        }
    }
}
