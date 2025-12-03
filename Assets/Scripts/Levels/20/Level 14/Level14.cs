using UnityEngine;

public class Level14 : MonoBehaviour
{
CharlieController charlie;
ScenesManager scene;
float rigidBodyGravity;
void Start()
{
    charlie = FindFirstObjectByType<CharlieController>();
    charlie.canExit = true;
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
}
