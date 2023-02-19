using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuGameController : MonoBehaviour
{
    public AudioSource musicSource, soundSource;

    public static List<GameObject> dontDestroyObjects = new List<GameObject>();

    public List<GameObject> inactiveBeforeChangeScene;

    private MainMenu canvas;

    void Awake()
    {
        SetObjectsActive(true);
        SetVolume();
        StartPlayingAudioSources();

        canvas = FindObjectOfType<MainMenu>();
        if(canvas != null)
        {
            canvas.ActivateMenu();
        }
        Cursor.lockState = CursorLockMode.None;
    }

    public void StartPlayingAudioSources()
    {
        if (!musicSource.isPlaying)
        {
            musicSource.Play();
        }
        if (!soundSource.isPlaying)
        {
            soundSource.Play();
        }
    }

    public void SetVolume()
    {
        musicSource.volume = Constants.musicVolume;
        soundSource.volume = Constants.soundVolume;

    }

    public bool MaxCapacity()
    {
        return dontDestroyObjects.Count == Constants.numDontDestroyMainMenu;
    }

    public bool TryAdd(GameObject newGO)
    {
        if (!MaxCapacity())
        {
            dontDestroyObjects.Add(newGO);
            return true;
        }
        return false;
    }

    public void SetObjectsActive(bool active)
    {
        //GameObject camera = GameObject.Find("MainCamera");

        //if (camera != null)
        //{
        //    AudioListener listener = camera.GetComponent<AudioListener>();

        //    if (active && listener == null)
        //    {
        //        camera.AddComponent<AudioListener>();
        //    }
        //    else if (!active && listener != null)
        //    {
        //        Destroy(listener);
        //    }
        //}
        
        foreach (GameObject go in dontDestroyObjects)
        {
            if (go != gameObject)
            {
                go.SetActive(active);
            }
        }
        if (active)
        {
            SetVolume();
        }


    }

    public void SetNeededObjectsInactive()
    {
        foreach (GameObject go in dontDestroyObjects)
        {
            foreach(GameObject inactive in inactiveBeforeChangeScene)
            {
                if (ReferenceEquals(go, inactive))
                {
                    go.SetActive(false);
                }
            }

            AudioSource source = go.GetComponent<AudioSource>();

            if (source != null)
            {
                StartCoroutine(FadeAudioSource.StartFade(source, 1.1f, 0));
            }
        }
    }
}
