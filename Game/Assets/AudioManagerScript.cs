using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("---------Source-----------------")]
    public AudioSource musicSource;
    public AudioSource SFXsource;

    [Header("---------Clip-----------------")]
    public AudioClip goblinTheme;
    public AudioClip goblinBossTheme;
    public AudioClip minotaurTheme;
    public AudioClip minotaurDeath;
    public AudioClip medusaTheme;
    public AudioClip medusaSFX;
    public AudioClip snakeTheme;
    public AudioClip menu;
    public AudioClip chillax;
    public AudioClip deathSFX;
    public AudioClip swallow;
    public AudioClip hurt;
    public AudioClip puke;
    public AudioClip punch;


    public void Start()
    {

        musicSource.clip = chillax;
        musicSource.Play();

    }

    public void PlaySFX(AudioClip clip)
    {
        SFXsource.PlayOneShot(clip);
    }

    public void PlayMusic(AudioClip theme)
    {
        musicSource.clip = theme;
        musicSource.Play();
    }

    public void Update()
    {



        if (!musicSource.isPlaying)
        {
            musicSource.Play();

        }
    }
}
