using UnityEngine;

public class PeaShooter : MonoBehaviour
{
    [SerializeField] Transform firePoint;
    [SerializeField] float fireRate = 1.5f;

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;

        if(timer >= fireRate)
        {
            Shoot();
            timer = 0;
        }
    }

    void Shoot()
    {
        PoolManager.Instance.Spawn(PoolType.PeaBullet, firePoint.position, Quaternion.identity);
    }
}
