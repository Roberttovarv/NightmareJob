using UnityEngine;
using UnityEngine.InputSystem;

public class WalkManager : MonoBehaviour
{
 [SerializeField] Animator animator;
    [SerializeField] float walkVel = 4.5f;
    Vector2 moveInput;
    int dir = 1;
    Rigidbody2D rigidBody;

    void Start()
    {
        rigidBody = FindAnyObjectByType<CharlieController>().rigidBody;
    }
    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }
    public void Walk()
    {
        rigidBody.linearVelocity = new Vector2(moveInput.x * walkVel, rigidBody.linearVelocityY);

        dir = rigidBody.linearVelocity.x < -0.1f ? -1 :
        rigidBody.linearVelocity.x > 0.1f ? 1 : dir;
        RotateChar();
        animator.SetBool("isWalking", true);

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
}
