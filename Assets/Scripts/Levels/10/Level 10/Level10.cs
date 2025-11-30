using System;
using UnityEngine;

public class Level10 : MonoBehaviour
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
        HandleDocument();
    }

    public void FinishLevel()
    {
        if (charlie.rigidBody.IsTouchingLayers(LayerMask.GetMask("Door")) && charlie.canExit)
        {
            scene.LoadNextLevel();
        }
    }

    public void GetDocument()
    {
        if (charlie.rigidBody.IsTouchingLayers(LayerMask.GetMask("Archs")))
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
