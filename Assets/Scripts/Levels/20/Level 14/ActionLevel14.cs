using UnityEngine;
using UnityEngine.InputSystem;

public class ActionLevel14 : MonoBehaviour
{
Level14 level;
void Start()
{
 level = FindFirstObjectByType<Level14>();
}
void OnAction(InputValue value)
{
level.FinishLevel();
}
}