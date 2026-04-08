using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class Level20 : MonoBehaviour
{
    CharlieController charlie;
    ScenesManager scene;
     [SerializeField] TextMeshPro text;
    
    float counter = 10f;
    void Start()
    {
        charlie = FindFirstObjectByType<CharlieController>();
        scene = FindFirstObjectByType<ScenesManager>();
        charlie.canExit = true;
        charlie.onAction = HandleAction;
    }
    void Update()
    {
        int integer = (int)counter;
        float floating = (int)((counter - integer) * 100);
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

    void HandleAction()
    {
        FinishLevel();
    }

    void OnAction(InputValue value)
    {
        charlie.TriggerAction();
    }
}
