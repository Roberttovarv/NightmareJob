using UnityEngine;
using UnityEngine.InputSystem;

public class ActionLevel19 : MonoBehaviour
{
Level19 level;
void Start()
{
 level = FindFirstObjectByType<Level19>();
}
void OnAction(InputValue value)
{
level.FinishLevel();
}
}