using UnityEngine;
using UnityEngine.InputSystem;

public class Level23 : MonoBehaviour
{
    CharlieController charlie;
    ScenesManager scene;
    void Start()
    {
        charlie = FindFirstObjectByType<CharlieController>();
        scene = FindFirstObjectByType<ScenesManager>();
        charlie.canExit = true;
        charlie.rigidBody.gravityScale = 3.5f;
    }

    void FinishLevel()
    {
        if (charlie.rigidBody.IsTouchingLayers(LayerMask.GetMask("Door"))
        && charlie.canExit)
        {
            scene.LoadNextLevel();
        }
    }
    void OnAction(InputValue value)
    {
        FinishLevel();
    }
}
