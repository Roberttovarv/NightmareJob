using UnityEngine;

public class Level9 : MonoBehaviour
{
    CharlieController charlie;
    ScenesManager scene;
    void Start()
    {
        charlie = FindFirstObjectByType<CharlieController>();
        scene = FindFirstObjectByType<ScenesManager>();
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
}
