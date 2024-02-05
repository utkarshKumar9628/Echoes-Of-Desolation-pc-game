using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using TMPro;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public TMP_Dropdown qualityDropdown; // Use TMP_Dropdown for TextMeshPro

    private void Start()
    {
        // Populate the dropdown with available quality levels
        PopulateQualityDropdown();
    }

    public void setVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    private void PopulateQualityDropdown()
    {
        // Check if the dropdown is assigned
        if (qualityDropdown == null)
        {
            Debug.LogError("TMP_Dropdown not assigned to SettingsMenu.");
            return;
        }

        // Clear existing options
        qualityDropdown.ClearOptions();

        // Get available quality levels and convert to string list
        List<string> qualityOptions = new List<string>();
        for (int i = 0; i < QualitySettings.names.Length; i++)
        {
            qualityOptions.Add(QualitySettings.names[i]);
        }

        // Populate the dropdown with quality options
        qualityDropdown.AddOptions(qualityOptions);

        // Set the initial value based on the current quality level
        qualityDropdown.value = QualitySettings.GetQualityLevel();
    }
}