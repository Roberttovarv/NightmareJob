using UnityEngine;

public class Level18 : MonoBehaviour
{
CharlieController charlie;
ScenesManager scene;
void Start()
{
    charlie = FindFirstObjectByType<CharlieController>();
    scene = FindFirstObjectByType<ScenesManager>();

    print("Charlie can exit? " + charlie.canExit);

}

public void FinishLevel()
{
    if (charlie.rigidBody.IsTouchingLayers(LayerMask.GetMask("Door")) && charlie.canExit)
    {
        scene.LoadNextLevel();
    }
}

public void GetNotes()
    {
             if (charlie.rigidBody.IsTouchingLayers(LayerMask.GetMask("Notes")))
    {
        print("Got notes");
        charlie.canExit = true;
    }
    }
}
