using System;
using UnityEngine;

public class InteractionTrigger : MonoBehaviour
{
    [Header("Interact Icon")] 
    [SerializeField] private GameObject interactIcon;

    private bool _playerInRange;

    private void Awake()
    {
        _playerInRange = false;
        interactIcon.SetActive(false);
    }

    private void Update()
    {

        if (_playerInRange && !InputManager.GetInstance().GetInteractPressed())
        {
            interactIcon.SetActive(true);
            if (InputManager.GetInstance().GetInteractPressed())
            {
                
                Debug.Log("Interact icon triggered");
            }
            
        }
        else
        {
            interactIcon.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("Player"))
        {
            _playerInRange = true;
            Debug.Log("Triggered");
        }
    }

    private void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.CompareTag("Player"))
        {
            _playerInRange = false;
        }
    }
}
