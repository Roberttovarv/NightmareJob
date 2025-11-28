using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ScenesManager : MonoBehaviour
{
    public void LoadLevel(int levelIndex)
    {
        SceneManager.LoadScene(levelIndex);
        FindFirstObjectByType<GameSessionManager>().SetLevel(levelIndex);

    }
    public void LoadNextLevel()
    {
        int currentLevel = SceneManager.GetActiveScene().buildIndex;
        int nextLevel = currentLevel + 1;

        ProgressManager.SetMaxLevel(nextLevel);
        SceneManager.LoadScene(nextLevel);
        FindFirstObjectByType<GameSessionManager>().SetLevel(nextLevel);


    }
    public void ReloadCurrentLevel()
    {
        int currentLevel = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentLevel);
        FindFirstObjectByType<GameSessionManager>().SetLevel(currentLevel);

    }

    public IEnumerator ReloadDelay()
    {
        yield return new WaitForSeconds(.3f);
        ReloadCurrentLevel();
    }

}
