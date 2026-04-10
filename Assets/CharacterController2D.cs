using UnityEngine;

public class CharacterController2D : MonoBehaviour
{
    // [Header("Movement Params")]
    // [SerializeField] private float runSpeed = 6.0f;
    // public float jumpSpeed = 8.0f;
    // public float gravityScale = 10.0f;
    //
    // private BoxCollider2D _coll;
    // private Rigidbody2D _rb;
    //
    // private bool _isGrounded = false;
    //
    // private void Awake()
    // {
    //     _coll = GetComponent<BoxCollider2D>();
    //     _rb = GetComponent<Rigidbody2D>();
    //
    //     _rb.gravityScale = gravityScale;
    // }
    //
    // private void FixedUpdate()
    // {
    //     if (DialogueManager.GetInstance().dialogueIsPlaying)
    //     {
    //         return;
    //     }
    //
    //     UpdateIsGrounded();
    //
    //     HandleHorizontalMovement();
    //     
    // }
    //
    // private void UpdateIsGrounded()
    // {
    //     Bounds colliderBounds = _coll.bounds;
    //     float colliderRadius = _coll.size.x * 0.4f * Mathf.Abs(transform.localScale.x);
    //     Vector3 groundCheckPos = colliderBounds.min + new Vector3(colliderBounds.size.x * 0.5f, colliderRadius * 0.9f, 0);
    //    
    //     Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheckPos, colliderRadius);
    //
    //     this._isGrounded = false;
    //     if (colliders.Length > 0)
    //     {
    //         for (int i = 0; i < colliders.Length; i++)
    //         {
    //             if (colliders[i] != _coll)
    //             {
    //                 this._isGrounded = true;
    //                 break;
    //             }
    //         }
    //     }
    // }
    //
    // private void HandleHorizontalMovement()
    // {
    //     Vector2 moveDirection = InputManager.GetInstance().GetMoveDirection();
    //     _rb.linearVelocity = new Vector2(moveDirection.x * runSpeed, _rb.linearVelocity.y);
    //
    //     if (moveDirection.x > 0f)
    //     { 
    //         transform.localScale = new Vector2(0.397122025f, 0.397122025f);
    //     }
    //     else if (moveDirection.x < 0f)
    //     {
    //         transform.localScale = new Vector2(-0.397122025f, 0.397122025f);
    //     }
    //     
    // }

    [Header("Config")]
    [SerializeField] private float moveSpeed = 5f;

    private Rigidbody2D _rb;
    private Vector2 _velocity = Vector2.zero;


    private bool _movementDisabled = false;

    private void Awake() 
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Start() 
    {
        GameEventsManager.instance.inputEvents.onMovePressed += MovePressed;
        GameEventsManager.instance.playerEvents.onDisablePlayerMovement += DisablePlayerMovement;
        GameEventsManager.instance.playerEvents.onEnablePlayerMovement += EnablePlayerMovement;
    }

    private void OnDestroy()
    {
        GameEventsManager.instance.inputEvents.onMovePressed -= MovePressed;
        GameEventsManager.instance.playerEvents.onDisablePlayerMovement -= DisablePlayerMovement;
        GameEventsManager.instance.playerEvents.onEnablePlayerMovement -= EnablePlayerMovement;
    }

    private void DisablePlayerMovement() 
    {
        _movementDisabled = true;
        _velocity = Vector2.zero;
    }

    private void EnablePlayerMovement() 
    {
        _movementDisabled = false;
    }

    private void MovePressed(Vector2 moveDir) 
    {
        _velocity = moveDir.normalized * moveSpeed;

        if (_movementDisabled) 
        {
            _velocity = Vector2.zero;
        }
    }

    private void FixedUpdate() 
    {
        _rb.linearVelocity = _velocity;
    }
}