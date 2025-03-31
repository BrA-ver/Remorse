using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string targetScene;

    public void Play()
    {
        SceneManager.LoadScene(targetScene);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
