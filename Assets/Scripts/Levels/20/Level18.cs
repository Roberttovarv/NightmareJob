using UnityEngine;
using UnityEngine.InputSystem;

public class Level18 : MonoBehaviour
{
CharlieController charlie;
ScenesManager scene;
void Start()
{
    charlie = FindFirstObjectByType<CharlieController>();
    scene = FindFirstObjectByType<ScenesManager>();
    charlie.onAction = HandleAction;

    print("Charlie can exit? " + charlie.canExit);

}

public void FinishLevel()
{
    if (charlie.rigidBody.IsTouchingLayers(LayerMask.GetMask("Door")) && charlie.canExit)
    {
        scene.LoadNextLevel();
    }
}

public void GetNotes()
    {
             if (charlie.rigidBody.IsTouchingLayers(LayerMask.GetMask("Notes")))
    {
        print("Got notes");
        charlie.canExit = true;
    }
    }

void HandleAction()
{
    GetNotes();
    FinishLevel();
}

void OnAction(InputValue value)
{
    charlie.TriggerAction();
}
}
