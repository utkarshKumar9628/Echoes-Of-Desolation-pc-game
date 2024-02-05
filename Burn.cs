using UnityEngine;

public class Burn : MonoBehaviour
{
    public GameObject Fire;
    public AudioClip fireAudio;
    private AudioSource audioSource;
    private bool hasTriggered = false;
    public GameObject noteUI;

    // Start is called before the first frame update
    void Start()
    {
        if (Fire != null)
        {
            Fire.SetActive(false);
        }

        // Initialize the AudioSource component
        audioSource = GetComponent<AudioSource>();
        if (audioSource != null && fireAudio != null)
        {
            audioSource.clip = fireAudio;
        }

        // Hide UI initially
        ToggleUI(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MainCamera") && !hasTriggered)
        {
            // Show UI
            ToggleUI(true);
            // Set the trigger flag when entering the trigger zone
            hasTriggered = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            // Hide UI when leaving the trigger zone
            ToggleUI(false);
            // Reset the trigger flag when leaving the trigger zone
            hasTriggered = false;
        }
    }

    void Update()
    {
        // Check for the 'Interact' button (e.g., 'E') press
        if (hasTriggered && Input.GetButtonDown("Interact"))
        {
            // Player pressed the "Interact" button
            ActiveFire();

            // Hide UI after interaction
            ToggleUI(false);
        }
    }

    public void ActiveFire()
    {
        Fire.SetActive(true);

        if (audioSource != null && fireAudio != null)
        {
            audioSource.Play();
        }
    }

    private void ToggleUI(bool show)
    {
        // Toggle the visibility of the UI elements
        if (noteUI != null)
        {
            noteUI.SetActive(show);
        }
    }
}