using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundRepository : MonoBehaviour, ISound
{

    public AudioClip[] footSteps;
    public AudioClip throwPunch;
    public AudioClip[] swordStrokes;
    public MusicManager music;
    public SoundManager sound;

    private AudioClip swordClip;

    // Start is called before the first frame update
    void Start()
    {
        Sound.Set(this);

        ChoseSwordClip(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FootStep(AudioSource source)
    {
        if (footSteps.Length > 0)
        {
            source.clip = footSteps[Mathf.FloorToInt(Random.value * footSteps.Length)];

            source.Play();
        }
    }

    public void ThrowPunch(AudioSource source)
    {
        if (throwPunch != null)
        {
            source.clip = throwPunch;

            source.Play();
        }
    }

    public void SwordStroke(AudioSource source)
    {
        if (swordStrokes.Length > 0)
        {
            source.clip = swordClip;

            source.Play();

            ChoseSwordClip(false);
        }
    }
    
    public void ChoseSwordClip(bool wall)
    {
        if (wall)
        {
            swordClip = swordStrokes[1];
        }
        else
        {
            swordClip = swordStrokes[0];
        }
    }

    

    public void StartRockDrop()
    {
        sound.RockDrop();
    }

    public void StartRegenerator()
    {
        sound.Regenerator();
    }

    public void StartGameOver()
    {
        sound.GameOver();
    }

    public void StopPlayingSound()
    {
        sound.StopSound();
    }

    public void StartAmbientMusic()
    {
        music.FadeMusic(1, 0);
        music.PlayAmbientSong();
        music.FadeMusic(1, Constants.musicVolume);
    }

    public void StartCombatMusic()
    {
        music.FadeMusic(1, 0);
        music.PlayCombatSong();
        music.FadeMusic(1, Constants.musicVolume);
    }

    public void StartFinalMusic()
    {
        music.FadeMusic(1, 0);
        music.PlayFinalSong();
        music.FadeMusic(1, Constants.musicVolume);
    }

    public void StopPlayingMusic()
    {
        music.StopPlayingMusic();
    }

    public void FadeMusic(float duration, float volumeTarget)
    {
        music.FadeMusic(duration, volumeTarget);
    }
}
