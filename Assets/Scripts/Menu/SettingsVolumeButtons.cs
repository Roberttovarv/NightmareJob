using TMPro;
using UnityEngine;

public class SettingsVolumeButtons : MonoBehaviour
{
    private enum Type
    {
        music,
        sound
    }

    [SerializeField] Type type;
    TextMeshProUGUI buttonText;
    string value;

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
}
