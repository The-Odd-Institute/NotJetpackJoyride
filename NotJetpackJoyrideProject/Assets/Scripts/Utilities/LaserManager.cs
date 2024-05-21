using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserManager : MonoBehaviour
{
    [SerializeField] private InstantiateLaser laserGenerator;
    [SerializeField] private Vector2Int laserInstantiateYVariance;

    public void SpawnLaser()
    {
        laserGenerator.InstantiateLaserEvent(Random.Range(laserInstantiateYVariance.x, laserInstantiateYVariance.y));
    }
}
