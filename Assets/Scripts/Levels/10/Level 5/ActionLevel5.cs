using UnityEngine;
using UnityEngine.InputSystem;

public class ActionLevel5 : MonoBehaviour
{
    Level5 level;
    void Start()
    {
        level = FindFirstObjectByType<Level5>();
    }
    void OnAction(InputValue value)
    {
        level.FinishLevel();
    }
}
