using System.Collections;
using TMPro; // Import TextMeshPro namespace
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textOB; // Use TextMeshProUGUI for UI text
    public GameObject Activator;
    public string dialogue = "Dialogue";
    public float timer = 2f;

    void Start()
    {
        // Ensure that the TextMeshProUGUI component is properly referenced in the Inspector
        if (textOB == null)
        {
            Debug.LogError("TextMeshProUGUI component not assigned in the Inspector!");
        }

        textOB.enabled = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("MainCamera")) // Assuming "MainCamera" is the player's camera
        {
            textOB.enabled = true;
            textOB.text = dialogue;
            StartCoroutine(DisableText());
        }
    }

    IEnumerator DisableText()
    {
        yield return new WaitForSeconds(timer);
        textOB.enabled = false;
        Destroy(Activator);
    }
}