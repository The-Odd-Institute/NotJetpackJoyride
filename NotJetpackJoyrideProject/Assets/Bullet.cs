using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] GameObject shrapnel;
    private List<ParticleCollisionEvent> collisionEvents;
    ParticleSystem bulletFX;

    private void Start()
    {
        bulletFX = GetComponent<ParticleSystem>();
        collisionEvents = new List<ParticleCollisionEvent>();
    }
    private void OnParticleCollision(GameObject other)
    {
        int numCollisionEvents = bulletFX.GetCollisionEvents(other, collisionEvents);
        int i = 0;
        while (i < numCollisionEvents)
        {
            Vector3 collisionHitLoc = collisionEvents[i].intersection;
            Instantiate(shrapnel, collisionHitLoc, Quaternion.identity);
            i++;
        }
    }
}
