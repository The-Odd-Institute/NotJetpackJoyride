using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        if (pauseMenu.activeSelf == true)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                pauseMenu.SetActive(false);
            }

        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                pauseMenu.SetActive(true);
            }
        }
    }

    private void TouchInputHandler()
    {

    }
}
