using UnityEngine;
using UnityEngine.InputSystem;

public class ActionLevel13 : MonoBehaviour
{
    Level13 level;


   void Start()
    {

        level = FindFirstObjectByType<Level13>();
    }
    void OnAction(InputValue value)
    {
        level.FinishLevel();
    }
}

