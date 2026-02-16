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
    // }
    //
    
    private Vector2 moveDirection = Vector2.zero;
    private bool sprintPressed = false;
    private bool interactPressed = false;
    private bool submitPressed = false;

    private static InputManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Found more than one Input Manager in the scene.");
        }
        instance = this;
    }

    public static InputManager GetInstance() 
    {
        return instance;
    }

    public void MovePressed(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            moveDirection = context.ReadValue<Vector2>();
        }
        else if (context.canceled)
        {
            moveDirection = context.ReadValue<Vector2>();
        } 
    }

    public void SprintPressed(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            sprintPressed = true;
        }
        else if (context.canceled)
        {
            sprintPressed = false;
        }
    }

    public void InteractButtonPressed(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            interactPressed = true;
        }
        else if (context.canceled)
        {
            interactPressed = false;
        } 
    }

    public void SubmitPressed(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            submitPressed = true;
        }
        else if (context.canceled)
        {
            submitPressed = false;
        } 
    }

    public Vector2 GetMoveDirection() 
    {
        return moveDirection;
    }

    public bool GetSprintPressed() 
    {
        bool result = sprintPressed;
        sprintPressed = false;
        return result;
    }

    public bool GetInteractPressed() 
    {
        bool result = interactPressed;
        interactPressed = false;
        return result;
    }

    public bool GetSubmitPressed() 
    {
        bool result = submitPressed;
        submitPressed = false;
        return result;
    }

    public void RegisterSubmitPressed() 
    {
        submitPressed = false;
    }

}
    
    //
    // private InputSystem_Actions inputSystem_Actions;
    //
    // private void Awake()
    // {
    //     inputSystem_Actions = new InputSystem_Actions();
    // }
    //
    // private void OnEnable()
    // {
    //     inputSystem_Actions.Enable();
    // }
    //
    // private void OnDisable()
    // {
    //     inputSystem_Actions.Disable();
    //     inputSystem_Actions.Player.Move.started -= Move;
    // }
    //
    // void Start()
    // {
    //     inputSystem_Actions.Player.Move.started += Move;
    //     inputSystem_Actions.Player.Move.performed += Move;
    //     inputSystem_Actions.Player.Move.canceled += Move;
    //     
    //     inputSystem_Actions.Player.Move.started += context => Move(context);
    // }
    //
    // public void Move(InputAction.CallbackContext context)
    // {
    //     Debug.Log("Move");
    // }
    //
    // private void Update()
    // {
    //     Vector2 move = inputSystem_Actions.Player.Move.ReadValue<Vector2>();
    // }