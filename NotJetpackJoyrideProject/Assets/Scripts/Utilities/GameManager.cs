using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    /*
    [SerializeField] float killTime;
    public void KillPlayer()
    {
        StartCoroutine(Delay());
    }
    IEnumerator Delay()
    {

        yield return new WaitForSeconds(killTime);
    }
    */
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.M))
        {
            SceneManager.LoadScene(2);

        }

    }


}
