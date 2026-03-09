using UnityEngine;

public class Level29Spikes : MonoBehaviour
{
    [SerializeField] private float scaleYReductionPerSecond = 0.05f;

    void Update()
    {
        Vector3 scale = transform.localScale;
        scale.y = Mathf.Max(0f, scale.y - scaleYReductionPerSecond * Time.deltaTime);
        transform.localScale = scale;
    }
}
