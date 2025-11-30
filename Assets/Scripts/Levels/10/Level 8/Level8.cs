using UnityEngine;

public class Level8 : MonoBehaviour
{
CharlieController charlie;
ScenesManager scene;
float counter = 5f;

void Start()
{
    charlie = FindFirstObjectByType<CharlieController>();
    charlie.canExit = true;
    scene = FindFirstObjectByType<ScenesManager>();
    CounterManager();
}

    void Update()
    {
        if (counter <= 0)
        {
            scene.ReloadCurrentLevel();
        }
    }

    public void FinishLevel()
{
    if (charlie.rigidBody.IsTouchingLayers(LayerMask.GetMask("Door")) && charlie.canExit)
    {
        scene.LoadNextLevel();
    }
}

void CounterManager()
    {
        while (true)
        {
            counter -= Time.deltaTime;
            print(counter);
        }
    }
}
