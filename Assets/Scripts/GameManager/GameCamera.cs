using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Camera))]
public class GameCamera : MonoBehaviour
{
    private static GameCamera instance;

    private int lastWidth;
    private int lastHeight;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        ApplyAspect();
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
        ApplyAspect();
    }

    void Update()
    {
        if (Screen.width != lastWidth || Screen.height != lastHeight)
        {
            ApplyAspect();
            lastWidth = Screen.width;
            lastHeight = Screen.height;
        }
    }

    void ApplyAspect()
    {
        Camera cam = GetComponent<Camera>();

        // 👉 SOLO aplicar en NO mobile
        if (!GameSessionManager.isMobile)
        {
            float targetAspect = 16f / 9f;
            float windowAspect = (float)Screen.width / Screen.height;
            float scaleHeight = windowAspect / targetAspect;

            Rect rect = cam.rect;

            if (scaleHeight < 1.0f)
            {
                rect.width = 1.0f;
                rect.height = scaleHeight;
                rect.x = 0;
                rect.y = (1.0f - scaleHeight) / 2.0f;
            }
            else
            {
                float scaleWidth = 1.0f / scaleHeight;

                rect.width = scaleWidth;
                rect.height = 1.0f;
                rect.x = (1.0f - scaleWidth) / 2.0f;
                rect.y = 0;
            }

            cam.rect = rect;
        }
        else
        {
            // 👉 En móvil usar pantalla completa
            cam.rect = new Rect(0, 0, 1, 1);
        }
    }
}