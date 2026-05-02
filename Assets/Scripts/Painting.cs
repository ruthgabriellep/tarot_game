using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class Painting : QuestStep
{
    [Header("Visual Cue")] [SerializeField]
    private GameObject visualCue;

    [SerializeField] private GameObject paintingInspect;

    private BoxCollider2D _boxCollider;
    private SpriteRenderer _visual;

    private bool playerInRange;

    private void Awake() 
    {
        visualCue.SetActive(false);
        playerInRange = false;
        paintingInspect.SetActive(false);
    }

    private void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Showing window inspect");
            Show();
            FinishQuestStep();
        }
        else
        {
            GameEventsManager.instance.playerEvents.EnablePlayerMovement();
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
        paintingInspect.SetActive(true);
        GameEventsManager.instance.playerEvents.DisablePlayerMovement();
    }
    
    protected override void SetQuestStepState(string state)
    {
        
    }
}
