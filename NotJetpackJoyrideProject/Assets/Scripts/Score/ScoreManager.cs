using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour, IDataPersistence
{
    private int coinsCollected = 0;
    private int currentScore = 0;
    private float fScore = 0.0f;
    private int highestScore = 0;

    private bool isRunning = true;

    [Range(1, 20), SerializeField] private float scoreIncrementSpeed = 1;
    [Range(0,10), SerializeField] private int coinsConvertMultiplier = 1;

    private void Start()
    {
        DataPersistenceManager.instance.LoadGame();
    }

    private void Update()
    {
        if (!isRunning) return;

        fScore += Time.deltaTime * scoreIncrementSpeed;
        currentScore = Mathf.RoundToInt(fScore);
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
            gameData.highestScore = currentScore;
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
        ConvertCoinToScore();
        DataPersistenceManager.instance.SaveGame();
    }

    public int GetScore { get { return currentScore; } }
    public int GetCoin {  get { return coinsCollected; } }
}
