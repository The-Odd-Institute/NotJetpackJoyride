using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZapperManager : MonoBehaviour
{
    [SerializeField] private InstantiateZapper zapperGenerator;
    [SerializeField] private Vector2 zapperInstantiateYVariance;

    public void SpawnZapper()
    {
        int rotate = Random.Range(0, 2);
        if (rotate == 0)
        {
            zapperGenerator.SetRotating(false);
        }
        else
        {
            zapperGenerator.SetRotating(true);
        }
        zapperGenerator.InstantiateObject(Random.Range(zapperInstantiateYVariance.x, zapperInstantiateYVariance.y));
    }
}
