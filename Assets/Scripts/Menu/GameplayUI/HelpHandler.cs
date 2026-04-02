using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HelpHandler : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI helpText;

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        RefreshText();
    }

    void Start()
    {
        RefreshText();
        print(helpText);
    }

    public void RefreshText()
    {
        if (helpText == null)
        {
            return;
        }

        int currentLevel = GameSessionManager.currentLevel;
        string hintKey = "hint_" + GameSessionManager.langCode;

        if (!LevelsData.level.TryGetValue(currentLevel, out var levelData))
        {
            helpText.text = "Just get out.";
            return;
        }

        if (!levelData.TryGetValue(hintKey, out var hintText))
        {
            if (!levelData.TryGetValue("hint_en", out hintText))
            {
                helpText.text = "Just get out.";
                return;
            }
        }

        helpText.text = hintText;
    }
    public void NextLevel()
    {
        FindFirstObjectByType<ScenesManager>().LoadNextLevel();
        FindAnyObjectByType<GameplayUI>().DeactivateHelp();
    }

    public void Continue()
    {
        FindAnyObjectByType<GameplayUI>().DeactivateHelp();
    }

    void Awake()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

}
