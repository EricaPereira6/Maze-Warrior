using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour, IUI
{

    public RectTransform playerHpBg, playerHpBar;
    private float playerHpBarWidth;

    public EnemyHpBar enemyHpBarPrefab;
    private Dictionary<GameObject, EnemyHpBar> registrer;

    public GameObject pauseMenu;
    public Image fadeOut;

    public Text numKeys;
    public Text centerText;


    private bool beginWarnings;


    private void Awake()
    {
        UI.SetInstance(this);

        registrer = new Dictionary<GameObject, EnemyHpBar>();

        playerHpBarWidth = playerHpBg.sizeDelta.x;

        beginWarnings = false;

        ResetFadeOutImage();
    }

    void Start()
    {

        ShowPauseMenu(false);

        SetNumKeys();
    }

    void Update()
    {

    }

    public void SetPlayerHealth(float hp, float maxHp)
    {

        Vector2 size = playerHpBar.sizeDelta;
        size.x = Mathf.Clamp(hp, 0, maxHp) / maxHp * playerHpBarWidth;

        playerHpBar.sizeDelta = size;
    }

    public void RegisterEnemy(GameObject enemy)
    {
        registrer[enemy] = Instantiate(enemyHpBarPrefab, enemy.transform);
    }

    public void RemoveEnemy(GameObject enemy)
    {
        Destroy(registrer[enemy].gameObject);
        registrer.Remove(enemy);
    }

    public void SetEnemyHealth(GameObject enemy, float hp, float maxHp)
    {
        if (registrer.TryGetValue(enemy, out EnemyHpBar enemyBar))
        {
            enemyBar.SetHp(hp, maxHp);
        }
    }

    public void SetNumKeys()
    {
        if (Constants.numkeys < 3)
        {
            Constants.numkeys++;
        }
        numKeys.text = Constants.numkeys + Constants.keyTextFormat;
    }


    public void SetText(string text, float duration)
    {
        if (centerText.color.a == 0 && beginWarnings)
        {
            centerText.text = text;

            StartCoroutine(FadingText(centerText, true));
            StartCoroutine(WaitToFadeOutText(centerText, false, duration));
        }
    }

    public void SetInitialText()
    {
        string[] texts = new string[3] { Constants.firstCongrats, Constants.youWinKeys, Constants.whyNeedKeys };
        int radius = 3;
        StartCoroutine(WaitToWriteInitialText(texts, radius));
    }

    public void SetFinalText()
    {
        string[] texts = new string[2] { Constants.youGotIt, Constants.yourWayOut };
        int radius = 2;
        StartCoroutine(WaitToWriteInitialText(texts, radius));
    }

    IEnumerator FadingText(Text text, bool fadeIn)
    {
        yield return null;

        Color alpha = text.color;

        alpha.a = fadeIn ? Mathf.Min(1, alpha.a + 0.01f) : Mathf.Max(0, alpha.a - 0.01f);

        text.color = alpha;
        if (text.color.a != 1 && text.color.a != 0)
        {
            yield return null;
            StartCoroutine(FadingText(text, fadeIn));
        }

        yield return null;
    }

    IEnumerator WaitToFadeOutText(Text text, bool fadeIn, float duration)
    {
        yield return new WaitForSeconds(duration);

        if (centerText.color.a < 1)
        {
            StartCoroutine(WaitToFadeOutText(text, fadeIn, duration));
        }

        StartCoroutine(FadingText(text, fadeIn));
    }

    
    IEnumerator WaitToWriteInitialText(string[] texts, int numTexts)
    {
        yield return new WaitForEndOfFrame();

        if (numTexts > 0)
        {
            if (centerText.color.a == 0)
            {
                centerText.text = texts[texts.Length - numTexts];

                StartCoroutine(FadingText(centerText, true));
                StartCoroutine(WaitToFadeOutText(centerText, false, Constants.timeTextRemains));
                numTexts--;
                StartCoroutine(WaitToWriteInitialText(texts, numTexts));
            }
            else
            {
                StartCoroutine(WaitToWriteInitialText(texts, numTexts));
            }
        }
        else
        {
            beginWarnings = true;
        }

        yield return null;

    }




    public void StartSceneChange(float startsFadingSeconds, bool changeScene)
    {

        Color color = Color.white;
        color.a = 0;
        fadeOut.color = color;

        StartCoroutine(WaitSeconds(startsFadingSeconds, changeScene));
    }


    IEnumerator WaitSeconds(float duration, bool exit)
    {
        yield return new WaitForSeconds(duration);

        StartCoroutine(FadingOutRoutine(exit));
    }

    IEnumerator FadingOutRoutine(bool exit)
    {
        yield return new WaitForEndOfFrame();

        Color alpha = fadeOut.color;
        alpha.a = Mathf.Min(1, alpha.a + 0.005f);
        fadeOut.color = alpha;

        if (fadeOut.color.a < 1)
        {
            StartCoroutine(FadingOutRoutine(exit));
        }
        else
        {
            if (exit)
            {
                Exit();
            }
            else
            {

                GameObject player = FindObjectOfType<Warrior>().gameObject;
                player.transform.position = Constants.playerInteriorPos;
                player.transform.localEulerAngles = Constants.playerInteriorRotation;

                Game.SetInteriorObjects();
                SceneManager.LoadScene(Constants.interiorGameScene);

                ResetFadeOutImage();
                Game.MakePayerWait(false);
            }
        }

        yield return null;
    }


    public void ResetFadeOutImage()
    {
        Color alpha = fadeOut.color;
        alpha.a = 0;
        fadeOut.color = alpha;
    }




    public void ResumeMenu()
    {
        Game.Resume();
    }

    public void MainMenu()
    {
        Game.Resume();

        if (!Constants.currentScene.Equals(Constants.interiorGameScene))
        {
            Game.SetObjectsActive(false);
            SceneManager.LoadScene(Constants.mainMenuScene);
        }
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void ShowPauseMenu(bool show)
    {
        pauseMenu.SetActive(show);
    }
}
