using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;

    // Reference to components that should be paused/unpaused
    public MonoBehaviour[] componentsToPause;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        //Time.timeScale = 0f; // Pause the physics and animations

        // Disable components that should not run when paused
        foreach (var component in componentsToPause)
        {
            if (component != null)
            {
                component.enabled = false;
            }
        }

        GameIsPaused = true;
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f; // Resume the physics and animations

        // Enable components that were disabled when paused
        foreach (var component in componentsToPause)
        {
            if (component != null)
            {
                component.enabled = true;
            }
        }

        GameIsPaused = false;
    }

    public void LoadMenu()
    {
        // Add your code to load the menu scene or handle menu logic
        Debug.Log("LoadMenu");
    }

    public void QuitGame()
    {
        // Add your code to quit the game
        Debug.Log("QuitMenu");
        Application.Quit();
    }
}