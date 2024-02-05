using UnityEngine;
using System.Collections;

public class TwoTriggers : MonoBehaviour
{
    public GameObject zombieModel; // Reference to the zombie model
    public AudioClip jumpscareSound; // Jumpscare sound
    private AudioSource audioSource; // Reference to the AudioSource component
    public Movement playerMovement;
    public MouseLook mouseLookScript;
    private bool hasTriggered = false;
    public float duration = 250f;

    void Start()
    {
        // Ensure the zombie model is initially inactive
        if (zombieModel != null)
        {
            zombieModel.SetActive(false);
        }

        // Get or add AudioSource component to the GameObject
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // Set the AudioClip for the AudioSource
        audioSource.clip = jumpscareSound;
        playerMovement = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Movement>();
       
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MainCamera") && !hasTriggered)
        {
            hasTriggered = true;
            ActivateJumpscare();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            DisableJumpscare();
        }
    }

    void ActivateJumpscare()
    {
        // Activate the zombie model
        if (zombieModel != null)
        {
            zombieModel.SetActive(true);
        }

        // Play the jumpscare sound through the AudioSource
        audioSource.Play();


        // Optionally, you can disable the collider after the jumpscare occurs
        GetComponent<Collider>().enabled = true;
        // playerMovement.enabled = false;
        // Invoke("EnablePlayerMovement", duration);
        StartCoroutine(Duration());
        // Optionally, you can destroy the script component to prevent further checks
        // Destroy(this);


    }

    IEnumerator Duration()
    {
        playerMovement.enabled = false;

        yield return new WaitForSecondsRealtime(duration);

        EnablePlayerMovement();

        StopCoroutine(Duration());
    
    }




    void DisableJumpscare()
    {
        // Disable the zombie model
        if (zombieModel != null)
        {
            zombieModel.SetActive(false);
        }

        // Optionally, you can enable the collider when the player exits
        GetComponent<Collider>().enabled = false;

        // Stop the jumpscare sound
        audioSource.Stop();
    }
    
    void EnablePlayerMovement()
    {
        // Enable player movement after 10 seconds
        playerMovement.enabled = true;
    }
}