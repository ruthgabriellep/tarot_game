using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private Vector2 _moveDirection;
    private bool _interactPressed;
    private bool _submitPressed;

    private static InputManager _instance;

    private void Awake()
    {
        if (_instance != null)
        {
            Debug.LogError("Found more than one Input Manager in the scene.");
        }
        
        _instance = this;
    }

    public static InputManager GetInstance()
    {
        return _instance;
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

    public void InteractPressed(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            _interactPressed = true;
            Debug.Log("Interact triggered");
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
            Debug.Log("Submit triggered");
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