using UnityEngine;

public class Level30Door : MonoBehaviour
{
    bool hasBeenMoved;
    void Start()
    {
        hasBeenMoved = false;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!hasBeenMoved)
        {
            transform.localPosition = new Vector3(8.5f, 1.1f, transform.localPosition.z);
            hasBeenMoved = true;
        }
    }
}
