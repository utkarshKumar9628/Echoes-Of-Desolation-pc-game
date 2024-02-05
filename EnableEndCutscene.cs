using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableEndCutscene : MonoBehaviour
{
    public GameObject endCutScene;

    private Movement movementScript;
    private MouseLook mouseLookScript;

    void Start()
    {
        // Assuming Movement and MouseLook are components attached to the same GameObject
        movementScript = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Movement>();
        mouseLookScript = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<MouseLook>(); 

        // Disable the Movement and MouseLook scripts at the start
      
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            Debug.Log("Entered end cutscene zone");
            EnableCutscene();
        }
    }

    private void EnableCutscene()
    {
        // Check if endCutScene is not already active
        if (endCutScene != null)
        {
            endCutScene.SetActive(true);
            

            // Disable the Movement and MouseLook scripts
            if (movementScript != null)
            {
                movementScript.enabled = false;
            }

            if (mouseLookScript != null)
            {
                mouseLookScript.enabled = false;
            }

            Debug.Log("End cutscene activated");
        }
    }
}