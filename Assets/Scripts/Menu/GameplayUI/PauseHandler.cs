using UnityEngine;

public class PauseHandler : MonoBehaviour
{
    HandleImage imgHandler;

    void Start()
    {
        imgHandler = FindFirstObjectByType<HandleImage>();

    }
    public void GoToMenu()
    {
        FindFirstObjectByType<ScenesManager>().LoadMenu();
        FindAnyObjectByType<GameplayUI>().DeactivatePause();
    }
    public void ManageSound()
    {
        int currentValue = PlayerPrefs.GetInt(SessionPreferences.SoundKey);
        int newValue = 1 - currentValue;
        PlayerPrefs.SetInt(SessionPreferences.SoundKey, newValue);
        PlayerPrefs.Save();
    }
    public void ManageMusic()
    {
        int currentValue = PlayerPrefs.GetInt(SessionPreferences.MusicKey);
        int newValue = 1 - currentValue;
        PlayerPrefs.SetInt(SessionPreferences.MusicKey, newValue);
        PlayerPrefs.Save();
    }
    public void Continue()
    {
        FindFirstObjectByType<GameplayUI>().DeactivatePause();
    }
}
