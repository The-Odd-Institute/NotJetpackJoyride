using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetpackSound : MonoBehaviour
{
    [SerializeField] private AudioSource JetpackAudio;
    [SerializeField] private PlayerController player;
    private bool JetpackActive = false;
    private MusicSFXController MusicSFX;
    void Start()
    {
        MusicSFX = FindAnyObjectByType<MusicSFXController>();
        JetpackAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!JetpackActive && player.GetJetpackStatus())
        {
            MusicSFX.PlaySound(JetpackAudio, SoundType.JetpackSound);
            JetpackActive = true;
        }
        else if (JetpackActive && !player.GetJetpackStatus())
        {
            JetpackAudio.Stop();
            JetpackActive = false;
        }
    }
}
