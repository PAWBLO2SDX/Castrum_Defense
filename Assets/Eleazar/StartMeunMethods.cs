using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMeunMethods : MonoBehaviour
{
    public void StartButton(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void QuitButton()
    {
        Debug.Log("Quit the game!");
        Application.Quit();
    }

}
