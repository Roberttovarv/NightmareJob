using UnityEngine;
using UnityEngine.InputSystem;

public class ActionLevel4 : MonoBehaviour
{
Level4 level;
void Start()
{
 level = FindFirstObjectByType<Level4>();
}
void OnAction(InputValue value)
{
    level.FinishLevel();
}
}
