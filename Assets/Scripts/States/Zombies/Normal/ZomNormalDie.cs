using UnityEngine;

public class ZomNormalDie : IState
{
    Zombie thisZombie;
    ZomNormal thisZomNormal;

    public ZomNormalDie(Zombie zombie, ZomNormal zomNormal)
    {
        thisZombie = zombie;
        thisZomNormal = zomNormal;
    }

    public void Enter()
    {
        // thisZomNormal.Die();
    }

    public void Execute()
    {
        
    }

    public void Exit()
    {
    }
}
