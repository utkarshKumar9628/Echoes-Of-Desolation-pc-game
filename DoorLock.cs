using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DoorLock : MonoBehaviour
{
    public Animator doorAnimator;
    public float interactionDistance = 3f;
    private bool isLocked = true; // Assume the door is initially locked
    public GameObject RoofDisabler;
    public GameObject BasementEnabler;
    public TextMeshProUGUI uiElement; // Reference to the UI element
    private bool isPlayerNearby = false;

    void Update()
    {
        // Check for player input and proximity to the door
        if (Input.GetButtonDown("Interact") && isPlayerNearby)
        {
            TryToggleDoor();
        }
    }

    void TryToggleDoor()
    {
        if (!isLocked)
        {
            ToggleDoor();
        }
        else
        {
            Debug.Log("The door is locked. Find a key or interact with the lock.");
        }
    }

    void ToggleDoor()
    {
        doorAnimator.SetBool("Open", !doorAnimator.GetBool("Open"));
        RoofDisabler.SetActive(false);
        BasementEnabler.SetActive(true);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            // Player entered the trigger zone
            isPlayerNearby = true;
            uiElement.gameObject.SetActive(true); // Enable the UI
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            // Player exited the trigger zone
            isPlayerNearby = false;
            uiElement.gameObject.SetActive(false); // Disable the UI
        }
    }

    // Unlock the door, called by the key
    public void Unlock()
    {
        isLocked = false;
        Debug.Log("Door unlocked!");
    }
}