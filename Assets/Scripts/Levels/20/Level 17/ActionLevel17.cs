using UnityEngine;
using UnityEngine.InputSystem;

public class ActionLevel17 : MonoBehaviour
{
Level17 level;
void Start()
{
 level = FindFirstObjectByType<Level17>();
}
void OnAction(InputValue value)
{
level.FinishLevel();
}
}