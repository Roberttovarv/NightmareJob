using UnityEngine;
using UnityEngine.InputSystem;

public class ActionLevel20 : MonoBehaviour
{
Level20 level;
void Start()
{
 level = FindFirstObjectByType<Level20>();
}
void OnAction(InputValue value)
{
level.FinishLevel();
}
}