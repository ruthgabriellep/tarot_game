using UnityEngine;

public class CharacterController2D : MonoBehaviour
{

    [Header("Movement Params")]
    public float runSpeed = 6.0f;
    public float gravityScale = 1.0f;
    
    private Rigidbody2D _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();

        _rb.gravityScale = gravityScale;
    }

    private void FixedUpdate()
    {
        if (DialogueManager.GetInstance().dialogueIsPlaying)
        {
            _rb.linearVelocity = new Vector2(0f, _rb.linearVelocity.y);
            return;
        }
        
        HandleHorizontalMovement();
        
    }
    

    private void HandleHorizontalMovement()
    {
        Vector2 moveDirection = InputManager.GetInstance().GetMoveDirection();
        _rb.linearVelocity = new Vector2(moveDirection.x * runSpeed, _rb.linearVelocity.y);
    }
}
