using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour, IGame
{

    private static bool isPaused;

    public static List<GameObject> dontDestroyGameObjects = new List<GameObject>();

    private bool gameOver, gameWon, interiorGame, stopMovingPayer;



    void Awake()
    {
        SetObjectsActive(true);
    }

    // Start is called before the first frame update
    void Start()
    {
        Game.SetInstance(this);

        isPaused = false;

        stopMovingPayer = false;
        gameOver = false;
        gameWon = false;
        interiorGame = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    public static bool IsPaused()
    {
        return isPaused;
    }

    public void Resume()
    {
        isPaused = false;
        Time.timeScale = 1;
        UI.ShowPauseMenu(false);
        Cursor.lockState = CursorLockMode.Locked;
    }
    
    public void Pause()
    {
        isPaused = true;
        Time.timeScale = 0;
        UI.ShowPauseMenu(true);
        Cursor.lockState = CursorLockMode.None;
    }
    
    public void TogglePause()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            Pause();
        }
        else
        {
            Resume();
        }
    }



    public bool MaxCapacity()
    {
        if (gameObject.scene.name.Equals(Constants.interiorGameScene))
        {
            return dontDestroyGameObjects.Count == Constants.numDontDestroyInteriorGame;
        }
        return dontDestroyGameObjects.Count == Constants.numDontDestroyGame;
    }

    public bool TryAdd(GameObject newGO)
    {
        if (!MaxCapacity())
        {
            dontDestroyGameObjects.Add(newGO); 
            return true;
        }
        return false;
    }

    public void SetObjectsActive(bool active)
    {
        //GameObject camera = GameObject.Find("arissaCamera");

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


        foreach (GameObject go in dontDestroyGameObjects)
        {
            if (go != gameObject)
            {
                go.SetActive(active);
            }
        }
    }

    public void SetInteriorObjects()
    {

        List<GameObject> gameObjects = new List<GameObject>();

        foreach (GameObject go in dontDestroyGameObjects)
        {
            gameObjects.Add(go);
        }

        foreach (GameObject go in gameObjects)
        {
            if (go.GetComponent<SecondFaseDestroyable>())
            {
                dontDestroyGameObjects.Remove(go);
                Destroy(go);
            }
        }
    }



    public void MakePayerWait(bool stop)
    {
        stopMovingPayer = stop;
    }

    public bool StopMoving()
    {
        return stopMovingPayer;
    }




    public bool IsGameOver()
    {
        return gameOver;
    }

    public bool IsGameWon()
    {
        return gameWon;
    }

    public bool IsInteriorGame()
    {
        return interiorGame;
    }

    public void StartGameOver()
    {
        gameOver = true;

        Sound.StopPlayingMusic();
        Sound.StartGameOver();

        MakePayerWait(true);

        UI.StartSceneChange(5, true);

    }

    public void StartGameWon()
    {
        gameWon = true;

        Sound.FadeMusic(1, 0);

        MakePayerWait(true);

        UI.StartSceneChange(5, true);

    }

    public void StartInteriorScene()
    {
        interiorGame = true;

        MakePayerWait(true);

        Resume();

        Constants.currentScene = Constants.interiorGameScene;

        UI.StartSceneChange(2, false);
        
    }

}
