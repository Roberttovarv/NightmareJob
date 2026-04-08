using UnityEngine;
using UnityEngine.InputSystem;
public class Level28 : MonoBehaviour
{
CharlieController charlie;
ScenesManager scene;

void Start()
{
    charlie = FindFirstObjectByType<CharlieController>();
    scene = FindFirstObjectByType<ScenesManager>();
    charlie.canExit = true;
    charlie.onAction = HandleAction;
}

void FinishLevel()
{
    if (charlie.rigidBody.IsTouchingLayers(LayerMask.GetMask("Door"))
    && charlie.canExit)
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
