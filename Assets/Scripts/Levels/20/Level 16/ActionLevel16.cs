using UnityEngine;
using UnityEngine.InputSystem;

public class ActionLevel16 : MonoBehaviour
{
Level16 level;
void Start()
{
 level = FindFirstObjectByType<Level16>();
}
void OnAction(InputValue value)
{
level.FinishLevel();
}
}