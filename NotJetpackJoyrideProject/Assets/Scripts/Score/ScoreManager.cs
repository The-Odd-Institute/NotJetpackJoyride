using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour, IDataPersistence
{
    private int coinsCollected = 0;
    private float currentScore = 0;
    private int highestScore = 0;

    private bool isRunning = true;

    [Range(1, 20), SerializeField] private float scoreIncrementSpeed = 1;
    [Range(0,10), SerializeField] private int coinsConvertMultiplier = 1;
    [SerializeField] private bool incrementDistanceOnDeath = true;

    private void Start()
    {
        DataPersistenceManager.instance.LoadGame();
        isRunning = true;
    }

    private void Update()
    {
        if (!isRunning) return;

        currentScore += Time.deltaTime * scoreIncrementSpeed;
    }

    //Convert all the coin to score when the game is over
    private void ConvertCoinToScore()
    {
        currentScore += coinsCollected * coinsConvertMultiplier;
    }

    public void SaveData(ref GameData gameData)
    {
        if(currentScore > highestScore) 
        {
            gameData.highestScore = Mathf.RoundToInt(currentScore);
            gameData.coinCollected = coinsCollected;
        }
    }

    public void LoadData(GameData gameData) 
    {
        highestScore = gameData.highestScore;
    }

    public void AddCoin()
    {
        coinsCollected++;
    }

    public void OnGameOver()
    {
        isRunning = false;
        //ConvertCoinToScore();
        DataPersistenceManager.instance.SaveGame();
    }

    public void StopDistanceIncrement()
    {
        if (incrementDistanceOnDeath) return;
        isRunning = false;
    }

    public int GetScore { get { return Mathf.RoundToInt(currentScore); } }
    public int GetCoin {  get { return coinsCollected; } }
}
