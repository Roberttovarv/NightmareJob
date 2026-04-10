using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSessionManager : MonoBehaviour
{
    private const float NonDefaultResolutionYOffset = -25f;

    [SerializeField] TextMeshProUGUI levelText;
    private Vector2 defaultLevelTextPosition;
    private bool hasCachedLevelTextPosition;

    public static bool IsPaused { get; private set; }

    public static int maxGameLeves = 30;
    public static string langCode;
    public static int currentLevel;
    public static int currentChapter;
    public static bool isMobile;

    void Awake()
    {
        isMobile = Application.isMobilePlatform;

        int gameSessionsNumber = FindObjectsByType<GameSessionManager>(FindObjectsSortMode.None).Length;
        if (gameSessionsNumber > 1)
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
        SceneManager.sceneLoaded += OnSceneLoaded;

        SessionPreferences.Initialize();
        RefreshSessionState();
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

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        currentLevel = scene.buildIndex;
        RefreshSessionState();
        RefreshLevelText();
    }

    private void RefreshSessionState()
    {
        langCode = SessionPreferences.GetLanguage();
        currentChapter = SessionPreferences.GetCurrentChapter();
    }

    private void RefreshLevelText()
    {
        if (levelText == null)
        {
            return;
        }

        bool shouldShowLevelText = SceneManager.GetActiveScene().name.StartsWith("Level ");
        levelText.gameObject.SetActive(shouldShowLevelText);
        if (!shouldShowLevelText)
        {
            return;
        }

        if (!LevelsData.level.TryGetValue(currentLevel, out var levelData))
        {
            levelText.text = currentLevel.ToString();
            UpdateLevelTextPosition();
            return;
        }

        if (!levelData.TryGetValue(langCode, out var localizedLevelText))
        {
            if (!levelData.TryGetValue("en", out localizedLevelText))
            {
                levelText.text = currentLevel.ToString();
                UpdateLevelTextPosition();
                return;
            }
        }

        levelText.text = currentLevel + " - " + localizedLevelText;
        UpdateLevelTextPosition();
    }

    private void UpdateLevelTextPosition()
    {
        if (levelText == null)
        {
            return;
        }

        RectTransform levelTextRect = levelText.rectTransform;
        if (!hasCachedLevelTextPosition)
        {
            defaultLevelTextPosition = levelTextRect.anchoredPosition;
            hasCachedLevelTextPosition = true;
        }

        bool isDefaultResolution = Screen.width == 1920 && Screen.height == 1080;
        float yOffset = !isMobile && !isDefaultResolution ? NonDefaultResolutionYOffset : 0f;

        levelTextRect.anchoredPosition = new Vector2(
            defaultLevelTextPosition.x,
            defaultLevelTextPosition.y + yOffset
        );
    }
}
