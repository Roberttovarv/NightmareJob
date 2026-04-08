using UnityEngine;
using UnityEngine.InputSystem;

public class Level1 : MonoBehaviour
{
    CharlieController charlie;
    ScenesManager scene;

    void Start()
    {
        charlie = FindFirstObjectByType<CharlieController>();
        scene = FindFirstObjectByType<ScenesManager>();

        if (charlie == null)
        {
            Debug.LogError("Level1: No se encontro CharlieController en la escena.", this);
            return;
        }

        if (scene == null)
        {
            Debug.LogError("Level1: No se encontro ScenesManager en la escena.", this);
            return;
        }

        charlie.canExit = true;
        charlie.onAction = HandleAction;
    }

    void Update()
    {

    }

    public void FinishLevel()
    {
        if (charlie == null || scene == null)
        {
            Debug.LogError("Level1: No se puede terminar el nivel porque faltan referencias inicializadas.", this);
            return;
        }

        if (charlie.rigidBody.IsTouchingLayers(LayerMask.GetMask("Door")) && charlie.canExit)
        {
            scene.LoadNextLevel();
        }
    }

    void HandleAction()
    {
        FinishLevel();
    }

    void OnAction(InputValue value)
    {
        if (charlie == null)
        {
            Debug.LogError("Level1: OnAction recibido pero CharlieController es null.", this);
            return;
        }

        charlie.TriggerAction();
    }
}
