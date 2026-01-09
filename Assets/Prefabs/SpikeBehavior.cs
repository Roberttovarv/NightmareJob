using System;
using UnityEngine;

public class SpikeBehavior : MonoBehaviour
{
    float velocity = 4f;
    Vector3 moveDirection;
    bool shouldMove = false;
    float rotation;

    void Start()
    {
        moveDirection = transform.up;
        rotation = transform.eulerAngles.z;
        ManageHorizontal();

    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        shouldMove = true;
    }

    void FixedUpdate()
    {
        if (shouldMove)
        {
            transform.Translate(moveDirection * velocity * Time.deltaTime, Space.World);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            collision.collider.GetComponent<CharlieController>().Kill();
        }
        if (collision.collider.CompareTag("Scene"))
        {
            print("Colisiona");
        Destroy(gameObject);
        }
    }

    void ManageHorizontal()
    {
        if (rotation == 90 || rotation == 270)
        {
            velocity = 1.5f;
        }
    }
}
