using UnityEngine;
using UnityEngine.InputSystem;

public class Level14 : MonoBehaviour
{
CharlieController charlie;
ScenesManager scene;
float rigidBodyGravity;
void Start()
{
    charlie = FindFirstObjectByType<CharlieController>();
    charlie.canExit = true;
    charlie.onAction = HandleAction;
    rigidBodyGravity = charlie.rigidBody.gravityScale;
    scene = FindFirstObjectByType<ScenesManager>();
    charlie.rigidBody.gravityScale = 0.4f;
}

public void FinishLevel()
{
    if (charlie.rigidBody.IsTouchingLayers(LayerMask.GetMask("Door")) && charlie.canExit)
    {
        charlie.rigidBody.gravityScale = rigidBodyGravity;
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
