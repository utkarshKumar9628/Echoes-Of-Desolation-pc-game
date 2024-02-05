using UnityEngine;

public class Jumpscare : MonoBehaviour
{
    public GameObject zombieModel; // Reference to the zombie model
    public AudioClip jumpscareSound; // Jumpscare sound

    private bool hasTriggered = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MainCamera") && !hasTriggered)
        {
            ActivateJumpscare();
        }
    }

    void ActivateJumpscare()
    {
        hasTriggered = true;

        // Disable other scripts or components attached to the player or other objects
        // For example, you might want to disable the player's movement script
        // other.GetComponent<MovementScript>().enabled = false;

        // Activate the zombie model
        if (zombieModel != null)
        {
            zombieModel.SetActive(true);
        }

        // Play the jumpscare sound
        if (jumpscareSound != null)
        {
            AudioSource.PlayClipAtPoint(jumpscareSound, transform.position);
        }

        // Disable this script, assuming it's attached to a GameObject with a Collider
        // and you don't want it to trigger multiple times
        GetComponent<Collider>().enabled = false;

        // Disable the zombie model after a delay (adjust the time as needed)
        Invoke("DisableZombieModel", 3f);
    }

    void DisableZombieModel()
    {
        // Disable the zombie model
        if (zombieModel != null)
        {
            zombieModel.SetActive(false);
        }
    }
}