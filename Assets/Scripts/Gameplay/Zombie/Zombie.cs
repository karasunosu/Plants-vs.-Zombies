using UnityEngine;

public class Zombie : MonoBehaviour
{
    public const string Zombie_Tag = "Zombie";

    public bool IsAttackable(float y)
    {
        return Mathf.Abs(transform.position.y - y) < 0.01f;
    }
}
