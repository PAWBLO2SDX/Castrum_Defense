using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using Unity.UI;

public class SettingMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    // Drag your "PopupPanel" GameObject here in the Unity Inspector
    [SerializeField] private GameObject popupPanel;

    // Call this method to show the popup (e.g., via a Button's OnClick event)
    public void OpenPopup()
    {
        popupPanel.SetActive(true);
        // Optional: Pause game time while popup is open
        // Time.timeScale = 0f; 
    }

    // Call this method to hide the popup
    public void ClosePopup()
    {
        popupPanel.SetActive(false);
        // Optional: Resume game time
        // Time.timeScale = 1f; 
    }


    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("Volume", volume);
    }

    public void SetQuality (int qualityIndex) 
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }


}
