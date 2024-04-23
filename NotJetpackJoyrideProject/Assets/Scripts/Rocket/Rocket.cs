using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    [SerializeField] private GameObject warning;
    [SerializeField] private float rocketSpeed;

    private GameObject player;
    private float warningTime = 2.0f;
    private float warningTimeCount;
    private bool rocketEnabled;
    private float rocketLifeTime = 2.0f;
    private float rocketLifeTimeCount;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        transform.parent.transform.position = new Vector3(transform.parent.position.x,player.transform.position.y,0);  
        warningTimeCount = 0;
        rocketLifeTimeCount = 0;
        warning.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        WarningHandler();
        RocketHandler();
    }

    private void RocketHandler()
    {
        if (rocketLifeTimeCount >= rocketLifeTime)
        {
            Destroy(this.gameObject);
        }
        if (rocketEnabled)
        {
            transform.Translate(-rocketSpeed, 0, 0);
            rocketLifeTimeCount += Time.deltaTime;
            return;
        }
    }

    private void WarningHandler()
    {
        if (warningTimeCount < warningTime)
        {
            warningTimeCount += Time.deltaTime;
        }
        if (warningTimeCount >= warningTime)
        {
            warningTimeCount = 0;
            warning.SetActive(false);
            rocketEnabled = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player got hit by a rocket. Ouch!");
            Destroy(this.gameObject);
        }
    }
}
