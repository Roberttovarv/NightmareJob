using UnityEngine;
using UnityEngine.InputSystem;

public class Level7 : MonoBehaviour
{
CharlieController charlie;
ScenesManager scene;
void Start()
{
    charlie = FindFirstObjectByType<CharlieController>();
    charlie.canExit = true;
    charlie.onAction = HandleAction;
    scene = FindFirstObjectByType<ScenesManager>();
}

public void FinishLevel()
{
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
