using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHits : MonoBehaviour
{
    public GameObject npcParent; 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Trigger enter detected");
        Debug.Log("Collided with: " + collision.gameObject.name);

        if (collision.gameObject.layer == LayerMask.NameToLayer("Bullet"))
        {
            npcParent.GetComponent<scientist>().HandleDeath();
        }
    }
}
