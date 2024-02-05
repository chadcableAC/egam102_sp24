using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenToggler : MonoBehaviour
{
    public enum ScreenType
    {
        Ready,
        Gameplay,
        Lose,
        Win
    }

    public ScreenType currentScreen;

    public GameObject loseScreen;
    public GameObject winScreen;
    public GameObject readyScreen;
    public GameObject gameplayScreen;

    void Update()
    {
        loseScreen.SetActive(currentScreen == ScreenType.Lose);
        winScreen.SetActive(currentScreen == ScreenType.Win);
        readyScreen.SetActive(currentScreen == ScreenType.Ready);
        gameplayScreen.SetActive(currentScreen == ScreenType.Gameplay);

        switch (currentScreen)
        {
            case ScreenType.Ready:
                UpdateReady();
                break;
        }

        // If you press space, load 
        if (Input.GetKeyDown(KeyCode.Space))
        {
            LoadScene(currentScreen);
        }
    }

    public void UpdateReady()
    {
        if (Input.GetMouseButtonDown(0))
        {
            currentScreen++;
        }
    }

    public void LoadScene(ScreenType screen)
    {
        switch (screen)
        {
            case ScreenType.Gameplay:
                SceneManager.LoadScene(screen.ToString());
                break;
        }
    }
}
