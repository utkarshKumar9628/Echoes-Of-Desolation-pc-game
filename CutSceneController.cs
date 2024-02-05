using UnityEngine;
using UnityEngine.Playables;

public class CutsceneController : MonoBehaviour
{
    public PlayableDirector cutsceneDirector;
    public Movement player;

    void Start()
    {
        if (cutsceneDirector != null && player != null)
        {
            // Subscribe to the 'stopped' event
            cutsceneDirector.stopped += OnCutsceneStopped;

            // Play the cutscene
            cutsceneDirector.Play();
            player.enabled = false;
        }
    }

    void Update()
    {
        // Check for input to skip the cutscene
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            SkipCutscene();
        }
    }

    void OnCutsceneStopped(PlayableDirector director)
    {
        Debug.Log("Cutscene stopped");
        EnablePlayer();
        DisableCutsceneObject();

        // Unsubscribe from the event to avoid memory leaks
        director.stopped -= OnCutsceneStopped;
    }

    void SkipCutscene()
    {
        cutsceneDirector.Stop(); // Stop the cutscene immediately
    }

    void EnablePlayer()
    {
        player.enabled = true;
    }

    void DisableCutsceneObject()
    {
        // Disable the GameObject containing the PlayableDirector
        gameObject.SetActive(false);
    }
}