using UnityEngine;

public class SnowPeaAttack : IState
{
    SnowPea thisSnowPea;
    Plant thisPlant;
    float shootTime;

    public SnowPeaAttack(SnowPea snowPea, Plant plant)
    {
        thisSnowPea = snowPea;
        thisPlant = plant;
    }

    public void Enter()
    {
        Debug.Log("Enter Attack State");
        shootTime = 0;
    }

    public void Execute()
    {
        Debug.Log("Execute Attack State");
        if (!thisSnowPea.IsHaveZombieInLane())
        {
            thisPlant.ChangeState(new SnowPeaIdle(thisSnowPea, thisPlant));
            return;
        }

        shootTime -= Time.deltaTime;
        if(shootTime <= 0)
        {
            thisSnowPea.Attack();
            shootTime = thisSnowPea.GetFireRate();
        }
    }

    public void Exit()
    {
    }
}
