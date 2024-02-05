using UnityEngine;

public class TriggerEnable : MonoBehaviour
{
    public GameObject targetObject;
    public GameObject roofEnabler;
    public GameObject EndCutsceneEnable;

    void OnEnable()
    {
        // Check if the target object is not null before enabling it
        if (targetObject != null)
        {
            targetObject.SetActive(true);
            Invoke("DeactivateTrigger", 15f);
            EndCutsceneEnable.SetActive(true);
        }
    }

    private void DeactivateTrigger()
    {

        // Deactivate the trigger and text
        targetObject.SetActive(false);
        roofEnabler.SetActive(true);
        

    }
    
}
