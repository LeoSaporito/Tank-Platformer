using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public PlayerMovement _playerMovement;
    public PlayerShooting _playerShooting;

    void Start()
    {
        _playerMovement = GetComponent<PlayerMovement>();    
        _playerShooting = GetComponent<PlayerShooting>();
    }
    public void GoalReached()
    {
        //turn off movement and shooting when goal is reached
        _playerMovement.goalReached = true;
        _playerShooting.goalReached = true;
    }
}
