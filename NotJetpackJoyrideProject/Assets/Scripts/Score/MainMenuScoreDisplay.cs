using UnityEngine;
using TMPro;

public class MainMenuScoreDisplay : MonoBehaviour, IDataPersistence
{
    [SerializeField] private TextMeshProUGUI highestScoreText;
    public void SaveData(ref GameData gameData) { return;}

    public void LoadData(GameData gameData)
    {
        highestScoreText.text = "Furthest Distance: " + gameData.highestScore.ToString() + "M";
    }
}
