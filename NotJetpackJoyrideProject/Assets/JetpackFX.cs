using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetpackFX : MonoBehaviour
{
    PlayerController playerController;
    ParticleSystem bulletFX;
    // Start is called before the first frame update
    void Start()
    {
        playerController = GetComponentInParent<PlayerController>();
        bulletFX = GetComponentInParent<ParticleSystem>();
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
}
