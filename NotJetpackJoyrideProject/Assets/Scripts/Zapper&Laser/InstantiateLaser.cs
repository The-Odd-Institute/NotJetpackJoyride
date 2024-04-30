using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateLaser : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject laser;
    private GameObject rightLaser;
    private GameObject leftLaser;
    private GameObject boxCollider;

    float laserWindup;
    float laserEaseIn;

    void Start()
    {
        leftLaser = laser.transform.GetChild(1).gameObject;
        rightLaser = laser.transform.GetChild(2).gameObject;
    }

    void Update()
    {
        

       

    }

    void InstantiateLaserEvent()
    {
        //lasers ease into frame


        //laser windup


        //activate laser

        boxCollider.SetActive(true);
    }

    void LaserActivation()
    {

    }
}
