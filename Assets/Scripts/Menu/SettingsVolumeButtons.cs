using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SettingsVolumeButtons : MonoBehaviour


{
    private enum Type
    {
        music,
        sound
    }

    [SerializeField] private Type type;
    [SerializeField] Sprite activeImg;
    [SerializeField] Sprite deactImg;


    private Image buttonImage;
    private string value;

    void Awake()
    {
        buttonImage = GetComponentInChildren<Image>();
        value = type == Type.music ? SessionPreferences.MusicKey : SessionPreferences.SoundKey;
    }

    void Start()
    {
        SetButtonColor();
    }

    void OnEnable()
    {
        SetButtonColor();
    }

    public void SetButtonColor()
    {
        int currentValue = PlayerPrefs.GetInt(value, 1);

        buttonImage.sprite = currentValue == 1 ? activeImg : deactImg;
    }

    public void ToggleValue()
    {
        int currentValue = PlayerPrefs.GetInt(value, 1);
        int newValue = 1 - currentValue;

        PlayerPrefs.SetInt(value, newValue);
        PlayerPrefs.Save();

        SetButtonColor();
    }
}
