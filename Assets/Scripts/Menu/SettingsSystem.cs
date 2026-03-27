using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsSystem : MonoBehaviour
{
    [SerializeField] public GameObject languagePanel;
    [SerializeField] public GameObject settingsPanel;
    [SerializeField] public TextMeshProUGUI buttonText;
    void Start()
    {
        languagePanel.SetActive(false);
        buttonText.text = PlayerPrefs.GetString("language").ToUpperInvariant();
    }
    public void GoToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void OpenLaguages()
    {
        languagePanel.SetActive(true);
        settingsPanel.SetActive(false);
    }

}
