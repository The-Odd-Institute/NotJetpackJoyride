using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public  class GameManager : MonoBehaviour
{
    [SerializeField] private float scrollSpeed = 10.0f;
    [SerializeField] PlayerController playerController;
    
    float playerSlideTime;
    private float currentSpeed; 
  
    public void LoadDeathScreen()
    {
        ScoreManager temp = FindAnyObjectByType<ScoreManager>();
        temp.OnGameOver();
        SceneManager.LoadScene(2);
    }
    public  void CaptureScreenshot(string filename, int superSize)
    {
        ScreenCapture.CaptureScreenshot("Death.png");
    }

    public float GetScrollSpeed()
    {
        if(playerController.GetPlayerDeathStatus())
        {
            playerSlideTime = scrollSpeed / 2;
            currentSpeed -= (currentSpeed/ playerSlideTime * Time.deltaTime);
            currentSpeed = Mathf.Clamp(currentSpeed, 0, 20);
            if(currentSpeed < 1) { currentSpeed = 0.5f; }
        }
        else
        {
            currentSpeed = scrollSpeed;
        }
        return currentSpeed;
    }

    public void SetScrollSpeed(float newSpeed)
    {
        scrollSpeed = newSpeed;
    }
}
