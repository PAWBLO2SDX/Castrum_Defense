using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsScene : MonoBehaviour
{
    public void CreditsButton(string sceneName)
    {
        SceneManager.LoadScene("John's Credit Scene");
    }
    public void CreditsButton1(string sceneName)
    {
        SceneManager.LoadScene("Eleazar's Credit Scene");
    }
    public void CreditsButton2(string sceneName)
    {
        SceneManager.LoadScene("Sylva's Credit Scene");
    }
    public void CreditsButton11(string sceneName)
    {
        SceneManager.LoadScene("Jackson's Credit Scene");
    }
    public void CreditsButton3(string sceneName)
    {
        SceneManager.LoadScene("Jayden's Credit Scene");
    }
    public void CreditsButton4(string sceneName)
    {
        SceneManager.LoadScene("Start Menu");
    }
}
