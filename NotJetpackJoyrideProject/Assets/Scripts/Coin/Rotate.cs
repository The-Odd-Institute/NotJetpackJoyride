using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField] private float rotateSpeed = default;
    
    [SerializeField] private bool clockWiseRotation = true;
    private int reverseRotation;

    private bool isRotating = default;
    public bool IsRotating { get { return isRotating; } set { isRotating = value; } }


    [SerializeField] private GameObject rotateAround = null;

    // Start is called before the first frame update
    void Start()
    {
       switch (clockWiseRotation) 
        {
            case true:
                reverseRotation = -1; break;

            case false:
                reverseRotation = 1; break;
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (isRotating)
        {
            if (rotateAround == null)
            {
                transform.Rotate(0, 0, rotateSpeed * reverseRotation * Time.deltaTime);
            }
            else
            {
                transform.RotateAround(rotateAround.transform.position, Vector3.forward, rotateSpeed * reverseRotation * Time.deltaTime);
            }
        }
    }
}
