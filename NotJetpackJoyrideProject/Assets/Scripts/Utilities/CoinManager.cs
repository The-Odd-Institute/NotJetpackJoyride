using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    [SerializeField] private CoinGenerator coinGenerator;
    [SerializeField] private float spawnDelay;

    private float currentTimer = 0.0f;

    public void Update()
    {
        currentTimer += Time.deltaTime;
        if (currentTimer > spawnDelay)
        {
            SpawnCoins();
            currentTimer = 0.0f;
        }
    }

    private void SpawnCoins()
    {
        coinGenerator.GenerateRandom(transform.position);
    }
}
