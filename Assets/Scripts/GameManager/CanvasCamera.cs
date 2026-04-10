using UnityEngine;

[RequireComponent(typeof(Canvas))]
public class CanvasCamera : MonoBehaviour
{
    void Start()
    {
        Canvas canvas = GetComponent<Canvas>();

        canvas.renderMode = RenderMode.ScreenSpaceCamera;

        canvas.worldCamera = Camera.main;
    }
}