using UnityEngine;
using UnityEngine.InputSystem;

public class ActionLevel6 : MonoBehaviour
{
Level6 level;
void Start()
{
 level = FindFirstObjectByType<Level6>();
}
void OnAction(InputValue value)
{
level.FinishLevel();
}
}
