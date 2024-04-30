using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateLaser : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject laser;
    [SerializeField] private GameObject rightLaser;
    [SerializeField] private GameObject leftLaser;
    private GameObject boxCollider;

    [SerializeField] private LineRenderer _lineRenderer;

    float laserWindup;
    float laserEase;




    void Start()
    {
        //leftLaser = laser.transform.GetChild(1).gameObject;
        //rightLaser = laser.transform.GetChild(2).gameObject;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            InstantiateLaserEvent();
        }
    }

    void InstantiateLaserEvent()
    {
        //lasers ease into frame
        //proly need to lerp smth
        //leftLaser.transform.position

 

        //laser windup


        //activate laser

        boxCollider.SetActive(true);
        //delay a couple seconds


        //ease out
    }

    void LaserActivation()
    {

    }
}
