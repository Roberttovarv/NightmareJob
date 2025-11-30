using UnityEngine;
using UnityEngine.InputSystem;

public class InteractLevel1 : MonoBehaviour
{
Level1 level;

    void Start()
    {
        level = FindAnyObjectByType<Level1>();
    }

    void OnAction(InputValue value)
    {
        level.FinishLevel();
    }
}
