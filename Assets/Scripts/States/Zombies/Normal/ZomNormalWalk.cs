using UnityEngine;

public class ZomNormalWalk : IState
{
    Zombie thisZombie;
    ZomNormal thisZomNormal;

    public ZomNormalWalk(Zombie zombie, ZomNormal zomNormal)
    {
        thisZombie = zombie;
        thisZomNormal = zomNormal;
    }
    public void Enter()
    {
        thisZomNormal.Walk();
    }

    public void Execute()
    {
        if (thisZomNormal.isDead)
        {
            // thisZombie.ChangeState(new ZomNormalDie(thisZombie, thisZomNormal));
            return;
        }

        if (thisZomNormal.IsCanEat())
        {
            thisZombie.ChangeState(new ZomNormalEat(thisZombie, thisZomNormal));
        }
    }

    public void Exit()
    {
    }
}
