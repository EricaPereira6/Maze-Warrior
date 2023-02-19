using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

    public RectTransform loadingBar, MainPanel, settingsPanel, creditsPanel;
    public Image menuBackground;

    private float barWidth;

    private enum MenuState { MAIN_MENU, START_GAME, SETTINGS, CREDITS, EXIT };

    private KeyCode key;

    private MenuGameController gameController;


    // Start is called before the first frame update
    void Start()
    {
        barWidth = loadingBar.sizeDelta.x;

        key = KeyCode.None;

        gameController = FindObjectOfType<MenuGameController>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartGame()
    {
        
        StartCoroutine(LoadGame());
    }

    public void NewGame()
    {
        StartCoroutine(LoadGame());
    }

    IEnumerator LoadGame()
    {
        SetMenuState(MenuState.START_GAME);

        if (gameController != null)
        {
            gameController.SetNeededObjectsInactive();
        }

        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(Constants.currentScene);

        while(!asyncOperation.isDone)
        {
            // 0 - 1 -> asyncOperation.progress;
            Vector3 size = loadingBar.sizeDelta;
            size.x = Mathf.Max( barWidth / 25, asyncOperation.progress * barWidth);

            loadingBar.sizeDelta = size;

            yield return new WaitForEndOfFrame();
        }


        if (gameController != null)
        {
            gameController.SetObjectsActive(false);
        }
    }

    public void Settings()
    {
        SetMenuState(MenuState.SETTINGS);

        UpdateSliders();
    }

    public void ChangeKey(Text control)
    {
        StartCoroutine(GetKeyPressed(control));
    }

    IEnumerator GetKeyPressed(Text control)
    {
        key = KeyCode.None;

        bool wait = true;

        while (wait)
        {
            if (Input.anyKeyDown)
            {
                String keyString = Input.inputString;
                if (keyString.Equals(" "))
                {
                    key = KeyCode.Escape;
                }
                else if(!keyString.Equals(""))
                {
                    keyString = keyString.ToUpper();
                    key = (KeyCode)Enum.Parse(typeof(KeyCode), keyString);
                }
                else
                {
                    key = Input.GetKeyDown(KeyCode.LeftArrow) ? KeyCode.LeftArrow :
                            Input.GetKeyDown(KeyCode.RightArrow) ? KeyCode.RightArrow :
                            Input.GetKeyDown(KeyCode.UpArrow) ? KeyCode.UpArrow :
                            Input.GetKeyDown(KeyCode.DownArrow) ? KeyCode.DownArrow :
                            Input.GetMouseButtonDown(0) ? KeyCode.Mouse0 :
                            Input.GetMouseButtonDown(1) ? KeyCode.Mouse1 :
                            Input.GetMouseButtonDown(2) ? KeyCode.Mouse2 : KeyCode.None;
                }

                if (key != KeyCode.None) {

                    string newKey = key.ToString().ToUpper();
                    if (!Constants.menuKeys.ContainsValue(newKey))
                    {
                        Constants.menuKeys[control.name] = newKey;
                        control.text = newKey;
                    }
                }
                else
                {
                    if ((Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift)) && !Constants.menuKeys.ContainsValue("SHFT"))
                    {
                        Constants.menuKeys[control.name] = "SHFT";
                        control.text = "SHFT";
                    }
                }
                wait = false;
            }

            yield return null;
        }
    }

    public void SetDefaultKey(GameObject controls)
    {
        Text[] texts = controls.GetComponentsInChildren<Text>();
        foreach (Text text in texts)
        {
            if (Constants.menuDefaultKeys.TryGetValue(text.name, out string k))
            {
                text.text = k;
            }
        }
        
    }

    public void Credits()
    {
        SetMenuState(MenuState.CREDITS);
    }

    public void Exit()
    {
        Application.Quit();
    }


    public void SetMusicVolume(Slider musicSlider)
    {
        Constants.musicVolume = musicSlider.value;

        if (gameController != null)
        {
            gameController.SetVolume();
        }
    }

    public void SetSoundVolume(Slider soundSlider)
    {
        Constants.soundVolume = soundSlider.value;

        if (gameController != null)
        {
            gameController.SetVolume();
        }
    }

    private void UpdateSliders()
    {
        Slider[] sliders = GetComponentsInChildren<Slider>();

        foreach(Slider slider in sliders)
        {
            if (slider.name.Equals(Constants.musicSliderName))
            {
                slider.value = Constants.musicVolume;
            }
            else if (slider.name.Equals(Constants.soundSliderName))
            {
                slider.value = Constants.soundVolume;
            }
        }
    }

    public void BackMainMenu()
    {
        SetMenuState(MenuState.MAIN_MENU);
    }

    private void SetMenuState(MenuState state)
    {
        switch(state)
        {
            case MenuState.MAIN_MENU:
                MainPanel.gameObject.SetActive(true);
                settingsPanel.gameObject.SetActive(false);
                creditsPanel.gameObject.SetActive(false);
                loadingBar.gameObject.SetActive(false);
                break;

            case MenuState.START_GAME:
                MainPanel.gameObject.SetActive(false);
                loadingBar.gameObject.SetActive(true);

                break;

            case MenuState.SETTINGS:
                MainPanel.gameObject.SetActive(false);
                settingsPanel.gameObject.SetActive(true);
                break;

            case MenuState.CREDITS:
                MainPanel.gameObject.SetActive(false);
                creditsPanel.gameObject.SetActive(true);
                break;

            case MenuState.EXIT:
                Exit();
                break;
        }
    }

    public void ActivateMenu()
    {
        SetMenuState(MenuState.MAIN_MENU);
        if (gameController != null)
            gameController.SetVolume();
    }

}
