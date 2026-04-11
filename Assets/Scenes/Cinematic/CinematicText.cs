using TMPro;
using System.Collections;
using UnityEngine;

public class CinematicText : MonoBehaviour
{

    ScenesManager scene;
    void Start()
    {
        scene = FindFirstObjectByType<ScenesManager>();
        TextMeshProUGUI text = GetComponent<TextMeshProUGUI>();
        int currentChapter = SessionPreferences.GetCurrentChapter();

        SessionPreferences.SetCurrentChapter(currentChapter + 1);
        currentChapter = 1 + currentChapter;

        text.text = "Chapter " + currentChapter;

        StartCoroutine(LoadNextUnlockedLevelDelay());
    }

    IEnumerator LoadNextUnlockedLevelDelay()
    {
        yield return new WaitForSeconds(1.5f);

        int maxLevelReached = ProgressManager.GetMaxLevelReached();
        int levelToLoad = maxLevelReached == 1 ? maxLevelReached : maxLevelReached + 1;

        scene.LoadLevel(levelToLoad);
    }
}
