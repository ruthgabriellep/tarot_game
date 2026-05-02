using UnityEngine;

public class Tapestry : MonoBehaviour
{
    
    [Header("Visual Cue")] [SerializeField]
    private GameObject visualCue;

    [SerializeField] private GameObject windowInspect;
    
    [SerializeField] public GameObject otherUI;

    private BoxCollider2D _boxCollider;
    private SpriteRenderer _visual;

    private bool playerInRange;

    private void Awake() 
    {
        visualCue.SetActive(false);
        playerInRange = false;
        windowInspect.SetActive(false);
    }

    private void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Showing tapestry inspect");
            Show();
            otherUI.SetActive(false);
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

    private void Show()
    {
        windowInspect.SetActive(true);
    }
}
