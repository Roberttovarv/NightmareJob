using UnityEngine;

public class GameplayUI : MonoBehaviour
{
    private static GameplayUI instance;
    [SerializeField] GameObject pausePanel;
    [SerializeField] GameObject helpPanel;
    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
        pausePanel.SetActive(false);
        helpPanel.SetActive(false);
    }

    public void ActivatePause()
    {
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
        helpPanel.SetActive(true);
        GameSessionManager.Pause();
    }
        public void DeactivateHelp()
    {
        helpPanel.SetActive(false);
        GameSessionManager.Resume();
    }


}