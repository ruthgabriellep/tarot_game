using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{

    private PlayerInput playerInput;
    
    private InputAction 

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        playerInput.actions["Move"]
    }

    private InputSystem_Actions inputSystems_Actions;

    private void Awake()
    {
        inputSystem_Actions = new InputSystem_Actions();
    }

    private void OnEnable()
    {
        inputSystem_Actions.Enable();
        inputSystem_Actions.Player.Move.started += Move;
        inputSystem_Actions.Player.Move.performed += Move;
        inputSystem_Actions.Player.Move.canceled += Move;
    }

    private void OnDisable()
    {
        inputSytem_Actions.Disable();
        inputSystem_Actions.Player.Move.started += Move;
    }

    void Start()
    {
        inputSystem_Actions.Player.Move.started += Move;
        inputSystem_Actions.Player.Move.performed += Move;
        inputSystem_Actions.Player.Move.canceled += Move;

        inputSystem_Actions.Player.Look.performed -= Move;
    }

    private void Move(InputAction.CallbackContext context)
    {
        Debug.Log("Move");
    }

    private void Update()
    {
        Vector2 move = inputSystem_Actions.Player.Move.ReadValue<Vector2>();
        Debug.Log(move);
        inputSystem_Actions.Player.Move.ReadValue<float>();
        if (inputSystem_Actions.Player.Move.ReadValue<float>() == 1)
            if (inputSystem_Actions.Player.Move.triggered)
                Debug.Log("Move");
    }
}