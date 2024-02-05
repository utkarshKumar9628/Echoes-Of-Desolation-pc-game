using UnityEngine;

public class InteractionManager : MonoBehaviour
{
    public GameObject gameObjectToEnable; // Assign GameObject2 to this field
    private bool isCollected = false;

    void OnTriggerEnter(Collider other)
    {
        if (!isCollected && other.CompareTag("MainCamera"))
        {
            CollectObject();
        }
    }

    void CollectObject()
    {
        isCollected = true;
        gameObject.SetActive(false);

        // Check if GameObject2 exists
        if (gameObjectToEnable != null)
        {
            gameObjectToEnable.SetActive(true);
        }
    }
}