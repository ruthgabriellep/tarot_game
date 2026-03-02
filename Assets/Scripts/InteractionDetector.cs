using UnityEngine;
using UnityEngine.InputSystem;

public class InteractionDetector : MonoBehaviour
{

    private IInteractable _interactableInRange = null;
    public GameObject interactIcon;
    
    private void Awake()
    {
        interactIcon.SetActive(false);
    }

    public void InteractButtonPressed(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            _interactableInRange?.Interact();
        }
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IInteractable interactable) && interactable.CanInteract())
        {
            _interactableInRange = interactable;
            interactIcon.SetActive(true);
            Debug.Log("Interact icon triggered");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IInteractable interactable) && interactable == _interactableInRange)
        {
            _interactableInRange = null;
            interactIcon.SetActive(false);
        }
    }
}
