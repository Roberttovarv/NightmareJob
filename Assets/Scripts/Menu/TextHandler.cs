using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextHandler : MonoBehaviour
{
    string objName;
    string lang;
    TextMeshProUGUI text;
    string word;


    void Awake()
    {
        objName = gameObject.name;
        int maxLevel = ProgressManager.GetMaxLevelReached();
        int currentChapter = SessionPreferences.GetCurrentChapter();

        if (objName == "start" && maxLevel > 1 && currentChapter == 0)
        {
            objName = "continue";
        }
        text = GetComponentInChildren<TextMeshProUGUI>();
    }

    void Start()
    {
        RefreshText();
    }

    public void RefreshText()
    {
        lang = PlayerPrefs.GetString(SessionPreferences.LanguageKey);
        FindKey();

        if (text != null)
        {
            text.text = word;
        }
    }

    void FindKey()
    {
        Dictionary<string, Dictionary<string, string>>[] sections =
        {
            MenuData.Menu,
            MenuData.Settings,
            MenuData.Levels
        };

        foreach (Dictionary<string, Dictionary<string, string>> section in sections)
        {
            if (section.TryGetValue(objName, out Dictionary<string, string> translations) &&
                translations.TryGetValue(lang, out word))
            {
                return;
            }
        }

        word = objName;
    }
}
