using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZapperManager : MonoBehaviour
{
    [SerializeField] private InstantiateZapper zapperGenerator;
    [SerializeField] private Vector2Int zapperInstantiateYVariance;

    public void SpawnZapper()
    {
        zapperGenerator.InstantiateObject(Random.Range(zapperInstantiateYVariance.x, zapperInstantiateYVariance.y));
    }
}
