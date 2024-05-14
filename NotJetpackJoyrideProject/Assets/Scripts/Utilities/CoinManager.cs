using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    [SerializeField] private CoinGenerator coinGenerator;

    public void SpawnCoins()
    {
        coinGenerator.GenerateRandom(coinGenerator.transform.position);
    }
}
