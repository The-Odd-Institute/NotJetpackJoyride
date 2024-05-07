using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZapperManager : MonoBehaviour
{
    [SerializeField] private InstantiateZapper zapperGenerator;

    public void SpawnZapper()
    {
        zapperGenerator.InstantiateObject(Random.Range(-5, 5));
    }
}
