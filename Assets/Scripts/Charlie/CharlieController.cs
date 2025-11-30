using System.Collections;
using UnityEngine;


public class CharlieController : MonoBehaviour
{
    [SerializeField] public Rigidbody2D rigidBody;
    [SerializeField] public Collider2D feetCollider;
    [SerializeField] public Collider2D bodyCollider;
    [SerializeField] public SpriteRenderer sprite;

    [SerializeField] public bool canExit;
    [SerializeField] public bool isAlive = true;
    public bool isGrounded;

    IEnumerator Reload;

    void Start()
    {
        Reload = FindAnyObjectByType<ScenesManager>().ReloadDelay();
    }

    void Update()
    {
        Grounded();
        Die();
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

    void Die()
    {
        if (bodyCollider.IsTouchingLayers(LayerMask.GetMask("Spikes")))
        {
            isAlive = false;
            StartCoroutine(Reload);
            transform.eulerAngles = new Vector3(0, 0, 90);
        }
    }

        public void Kill()
    {
        {
            isAlive = false;
            StartCoroutine(Reload);
            transform.eulerAngles = new Vector3(0, 0, 90);
        }
    }



}
