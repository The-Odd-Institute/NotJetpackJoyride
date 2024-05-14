using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public  class GameManager : MonoBehaviour
{
    [SerializeField] private float scrollSpeed = 10.0f;
    [SerializeField] PlayerController playerController;
  
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
        return scrollSpeed;
    }

    public void SetScrollSpeed(float newSpeed)
    {
        scrollSpeed = newSpeed;
    }

    private void ScrollSpeedHandler()
    {
        if (playerController.GetPlayerDeathStatus())
        {

        }
    }
}
