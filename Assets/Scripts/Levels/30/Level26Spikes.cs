using UnityEngine;
using UnityEngine.SocialPlatforms.GameCenter;

public class Level26Spikes : MonoBehaviour
{
    float spikeVel = 1f;
    float radius = 2f;
    float angle;

    Vector3 center;

    void Start() {
        center = transform.position;
    }
    void Update()
    {
        SpikeManager();
    }

    void SpikeManager()
    {
        angle += spikeVel * Time.deltaTime;

        float x = Mathf.Cos(angle) * radius;
        float y = Mathf.Sin(angle) * radius;

        transform.position = center + new Vector3(x, y, 0);
    }
}
