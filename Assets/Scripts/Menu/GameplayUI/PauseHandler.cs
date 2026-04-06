using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseHandler : MonoBehaviour
{
    HandleImage imgHandler;

    void Start()
    {
        imgHandler = FindFirstObjectByType<HandleImage>();

    }
    public void GoToMenu()
    {
        SceneManager.LoadScene("Menu");
        FindAnyObjectByType<GameplayUI>().DeactivatePause();
    }
    public void ManageSound()
    {
        int currentValue = PlayerPrefs.GetInt("soundValue");
        int newValue = 1 - currentValue;
        PlayerPrefs.SetInt("soundValue", newValue);
        PlayerPrefs.Save();
    }
    public void ManageMusic()
    {
        int currentValue = PlayerPrefs.GetInt("musicValue");
        int newValue = 1 - currentValue;
        PlayerPrefs.SetInt("musicValue", newValue);
        PlayerPrefs.Save();
    }
    public void Continue()
    {
        FindFirstObjectByType<GameplayUI>().DeactivatePause();
    }
}
