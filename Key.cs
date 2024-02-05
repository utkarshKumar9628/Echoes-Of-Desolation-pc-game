using UnityEngine;

public class Key : MonoBehaviour
{
    public DoorLock doorLock;
    public GameObject gameObjectToEnable;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            if (doorLock != null)
            {
                doorLock.Unlock();
                Pickup();

                gameObject.SetActive(false); // Disable the key after pickup

            }
            else
            {
                Debug.LogWarning("Door lock reference is not set on the key.");
            }
        }
    }

    public void Pickup()
    {

        gameObjectToEnable.SetActive(true);

    }
}