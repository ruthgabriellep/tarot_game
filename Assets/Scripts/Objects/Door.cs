using UnityEngine;

public class Door : MonoBehaviour
{
    [Header("Visual Cue")] [SerializeField]
    private GameObject visualCue;

    private BoxCollider2D _boxCollider;
    private SpriteRenderer _visual;

    private bool playerInRange;

    private void Awake() 
    {
        visualCue.SetActive(false);
        playerInRange = false;
    }
    
    private void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            // OpenDoor();
        }
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
