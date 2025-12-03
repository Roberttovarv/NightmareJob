using UnityEngine;

public class Level15 : MonoBehaviour
{
CharlieController charlie;
ScenesManager scene;
void Start()
{
    charlie = FindFirstObjectByType<CharlieController>();
    scene = FindFirstObjectByType<ScenesManager>();
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
}
