using UnityEngine;

public class Wood : MonoBehaviour
{
    [Header("Visual")] [SerializeField] private GameObject visual;
    
    [Header("Visual Cue")] [SerializeField]
    private GameObject visualCue;

    [Header("Item")] [SerializeField] private GameObject wood;

    private CircleCollider2D _circleCollider;

    private bool playerInRange;
    

    private void Awake() 
    {
        _circleCollider = GetComponent<CircleCollider2D>();
        visualCue.SetActive(false);
        visual.SetActive(true);
        playerInRange = false;
        wood.SetActive(false);
    }
    
    private void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        { 
            CollectWood();
        }
    }
        
    private void CollectWood() 
    {
        _circleCollider.enabled = false;
        visualCue.SetActive(false);
        wood.SetActive(true);
        visual.SetActive(false);
    }
    
    private void OnTriggerEnter2D(Collider2D otherCollider) 
    {
        if (otherCollider.CompareTag("Player"))
        {
            playerInRange = true;
            visualCue.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D otherCollider)
    {
        if (otherCollider.CompareTag("Player"))
        {
            playerInRange = false;
            visualCue.SetActive(false);
        }
    }
}
