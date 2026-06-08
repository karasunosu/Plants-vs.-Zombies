using System.Collections;
using UnityEngine;

public class ZomSpawnManager : MonoBehaviour
{
    [SerializeField] LevelData levelData;
    [SerializeField] Transform[] spawnPos;

    [SerializeField] float minTimeBetweenZomSpawnInWave = 2f;
    [SerializeField] float maxTimeBetweenZomSpawnInWave = 10f;

    void Start()
    {
        StartCoroutine(LevelSpawn());
    }

    IEnumerator LevelSpawn()
    {
        foreach(var wave in levelData.waves)
        {
            yield return new WaitForSeconds(wave.timeStart); // doi 1 khoang thoi gian = time start cho tung wave roi moi spawn

            StartCoroutine(SpawnWave(wave));
        }
    }

    IEnumerator SpawnWave(WaveData wave)
    {
        foreach (ZombieSpawnData data in wave.zombies)
        {
            for(int i = 0; i < data.amount; i++)
            {
                SpawnZombie(data.type);
                
                yield return new WaitForSeconds(GetRandomTimeSpawnZomInWave());
            }
        }
    }    

    void SpawnZombie(PoolType type)
    {
        int lane = Random.Range(0, spawnPos.Length);

        GameObject zombie = PoolManager.Instance.Spawn(type, spawnPos[lane].position, Quaternion.identity);
    }

    float GetRandomTimeSpawnZomInWave()
    {
        return Random.Range(minTimeBetweenZomSpawnInWave, maxTimeBetweenZomSpawnInWave);
    }
}
