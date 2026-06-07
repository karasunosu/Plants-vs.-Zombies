using UnityEngine;

// Lưu thông tin cấu hình cho từng pool
[System.Serializable]
public class PoolData
{   
    public PoolType poolType;
    public GameObject prefab;
    public Transform parent;
    public int defaultSize = 10;
    public int maxSize = 50;
}
