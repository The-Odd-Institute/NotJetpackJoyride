using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetpackFX : MonoBehaviour
{
    [SerializeField] GameObject bullets;
    [SerializeField] GameObject shells;

    PlayerController playerController;
    ParticleSystem bulletFX;
    ParticleSystem shellFX;

    // Start is called before the first frame update
    void Start()
    {
        playerController = GetComponentInParent<PlayerController>();
        bulletFX = bullets.GetComponent<ParticleSystem>();
        shellFX = shells.GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerController == null) 
        {
            playerController = GetComponentInParent<PlayerController>();
            return;
        }
        if (bulletFX == null || shellFX == null)
        {
            bulletFX = bullets.GetComponent<ParticleSystem>();
            shellFX = shells.GetComponent<ParticleSystem>();
            return;
        }
        if (!playerController.GetJetpackStatus() || playerController.GetPlayerDeathStatus()) 
        {
            var emitter = bulletFX.emission;
            emitter.enabled = false;

            var emitterShell = shellFX.emission;
            emitterShell.enabled = false;
        }
        else 
        {
            var emitter = bulletFX.emission;
            emitter.enabled = true;

            var emitterShell = shellFX.emission;
            emitterShell.enabled = true;
        }
    }

    
}
