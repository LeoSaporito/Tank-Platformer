using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletTransform;
    public bool goalReached;
    public float fastBullet;
    public float slowBullet;
    void Update()
    {
    }
    public void SpawnBullet(float power)
    {
        if (goalReached) { return; }

        GameObject bulletSpawned = Instantiate(bullet, bulletTransform.position, transform.rotation);
        bulletSpawned.GetComponent<BulletMovement>().power = power;
    }
}
