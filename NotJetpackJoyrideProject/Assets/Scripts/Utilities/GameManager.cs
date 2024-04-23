using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public int highscore;
    public int lastscore;
    void Start()
    {
       

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LoadMainScene()
    {
        SceneManager.LoadScene(2);
    }
}
