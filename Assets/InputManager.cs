using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private PlayerInput playerInput;

    private InputAction interactAction;

    private InputAction moveAction;
    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        interactAction = playerInput.actions["Interact"];
        interactAction.ReadValue<float>();
        
        playerInput = GetComponent<PlayerInput>();
        moveAction = playerInput.actions["Interact"];
        moveAction.ReadValue<float>();
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
}