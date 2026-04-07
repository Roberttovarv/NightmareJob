using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MoveButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public float direction; 
    WalkManager walkManager;
    void Awake()
    {
        RefreshWalkManager();
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        RefreshWalkManager();
    }

    void RefreshWalkManager()
    {
        walkManager = FindFirstObjectByType<WalkManager>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (walkManager == null)
        {
            RefreshWalkManager();
            if (walkManager == null) return;
        }

        walkManager.SetHorizontalInput(direction);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (walkManager == null)
        {
            RefreshWalkManager();
            if (walkManager == null) return;
        }

        walkManager.SetHorizontalInput(0);
    }

}
