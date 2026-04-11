using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class SettingsSystem : MonoBehaviour
{
    [SerializeField] public GameObject languagePanel;
    [SerializeField] public GameObject settingsPanel;
    [SerializeField] public TextMeshProUGUI buttonText;
    [SerializeField] GameObject languageButton;
    private bool lastInput;

    void Awake()
    {
        ClearSelection();
    }
    
    void Start()
    {
        languagePanel.SetActive(false);
        buttonText.text = PlayerPrefs.GetString(SessionPreferences.LanguageKey).ToUpperInvariant();
        lastInput = InputDeviceManager.isController;
        RefreshSelection();
    }

    void Update()
    {
        if (InputDeviceManager.isController != lastInput)
        {
            lastInput = InputDeviceManager.isController;
            RefreshSelection();
        }
    }

    public void GoToMenu()
    {
        FindFirstObjectByType<ScenesManager>().LoadMenu();
    }

    public void OpenLaguages()
    {
        languagePanel.SetActive(true);
        settingsPanel.SetActive(false);
    }

    void RefreshSelection()
    {
        if (GameSessionManager.isMobile || EventSystem.current == null)
        {
            ClearSelection();
            return;
        }

        if (InputDeviceManager.isController && languageButton != null)
        {
            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(languageButton);
            return;
        }

        ClearSelection();
    }

    void ClearSelection()
    {
        if (EventSystem.current == null)
        {
            return;
        }

        EventSystem.current.SetSelectedGameObject(null);
    }

}
