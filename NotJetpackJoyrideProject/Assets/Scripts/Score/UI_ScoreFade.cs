using UnityEngine;
using TMPro;

public class UI_ScoreFade : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI distanceText = default;
    [SerializeField] private TextMeshProUGUI coinText = default;
    [SerializeField] private Transform player = default;

    private Color32 fadeColor = new Color32(255, 255, 255, 50);

    private void Update()
    {
        if (player.localPosition.y > -177.0f)
        {
            distanceText.faceColor = fadeColor;
            coinText.faceColor = fadeColor;
        }
        else
        {
            distanceText.faceColor = Color.white;
            coinText.faceColor = Color.white;
        }
    }
}
