using UnityEngine;
using UnityEngine.Rendering.Universal;

public class DoorLight : MonoBehaviour
{
    CharlieController charlie;
    Light2D lightComponent;

    void Start()
    {
        charlie = FindAnyObjectByType<CharlieController>();
        lightComponent = GetComponent<Light2D>();
    }
    void Update()
    {
        lightComponent.enabled = charlie.canExit;
    }
}
