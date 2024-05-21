using UnityEngine;
using TMPro;


public class MainMenuScoreDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI highestScoreText;

    private void Start()
    {
        highestScoreText.text = "High Score: " + DataPersistenceManager.instance.GetGameData().highestScore + "M";
    }
}
