using UnityEngine;
using UnityEngine.InputSystem;

public class Level23 : MonoBehaviour
{
    CharlieController charlie;
    ScenesManager scene;

    void Start()
    {
        charlie = FindFirstObjectByType<CharlieController>();
        charlie.onAction = HandleAction;
        scene = FindFirstObjectByType<ScenesManager>();
        charlie.canExit = true;
        charlie.rigidBody.gravityScale = 3.5f;
    }

    void FinishLevel()
    {
        if (charlie.rigidBody.IsTouchingLayers(LayerMask.GetMask("Door"))
        && charlie.canExit)
        {
            scene.LoadNextLevel();
        }
    }
    void OnAction(InputValue value)
    {
        charlie.TriggerAction();
    }

    void HandleAction()
    {
        FinishLevel();
    }
}
