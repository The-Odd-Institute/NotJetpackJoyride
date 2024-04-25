using System;
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

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        warningTimeCount = 0;
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
        if (rocketEnabled)
        {
            transform.Translate(-rocketSpeed * Time.deltaTime, 0, 0);
            return;
        }
    }

    private void WarningHandler()
    {
        if(warningTimeCount < warningTime/2 && !rocketEnabled)
        {
            warningTimeCount += Time.deltaTime;
            transform.parent.transform.position = new Vector3(transform.parent.position.x, player.transform.position.y, 0);
        }
        else if (warningTimeCount < warningTime && !rocketEnabled)
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player got hit by a rocket. Ouch!");
            Destroy(this.gameObject);
        }
    }
}

