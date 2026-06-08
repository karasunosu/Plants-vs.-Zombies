using UnityEngine;

public class PeaShooter : MonoBehaviour
{
    [SerializeField] Transform firePoint;
    [SerializeField] float fireRate = 1.11f;
    [SerializeField] float attackRange = 10f;

    Plant thisPeashooter;

    void Awake()
    {
        thisPeashooter = GetComponent<Plant>();
    }

    void Start()
    {
        thisPeashooter.ChangeState(new PeaShooterIdle(this, thisPeashooter));
    }

    public void Attack()
    {
        thisPeashooter.ChangeAnim(ANIM_PEA_ATTACK);
        // Invoke(nameof(Shoot), 0.31f);
        // Shoot();
    }

    public void Idle()
    {
        thisPeashooter.ChangeAnim(ANIM_PEA_IDLE); 
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
        PoolManager.Instance.Spawn(PoolType.PeaBullet, firePoint.position, Quaternion.identity);
    }

    public float GetFireRate()
    {
        return fireRate;
    }

    public const string ANIM_PEA_IDLE = "Idle";
    public const string ANIM_PEA_ATTACK = "Attack";
}