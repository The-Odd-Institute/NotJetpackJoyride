using UnityEngine;
using TMPro;

public class HighScoreManager : MonoBehaviour
{
    [SerializeField] private SOSaveData saveData = default;
    [SerializeField] private TextMeshProUGUI distanceText = default;

    [Header("Startup Config")]
    [SerializeField] bool clearSaveDataOnStart = default;

    private float currentDistance = default;
    [Header("DebugOnly: To Do Update")]
    [SerializeField] private float playerSpeed = default;

    private void Awake()
    {
#if UNITY_EDITOR
        if (saveData == null)
            Debug.LogError("SaveDataManager: Null Reference for saveData. " +
                "Please assign correct file in Folder_Tin/ScriptableObjects/saveData");

        if (distanceText == null)
            Debug.LogError("SaveDataManager: Null Reference for distanceText");
#endif
    }

    private void Start()
    {
        if (clearSaveDataOnStart == false)
            return;

        saveData.UpdateHighDistance(0, true);
    }

    private void OnDisable()
    {
        SaveHighDistanceData();
    }

    private void Update()
    {
        currentDistance += playerSpeed * Time.deltaTime;

        if (currentDistance <= 9)
        {
            distanceText.SetText("000" + ((int)currentDistance).ToString());
        }
        else if (currentDistance <= 99)
        {
            distanceText.SetText("00" + ((int)currentDistance).ToString());
        }
        else if (currentDistance <= 999)
        {
            distanceText.SetText("0" + ((int)currentDistance).ToString());
        }
        else
        {
            distanceText.SetText(((int)currentDistance).ToString());
        }
    }

    public void SaveHighDistanceData()
    {
        saveData.UpdateHighDistance((int)currentDistance);
    }
}