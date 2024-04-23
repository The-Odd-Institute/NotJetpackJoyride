using UnityEngine;

public class ScoreTracking : MonoBehaviour, IDataPersistence
{
    private float scores = 0;
    [SerializeField] private float moveSpeed = 10; //Might need to change later 

    public void LoadData(GameData data)
    {
        scores = data.HighestScore;
    }
    public void SaveData(ref GameData data)  
    {
        data.HighestScore = scores;
    }

    private void Update()
    {
        scores += moveSpeed / 2 * Time.deltaTime;
    }
}
