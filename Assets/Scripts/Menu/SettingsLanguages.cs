using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SettingsLanguages : MonoBehaviour
{
    [SerializeField] private SettingsSystem settings;
    [SerializeField] private GameObject languageButton;
    [SerializeField] private GameObject defaultButton;
    [SerializeField] private Transform buttonContainer;
    private GameObject firstButton = null;
    private bool buttonsGenerated;

    private enum Languages { es, en, it, pt, ru, zh, ja, de, ar }

    private void Start()
    {
        settings = FindFirstObjectByType<SettingsSystem>();
        GenerateLangButtons();
    }

    private void OnEnable()
    {
        StartCoroutine(SelectDefaultButtonNextFrame());
    }

    public void ClosePanel()
    {
        settings.languagePanel.SetActive(false);
        settings.settingsPanel.SetActive(true);
    }

    public void GenerateLangButtons()
    {
        if (buttonsGenerated)
        {
            return;
        }

        foreach (Languages lang in Enum.GetValues(typeof(Languages)))
        {
            Languages currentLang = lang;
            GameObject buttonObject = Instantiate(languageButton, buttonContainer);
            buttonObject.GetComponentInChildren<TextMeshProUGUI>().text = GetLanguageDisplayName(currentLang);

            buttonObject.GetComponent<Button>().onClick.AddListener(() =>
            {
                PlayerPrefs.SetString("language", currentLang.ToString());
                settings.buttonText.text = lang.ToString().ToUpperInvariant();
                PlayerPrefs.Save();

                GameSessionManager gameSession = FindFirstObjectByType<GameSessionManager>();
                if (gameSession != null)
                {
                    gameSession.langCode = currentLang.ToString();
                }

                ClosePanel();
                EventSystem.current.SetSelectedGameObject(defaultButton);
            });
            if (firstButton == null)
            {
                firstButton = buttonObject;
            }
        }

        if (firstButton == null && buttonContainer.childCount > 0)
        {
            firstButton = buttonContainer.GetChild(0).gameObject;
        }

        buttonsGenerated = true;
    }

private IEnumerator SelectDefaultButtonNextFrame()
{
    yield return null;

    LayoutRebuilder.ForceRebuildLayoutImmediate((RectTransform)buttonContainer);

    yield return null;

    if (EventSystem.current == null || firstButton == null)
        yield break;

    EventSystem.current.SetSelectedGameObject(null);
    EventSystem.current.SetSelectedGameObject(firstButton);
}

    private string GetLanguageDisplayName(Languages lang)
    {
        switch (lang)
        {
            case Languages.es: return "Español";
            case Languages.en: return "English";
            case Languages.it: return "Italiano";
            case Languages.pt: return "Português";
            case Languages.ru: return "Русский";
            case Languages.zh: return "中文";
            case Languages.ja: return "日本語";
            case Languages.de: return "Deutsch";
            case Languages.ar: return "العربية";
            default: return lang.ToString();
        }
    }
}
