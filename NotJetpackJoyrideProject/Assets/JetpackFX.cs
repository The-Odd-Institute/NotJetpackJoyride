using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetpackFX : MonoBehaviour
{
    [SerializeField] GameObject shrapnel;
    PlayerController playerController;
    ParticleSystem bulletFX;
    private List<ParticleCollisionEvent> collisionEvents;
    // Start is called before the first frame update
    void Start()
    {
        playerController = GetComponentInParent<PlayerController>();
        bulletFX = GetComponentInParent<ParticleSystem>();
        collisionEvents = new List<ParticleCollisionEvent>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerController == null) 
        {
            playerController = GetComponentInParent<PlayerController>();
            return;
        }
        if (bulletFX == null)
        {
            bulletFX = GetComponentInParent<ParticleSystem>();
            return;
        }
        if (playerController.GetJetpackStatus()) 
        { 
            //bulletFX.Play();
            var emitter = bulletFX.emission;
            emitter.enabled = true;
        }
        else 
        { 
            //bulletFX.Stop();
            var emitter = bulletFX.emission;
            emitter.enabled = false;
        }
    }

    private void OnParticleCollision(GameObject other)
    {
        //int safeLength = bulletFX.GetSafeCollisionEventSize();
        //if (collisionEvents.Length < safeLength)
        //    collisionEvents = new ParticleCollisionEvent[safeLength];
        //int random = Random.Range(0, 2);
        //if(random == 1)
        //{
        //    return;
        //}
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
