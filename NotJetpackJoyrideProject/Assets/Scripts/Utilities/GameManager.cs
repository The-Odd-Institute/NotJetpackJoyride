using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;

public class GameManager : MonoBehaviour
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
            //Debug.Log("Revival screen is active, timer: " + timer); 
            timer += Time.deltaTime;
            if (timer >= revivalTime)
            {
                Debug.Log("Time is up, loading death screen");
                LoadDeathScreen();
                timer = 0.0f;
            }
        }
    }

    public void LoadRevivalScreen()
    {
        if (!isRevivalScreenActive)
        {
            Debug.Log("Loading revival screen");
            revivalScreen.SetActive(true);
            timer = 0.0f;
            isRevivalScreenActive = true;
        }
    }

    public void RevivePlayer()
    {
        Debug.Log("Reviving player");
        playerController.Revive();
        revivalScreen.SetActive(false);
        isRevivalScreenActive = false;
        timer = 0.0f;
    }

    public void LoadDeathScreen()
    {
        if(playerController.GetPlayerDeathStatus()==true)
        {
            ScoreManager temp = FindAnyObjectByType<ScoreManager>();
            temp.OnGameOver(); // crashes here
            SceneManager.LoadScene(2);
        }
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
