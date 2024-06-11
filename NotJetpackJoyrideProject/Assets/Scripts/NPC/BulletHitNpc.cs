using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHitNpc : MonoBehaviour
{
    //[SerializeField] GameObject Scientist;
    private void OnParticleCollision(GameObject collision)
    {
        Debug.Log("Collided with: " + collision.gameObject.name);

        if (collision.layer == 12)
        {
            Debug.Log("Scientist shot");
            collision.GetComponent<scientist>().HandleDeath();
        }
    }
}
