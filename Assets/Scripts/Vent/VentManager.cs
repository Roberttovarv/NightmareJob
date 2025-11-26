using UnityEngine;

public class VentManager : MonoBehaviour
{
    Rigidbody2D rigidBody;
    float gravityScale;
    
    void Start()
    {
        rigidBody = FindFirstObjectByType<CharlieController>().rigidBody;
        gravityScale = rigidBody.gravityScale;
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        rigidBody.gravityScale = 0;
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        rigidBody.gravityScale = gravityScale;
    }
}
