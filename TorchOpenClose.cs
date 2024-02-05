using System.Collections;
using TMPro;
using UnityEngine;

public class TorchOpenClose : MonoBehaviour
{
    public TextMeshProUGUI torchEnableText;
    public float displayTimeInSeconds = 5f;
    public float initialDelayInSeconds = 5f;
    public GameObject cutsceneObject;

    private void Start()
    {
        StartCoroutine(TorchEnableText());
    }

    IEnumerator TorchEnableText()
    {
        // Wait for the cutscene object to be disabled
        while (cutsceneObject.activeSelf)
        {
            yield return null;
        }

        // Initially disable the text
        torchEnableText.gameObject.SetActive(false);

        // Wait for the initial delay
        yield return new WaitForSeconds(initialDelayInSeconds);

        // Enable the text for the specified display time
        torchEnableText.gameObject.SetActive(true);
        yield return new WaitForSeconds(displayTimeInSeconds);

        // Disable the text again
        torchEnableText.gameObject.SetActive(false);
    }
}