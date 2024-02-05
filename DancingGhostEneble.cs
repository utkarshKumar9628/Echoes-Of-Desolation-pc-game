using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DancingGhostEneble : MonoBehaviour
{
    public GameObject trigger;
    private bool hasTriggered = false;
    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MainCamera") && !hasTriggered)
        {
            if (trigger != null)
            {
                trigger.SetActive(true);
            }
            
        }
    }

   
}
