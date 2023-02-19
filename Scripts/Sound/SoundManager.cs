using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    private AudioSource source;

    public AudioClip regenerator;
    public AudioClip rockDrop;
    public AudioClip gameOver;

    void Start()
    {
        source = GetComponent<AudioSource>();
        source.volume = Constants.soundVolume;
    }

    void Update()
    {
        
    }

    public void Regenerator()
    {
        source.clip = regenerator;

        source.volume = Constants.soundVolume;
        source.Play();
    }

    public void RockDrop()
    {
        source.clip = rockDrop;

        source.volume = Constants.soundVolume;
        source.Play();
    }

    public void GameOver()
    {
        source.clip = gameOver;

        source.volume = Constants.soundVolume;
        source.Play();
    }

    public void StopSound()
    {
        float duration = 1f;

        StartCoroutine(FadeAudioSource.StartFade(source, duration, 0));

        StartCoroutine(StoppingSound());
    }

    IEnumerator StoppingSound()
    {
        yield return new WaitForSeconds(1);

        if (source.volume > 0)
        {
            StartCoroutine(StoppingSound());
        }
        else
        {
            source.Stop();
        }

        yield return null;

    }
}
