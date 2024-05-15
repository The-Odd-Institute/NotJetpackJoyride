using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public  class GameManager : MonoBehaviour
{
    [SerializeField] private float scrollSpeed = 10.0f;
    [SerializeField] PlayerController playerController;

    private float currentSpeed; 
  
    public void LoadDeathScreen()
    {
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
            currentSpeed -= Mathf.Pow((Time.deltaTime * 10),2);
            currentSpeed = Mathf.Clamp(currentSpeed, 0, 20);
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
