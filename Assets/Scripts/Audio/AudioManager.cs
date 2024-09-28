using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AudioManager : Singleton<AudioManager>
{
    public Sound[] musicSounds, sfxSounds;
    public AudioSource musicSource, sfxSource;

    private void Start()
    {
        PlayMusic("Background");
    }
    public static bool GetToggleState(string key)
    {
        return PlayerPrefs.GetInt(key, 1) == 1 ? true : false;
    }
    public static void ToggleState(string key)
    {
        //PlayerPrefs.SetInt(key, PlayerPrefs.GetInt(key, 1));
        //if(key=="Music")
        //{
        //    //TODO: stop or play Music (background)
        //}

        int currentState = PlayerPrefs.GetInt(key, 1);
        int newState = currentState == 1 ? 0 : 1;
        PlayerPrefs.SetInt(key, newState);

        if (key == "Music")
        {
           if (newState == 0)
            {
                AudioManager.Instance.StopMusic("Background");
            } else
            {
                AudioManager.Instance.PlayMusic("Background");

            }
        }
    }
    public void PlayMusic(string name)
    {
        if (!GetToggleState("Music")) return;
        Sound s = Array.Find(musicSounds, x => x.name == name);

        if (s == null)
        {
            Debug.Log("Music not found");
        }
        else
        {
            musicSource.clip = s.clip;
            musicSource.loop = true;

            musicSource.Play();

        }
    }

    public void StopMusic(string name)
    {
        Sound s = Array.Find(musicSounds, x => x.name == name);
        if (s == null)
        {
            Debug.Log("Music not found");
        }
        else
        {
            musicSource.clip = s.clip;
            musicSource.Stop();
        }
    }
    public void PlaySFX(string name)
    {
        if (!GetToggleState("Sound")) return;
        Sound s = Array.Find(sfxSounds, x => x.name == name);

        if (s == null)
        {
            Debug.Log("Sound not found");
        }
        else
        {
            sfxSource.clip = s.clip;
            sfxSource.Play();
        }
    }
    public static void Vibrate()
    {
        if (!GetToggleState("Vibration")) return;
        Handheld.Vibrate();
    }

    public void ToggleMusic()
    {
        musicSource.mute = !musicSource.mute;
    }


    public void ToggleSFX()
    {
        sfxSource.mute = !sfxSource.mute;
    }




}
