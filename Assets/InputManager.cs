using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    // private PlayerInput playerInput;
    //
    // private InputAction moveAction;
    //
    // private InputAction interactAction;
    //
    // private InputAction sprintAction;
    //
    // private CharacterController2D characterController2D;
    //
    // private void Awake()
    // {
    //     playerInput = GetComponent<PlayerInput>();
    //     moveAction = playerInput.actions["Move"];
    //     moveAction.ReadValue<float>();
    //     
    //     playerInput = GetComponent<PlayerInput>();
    //     interactAction = playerInput.actions["Interact"];
    //     interactAction.ReadValue<float>();
    //     
    //     playerInput = GetComponent<PlayerInput>();
    //     sprintAction = playerInput.actions["Sprint"];
    //     sprintAction.ReadValue<float>();
    //
    //     characterController2D = GetComponent<CharacterController2D>();
    // }
    //
    // private void Sprint(InputAction.CallbackContext context)
    // {
    //     characterController2D.Sprint();
    // }
    //
    // void Update()
    // {
    //     Vector2 moveVector = moveAction.ReadValue<Vector2>();
    //     characterController2D.Move(moveVector);
    // }
    

    private Vector2 _moveDirection = Vector2.zero;
    private bool _sprintPressed = false;
    private bool _interactPressed = false;
    private bool _submitPressed = false;
    
    public CharacterController2D characterController2D;
    
    private static InputManager instance;
    
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Found more than one Input Manager in the scene.");
        }
    
        instance = this;

        characterController2D = GetComponent<CharacterController2D>();
    }
    
    public static InputManager GetInstance()
    {
        return instance;
    }
    
    public void MovePressed(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            _moveDirection = context.ReadValue<Vector2>();
        }
        else if (context.canceled)
        {
            _moveDirection = context.ReadValue<Vector2>();
        }
    }
    
    public void SprintPressed(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            _sprintPressed = true;
        }
        else if (context.canceled)
        {
            _sprintPressed = false;
        }
    }
    
    public void InteractPressed(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            _interactPressed = true;
        }
        else if (context.canceled)
        {
            _interactPressed = false;
        }
    }
    
    public void SubmitPressed(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            _submitPressed = true;
        }
        else if (context.canceled)
        {
            _submitPressed = false;
        }
    }
    
    public Vector2 GetMoveDirection()
    {
        return _moveDirection;
    }
    
    public bool GetSprintPressed()
    {
        bool result = _sprintPressed;
        _sprintPressed = false;
        return result;
    }
    
    public bool GetInteractPressed()
    {
        bool result = _interactPressed;
        _interactPressed = false;
        return result;
    }
    
    public bool GetSubmitPressed()
    {
        bool result = _submitPressed;
        _submitPressed = false;
        return result;
    }
    
    public void RegisterSubmitPressed()
    {
        _submitPressed = false;
    }

}