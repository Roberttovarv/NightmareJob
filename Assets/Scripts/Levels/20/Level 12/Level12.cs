using UnityEngine;

public class Level12 : MonoBehaviour
{
    CharlieController charlie;
    ScenesManager scene;
    WalkManager walkManager;
    float originalVelocity;

    void Start()
    {
        walkManager = FindFirstObjectByType<WalkManager>();
        originalVelocity = walkManager.walkVel;
        walkManager.walkVel = 20f;
        charlie = FindFirstObjectByType<CharlieController>();
        scene = FindFirstObjectByType<ScenesManager>();
        charlie.canExit = true;
    }

    public void FinishLevel()
    {
        if (charlie.rigidBody.IsTouchingLayers(LayerMask.GetMask("Door")) && charlie.canExit)
        {
            walkManager.walkVel = originalVelocity;
            scene.LoadNextLevel();
        }
    }
}
