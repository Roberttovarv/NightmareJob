using UnityEngine;
using UnityEngine.Rendering.Universal;

public class DisableLights : MonoBehaviour
{
    void Awake()
    {
        if (!Application.isMobilePlatform) return;

        // Busca todas las luces en hijos
        var lights = GetComponentsInChildren<Light2D>();

        foreach (var light in lights)
        {
            light.enabled = false;
        }
    }
}
