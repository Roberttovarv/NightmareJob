using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    public void LoadLevel(int levelIndex)
    {
        FindFirstObjectByType<GameSessionManager>().currentLevel = levelIndex;
        SceneManager.LoadScene(levelIndex);

    }
    public void LoadNextLevel()
    {
        int currentLevel = SceneManager.GetActiveScene().buildIndex;
        int nextLevel = currentLevel + 1;

        FindFirstObjectByType<GameSessionManager>().currentLevel = nextLevel;
        ProgressManager.SetMaxLevel(nextLevel);
        SceneManager.LoadScene(nextLevel);

    }
    public void ReloadCurrentLevel()
    {
        int currentLevel = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentLevel);
    }

}
