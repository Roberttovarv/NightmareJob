using UnityEngine;
using UnityEngine.InputSystem;

public class Level4 : MonoBehaviour
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
    if (charlie.rigidBody.IsTouchingLayers(LayerMask.GetMask("Window")))
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
