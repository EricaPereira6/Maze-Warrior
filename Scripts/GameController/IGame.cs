using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGame
{

    void Resume();

    void Pause();
    
    void TogglePause();

    void SetObjectsActive(bool active);

    void SetInteriorObjects();

    void MakePayerWait(bool stop);

    bool StopMoving();

    bool IsGameOver();

    void StartGameOver();

    bool IsGameWon();

    void StartGameWon();

    void StartInteriorScene();

}
