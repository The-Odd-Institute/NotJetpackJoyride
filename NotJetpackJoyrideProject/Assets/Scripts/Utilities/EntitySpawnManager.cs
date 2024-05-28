using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntitySpawnManager : MonoBehaviour
{
    [SerializeField] private CoinManager coinManager;
    [SerializeField] private ZapperManager zapperManager;
    [SerializeField] private RocketManager rocketManager;
    [SerializeField] private LaserManager laserManager;
    [SerializeField] private ScientistManager scientistManager;
    [SerializeField] private float zapperCoinSpawnDelay;
    [SerializeField] private float delayAfterCoinSpawn;
    [SerializeField] private float delayAfterZapperSpawn;
    [SerializeField] private float rocketLaserSpawnDelay;
    [SerializeField] private float delayAfterRocketSpawn;
    [SerializeField] private float delayAfterLaserSpawn;
    [SerializeField] private float scientistSpawnDelay;

    private float currentZapperCoinTimer = 0.0f;
    private float currentRocketLaserTimer = 0.0f;

    private float currentScientistTimer = 0.0f;

    public void Update()
    {
        currentZapperCoinTimer += Time.deltaTime;
        currentRocketLaserTimer += Time.deltaTime;
        currentScientistTimer += Time.deltaTime;

        if (currentZapperCoinTimer > zapperCoinSpawnDelay)
        {
            int zapperOrCoin = Random.Range(0, 5);
            if (zapperOrCoin == 0)
            {
                coinManager.SpawnCoins();
                zapperCoinSpawnDelay = delayAfterCoinSpawn;
            }
            else
            {
                zapperManager.SpawnZapper();
                zapperCoinSpawnDelay = delayAfterZapperSpawn;
            }
            currentZapperCoinTimer = 0.0f;
        }
        if (currentRocketLaserTimer > rocketLaserSpawnDelay)
        {
            int rocketOrLaser = Random.Range(0, 5);
            if (rocketOrLaser == 0)
            {
                laserManager.SpawnLaser();
                rocketLaserSpawnDelay = delayAfterLaserSpawn;
            }
            else
            {
                rocketManager.SpawnRockets();
                rocketLaserSpawnDelay = delayAfterRocketSpawn;
            }
            currentRocketLaserTimer = 0.0f;
        }
        if (currentScientistTimer > scientistSpawnDelay)
        {
            scientistManager.SpawnScientist();
            currentScientistTimer = 0.0f;
        }
    }
}
