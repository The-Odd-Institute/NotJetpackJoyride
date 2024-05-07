using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreUIHandler : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI coinText;

    ScoreManager scoreManager;

    private void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
        scoreText.text = "Distance: " + 0;
        coinText.text = "Coin " + 0;
    }

    private void Update()
    {
        scoreText.text = "Distance: " + scoreManager.GetScore;
        coinText.text = "Coin: " + scoreManager.GetCoin;
    }
}
