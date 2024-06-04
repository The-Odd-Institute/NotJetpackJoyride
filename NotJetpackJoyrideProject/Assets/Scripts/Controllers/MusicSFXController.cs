using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SoundType
{ 
    Jump = 0,
    PlayerDeath = 1,
    CoinCollect = 2,
    JetpackSound = 3,
    UiClick = 4,
    Laser = 5,
    MissileCountDown = 6,
    MissileLaunch = 7

}


public class MusicSFXController : MonoBehaviour
{
    [SerializeField] private List<AudioClip> sounds;

   public void PlaySound(AudioSource source, SoundType type)
    {
        source.clip = sounds[(int)type];
        source.Play();
    }
}
