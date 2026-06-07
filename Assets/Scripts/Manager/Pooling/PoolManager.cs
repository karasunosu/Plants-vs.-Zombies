using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class PoolManager : MonoBehaviour
{
    public static PoolManager Instance;

    [SerializeField] private List<PoolData> poolConfig; // chua cac loai pool

    private Dictionary<PoolType, ObjectPool<GameObject>> poolDictionary; // list cac pool

    void Awake()
    {
        Instance = this;

        poolDictionary = new();

        foreach(PoolData poolData in poolConfig)
        {
            CreatePool(poolData);
        }
    }

    void CreatePool(PoolData data)
    {
        ObjectPool<GameObject> pool = new ObjectPool<GameObject>(
            () => CreateObject(data), OnGetFromPool, OnReleaseToPool, OnDestroyPooledObject, true, data.defaultSize, data.maxSize);
        poolDictionary.Add(data.poolType, pool);
    }

    public GameObject Spawn(PoolType type, Vector3 position, Quaternion rotation)
    {
        if (!poolDictionary.ContainsKey(type))
        {
            Debug.LogError("Pool does not exist type: " + type);
            return null;
        }

        GameObject obj = poolDictionary[type].Get();
        obj.transform.SetPositionAndRotation(position, rotation);
        return obj;
    }

    public void Return(PoolType type, GameObject obj)
    {
        if (!poolDictionary.ContainsKey(type))
        {
            Debug.LogError("Pool does not exist type: " + type);
            return;
        }

        poolDictionary[type].Release(obj);
    }

    GameObject CreateObject(PoolData data)
    {
        GameObject obj = Instantiate(data.prefab, data.parent);
        return obj;
    }

    void OnGetFromPool(GameObject obj)
    {
        obj.SetActive(true);
    }

    void OnReleaseToPool(GameObject obj)
    {
        obj.SetActive(false);
    }

    void OnDestroyPooledObject(GameObject obj)
    {
        Destroy(obj);
    }

}
