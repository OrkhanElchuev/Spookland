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
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void ResumeGame()
    {
        // Make pause panel inactive
        pauseMenuUI.SetActive(false);
        // Resume the game flow
        Time.timeScale = 1.0f;
        GameIsPaused = false;
    }

    // Load start menu and resume the game flow
    public void LoadStartMenu()
    {
        Time.timeScale = 1.0f;
        sceneFade.LoadScene("MainMenu");
    }

    private void PauseGame()
    {
        pauseMenuUI.SetActive(true);
        // Freeze the game flow
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
}