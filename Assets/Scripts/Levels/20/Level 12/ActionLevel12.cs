using UnityEngine;
using UnityEngine.InputSystem;

public class ActionLevel12 : MonoBehaviour
{
    Level12 level;

    void Start()
    {
        level = FindFirstObjectByType<Level12>();
    }
    void OnAction(InputValue value)
    {
        level.FinishLevel();
    }
}