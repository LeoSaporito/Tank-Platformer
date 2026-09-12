using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletTransform;
    public bool canFire;
    private void Start()
    {
        canFire = true;
    }
    void Update()
    {
    }
    public void SpawnBullet()
    {
        if (canFire)
        {
        }
            canFire = false;
            Instantiate(bullet, bulletTransform.position, transform.rotation);
    }
}
