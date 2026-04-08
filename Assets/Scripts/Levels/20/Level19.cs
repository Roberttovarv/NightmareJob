using UnityEngine;
using UnityEngine.InputSystem;

public class Level19 : MonoBehaviour
{
    CharlieController charlie;
    ScenesManager scene;
    void Start()
    {
        charlie = FindFirstObjectByType<CharlieController>();
        scene = FindFirstObjectByType<ScenesManager>();
        charlie.onAction = HandleAction;
    }

    public void FinishLevel()
    {
        if (charlie.rigidBody.IsTouchingLayers(LayerMask.GetMask("Water")))
        {
            charlie.canExit = true;
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
        charlie.TriggerAction();
    }

}
