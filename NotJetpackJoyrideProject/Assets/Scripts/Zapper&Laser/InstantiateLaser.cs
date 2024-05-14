using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InstantiateLaser : MonoBehaviour
{
    [SerializeField] private GameObject laserPrefab;

    private GameObject newLaser = null;

    //[SerializeField] private float laserPositionY;
    //used to determine the height of the laser


    private float elapsedTime;

    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.L))
        //{
        //    InstantiateLaserEvent(laserPositionY);
        //}

    }
    public void InstantiateLaserEvent(float laserPositionY)
    {
        newLaser = Instantiate(laserPrefab, new Vector2(gameObject.transform.position.x, laserPositionY), Quaternion.identity);
    }
}
