using UnityEngine;

public class InteractionTrigger : MonoBehaviour
{
    // [Header("Interact Icon")] 
    // [SerializeField] private GameObject interactIcon;
    //
    // public bool interactableInRange;
    //
    // private void Awake()
    // {
    //     interactableInRange = false;
    //     interactIcon.SetActive(false);
    // }
    //
    // private void Update()
    // {
    //
    //     if (interactableInRange)
    //     { 
    //         interactIcon.SetActive(true);
    //         if (InputManager.GetInstance().GetInteractPressed())
    //         {
    //             CardTrigger.GetInstance().EnterCardIsShowing();
    //             Debug.Log("Interact icon triggered");
    //         }
    //         
    //     }
    //     else
    //     {
    //         interactIcon.SetActive(false);
    //     }
    // }
    //
    // private void OnTriggerEnter2D(Collider2D coll)
    // {
    //     if (coll.CompareTag("Interactable"))
    //     {
    //         interactableInRange = true;
    //         interactIcon.SetActive(true);
    //         Debug.Log("Triggered");
    //
    //         CardTrigger.GetInstance().canShowCard = true;
    //     }
    // }
    //
    // private void OnTriggerExit2D(Collider2D coll)
    // {
    //     if (coll.CompareTag("Interactable"))
    //     {
    //         interactableInRange = false;
    //
    //         CardTrigger.GetInstance().canShowCard = false;
    //     }
    // }
}
