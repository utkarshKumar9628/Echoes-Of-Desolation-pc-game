using UnityEngine;

public class Jumpscare2 : MonoBehaviour
{
    public GameObject zombieModel; // Reference to the zombie model
    //public AudioClip jumpscareSound; // Jumpscare sound

    private bool isInTriggerZone = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MainCamera") && !isInTriggerZone)
        {
            isInTriggerZone = true;
            ActivateJumpscare();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MainCamera") && isInTriggerZone)
        {
            isInTriggerZone = false;
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

        // Play the jumpscare sound
       
    }

    void DisableJumpscare()
    {
        // Disable the zombie model
        if (zombieModel != null)
        {
            zombieModel.SetActive(false);
          //  GetComponent<Collider>().enabled = false;
        }
    }
}