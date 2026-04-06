using UnityEngine;

public class Level29Spikes : MonoBehaviour
{
    [SerializeField] private float velocity = .5f;
    [SerializeField] private int direction = 1;

    void Update()
    {
        Vector3 position = transform.position;

        if (direction == 1)
        {
            position.y += velocity * Time.deltaTime;
        }
        else
        {
            position.y -= velocity * Time.deltaTime;
        }

        transform.position = position;
    }
}
