using UnityEngine;
using UnityEngine.InputSystem;

public class InputDeviceManager : MonoBehaviour
{
    public static bool isController { get; private set; }

    void Update()
    {
        bool gamepad = Gamepad.current != null && Gamepad.current.wasUpdatedThisFrame;
        bool mouseKeyboard = Keyboard.current.anyKey.wasPressedThisFrame || 
                             Mouse.current.delta.ReadValue() != Vector2.zero;
        if (gamepad) { isController = true; }
        if (mouseKeyboard) { isController = false; }
    }
}
