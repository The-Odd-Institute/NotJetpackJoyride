using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public void LoadMainScene()
    {
        SceneManager.LoadScene(2);
    }

    public void LoadLeaderboardScene()
    {
        SceneManager.LoadScene(3);
    }

    public void LoadMainMenuScene()
    {
        SceneManager.LoadScene(1);
    }

    private void Update()
    {
        if(SceneManager.GetActiveScene().buildIndex == 2 && Input.GetKeyDown(KeyCode.M)) 
        {
            ScoreManager temp = FindAnyObjectByType<ScoreManager>();
            temp.OnGameOver();
            LoadLeaderboardScene();
        }
    }
}
