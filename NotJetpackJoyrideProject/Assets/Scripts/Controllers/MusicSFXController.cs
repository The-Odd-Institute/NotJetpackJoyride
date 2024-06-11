using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SoundType
{ 
    Jump,
    PlayerDeath,
    CoinCollect,
    JetpackSound,
    UiClick,
    Laser,
    MissileCountDown,
    MissileLaunch

}


public class MusicSFXController : MonoBehaviour
{
    [SerializeField] private AudioSource bgSource;
    [SerializeField] private List<AudioClip> sounds;
   
    public void PlaySound(AudioSource source, SoundType type)
    {
        source.clip = sounds[(int)type];
        source.Play();
    }
    public void UiSFX()
    {
        PlaySound(bgSource, SoundType.UiClick);
    }
}
