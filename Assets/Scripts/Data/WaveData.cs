using System.Collections.Generic;
using UnityEngine;

// Zombie wave
[System.Serializable]
public class WaveData
{
    public float timeStart;
    public List<ZombieSpawnData> zombies;
}
