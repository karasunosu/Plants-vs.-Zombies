using UnityEngine;

public class SnowPeaAnimEvent : MonoBehaviour
{
    private SnowPea snowPea;

    private void Awake()
    {
        snowPea = GetComponentInParent<SnowPea>();
    }

    public void ShootEvent()
    {
        snowPea.Shoot();
    }
}
