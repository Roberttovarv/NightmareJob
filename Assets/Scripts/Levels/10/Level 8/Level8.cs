using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Level8 : MonoBehaviour
{
    CharlieController charlie;
    ScenesManager scene;

    [SerializeField] TextMeshPro text;
    
    float counter = 5f;

    void Start()
    {
        charlie = FindFirstObjectByType<CharlieController>();
        charlie.canExit = true;
        scene = FindFirstObjectByType<ScenesManager>();
    }

    void Update()
    {
        int integer = (int)counter;
        float floating = (int)((counter- integer) * 100);
        text.text = integer.ToString() + ":" + floating.ToString();
        counter -= Time.deltaTime;
        if (counter <= 0)
        {      
            charlie.Kill();
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


