using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateLaser : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject laserPrefab;
    private GameObject rightLaser;
    private GameObject leftLaser;
    private GameObject boxCollider;

    [SerializeField] private LineRenderer _lineRenderer;

    [SerializeField] private float laserWindup;
    [SerializeField] private float laserEase;

    [SerializeField] private float windupWidth;


    void Start()
    {
        leftLaser = laserPrefab.transform.GetChild(1).gameObject;
        rightLaser = laserPrefab.transform.GetChild(2).gameObject;
        boxCollider = laserPrefab.transform.GetChild(3).gameObject;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            InstantiateLaserEvent();
        }
    }

    public void InstantiateLaserEvent()
    {
        //lasers ease into frame
        //proly need to lerp smth
        //leftLaser.transform.position



        //laser windup
        _lineRenderer.startWidth = windupWidth;

        //activate laser
        LaserActivation();

        boxCollider.SetActive(true);
        //delay a couple seconds


        //ease out
    }

    void LaserActivation()
    {

    }
}
