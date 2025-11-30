using UnityEngine;

public class Level11 : MonoBehaviour
{
CharlieController charlie;
ScenesManager scene;
    [SerializeField] GameObject document;
    SpriteRenderer[] childDoc;
    
void Start()
{
    charlie = FindFirstObjectByType<CharlieController>();
    scene = FindFirstObjectByType<ScenesManager>();
            childDoc = document.GetComponentsInChildren<SpriteRenderer>();

}

public void FinishLevel()
{
    if (charlie.rigidBody.IsTouchingLayers(LayerMask.GetMask("Door")) && charlie.canExit)
    {
        scene.LoadNextLevel();
    }
}
    public void DisposeDocument()
    {
        if (charlie.rigidBody.IsTouchingLayers(LayerMask.GetMask("Trash")))
        {
            HandleDocument();
            charlie.canExit = true;
        }
    }

    void HandleDocument()
    {
        foreach (var slide in childDoc)
        {   
            slide.enabled = slide.enabled ? false : true;
        }
    }
}
