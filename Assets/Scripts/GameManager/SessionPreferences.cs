using System.Globalization;
using UnityEngine;

public static class SessionPreferences
{
    public const string LanguageKey = "language";
    public const string MusicKey = "musicValue";
    public const string SoundKey = "soundValue";
    public const string DeathsKey = "deaths";
    public const string CurrentChapterKey = "currentChapter";

    public static void Initialize()
    {
        bool saveNeeded = false;

        ProgressManager.InitializeProgress();

        if (!PlayerPrefs.HasKey(MusicKey))
        {
            PlayerPrefs.SetInt(MusicKey, 1);
            saveNeeded = true;
        }

        if (!PlayerPrefs.HasKey(SoundKey))
        {
            PlayerPrefs.SetInt(SoundKey, 1);
            saveNeeded = true;
        }

        if (!PlayerPrefs.HasKey(LanguageKey))
        {
            PlayerPrefs.SetString(LanguageKey, GetDefaultLanguage());
            saveNeeded = true;
        }

        if (!PlayerPrefs.HasKey(DeathsKey))
        {
            PlayerPrefs.SetInt(DeathsKey, 0);
            saveNeeded = true;
        }

        if (!PlayerPrefs.HasKey(CurrentChapterKey))
        {
            PlayerPrefs.SetInt(CurrentChapterKey, 0);
            saveNeeded = true;
        }

        string langCode = PlayerPrefs.GetString(LanguageKey, "en");
        if (langCode != "es" && langCode != "en")
        {
            PlayerPrefs.SetString(LanguageKey, "en");
            saveNeeded = true;
        }

        if (saveNeeded)
        {
            PlayerPrefs.Save();
        }
    }

    public static string GetLanguage()
    {
        return PlayerPrefs.GetString(LanguageKey, "en");
    }

    public static int GetCurrentChapter()
    {
        return PlayerPrefs.GetInt(CurrentChapterKey, 0);
    }

    public static void SetCurrentChapter(int chapter)
    {
        PlayerPrefs.SetInt(CurrentChapterKey, chapter);
        PlayerPrefs.Save();
    }

    public static void ResetData()
    {
        PlayerPrefs.SetInt(DeathsKey, 0);
        PlayerPrefs.SetInt(CurrentChapterKey, 0);
        PlayerPrefs.SetInt("MaxLevelUnlocked", 0);
        PlayerPrefs.SetString(LanguageKey, "en");
        PlayerPrefs.Save();
    }

    private static string GetDefaultLanguage()
    {
        string systemLanguage = CultureInfo.CurrentCulture.TwoLetterISOLanguageName;
        return systemLanguage == "es" || systemLanguage == "en" ? systemLanguage : "en";
    }
}
