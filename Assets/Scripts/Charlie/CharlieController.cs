using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharlieController : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] Rigidbody2D rigidBody;
    [SerializeField] Collider2D feetCollider;
    [SerializeField] Collider2D bodyCollider;
    [SerializeField] SpriteRenderer sprite;

    [SerializeField] float walkVel = 6f;
    [SerializeField] float jumpForce = 6;
    Vector2 moveInput;
    bool isGrounded;

    int dir = 1;

    void Update()
    {
        Grounded();
    }

    void FixedUpdate()
    {
        Walk();
        Iddle();
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    void Walk()
    {
        rigidBody.linearVelocity = new Vector2(moveInput.x * walkVel, rigidBody.linearVelocityY);

        dir = rigidBody.linearVelocity.x < -0.1f ? -1 :
        rigidBody.linearVelocity.x > 0.1f ? 1 : dir;
        RotateChar();
        animator.SetBool("isWalking", true);

    }

    void Iddle()
    {
        if (rigidBody.linearVelocityX == 0)
        {
            animator.SetBool("isWalking", false);
        }

    }
    void OnJump(InputValue value)
    {
        if (isGrounded) rigidBody.linearVelocity += new Vector2(0, jumpForce);
    }

    void RotateChar()
    {
        Vector3 scale = transform.localScale;
        scale.x = Mathf.Abs(scale.x) * dir;
        transform.localScale = scale;
    }

    void Grounded()
    {
        isGrounded = feetCollider.IsTouchingLayers(LayerMask.GetMask("Floor"));
    }

}
