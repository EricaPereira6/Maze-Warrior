using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    private static MenuGameController menuGameController;
    private static GameController gameController;

    void Awake()
    {
        if (gameObject.scene.name.Equals(Constants.mainMenuScene))
        {
            menuGameController = FindObjectOfType<MenuGameController>();

            if (menuGameController != null && menuGameController.TryAdd(gameObject))
            {
                DontDestroyOnLoad(gameObject);
            }
            else
            {

                Destroy(gameObject);
            }
        }

        if (gameObject.scene.name.Equals(Constants.gameScene) || gameObject.scene.name.Equals(Constants.interiorGameScene))
        {
            gameController = FindObjectOfType<GameController>();

            if (gameController != null && gameController.TryAdd(gameObject))
            {
                DontDestroyOnLoad(gameObject);
            }
            else
            {

                Destroy(gameObject);
            }
        }
    }
}
