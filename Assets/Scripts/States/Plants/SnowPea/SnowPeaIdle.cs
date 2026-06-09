using UnityEngine;

public class SnowPeaIdle : IState
{
    SnowPea thisSnowPea;
    Plant thisPlant;

    public SnowPeaIdle(SnowPea snowPea, Plant plant)
    {
        thisSnowPea = snowPea;
        thisPlant = plant;
    }

    public void Enter()
    {
        Debug.Log("Enter Idle State");
        thisSnowPea.Idle();
    }

    public void Execute()
    {
        Debug.Log("Execute Idle State");
        if (thisSnowPea.IsHaveZombieInLane())
        {
            thisPlant.ChangeState(new SnowPeaAttack(thisSnowPea, thisPlant));
        }
    }

    public void Exit()
    {
        Debug.Log("Exit State");
    }
}
