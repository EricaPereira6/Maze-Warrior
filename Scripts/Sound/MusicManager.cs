using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{

    private AudioSource source;

    public AudioClip[] combatSongs;
    public AudioClip[] ambientSongs;
    public AudioClip[] finalSongs;

    public bool isCombat;

    void Start()
    {
        source = GetComponent<AudioSource>();
        source.volume = Constants.musicVolume;

        PlayAmbientSong();

        isCombat = false;
    }



    // Update is called once per frame
    void Update()
    {
        if (source != null && source.volume != Constants.musicVolume)
        {
            source.volume = Constants.musicVolume;
        }
    
        if (!source.isPlaying)
        {
            if (isCombat)
            {
                PlayCombatSong();
            }
            else if (Constants.numkeys == 3)
            {
                PlayFinalSong();
            }
            else
            {
                PlayAmbientSong();
            }
            
        }
    }

    public void PlayCombatSong()
    {
        isCombat = true;
        PlaySong(combatSongs);
    }

    public void PlayAmbientSong()
    {
        isCombat = false;
        PlaySong(ambientSongs);
    }

    public void PlayFinalSong()
    {
        PlaySong(finalSongs);
        
    }

    public void StopPlayingMusic()
    {
        source.Stop();
    }

    public void PlaySong(AudioClip[] songList)
    {
        if (!Game.IsGameOver())
        {
            if (songList.Length > 0)
            {
                source.clip = GetRandomSong(songList);

                source.volume = 0;

                source.Play();

                FadeMusic(1, Constants.musicVolume);
            }
        }
    }

    public void FadeMusic(float duration, float targetVolume)
    {
        StartCoroutine(FadeAudioSource.StartFade(source, duration, targetVolume));
    }

    private AudioClip GetRandomSong(AudioClip[] songs)
    {
        return songs[Mathf.FloorToInt(Random.value * songs.Length)];
    }

    
}
