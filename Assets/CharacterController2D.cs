using UnityEngine;

public class CharacterController2D : MonoBehaviour
{
    
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