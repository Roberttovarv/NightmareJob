using UnityEngine;
using UnityEngine.InputSystem;

public class Level1 : MonoBehaviour
{
    CharlieController charlie;
    ScenesManager scene;
    void Start()
    {
        charlie = FindFirstObjectByType<CharlieController>();
        charlie.canExit = true;
        scene = FindFirstObjectByType<ScenesManager>();
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
}
