using UnityEngine;

public class Level13 : MonoBehaviour
{
    CharlieController charlie;
    ScenesManager scene;
    JumpManager jump;
    float originalJump;
    void Start()
    {
        jump = FindFirstObjectByType<JumpManager>();
        originalJump = jump.jumpForce;
        charlie = FindFirstObjectByType<CharlieController>();
        scene = FindFirstObjectByType<ScenesManager>();
        jump.jumpForce = 35;
        charlie.canExit = true;
    }

    public void FinishLevel()
    {
        if (charlie.rigidBody.IsTouchingLayers(LayerMask.GetMask("Door")) && charlie.canExit)
        {
            jump.jumpForce = originalJump;
            scene.LoadNextLevel();
        }
    }
}
