using UnityEngine;
using UnityEngine.InputSystem;

public class ActionLevel18 : MonoBehaviour
{
    Level18 level;
    void Start()
    {
        level = FindFirstObjectByType<Level18>();
    }
    void OnAction(InputValue value)
    {
        level.GetNotes();
        level.FinishLevel();
    }
}