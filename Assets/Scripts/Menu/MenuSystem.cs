using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class MenuSystem : MonoBehaviour
{
    private bool lastInput;
    [SerializeField] GameObject firstButton;

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
        SceneManager.LoadScene(ProgressManager.GetMaxLevelReached());
    }
    public void Levels()
    {
        SceneManager.LoadScene("Levels");
    }
    public void Settings()
    {
        SceneManager.LoadScene("Settings");

    }
    public void Quit()
    {
        print("Saliendo");
        Application.Quit();
    }
}
