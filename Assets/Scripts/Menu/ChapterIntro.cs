using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;

public class ChapterIntro : MonoBehaviour
{
    private static ChapterIntro instance;

    public CanvasGroup canvasGroup;
    public TextMeshProUGUI text;

    public float fadeDuration = 0.5f;
    public float displayTime = 2f;

    private int currentChapter;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);

        canvasGroup.alpha = 0;
    }

    void Start()
    {
        currentChapter = SessionPreferences.GetCurrentChapter();
        OnSceneLoaded(SceneManager.GetActiveScene(), LoadSceneMode.Single);
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        int level = GetLevelFromScene(scene.name);

        CheckAndPlayChapter(level);
    }

    void CheckAndPlayChapter(int level)
    {
        if (level >= 1 && currentChapter == 0)
        {
            PlayChapter(1);
            currentChapter = 1;
            SessionPreferences.SetCurrentChapter(currentChapter);
        }
        else if (level >= 31 && currentChapter == 1)
        {
            PlayChapter(2);
            currentChapter = 2;
            SessionPreferences.SetCurrentChapter(currentChapter);

        }
        else if (level >= 61 && currentChapter == 2)
        {
            PlayChapter(3);
            currentChapter = 3;
            SessionPreferences.SetCurrentChapter(currentChapter);

        }
    }

    void PlayChapter(int chapter)
    {
        text.text = "Capítulo " + chapter;
        StopAllCoroutines();
        StartCoroutine(PlayAnimation());
    }

    IEnumerator PlayAnimation()
    {
        GameSessionManager.Pause();

        yield return Fade(0, 1);

        yield return new WaitForSecondsRealtime(displayTime);

        yield return Fade(1, 0);

        GameSessionManager.Resume();
    }

    IEnumerator Fade(float start, float end)
    {
        float time = 0;

        while (time < fadeDuration)
        {
            time += Time.unscaledDeltaTime;
            float t = time / fadeDuration;
            canvasGroup.alpha = Mathf.Lerp(start, end, t);
            yield return null;
        }

        canvasGroup.alpha = end;
    }

    int GetLevelFromScene(string sceneName)
    {
        string number = sceneName.Replace("Level ", "");
        int.TryParse(number, out int level);
        return level;
    }
}
