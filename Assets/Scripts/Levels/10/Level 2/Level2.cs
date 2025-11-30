using UnityEngine;
using System.Collections;

public class Level2 : MonoBehaviour
{
    CharlieController charlie;
    ScenesManager scene;

    private void Start()
    {
        charlie = FindFirstObjectByType<CharlieController>();
        scene = FindFirstObjectByType<ScenesManager>();
        StartCoroutine(SwitchExit());
    }



    IEnumerator SwitchExit()
    {
        while (true)
        {
            yield return new WaitForSeconds(.2f);
            charlie.canExit = !charlie.canExit;
        }
    }

    public void FinishLevel()
    {
        if (charlie.rigidBody.IsTouchingLayers(LayerMask.GetMask("Door")) && charlie.canExit)
        {
            scene.LoadNextLevel();
        }
    }
}
