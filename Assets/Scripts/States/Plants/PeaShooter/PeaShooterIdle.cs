using UnityEngine;

public class PeaShooterIdle : IState
{
    PeaShooter thisPeashooter;
    Plant thisPlant;

    public PeaShooterIdle(PeaShooter peaShooter, Plant plant)
    {
        thisPeashooter = peaShooter;
        thisPlant = plant;
    }

    public void Enter()
    {
        Debug.Log("Enter Idle State");
        thisPeashooter.Idle();
    }

    public void Execute()
    {
        Debug.Log("Execute Idle State");
        if (thisPeashooter.IsHaveZombieInLane())
        {
            thisPlant.ChangeState(new PeaShooterAttack(thisPeashooter, thisPlant));
        }
    }

    public void Exit()
    {
        Debug.Log("Exit State");
    }
}
