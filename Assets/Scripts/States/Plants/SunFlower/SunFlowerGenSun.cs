using UnityEngine;

public class SunFlowerGenSun : IState
{

    Plant thisPlant;
    SunFlower thisSunFlower;
    float timeToGen = 0f;

    public SunFlowerGenSun(Plant plant, SunFlower sunFlower)
    {
        thisPlant = plant;
        thisSunFlower = sunFlower;
    }

    public void Enter()
    {
        thisSunFlower.GenSun();
        timeToGen = 1.2f;
    }

    public void Execute()
    {
        if(timeToGen > 0)
        {
            timeToGen -= Time.deltaTime;
            if(timeToGen <= 0)
            {
                thisPlant.ChangeState(new SunFlowerIdle(thisPlant, thisSunFlower));
            }        
        }
    }

    public void Exit()
    {
    }
}
