using System.Collections;
using UnityEngine;

public class SunSpawnManager : MonoBehaviour
{
    [SerializeField] float minX = -2.6f;
    [SerializeField] float maxX = 4f;
    [SerializeField] float minY = -2.25f;
    [SerializeField] float maxY = 1.75f;

    [SerializeField] float spawnInterval = 8f;
    [SerializeField] bool isSpawningSun = true;

    void Start()
    {
        StartCoroutine(SpawnCoroutine());
    }

    IEnumerator SpawnCoroutine()
    {
        while (isSpawningSun)
        {
            yield return new WaitForSeconds(spawnInterval);

            SpawnSun();
        }
    }

    private void SpawnSun()
    {
        float x = Random.Range(minX, maxX);

        Vector3 spawnPos = new Vector3(x, 5f, 0);
        Vector3 targetPos = new Vector3(x, Random.Range(minY, maxY), 0);

        PoolManager.Instance.Spawn(PoolType.Sun, spawnPos, Quaternion.identity).GetComponent<Sun>().Init(targetPos);
    }
}
