using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHitNpc : MonoBehaviour
{
    //[SerializeField] GameObject Scientist;
    private void OnParticleCollision(GameObject collision)
    {
        Debug.Log("Collided with: " + collision.gameObject.name);

        if (collision.gameObject.layer == 10)
        {
            Debug.Log("Scientist shot");
            gameObject.GetComponent<scientist>().HandleDeath();
        }
    }
}
