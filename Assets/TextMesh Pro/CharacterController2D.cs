using UnityEngine;

public class CharacterController2D : MonoBehaviour
{
      [Header("Movement Params")]
    public float runSpeed = 6.0f;
    public float sprintSpeed = 8.0f;
    public float gravityScale = 20.0f;

    // components attached to player
    private BoxCollider2D coll;
    private Rigidbody2D rb;

    // other
    private bool isGrounded = false;

    private void Awake()
    {
        coll = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();

        rb.gravityScale = gravityScale;
    }

    public void FixedUpdate()
    {
        if (DialogueManager.GetInstance().dialogueIsPlaying)
        {
            return;
        }

        UpdateIsGrounded();

        HandleHorizontalMovement();

        HandleJumping();
    }

    private void UpdateIsGrounded()
    {
        Bounds colliderBounds = coll.bounds;
        float colliderRadius = coll.size.x * 0.4f * Mathf.Abs(transform.localScale.x);
        Vector3 groundCheckPos = colliderBounds.min + new Vector3(colliderBounds.size.x * 0.5f, colliderRadius * 0.9f, 0);
        // Check if player is grounded
        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheckPos, colliderRadius);
        // Check if any of the overlapping colliders are not player collider, if so, set isGrounded to true
        this.isGrounded = false;
        if (colliders.Length > 0)
        {
            for (int i = 0; i < colliders.Length; i++)
            {
                if (colliders[i] != coll)
                {
                    this.isGrounded = true;
                    break;
                }
            }
        }
    }

    private void HandleHorizontalMovement()
    {
        Vector2 moveDirection = InputManager.GetInstance().GetMoveDirection();
        rb.linearVelocity = new Vector2(moveDirection.x * runSpeed, rb.linearVelocity.y);
    }

    private void HandleJumping()
    {
        bool sprintPressed = InputManager.GetInstance().GetSprintPressed();
        if (isGrounded && sprintPressed)
        {
            isGrounded = false;
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, sprintSpeed);
        }
    }

}
