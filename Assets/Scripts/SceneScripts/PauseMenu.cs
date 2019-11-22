using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    // Public
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;

    // Private 
    private SceneFadeTransition sceneFade;

    private void Start()
    {
        sceneFade = FindObjectOfType<SceneFadeTransition>();
    }

    // When escape key pressed, pause or resume the game
    void Update()
    {
        if (GameIsPaused)
        {
            PauseGame();
        }
        else
        {
            ResumeGame();
        }
    }

    public void OnPause()
    {
        GameIsPaused = true;
    }

    public void ResumeGame()
    {
        // Make pause panel inactive
        pauseMenuUI.SetActive(false);
        // Resume the game flow
        Time.timeScale = 1.0f;
        GameIsPaused = false;
    }

    // Load main menu and resume the game flow
    public void LoadStartMenu()
    {
        GameIsPaused = false;
        Time.timeScale = 1.0f;
        sceneFade.LoadScene("MainMenu");
    }

    // Replay the game
    public void Retry()
    {
        GameIsPaused = false;
        Time.timeScale = 1.0f;
        sceneFade.LoadScene("GamePlay");
    }

    private void PauseGame()
    {
        pauseMenuUI.SetActive(true);
        // Freeze the game flow
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
}