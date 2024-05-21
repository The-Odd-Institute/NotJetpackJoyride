using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightManipulator : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rb2D;

    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        Vector3 forward = transform.TransformDirection(Vector3.forward) * 10;
        Debug.DrawRay(transform.position, forward, Color.green);

        RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up);

        // If it hits something...
        if (hit.collider != null)
        {

            float distance = Mathf.Abs(hit.point.y - transform.position.y);

            rb2D.AddForce(Vector3.up * hit.point.x);
        }
    }
}
