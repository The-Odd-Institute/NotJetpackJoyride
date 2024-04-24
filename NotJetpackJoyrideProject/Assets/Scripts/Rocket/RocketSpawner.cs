using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class RocketSpawner : MonoBehaviour
{
    private static RocketSpawner instance = null;
    [SerializeField] GameObject rocket;
    private RocketSpawner()
    {
    }

    public static RocketSpawner Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new RocketSpawner();
            }
            return instance;
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            SpawnRockets(3, 1.5f);
        }
    }

    public void SpawnRocket()
    {
        Instantiate(rocket,this.transform);
    }

    public void SpawnRockets(int numRockets, float offsetTime)
    {
        for(int i = 0; i < numRockets; i++)
        {
            Invoke(nameof(SpawnRocket), i * offsetTime);
        }
    }
}