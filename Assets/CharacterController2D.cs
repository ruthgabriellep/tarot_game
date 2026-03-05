using UnityEngine;

public class CharacterController2D : MonoBehaviour
{

    [Header("Movement Params")]
    public float runSpeed = 6.0f;
    public float jumpSpeed = 8.0f;
    public float gravityScale = 10.0f;
    
    private BoxCollider2D _coll;
    private Rigidbody2D _rb;
    
    private bool _isGrounded = false;

    private void Awake()
    {
        _coll = GetComponent<BoxCollider2D>();
        _rb = GetComponent<Rigidbody2D>();

        _rb.gravityScale = gravityScale;
    }

    private void FixedUpdate()
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
        Bounds colliderBounds = _coll.bounds;
        float colliderRadius = _coll.size.x * 0.4f * Mathf.Abs(transform.localScale.x);
        Vector3 groundCheckPos = colliderBounds.min + new Vector3(colliderBounds.size.x * 0.5f, colliderRadius * 0.9f, 0);
       
        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheckPos, colliderRadius);

        this._isGrounded = false;
        if (colliders.Length > 0)
        {
            for (int i = 0; i < colliders.Length; i++)
            {
                if (colliders[i] != _coll)
                {
                    this._isGrounded = true;
                    break;
                }
            }
        }
    }

    private void HandleHorizontalMovement()
    {
        Vector2 moveDirection = InputManager.GetInstance().GetMoveDirection();
        _rb.linearVelocity = new Vector2(moveDirection.x * runSpeed, _rb.linearVelocity.y);
    }

    private void HandleJumping()
    {
        bool jumpPressed = InputManager.GetInstance().GetJumpPressed();
        if (_isGrounded && jumpPressed)
        {
            _isGrounded = false;
            _rb.linearVelocity = new Vector2(_rb.linearVelocity.x, jumpSpeed);
        }
    }

}