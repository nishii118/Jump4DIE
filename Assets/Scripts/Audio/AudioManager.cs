using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{
    AudioSource backgroundMusic;
    AudioSource[] soundEffects;

    [SerializeField] AudioClip backgroundMusicClip;
    [SerializeField] AudioClip[] soundEffectsClip;

    private bool canPlaySFX;
    private bool canPlayBGM;

    public bool GetCanPlayiSFX()
    {
        return canPlaySFX;
    }

    public bool GetCanPlayBGM() { return canPlayBGM; }

    private void Start()
    {
        backgroundMusic = gameObject.AddComponent<AudioSource>();
        backgroundMusic.clip = backgroundMusicClip;
        backgroundMusic.loop = true;
        backgroundMusic.volume = 0.5f;
        backgroundMusic.Play();

        soundEffects = new AudioSource[soundEffectsClip.Length];
        for (int i = 0; i< soundEffectsClip.Length; i++)
        {
            soundEffects[i] = gameObject.AddComponent<AudioSource>();
            soundEffects[i].clip = soundEffectsClip[i];
        }

        canPlaySFX = true;
        canPlayBGM = true;
    }
    
    public void PlaySFX(int index)
    {
        soundEffects[index].Play();
    }

    //public void StopSFX() {
    //    canPlayingSFX = false;
    //}

    public void PlayBackGroundMusic()
    {
        backgroundMusic.Play();
    }

    public void StopBackGroundMusic()
    {
        backgroundMusic.Stop();
    }


    public void ToggleBackgroundMusicState()
    {
        canPlayBGM = !canPlayBGM;
        if (canPlayBGM)
        {
            backgroundMusic.Play();
        }
        else {
            backgroundMusic.Stop();
        }
    }

    public void ToggleSFXMusicState()
    {
        canPlaySFX = !canPlaySFX;
        
    }

    
}
