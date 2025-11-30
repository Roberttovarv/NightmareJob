using UnityEngine;
using UnityEngine.InputSystem;

public class ActionLevel10 : MonoBehaviour
{
    Level10 level;
    void Start()
    {
        level = FindFirstObjectByType<Level10>();
    }
    void OnAction(InputValue value)
    {
        level.GetDocument();
        level.FinishLevel();
    }
}