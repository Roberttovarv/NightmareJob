using UnityEngine;
using UnityEngine.InputSystem;

public class ActionLevel11 : MonoBehaviour
{
Level11 level;
void Start()
{
 level = FindFirstObjectByType<Level11>();
}
void OnAction(InputValue value)
{
level.FinishLevel();
level.DisposeDocument();
}
}