using UnityEngine;
using UnityEngine.InputSystem;

public class Level15 : MonoBehaviour
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
        if (charlie.rigidBody.IsTouchingLayers(LayerMask.GetMask("Clock")))
        {
            print("tocando el reloj");
        }    }

    public void FinishLevel()
{
    if (charlie.rigidBody.IsTouchingLayers(LayerMask.GetMask("Door")) && charlie.canExit)
    {
        scene.LoadNextLevel();
    }
}

public void GetTime()
    {
        if (charlie.rigidBody.IsTouchingLayers(LayerMask.GetMask("Clock")))
        {
            charlie.canExit = true;
        }
    }

void HandleAction()
{
    GetTime();
    FinishLevel();
}

void OnAction(InputValue value)
{
    charlie.TriggerAction();
}
}
