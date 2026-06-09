using System;
using Unity.VisualScripting;
using UnityEngine;

public class PeaShooterBullet : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    [SerializeField] float damage = 10;
    [SerializeField] SpriteRenderer sprite;
    [SerializeField] SpriteRenderer explodeSprite;

    bool isExploding;
    bool isReleased;

    private void OnEnable()
    {
        isExploding = false;
        isReleased = false;

        sprite.enabled = true;
        explodeSprite.enabled = false;
    }

    void Update()
    {
        if(isExploding) return;

        Move();
        WentToFar();
    }

    void Move()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    void ReleaseBullet()
    {
        if(isReleased) return;

        isReleased = true;
        isExploding = false;
        sprite.enabled = true;
        explodeSprite.enabled = false;
        PoolManager.Instance.Return(PoolType.PeaBullet, gameObject);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(Zombie.Zombie_Tag))
        {
            ZomNormal zom = collision.GetComponent<ZomNormal>();
            if(zom != null)
            {
                zom.TakeDamage(damage);
                Explode();
            }
        }
    }

    void Explode()
    {
        isExploding = true;
        sprite.enabled = false;
        explodeSprite.enabled = true;
        Invoke(nameof(ReleaseBullet), 0.15f);
    }

    void WentToFar()
    {
        if(transform.position.x > 15f)
        {
            ReleaseBullet();
        }
    }

    public float GetDamage()
    {
        return damage;
    }
}
