using UnityEngine;

public class PauseMEnuDifferent : MonoBehaviour
{
    private bool isPaused = false;
    public GameObject pauseUI;

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
        // Enable the pause menu UI
        pauseUI.SetActive(true);
        isPaused = true;

        // Disable everything except the pause UI and the main camera
        DisableAllExceptUIAndCamera();

        Debug.Log("Game Paused");
    }

    private void DisableAllExceptUIAndCamera()
    {
        // Get all objects in the scene
        GameObject[] allObjects = UnityEngine.Object.FindObjectsOfType<GameObject>();

        // Disable each object except the pause UI and the main camera
        foreach (GameObject obj in allObjects)
        {
            if (obj != pauseUI && obj.CompareTag("MainCamera"))
            {
                obj.SetActive(false);
            }
        }
    }

    private void ResumeGame()
    {
        // Disable the pause menu UI
        pauseUI.SetActive(false);
        isPaused = false;

        // Enable everything except the pause UI and the main camera
        EnableAllExceptUIAndCamera();

        Debug.Log("Game Resumed");
    }

    private void EnableAllExceptUIAndCamera()
    {
        // Get all objects in the scene
        GameObject[] allObjects = UnityEngine.Object.FindObjectsOfType<GameObject>();

        // Enable each object except the pause UI and the main camera
        foreach (GameObject obj in allObjects)
        {
            if (obj != pauseUI && obj.CompareTag("MainCamera"))
            {
                obj.SetActive(true);
            }
        }
    }

    private void QuitGame()
    {
        // You can replace this with any code you want to execute before quitting
        Debug.Log("Quitting Game");
        Application.Quit();
    }
}