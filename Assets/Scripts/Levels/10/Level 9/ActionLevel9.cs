using UnityEngine;
using UnityEngine.InputSystem;

public class ActionLevel9 : MonoBehaviour
{
    Level9 level;
    void Start()
    {
        level = FindFirstObjectByType<Level9>();
    }
    void OnAction(InputValue value)
    {
        level.DrinkCoffee();
        level.FinishLevel();
    }
}