using UnityEngine;
using UnityEngine.InputSystem;

public class Level9 : MonoBehaviour
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
        if (charlie.rigidBody.IsTouchingLayers(LayerMask.GetMask("Door")) && charlie.canExit)
        {
            scene.LoadNextLevel();
        }
    }
    public void DrinkCoffee()
    {
        if (charlie.rigidBody.IsTouchingLayers(LayerMask.GetMask("Coffee"))) charlie.canExit = true;
    }

    void HandleAction()
    {
        DrinkCoffee();
        FinishLevel();
    }

    void OnAction(InputValue value)
    {
        charlie.TriggerAction();
    }
}
