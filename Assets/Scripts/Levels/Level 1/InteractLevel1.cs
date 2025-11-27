using UnityEngine;
using UnityEngine.InputSystem;

public class InteractLevel1 : MonoBehaviour
{
Level1 level;

    void Start()
    {
        print("Funciona");
        level = FindAnyObjectByType<Level1>();
        print(level);
    }

    void OnAction(InputValue value)
    {
        level.FinishLevel();
    }
}
