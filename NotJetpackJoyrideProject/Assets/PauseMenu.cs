using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(pauseMenu.activeSelf == true)
        {
            Time.timeScale = 0.0f;
        }
        else
        {
            Time.timeScale = 1.0f;
        }
        InputHandler();
    }
    private void InputHandler()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePauseMenu();
        }
    }

    public void TogglePauseMenu()
    {
        pauseMenu.SetActive(!pauseMenu.activeSelf);
    }

    public void RestartButton()
    {
        SceneManager.LoadScene(1);
    }

    public void MainMenuButton()
    {
        SceneManager.LoadScene(0);
    }

    public void ContinueButton()
    {
        pauseMenu.SetActive(!pauseMenu.activeSelf);
    }

    private void TouchInputHandler()
    {

    }
}
