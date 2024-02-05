using UnityEngine;

public class PauseMenuScene : MonoBehaviour
{
    private bool isPaused = false;
    public GameObject pauseUI;
   
    public GameObject doorText;
    private Movement movementScript;
    private MouseLook mouseLookScript;

    private void Start()
    {
        movementScript = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Movement>();
        mouseLookScript = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<MouseLook>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }

        if (isPaused && Input.GetKeyDown(KeyCode.Q))
        {
            QuitGame();
        }
    }

    private void PauseGame()
    {
        pauseUI.SetActive(true);
        Time.timeScale = 0f; // Pause the game
        isPaused = true;
        Debug.Log("Game Paused");
       doorText.SetActive(false);

        // Disable the Movement and MouseLook scripts
        if (movementScript != null)
        {
            movementScript.enabled = false;
        }

        if (mouseLookScript != null)
        {
            mouseLookScript.enabled = false;
        }


    }

    private void ResumeGame()
    {
        pauseUI.SetActive(false);
        Time.timeScale = 1f; // Resume the game
        isPaused = false;
        doorText.SetActive(true);
       
       
        Debug.Log("Game Resumed");
        // Disable the Movement and MouseLook scripts
        if (movementScript != null)
        {
            movementScript.enabled = true;
        }

        if (mouseLookScript != null)
        {
            mouseLookScript.enabled = true;
        }



    }

    private void QuitGame()
    {
        // You can replace this with any code you want to execute before quitting
        Debug.Log("Quitting Game");
        Application.Quit();
    }

   
}
