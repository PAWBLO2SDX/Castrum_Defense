using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMeunMethods : MonoBehaviour
{
    public void StartButton(string sceneName)
    {
        SceneManager.LoadScene("JohnScene");
    }

    public void QuitButton()
    {
        Debug.Log("Quit the game!");
        Application.Quit();
    }
    public void CreditButton(string sceneName)
    {
        SceneManager.LoadScene("Credits");
    }
    public void QuitCredit()
    {
        Debug.Log("Quit the game!");
        Application.Quit();
    }
}
