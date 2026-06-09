using UnityEngine;

public class SunFlower : MonoBehaviour
{
    [SerializeField] float generateInterval = 15f;

    Plant thisSunFlower;

    void Awake()
    {
        thisSunFlower = GetComponent<Plant>();
    }

    void Start()
    {
        thisSunFlower.ChangeState(new SunFlowerIdle(thisSunFlower, this));
    }

    public void Idle()
    {
        thisSunFlower.ChangeAnim(ANIM_SUN_FLOWER_IDLE);
    }

    public void GenSun()
    {
        thisSunFlower.ChangeAnim(ANIM_SUN_FLOWER_GENSUN);
    }

    public void GenerateSun()
    {
        Vector3 spawnPos = transform.position + Vector3.up * 0.5f + Vector3.right * 0.3f; // luc spawn thi bay len 1 doan
        Vector3 dropPos = spawnPos + Vector3.down * 0.5f;

        PoolManager.Instance.Spawn(PoolType.Sun, spawnPos, Quaternion.identity).GetComponent<Sun>().Init(dropPos);
    }

    public float GetGenerateInterval()
    {
        return generateInterval;
    }

    public const string ANIM_SUN_FLOWER_IDLE = "Idle";
    public const string ANIM_SUN_FLOWER_GENSUN = "GenSun";
}
