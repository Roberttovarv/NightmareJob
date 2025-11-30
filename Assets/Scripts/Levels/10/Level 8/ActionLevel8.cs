using UnityEngine;
using UnityEngine.InputSystem;

public class ActionLevel8 : MonoBehaviour
{
Level8 level;
void Start()
{
 level = FindFirstObjectByType<Level8>();
}
void OnAction(InputValue value)
{
level.FinishLevel();
}
}