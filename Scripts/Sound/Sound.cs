using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound
{

    private static ISound instance;

    public static void Set(ISound instance)
    {
        if (Sound.instance == null)
        {
            Sound.instance = instance;
        }
    }

    public static void FootStep(AudioSource source)
    {
        if (instance != null)
        {
            instance.FootStep(source);
        }
        
    }

    public static void ThrowPunch(AudioSource source)
    {
        if (instance != null)
        {
            instance.ThrowPunch(source);
        }
    }

    public static void SwordStroke(AudioSource source)
    {
        if (instance != null)
        {
            instance.SwordStroke(source);
        }
    }

    public static void StartRockDrop()
    {
        if (instance != null)
        {
            instance.StartRockDrop();
        }
    }

    public static void StartRegenerator()
    {
        if (instance != null)
        {
            instance.StartRegenerator();
        }
    }

    public static void StartGameOver()
    {
        if (instance != null)
        {
            instance.StartGameOver();
        }
    }

    public static void StopPlayingSound()
    {
        if (instance != null)
        {
            instance.StopPlayingSound();
        }
    }

    public static void StartAmbientMusic()
    {
        if (instance != null)
        {
            instance.StartAmbientMusic();
        }
    }

    public static void StartCombatMusic()
    {
        if (instance != null)
        {
            instance.StartCombatMusic();
        }
    }

    public static void StartFinalMusic()
    {
        if (instance != null)
        {
            instance.StartFinalMusic();
        }
    }

    public static void StopPlayingMusic()
    {
        if (instance != null)
        {
            instance.StopPlayingMusic();
        }
    }

    public static void FadeMusic(float duration, float volumeTarget)
    {
        if (instance != null)
        {
            instance.FadeMusic(duration, volumeTarget);
        }
    }


}
