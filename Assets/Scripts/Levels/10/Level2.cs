using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;

public class Level2 : MonoBehaviour
{
    CharlieController charlie;
    ScenesManager scene;

    private void Start()
    {
        charlie = FindFirstObjectByType<CharlieController>();
        scene = FindFirstObjectByType<ScenesManager>();
        charlie.onAction = HandleAction;
        StartCoroutine(SwitchExit());
    }



    IEnumerator SwitchExit()
    {
        while (true)
        {
            yield return new WaitForSeconds(.1f);
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

    void HandleAction()
    {
        FinishLevel();
    }

    void OnAction(InputValue value)
    {
        charlie.TriggerAction();
    }
}
