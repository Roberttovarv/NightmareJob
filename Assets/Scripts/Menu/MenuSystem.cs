using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSystem : MonoBehaviour
{
    public void Continue()
    {
        SceneManager.LoadScene(ProgressManager.GetMaxLevelReached());
    }
    public void Levels()
    {
        SceneManager.LoadScene("Levels");
    }
    public void Settings()
    {
        SceneManager.LoadScene("Settings");

    }
    public void Quit()
    {
        print("Saliendo");
        Application.Quit();
    }
}
