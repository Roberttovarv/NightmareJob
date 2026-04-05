using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplayUI : MonoBehaviour
{
    private static GameplayUI instance;
    [SerializeField] GameObject pausePanel;
    [SerializeField] GameObject helpPanel;
    [SerializeField] GameObject controllerLayout;
    [SerializeField] GameObject mnkLayout;
    [SerializeField] GameObject rootUI;

    private bool lastInput;
    private bool isLevel;

    void Start()
    {
        OnSceneLoaded(SceneManager.GetActiveScene(), LoadSceneMode.Single);
    }

void Awake()
{
    if (instance != null)
    {
        Destroy(gameObject);
        return;
    }

    instance = this;
    DontDestroyOnLoad(gameObject);

    SceneManager.sceneLoaded += OnSceneLoaded;

    pausePanel.SetActive(false);
    helpPanel.SetActive(false);
}

void OnDestroy()
{
    SceneManager.sceneLoaded -= OnSceneLoaded;
}
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        isLevel = scene.name.Contains("Level ");
        print(scene.name);

        rootUI.SetActive(isLevel);
        UpdateInputUI();
    }

    void Update()
    {
        if (!isLevel) return;
        if (InputDeviceManager.isController != lastInput)
        {
            lastInput = InputDeviceManager.isController;
            UpdateInputUI();
        }
    }

    public void ActivatePause()
    {
        if (GameSessionManager.IsPaused) return;
        pausePanel.SetActive(true);
        GameSessionManager.Pause();
    }
    public void DeactivatePause()
    {
        pausePanel.SetActive(false);
        GameSessionManager.Resume();
    }
    public void ActivateHelp()
    {
        if (GameSessionManager.IsPaused) return;
        helpPanel.SetActive(true);
        GameSessionManager.Pause();
    }
    public void DeactivateHelp()
    {
        helpPanel.SetActive(false);
        GameSessionManager.Resume();
    }
    void UpdateInputUI()
    {
        if (lastInput)
        {
            controllerLayout.SetActive(true);
            mnkLayout.SetActive(false);
        }
        else
        {
            controllerLayout.SetActive(false);
            mnkLayout.SetActive(true);
        }
    }

}