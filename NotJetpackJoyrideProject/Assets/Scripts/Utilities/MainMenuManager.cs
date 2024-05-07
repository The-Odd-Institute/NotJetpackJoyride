using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public void LoadMainScene()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadLeaderboardScene()
    {
        SceneManager.LoadScene(2);
    }

    public void LoadMainMenuScene()
    {
        SceneManager.LoadScene(0);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.M)) 
        {
            ScoreManager temp = FindAnyObjectByType<ScoreManager>();
            temp.OnGameOver();
            LoadLeaderboardScene();
        }
    }
}
