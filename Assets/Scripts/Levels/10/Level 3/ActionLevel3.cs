using UnityEngine;
using UnityEngine.InputSystem;

public class ActionLevel3 : MonoBehaviour
{
    CharlieController charlie;
    Level3 level;

    void Start()
    {
        level = FindFirstObjectByType<Level3>();
        charlie = FindAnyObjectByType<CharlieController>();
    }
    void OnAction(InputValue value)
    {
        level.UseComputer();
        level.FinishLevel();
    }
}
