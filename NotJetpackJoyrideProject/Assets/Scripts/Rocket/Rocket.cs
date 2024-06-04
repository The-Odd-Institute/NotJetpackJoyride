using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    [SerializeField] private GameObject warning;
    [SerializeField] private GameObject warningTriangle;
    [SerializeField] private float rocketSpeed;
    [SerializeField] private float warningTime;

    private GameObject player;
    private float warningTimeCount;
    private bool rocketEnabled;
    
    public bool targetPlayer = false;
    public bool followPlayer = false;

    // Start is called before the first frame update

    private void OnEnable()
    {
        if(player == null)
        {
            player = GameObject.Find("Player");
        }
        warningTimeCount = 0;
        warning.SetActive(true);
        targetPlayer = false;
        followPlayer = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (rocketEnabled) 
        { 
            RocketHandler(); 
        }
        else 
        { 
            WarningHandler();
            if (followPlayer)
            {
                SnapToPlayerPosition();
            }
            else if (targetPlayer) 
            { 
                SnapToPlayerPosition();
                targetPlayer = false;
            }
        }
    }

    private void RocketHandler()
    {
        transform.Translate(-rocketSpeed * Time.deltaTime, 0, 0);
        return;
    }

    private void WarningHandler()
    {
        if(warningTimeCount < warningTime/2)
        {
            warningTimeCount += Time.deltaTime;
            
        }
        else if (warningTimeCount < warningTime)
        {
            warningTimeCount += Time.deltaTime;
            warningTriangle.SetActive(true);
        }
        if (warningTimeCount >= warningTime)
        {
            warningTimeCount = 0;
            warning.SetActive(false);
            warningTriangle.SetActive(false);
            rocketEnabled = true;
        }
    }

    private void SnapToPlayerPosition()
    {
        transform.position = new Vector3(transform.parent.position.x, player.transform.position.y, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
         //   Debug.Log("Player got hit by a rocket. Ouch!");
            Destroy(this.gameObject);
        }
    }
}

