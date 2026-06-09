using UnityEngine;

public class ZomNormal : MonoBehaviour, IDamageable
{
    [SerializeField] GameObject head;
    [SerializeField] float maxHp = 100f;
    public float damage = 20f;

    Zombie thisZombie;
    float currentHp;
    public bool isDead = false;

    void Awake()
    {
        thisZombie = GetComponent<Zombie>();
    }

    void Start()
    {
        currentHp = maxHp;
        thisZombie.ChangeState(new ZomNormalWalk(thisZombie, this));
    }

    public void Walk()
    {
        Move();
        thisZombie.ChangeAnim(ANIM_ZOM_NORMAL_WALK);
    }

    public void Attack()
    {
        Stop();
        thisZombie.ChangeAnim(ANIM_ZOM_NORMAL_ATTACK);
    }

    public void Die()
    {
        isDead = true;
        Stop();
        head.SetActive(true);
        thisZombie.ChangeAnim(ANIM_ZOM_NORMAL_DIE);
        PoolManager.Instance.Return(PoolType.NormalZombie, gameObject);
    }

    public bool IsCanEat()
    {
        Vector2 start = transform.position;
        Vector2 direction = Vector2.left;

        Debug.DrawLine(start, start + direction * 0.1f, Color.red, 1f);
        RaycastHit2D[] raycasts = Physics2D.RaycastAll(start, direction, 0.1f);
        foreach(var hit in raycasts)
        {
            if(hit.collider != null && hit.collider.gameObject.CompareTag(Plant.PLANT_TAG))
            {
                Plant plant = hit.collider.GetComponent<Plant>();
                if(plant != null)
                {
                    return true;
                }
            }
        }
        return false;
    }

    void Move()
    {
        thisZombie.rb.linearVelocity = Vector2.left * thisZombie.moveSpeed;
    }

    void Stop()
    {
        // dung yen ko di chuyen
        thisZombie.rb.linearVelocity = Vector2.zero;
    }

    public void TakeDamage(float damage)
    {
        currentHp -= damage;

        if(currentHp <= 0)
        {
            Die();
        }
    }

    public const string ANIM_ZOM_NORMAL_WALK = "Walk";
    public const string ANIM_ZOM_NORMAL_ATTACK = "Attack";
    public const string ANIM_ZOM_NORMAL_DIE = "Die";
}
