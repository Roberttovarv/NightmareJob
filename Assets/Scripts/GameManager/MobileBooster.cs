using UnityEngine;
using UnityEngine.Rendering.Universal;

public class MobileBooster : MonoBehaviour
{
    void Start()
    {
        if (!Application.isMobilePlatform) return;

        var urpAsset = (UniversalRenderPipelineAsset)QualitySettings.renderPipeline;
        urpAsset.shadowDistance = 0;
        var camera = Camera.main;
        var data = camera.GetUniversalAdditionalCameraData();
        data.renderPostProcessing = false;
    }
}
