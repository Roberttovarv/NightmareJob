using UnityEngine;
using UnityEngine.InputSystem;
public class Level30 : MonoBehaviour
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
        FinishLevel30();
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

void FinishLevel30()
    {
        if (SessionPreferences.GetCurrentChapter() == 1)
        {
            scene.LoadCinematic();
        }
        else
        {
            scene.LoadNextLevel();
        }
    }
}

