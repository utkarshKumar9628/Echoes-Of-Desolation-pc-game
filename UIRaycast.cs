using UnityEngine;
using UnityEngine.UI;

public class UIRaycast : MonoBehaviour
{
    void Update()
    {
        // Check for mouse input
        if (Input.GetMouseButtonDown(0))
        {
            // Perform a raycast from the mouse position
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Set the maximum distance based on your needs
            float maxRaycastDistance = 100f;

            // Perform the raycast
            if (Physics.Raycast(ray, out hit, maxRaycastDistance))
            {
                // Check if the hit object has a GraphicRaycaster component
                GraphicRaycaster graphicRaycaster = hit.collider.GetComponent<GraphicRaycaster>();
                if (graphicRaycaster != null)
                {
                    // Ray hit a UI element, handle the interaction here
                    Debug.Log("UI element clicked: " + hit.collider.gameObject.name);

                    // Add your custom logic for UI interaction
                    // For example, you can call the button click function:
                    // hit.collider.GetComponent<Button>().onClick.Invoke();
                }
            }
        }
    }
}