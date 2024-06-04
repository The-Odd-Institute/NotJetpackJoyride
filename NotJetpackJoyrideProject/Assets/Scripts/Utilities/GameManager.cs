using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public  class GameManager : MonoBehaviour
{
    [SerializeField] private float scrollSpeed = 10.0f;
    [SerializeField] PlayerController playerController;
    [SerializeField] GameObject revivalScreen;
    [SerializeField] private float revivalTime = 5.0f; // time before loading death screen

    private float currentSpeed;
    private float timer = 0.0f;
    private bool isRevivalScreenActive = false;

    void Start()
    {
        revivalScreen.SetActive(false);
    }

    void Update()
    {
        if (isRevivalScreenActive)
        {
            timer += Time.deltaTime;
            if (timer >= revivalTime)
            {
                LoadDeathScreen();
            }
        }
    }

    public void LoadRevivalScreen()
    {
        revivalScreen.SetActive(true);
        timer = 0.0f;
        isRevivalScreenActive = true;
    }

    public void RevivePlayer()
    {
        playerController.Revive();
        revivalScreen.SetActive(false);
        isRevivalScreenActive = false;
    }

    public void LoadDeathScreen()
    {
        ScoreManager temp = FindAnyObjectByType<ScoreManager>();
        temp.OnGameOver();
        SceneManager.LoadScene(2);
    }

    public void CaptureScreenshot(string filename, int superSize)
    {
        ScreenCapture.CaptureScreenshot("Death.png", 1);
    }

    public float GetScrollSpeed()
    {
        if (playerController.GetPlayerDeathStatus())
        {
            currentSpeed -= ((currentSpeed / 15) * Time.deltaTime);
            currentSpeed = Mathf.Clamp(currentSpeed, 0, 20);
            if (currentSpeed < 1.0f) { currentSpeed = 0.0f; }
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
