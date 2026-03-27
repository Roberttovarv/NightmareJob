using TMPro;
using UnityEngine;

public class SettingsVolumeButtons : MonoBehaviour
{
    private enum Type
    {
        music,
        sound
    }

    [SerializeField] private Type type;

    private TextMeshProUGUI buttonText;
    private string value;

    void Awake()
    {
        buttonText = GetComponentInChildren<TextMeshProUGUI>();
        value = type == Type.music ? "musicValue" : "soundValue";
    }

    void Start()
    {
        SetButtonText();
    }

    void OnEnable()
    {
        SetButtonText();
    }

    public void SetButtonText()
    {
        int currentValue = PlayerPrefs.GetInt(value, 1);

        buttonText.text = currentValue == 1 ? "Turn Off" : "Turn On";
    }

    public void ToggleValue()
    {
        int currentValue = PlayerPrefs.GetInt(value, 1);
        int newValue = currentValue == 1 ? 0 : 1;

        PlayerPrefs.SetInt(value, newValue);
        PlayerPrefs.Save();

        SetButtonText();
    }
}
