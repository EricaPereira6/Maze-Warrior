using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game
{

    private static IGame instance;

    public static void SetInstance(IGame instance)
    {
        if (Game.instance == null)
        {
            Game.instance = instance;
        }
    }

    public static void TogglePause()
    {
        if (instance != null)
        {
            instance.TogglePause();
        }
    }
    
    public static void Resume()
    {
        if (instance != null)
        {
            instance.Resume();
        }
    }
    
    public static void Pause()
    {
        if (instance != null)
        {
            instance.Pause();
        }
    }

    public static void SetObjectsActive(bool active)
    {
        if (instance != null)
        {
            instance.SetObjectsActive(active);
        }
    }

    public static void SetInteriorObjects()
    {
        if (instance != null)
        {
            instance.SetInteriorObjects();
        }
    }

    public static void MakePayerWait(bool stop)
    {
        if (instance != null)
        {
            instance.MakePayerWait(stop);
        }
    }

    public static bool StopMoving()
    {
        if (instance != null)
        {
            return instance.StopMoving();
        }
        return false;
    }

    public static bool IsGameOver()
    {
        if (instance != null)
        {
            return instance.IsGameOver();
        }
        return false;
    }

    public static bool IsGameWon()
    {
        if (instance != null)
        {
            return instance.IsGameWon();
        }
        return false;
    }

    public static void StartGameOver()
    {
        if (instance != null)
        {
            instance.StartGameOver();
        }
    }

    public static void StartGameWon()
    {
        if (instance != null)
        {
            instance.StartGameWon();
        }
    }


    public static void StartInteriorScene()
    {
        if (instance != null)
        {
            instance.StartInteriorScene();
        }
    }
}
