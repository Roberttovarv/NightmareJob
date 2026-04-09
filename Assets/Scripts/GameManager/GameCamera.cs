using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Camera))]
public class GameCamera : MonoBehaviour
{
    public float targetWidth = 17.7f;

    private static GameCamera instance;
    private Camera cam;

    void Awake()
    {
        // Singleton (evita duplicados)
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);

        cam = GetComponent<Camera>();
    }

    void Start()
    {
        ApplyWidthFit();
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
        ApplyWidthFit();
    }

    void ApplyWidthFit()
    {
        float aspect = (float)Screen.width / Screen.height;
        cam.orthographicSize = targetWidth / (2f * aspect);
    }
}