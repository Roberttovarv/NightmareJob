using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Globalization;

public class GameSessionManager : MonoBehaviour
{
    private const string LanguageKey = "language";
    private const string MusicKey = "musicValue";
    private const string SoundKey = "soundValue";
    private const string DeathsKey = "deaths";

    [SerializeField] TextMeshProUGUI levelText;

    public static bool IsPaused { get; private set; }

    public static int maxGameLeves = 30;
    public static string langCode;
    public static int currentLevel;

    void Awake()
    {
        int gameSessionsNumber = FindObjectsByType<GameSessionManager>(FindObjectsSortMode.None).Length;
        if (gameSessionsNumber > 1)
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
        SceneManager.sceneLoaded += OnSceneLoaded;

        InitializeSessionData();
    }

    void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void Start()
    {
        currentLevel = SceneManager.GetActiveScene().buildIndex;
        RefreshLevelText();

    }

    public void SetLevel(int levelIndex)
    {
        currentLevel = levelIndex;
        RefreshLevelText();
        FindFirstObjectByType<CharlieController>().canExit = false;
    }

    public static void Pause()
    {
        Time.timeScale = 0f;
        IsPaused = true;
    }

    public static void Resume()
    {
        Time.timeScale = 1f;
        IsPaused = false;
    }

    private void InitializeSessionData()
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

        langCode = PlayerPrefs.GetString(LanguageKey, "en");
        if (langCode != "es" && langCode != "en")
        {
            langCode = "en";
            PlayerPrefs.SetString(LanguageKey, langCode);
            saveNeeded = true;
        }

        if (saveNeeded)
        {
            PlayerPrefs.Save();
        }
    }

    private string GetDefaultLanguage()
    {
        string systemLanguage = CultureInfo.CurrentCulture.TwoLetterISOLanguageName;
        return systemLanguage == "es" || systemLanguage == "en" ? systemLanguage : "en";
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        currentLevel = scene.buildIndex;
        langCode = PlayerPrefs.GetString(LanguageKey, "en");
        RefreshLevelText();
    }

    private void RefreshLevelText()
    {
        if (levelText == null)
        {
            return;
        }

        if (!LevelsData.level.TryGetValue(currentLevel, out var levelData))
        {
            levelText.text = currentLevel.ToString();
            return;
        }

        if (!levelData.TryGetValue(langCode, out var localizedLevelText))
        {
            if (!levelData.TryGetValue("en", out localizedLevelText))
            {
                levelText.text = currentLevel.ToString();
                return;
            }
        }

        levelText.text = currentLevel + " - " + localizedLevelText;
    }
}
