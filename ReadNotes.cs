using System.Collections;
using UnityEngine;

public class ReadNotes : MonoBehaviour
{
    public GameObject player;
    public GameObject noteUI;
    public GameObject pickUpText;
    public GameObject HiddenKey;
    public GameObject jumpScareTrigger;
    public GameObject pauseMenu;

    private bool inReach;
    private bool isReadingNote;

    void Start()
    {
        noteUI.SetActive(false);
        pickUpText.SetActive(false);
        inReach = false;
        isReadingNote = false;
        HiddenKey.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && noteUI.activeSelf)
        {
            ExitNote();
        }

        if (!isReadingNote)
        {
            Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 2f))
            {
                if (hit.collider.CompareTag("Note"))
                {
                    inReach = true;
                    pickUpText.SetActive(true);

                    if (Input.GetButtonDown("Interact"))
                    {
                        ReadNote();
                    }
                }
                else
                {
                    inReach = false;
                    pickUpText.SetActive(false);
                }
            }
            else
            {
                inReach = false;
                pickUpText.SetActive(false);
            }
        }
    }

    void ReadNote()
    {
        jumpScareTrigger.SetActive(true);
        isReadingNote = true;
        HiddenKey.SetActive(true);
        noteUI.SetActive(true);
        pickUpText.SetActive(false);
        player.GetComponent<Movement>().enabled = false;
        player.GetComponent<MouseLook>().enabled = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        pauseMenu.SetActive(false);
    }

    public void ExitButton()
    {
        ExitNote();
    }

    void ExitNote()
    {
        isReadingNote = false;
        noteUI.SetActive(false);
        player.GetComponent<Movement>().enabled = true;
        player.GetComponent<MouseLook>().enabled = true;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        pauseMenu.SetActive(true);
    }
}