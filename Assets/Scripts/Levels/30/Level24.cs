using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.Universal;


public class Level24 : MonoBehaviour
{
    CharlieController charlie;
    ScenesManager scene;
    Light2D currentLamp = null;

    bool[] lampIsOff = new bool[4];

    int? currentItem;

    void Start()
    {
        charlie = FindFirstObjectByType<CharlieController>();
        scene = FindFirstObjectByType<ScenesManager>();
    }

    void FinishLevel()
    {
        if (charlie.rigidBody.IsTouchingLayers(LayerMask.GetMask("Door"))
        && charlie.canExit)
        {
            scene.LoadNextLevel();
        }
    }
    void OnAction(InputValue value)
    {
        FinishLevel();
        handleLamp();
    }
    void handleLamp()
    {
        if (charlie.rigidBody.IsTouchingLayers(LayerMask.GetMask("WallLamp"))
        && currentItem.HasValue)
        {
            lampIsOff[currentItem.Value] = !lampIsOff[currentItem.Value];
            if (currentLamp != null) currentLamp.enabled = !currentLamp.enabled;

        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("WallLamp"))
        {
            currentItem = int.Parse(collision.gameObject.name);
            currentLamp = collision.GetComponent<Light2D>();
            print(currentItem);
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("WallLamp"))
        {
            currentItem = null;
            currentLamp = null;
        }
    }

    void AreAllOff()
    {
        for (int i = 0; i < 4; i++)
        {
            if (!lampIsOff[i]) charlie.canExit = false;
        }
        charlie.canExit = true;
    }
    void Update()
    {
        AreAllOff();
    }
}
