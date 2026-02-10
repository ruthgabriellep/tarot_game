using UnityEngine;

public class InputManager : MonoBehaviour
{
    
    private InputSystem_Actions inputSystems_Actions

    private void Awake()
    {
        inputSystem_Actions = new InputSystem_Actions();
    }

    private void OnEnable()
    {
        inputSystem_Actions.Enable();
    }

    private void OnDisable()
    {
        inputSytem_Actions.Disable();
    }
    void Start()
    {
        
    }

    private void Update()
    {
        Vector2 move = inputSystem_Actions.Player.Move.ReadValue<Vector2>();
        Debug.Log(move);
        inputSystem_Actions.Player.Look.ReadValue<float>();
        if (inputSystem_Actions.Player.Look.ReadValue<float>() == 1)
            if (inputSystem_Actions.Player.Look.triggered)
                Debug.Log("Look");
    }
    
}