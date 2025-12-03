using UnityEngine;
using UnityEngine.InputSystem;

public class ActionLevel15 : MonoBehaviour
{
Level15 level;
void Start()
{
 level = FindFirstObjectByType<Level15>();
}
void OnAction(InputValue value)
{
    level.GetTime();
level.FinishLevel();
}
}