using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUI
{

    void SetPlayerHealth(float hp, float maxHp);

    void RegisterEnemy(GameObject enemy);

    void RemoveEnemy(GameObject enemy);

    void SetEnemyHealth(GameObject enemy, float hp, float maxHp);
    
    void ShowPauseMenu(bool show);

    void SetNumKeys();

    void SetText(string text, float duration);

    void SetInitialText();

    void SetFinalText();

    void StartSceneChange(float startsFadingSeconds, bool changeScene);
}
