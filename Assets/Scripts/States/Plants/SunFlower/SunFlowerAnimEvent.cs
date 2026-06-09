using UnityEngine;

public class SunFlowerAnimEvent : MonoBehaviour
{
    SunFlower thisSunFlower;

    void Awake()
    {
        thisSunFlower = GetComponentInParent<SunFlower>();
    }

    public void GenSunEvent()
    {
        thisSunFlower.GenerateSun();
    }
}
