using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMeunMethods : MonoBehaviour
{
    public void StartButton(string sceneName)
    {
        SceneManager.LoadScene("Game");
    }

    public void QuitButton()
    {
        Debug.Log("Quit the game!");
        Application.Quit();
    }
    public void CreditsButton(string sceneName)
    {
        SceneManager.LoadScene("John's Credit Scene");
    }
    public void QuitCredit()
    {
        Debug.Log("Quit the game!");
        Application.Quit();
    }
   
}
