using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ScenesManager : MonoBehaviour
{
    public void LoadLevel(int levelIndex)
    {
        LoadSceneWithFade("Level " + levelIndex);
        FindFirstObjectByType<GameSessionManager>().SetLevel(levelIndex);

    }
    public void LoadNextLevel()
    {
        int currentLevel = GetActiveLevelIndex();

        if (GameSessionManager.maxGameLeves == currentLevel)
        {
            LoadMenu();
            return;
        }

        int nextLevel = currentLevel + 1;

        ProgressManager.SetMaxLevel(nextLevel);
        LoadLevel(nextLevel);


    }
    public void ReloadCurrentLevel()
    {
        int currentLevel = GetActiveLevelIndex();
        LoadLevel(currentLevel);

    }

    public void ReloadCurrentLevelWithoutFade()
    {
        int currentLevel = GetActiveLevelIndex();
        LoadSceneWithoutFade("Level " + currentLevel);
        FindFirstObjectByType<GameSessionManager>().SetLevel(currentLevel);
    }

    public void LoadCinematic()
    {
        LoadSceneWithFade("Cinematic");
    }

    public void LoadMenu()
    {
        LoadSceneWithoutFade("Menu");
    }

    public void LoadLevels()
    {
        LoadSceneWithoutFade("Levels");
    }

    public void LoadSettings()
    {
        LoadSceneWithoutFade("Settings");
    }

    public void Continue()
    {
        int maxLevelReached = ProgressManager.GetMaxLevelReached();

        if (ShouldLoadCinematicOnContinue(maxLevelReached))
        {
            LoadCinematic();
            return;
        }

        LoadLevel(maxLevelReached);

    }

    bool ShouldLoadCinematicOnContinue(int maxLevelReached)
    {
        int currentChapter = SessionPreferences.GetCurrentChapter();

        return currentChapter == 0 && maxLevelReached == 1
            || currentChapter == 1 && maxLevelReached == 31
            || currentChapter == 2 && maxLevelReached == 61;
    }

    int GetActiveLevelIndex()
    {
        string sceneName = SceneManager.GetActiveScene().name;
        if (sceneName.StartsWith("Level ")
            && int.TryParse(sceneName.Replace("Level ", ""), out int levelIndex))
        {
            return levelIndex;
        }

        return SceneManager.GetActiveScene().buildIndex;
    }

    private void LoadSceneWithFade(string sceneName)
    {
        StartCoroutine(LoadSceneRoutine(sceneName));
    }

    private void LoadSceneWithoutFade(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    private IEnumerator LoadSceneRoutine(string sceneName)
    {
        yield return FadeManager.Instance.FadeOut();

        yield return SceneManager.LoadSceneAsync(sceneName);

        yield return FadeManager.Instance.FadeIn();
    }

    public IEnumerator ReloadDelay()
    {
        yield return new WaitForSeconds(.3f);
        ReloadCurrentLevel();
    }

    public IEnumerator ReloadDelayWithoutFade()
    {
        yield return new WaitForSeconds(.3f);
        ReloadCurrentLevelWithoutFade();
    }

}
