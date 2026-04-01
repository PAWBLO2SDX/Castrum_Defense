using UnityEngine;
using Unity.UI;

public class PopUpManager : MonoBehaviour
{
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
}
