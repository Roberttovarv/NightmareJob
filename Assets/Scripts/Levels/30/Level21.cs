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
    }

    void FinishLevel()
    {
        if (charlie.rigidBody.IsTouchingLayers(LayerMask.GetMask("Door")) && charlie.canExit)
           { scene.LoadNextLevel();}
    }

    void Flip()
    {
        charlie.rigidBody.gravityScale = -charlie.rigidBody.gravityScale;
        Vector3 scale = transform.localScale;
        scale.y *= -1;
        transform.localScale = scale;
    }
    void OnAction(InputValue value)
    {
           FinishLevel();
    }

    void OnJump(InputValue value)
    {
        Flip();    
    }

}