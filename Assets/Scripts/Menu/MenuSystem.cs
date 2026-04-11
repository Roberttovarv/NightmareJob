using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class MenuSystem : MonoBehaviour
{
    private bool lastInput;
    [SerializeField] GameObject firstButton;
    ScenesManager scene;

    void Start()
    {
       scene = FindFirstObjectByType<ScenesManager>(); 
    }

    void Update()
    {
        if (InputDeviceManager.isController != lastInput)
        {
            lastInput = InputDeviceManager.isController;
            if (lastInput)
            {
                EventSystem.current.SetSelectedGameObject(null);
                EventSystem.current.SetSelectedGameObject(firstButton);
            }
            else
            {
                EventSystem.current.SetSelectedGameObject(null);
            }
        }
    }

    public void Continue()
    {
        scene.Continue();
    }
    public void Levels()
    {
        scene.LoadLevels();
    }
    public void Settings()
    {
        scene.LoadSettings();

    }
    public void Quit()
    {
        print("Saliendo");
        Application.Quit();
    }
}
