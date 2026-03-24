using UnityEngine;

public class SettingsSystem : MonoBehaviour
{
    public void SetSound()
    {
        int currentValue = PlayerPrefs.GetInt("soundValue");
        int newValue = currentValue == 1 ? 0 : 1;
        PlayerPrefs.SetInt("soundValue", newValue);
        PlayerPrefs.Save();
    }
    public void SetMusic()
    {
        int currentValue = PlayerPrefs.GetInt("musicValue");
        int newValue = currentValue == 1 ? 0 : 1;
        PlayerPrefs.SetInt("musicValue", newValue);
        PlayerPrefs.Save();
    }
}
