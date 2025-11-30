using UnityEngine;
using UnityEngine.InputSystem;

public class ActionLevel7 : MonoBehaviour
{
    Level7 level;
    void Start()
    {
        level = FindFirstObjectByType<Level7>();
    }
    void OnAction(InputValue value)
    {
        level.FinishLevel();
    }
}
