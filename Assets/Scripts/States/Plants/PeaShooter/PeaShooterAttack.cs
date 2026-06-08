using UnityEngine;

public class PeaShooterAttack : IState
{
    PeaShooter thisPeashooter;
    Plant thisPlant;
    float shootTime;

    public PeaShooterAttack(PeaShooter peaShooter, Plant plant)
    {
        thisPeashooter = peaShooter;
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
        if (!thisPeashooter.IsHaveZombieInLane())
        {
            thisPlant.ChangeState(new PeaShooterIdle(thisPeashooter, thisPlant));
            return;
        }

        shootTime -= Time.deltaTime;
        if(shootTime <= 0)
        {
            thisPeashooter.Attack();
            shootTime = thisPeashooter.GetFireRate();
        }
    }

    public void Exit()
    {
    }
}
