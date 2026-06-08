using System;
using UnityEngine;

public class PeaShooterBullet : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    [SerializeField] int damage = 10;
    
    void Update()
    {
        Move();
        ReleaseBullet();
    }

    void Move()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    void ReleaseBullet()
    {
        if(transform.position.x > 15f)
        {
            PoolManager.Instance.Return(PoolType.PeaBullet, gameObject);
        }
    }
}
