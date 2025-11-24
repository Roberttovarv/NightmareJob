using UnityEngine;


public class CharlieController : MonoBehaviour
{
    [SerializeField] public Rigidbody2D rigidBody;
    [SerializeField] public Collider2D feetCollider;
    [SerializeField] public Collider2D bodyCollider;
    [SerializeField] public SpriteRenderer sprite;


    public bool isGrounded;


    void Update()
    {
        Grounded();
    }

    void FixedUpdate()
    {
        FindFirstObjectByType<WalkManager>().Walk();
        FindFirstObjectByType<WalkManager>().Iddle();
    }

    void Grounded()
    {
        isGrounded = feetCollider.IsTouchingLayers(LayerMask.GetMask("Floor"));
    }

}
