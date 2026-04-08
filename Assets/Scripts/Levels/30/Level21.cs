using UnityEngine;
using UnityEngine.InputSystem;

public class Level21 : MonoBehaviour
{
    CharlieController charlie;
    ScenesManager scene;

    void Start()
    {
        charlie = FindFirstObjectByType<CharlieController>();
        scene = FindFirstObjectByType<ScenesManager>();
        charlie.canExit = true;
        charlie.onAction = HandleAction;
        charlie.onJump = Flip;
    }

    void FinishLevel()
    {
        if (charlie.rigidBody.IsTouchingLayers(LayerMask.GetMask("Door")) && charlie.canExit)
           { scene.LoadNextLevel();}
    }

    void HandleAction()
    {
        FinishLevel();
    }

    void OnAction(InputValue value)
    {
        charlie.TriggerAction();
    }

    void Flip()
    {
        charlie.rigidBody.gravityScale = -charlie.rigidBody.gravityScale;
        Vector3 scale = transform.localScale;
        scale.y *= -1;
        transform.localScale = scale;
    }

    void OnJump(InputValue value)
    {
        charlie.TriggerJump();
    }

}

