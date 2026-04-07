using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class JumpButton : MonoBehaviour, IPointerDownHandler
{
    JumpManager jumpManager;
    
    void Awake()
    {
        RefreshJumpManager();
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        RefreshJumpManager();
    }

    void RefreshJumpManager()
    {
        jumpManager = FindFirstObjectByType<JumpManager>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (jumpManager == null)
        {
            RefreshJumpManager();
            if (jumpManager == null) return;
        }

        jumpManager.JumpFromUI();
    }
}
