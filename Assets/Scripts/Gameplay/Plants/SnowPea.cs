using UnityEngine;

public class SnowPea : MonoBehaviour
{
    [SerializeField] Transform firePoint;
    [SerializeField] float fireRate = 1.11f;
    [SerializeField] float attackRange = 10f;

    Plant thisSnowPea;

    void Awake()
    {
        thisSnowPea = GetComponent<Plant>();
    }

    void Start()
    {
        thisSnowPea.ChangeState(new SnowPeaIdle(this, thisSnowPea));
    }

    public void Attack()
    {
        thisSnowPea.ChangeAnim(PeaShooter.ANIM_PEA_ATTACK);
        // Invoke(nameof(Shoot), 0.31f);
        // Shoot();
    }

    public void Idle()
    {
        thisSnowPea.ChangeAnim(PeaShooter.ANIM_PEA_IDLE); 
    }

    public bool IsHaveZombieInLane()
    {
        Vector2 start = transform.position;
        Vector2 direction = Vector2.right;

        Debug.DrawLine(start, start + direction * attackRange, Color.red, 1f);
        RaycastHit2D[] rayCast = Physics2D.RaycastAll(start, direction, attackRange);
        foreach(var hit in rayCast)
        {
            if(hit.collider != null && hit.collider.gameObject.CompareTag(Zombie.Zombie_Tag))
            {
                Zombie zombie = hit.collider.GetComponent<Zombie>();

                if (zombie != null &&zombie.IsAttackable(this.transform.position.y))
                {
                    return true;
                }
            }
        }

        return false;
    }

    public void Shoot()
    {
        PoolManager.Instance.Spawn(PoolType.SnowPeaBullet, firePoint.position, Quaternion.identity);
    }

    public float GetFireRate()
    {
        return fireRate;
    }

}