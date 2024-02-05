using UnityEngine;
using TMPro;

public class TriggerCupBoard : MonoBehaviour
{
    public TextMeshProUGUI text;

    private bool textEnabled = false;

    void Update()
    {
        if (textEnabled && Input.GetKeyDown(KeyCode.E))
        {
            // Player has pressed 'E', so disable the text
            text.gameObject.SetActive(false);
            textEnabled = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            // Enable the text when entering the trigger zone
            text.gameObject.SetActive(true);
            textEnabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            text.gameObject.SetActive(false);
            text.enabled = false;
        }
    }
}