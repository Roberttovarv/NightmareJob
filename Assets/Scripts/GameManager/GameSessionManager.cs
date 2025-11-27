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
        if (gameSessionsNumber > 1) Destroy(gameObject);
        else DontDestroyOnLoad(gameObject);

        int maxLevelReached = ProgressManager.GetMaxLevelReached();

        currentLevel = SceneManager.GetActiveScene().buildIndex;
        langCode = CultureInfo.CurrentCulture.TwoLetterISOLanguageName;
        if (langCode != "es" && langCode != "en") langCode = "en";
    }
    void Start()
    {
        levelText.text = currentLevel + " - " + LevelsData.level[currentLevel][langCode];
    }

    
}
