using UnityEngine;
using UnityEngine.InputSystem;

public class WalkManager : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] public float walkVel = 4.5f;
    Vector2 moveInput;
    int dir = 1;
    Rigidbody2D rigidBody;

    void Start()
    {
        rigidBody = FindAnyObjectByType<CharlieController>().rigidBody;
    }
    void OnMove(InputValue value)
    {
        var charlie = FindAnyObjectByType<CharlieController>();
        if (!charlie.isAlive) return;
        Vector2 rawInput = value.Get<Vector2>();

        if (rawInput.magnitude > 0.1f)
        {
            moveInput = rawInput.normalized;
        }
        else
        {
            moveInput = Vector2.zero;
        }
    }
    public void Walk()
    {
        if (GameSessionManager.IsPaused) return;

        if (!rigidBody)
        {
            var charlie = FindAnyObjectByType<CharlieController>();
            if (charlie == null) return;

            rigidBody = charlie.rigidBody;
        }

        rigidBody.linearVelocity = new Vector2(moveInput.x * walkVel, rigidBody.linearVelocityY);

        dir = rigidBody.linearVelocity.x < -0.1f ? -1 :
              rigidBody.linearVelocity.x > 0.1f ? 1 : dir;

        RotateChar();
        animator.SetBool("isWalking", Mathf.Abs(moveInput.x) > 0.1f);
    }

    public void Iddle()
    {
        if (rigidBody.linearVelocityX == 0)
        {
            animator.SetBool("isWalking", false);
        }

    }
    void RotateChar()
    {
        Vector3 scale = transform.localScale;
        scale.x = Mathf.Abs(scale.x) * dir;
        transform.localScale = scale;
    }
    public void SetHorizontalInput(float x)
    {
        if (rigidBody == null)
        {
            var charlie = FindAnyObjectByType<CharlieController>();
            if (charlie != null)
                rigidBody = charlie.rigidBody;
        }

        moveInput.x = x;
    }
}
