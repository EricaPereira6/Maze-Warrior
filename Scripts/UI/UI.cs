using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI
{

    private static IUI instance;

    public static void SetInstance(IUI instance)
    {
        if (UI.instance == null)
        {
            UI.instance = instance;
        }
    }

    public static void SetPlayerHealth(float hp, float maxHp)
    {
        if (instance != null)
        {
            instance.SetPlayerHealth(hp, maxHp);
        }
    }

    public static void RegisterEnemy(GameObject enemy)
    {
        if (instance != null)
        {
            instance.RegisterEnemy(enemy);
        }
    }

    public static void RemoveEnemy(GameObject enemy)
    {
        if (instance != null)
        {
            instance.RemoveEnemy(enemy);
        }
    }

    public static void SetEnemyHealth(GameObject enemy, float hp, float maxHp)
    {
        if (instance != null)
        {
            instance.SetEnemyHealth(enemy, hp, maxHp);
        }
    }

    public static void ShowPauseMenu(bool show)
    {
        if (instance != null)
        {
            instance.ShowPauseMenu(show);
        }
    }

    public static void SetNumKeys()
    {
        if (instance != null)
        {
            instance.SetNumKeys();
        }
    }

    public static void SetText(string text, float duration)
    {
        if (instance != null)
        {
            instance.SetText(text, duration);
        }
    }

    public static void SetInitialText()
    {
        if (instance != null)
        {
            instance.SetInitialText();
        }
    }

    public static void SetFinalText()
    {
        if (instance != null)
        {
            instance.SetFinalText();
        }
    }

    public static void StartSceneChange(float startsFadingSeconds, bool changeScene)
    {
        if (instance != null)
        {
            instance.StartSceneChange(startsFadingSeconds, changeScene);
        }
    }
}
