using UnityEngine;

public class ZomNormalEat : IState
{
    Zombie thisZombie;
    ZomNormal thisZomNormal;

    float countTime = 0f;
    float timeDealDamage = 1f; // sau khoang nay thi gay sat thuong

    public ZomNormalEat(Zombie zombie, ZomNormal zomNormal)
    {
        thisZombie = zombie;
        thisZomNormal = zomNormal;
    }

    public void Enter()
    {
        thisZomNormal.Attack();
        countTime = 0f;
    }

    public void Execute()
    {
        if (thisZomNormal.isDead)
        {
            // thisZombie.ChangeState(new ZomNormalDie(thisZombie, thisZomNormal));
            return;
        }

        if (!thisZomNormal.IsCanEat())
        {
            thisZombie.ChangeState(new ZomNormalWalk(thisZombie, thisZomNormal));
            return;
        }

        countTime += Time.deltaTime;
        if(countTime >= timeDealDamage)
        {
            countTime = 0;

                Vector2 start = thisZomNormal.transform.position;
                Vector2 direction = Vector2.left;
                RaycastHit2D[] raycasts = Physics2D.RaycastAll(start, direction, 0.1f);
                foreach(var hit in raycasts)
                {
                    if(hit.collider != null && hit.collider.gameObject.CompareTag(Plant.PLANT_TAG))
                    {
                        Plant plant = hit.collider.GetComponent<Plant>();
                        if(plant != null)
                        {
                            plant.TakeDamage(thisZomNormal.damage);
                        }
                    }
                }
            
        }
    }

    public void Exit()
    {  
    }
}
