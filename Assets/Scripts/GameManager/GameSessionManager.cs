using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Globalization;


public class GameSessionManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI levelText;

    public string langCode;
    public int currentLevel;

    void Awake()
    {
        int gameSessionsNumber = FindObjectsByType<GameSessionManager>(FindObjectsSortMode.None).Length;
        int levelTextNumber = FindObjectsByType<TextMeshProUGUI>(FindObjectsSortMode.None).Length;
        if (gameSessionsNumber > 1) Destroy(gameObject);
        else DontDestroyOnLoad(gameObject);
        if (levelTextNumber > 1) Destroy(levelText.gameObject);
        else DontDestroyOnLoad(levelText.gameObject);

        langCode = CultureInfo.CurrentCulture.TwoLetterISOLanguageName;
        if (langCode != "es" && langCode != "en") langCode = "en";
    }
    void Start()
    {
        levelText.text = currentLevel + " - " + LevelsData.level[currentLevel][langCode];

    }
    public void SetLevel(int levelIndex)
    {
        currentLevel = levelIndex;
        levelText.text = currentLevel + " - " + LevelsData.level[currentLevel][langCode];
        FindFirstObjectByType<CharlieController>().canExit = false;

    }



}
