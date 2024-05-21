using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateLight : MonoBehaviour
{
    public float speed = 50.0f;

    void Update()
    {
        transform.Rotate(0, 0, speed * Time.deltaTime); 
    }
}
