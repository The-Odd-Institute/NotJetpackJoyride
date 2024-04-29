using UnityEngine;
using TMPro;

public class DistanceText : MonoBehaviour, IDataPersistence
{
    [SerializeField] private TextMeshProUGUI distanceText;
    [SerializeField] private TextMeshProUGUI highestScoreText;

    [SerializeField] private int scoreIncrementSpeed = 5;
    private int score = 0;
    private float floatScore = 0;

    public void SaveData(ref GameData gameData)
    {
        if(gameData.HighestScore < score)
        {
            gameData.HighestScore = score;
        }
    }

    public void LoadData(GameData gameData)
    {
        highestScoreText.text = "Furthest Distance: " + gameData.HighestScore.ToString() + "M";
    }

    void Update()
    {
        floatScore += scoreIncrementSpeed * Time.deltaTime;
        score = Mathf.RoundToInt(floatScore);

        distanceText.text = "Distance: " + score.ToString() + "M";
    }
}
