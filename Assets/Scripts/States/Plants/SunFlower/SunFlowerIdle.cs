using UnityEngine;

public class SunFlowerIdle : IState
{
    Plant thisPlant;
    SunFlower thisSunFlower;
    float time;

    public SunFlowerIdle(Plant plant, SunFlower sunFlower)
    {
        thisPlant = plant;
        thisSunFlower = sunFlower;
    }

    public void Enter()
    {
        thisSunFlower.Idle();
        time = thisSunFlower.GetGenerateInterval();
    }

    public void Execute()
    {
        if(time > 0)
        {
            time -= Time.deltaTime;
            if(time <= 0)
            {
                thisPlant.ChangeState(new SunFlowerGenSun(thisPlant, thisSunFlower));
            }        
        }

    }

    public void Exit()
    {
    }

}
