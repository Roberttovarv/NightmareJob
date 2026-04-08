using UnityEngine;
using UnityEngine.InputSystem;

public class Level3 : MonoBehaviour
{
CharlieController charlie;
ScenesManager scene;
void Start()
{
    charlie = FindFirstObjectByType<CharlieController>();
    scene = FindFirstObjectByType<ScenesManager>();
    charlie.onAction = HandleAction;
}

void Update()
{

}

public void FinishLevel()
{
    if (charlie.rigidBody.IsTouchingLayers(LayerMask.GetMask("Door")) && charlie.canExit)
    {
        scene.LoadNextLevel();
    }
}
public void UseComputer()
    {
    if (charlie.rigidBody.IsTouchingLayers(LayerMask.GetMask("Computer")))
        {
            charlie.canExit = true;
        }
    }

void HandleAction()
{
    UseComputer();
    FinishLevel();
}

void OnAction(InputValue value)
{
    charlie.TriggerAction();
}
}
