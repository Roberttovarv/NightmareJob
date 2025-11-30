using UnityEngine;
using UnityEngine.InputSystem;

public class ActionLevel2 : MonoBehaviour
{
    Level2 level;

    void Start()
    {
        level = FindFirstObjectByType<Level2>();
    }

    void OnAction(InputValue value)
    {
        level.FinishLevel();
    }
    
}
