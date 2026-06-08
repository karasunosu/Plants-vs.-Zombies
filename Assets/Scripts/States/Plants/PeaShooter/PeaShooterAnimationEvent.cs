using UnityEngine;

public class PeaShooterAnimationEvent : MonoBehaviour
{
    private PeaShooter peaShooter;

    private void Awake()
    {
        peaShooter = GetComponentInParent<PeaShooter>();
    }

    public void ShootEvent()
    {
        peaShooter.Shoot();
    }
}
