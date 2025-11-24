using UnityEngine;
using UnityEngine.InputSystem;

public class JumpManager : MonoBehaviour
{
    [SerializeField] float jumpForce = 12f;
    [SerializeField] float coyoteTime = .1f;

    float coyoteTimer; CharlieController charlie;

    void Start()
    {
        charlie = FindAnyObjectByType<CharlieController>();
    }
    void FixedUpdate()
    {
        TimersManager();
    }
    void OnJump(InputValue value)
    {
        if (CanJump()) { charlie.rigidBody.linearVelocity += new Vector2(0, jumpForce); coyoteTimer = 0; }
    }
    void TimersManager()
    {
        if (charlie.isGrounded) { coyoteTimer = coyoteTime; } else { coyoteTimer -= Time.deltaTime; }
        if (coyoteTimer < 0) coyoteTimer = 0;
    }
    bool CanJump()
    {
        return coyoteTimer > 0;
    }
}
