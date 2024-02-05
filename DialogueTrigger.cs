using UnityEngine;
using TMPro;

public class DialogueTrigger : MonoBehaviour
{
    public GameObject audioGameObject; // The GameObject with the AudioSource component
    public AudioClip triggerAudio; // The audio to be played
    public TextMeshProUGUI triggerText; // The TextMeshPro element
    public float displayTime = 3f; // How long the text should be displayed
    public GameObject DisableDoorLocks;
    private bool hasTriggered = false;
    private AudioSource audioSource; // Reference to the AudioSource component

    void Start()
    {
        // Get or add AudioSource component to the specified GameObject
        if (audioGameObject != null)
        {
            audioSource = audioGameObject.GetComponent<AudioSource>();
            if (audioSource == null)
            {
                audioSource = audioGameObject.AddComponent<AudioSource>();
            }
        }
        else
        {
            Debug.LogError("Audio GameObject not assigned in the Inspector!");
        }

        // Set the AudioClip for the AudioSource
        audioSource.clip = triggerAudio;

        // Disable the TextMeshProUGUI initially
        if (triggerText != null)
        {
            triggerText.gameObject.SetActive(false);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MainCamera") && !hasTriggered)
        {
            // Play the trigger audio on the specified GameObject
            if (audioSource != null)
            {
                audioSource.Play();
            }
            else
            {
                Debug.LogError("AudioSource component not found on the specified GameObject!");
            }

            // Display the trigger text from the TextMeshProUGUI component
            DisplayTriggerText();

            // Set the flag to prevent repeated triggering
            hasTriggered = true;
        }
    }

    void DisplayTriggerText()
    {
        // Assuming the TextMeshPro component is directly on the canvas
        if (triggerText != null)
        {
            // Enable the TextMeshProUGUI
            triggerText.gameObject.SetActive(true);

            DisableDoorLocks.SetActive(false);

            // Get the text from the TextMeshProUGUI component
            string displayMessage = triggerText.text;

            // Invoke the method to clear the text after displayTime seconds
            Invoke(nameof(ClearTriggerText), displayTime);
        }
    }

    void ClearTriggerText()
    {
        // Clear the TextMeshPro text
        if (triggerText != null)
        {
            // Disable the TextMeshProUGUI
            triggerText.gameObject.SetActive(false);
        }
    }
}