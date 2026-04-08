using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ActButton : MonoBehaviour, IPointerDownHandler
{
    CharlieController charlie;

    void Awake()
    {
        RefreshCharlie();
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        RefreshCharlie();
    }

    void RefreshCharlie()
    {
        charlie = FindFirstObjectByType<CharlieController>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (charlie == null)
        {
            RefreshCharlie();
            if (charlie == null) return;
        }

        charlie.TriggerAction();
    }
}
