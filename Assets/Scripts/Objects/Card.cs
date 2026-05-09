using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem.HID;

[RequireComponent(typeof(CircleCollider2D))]
public class Card : MonoBehaviour, IDataPersistence
{
    [SerializeField] private string id;

    [ContextMenu("Generate guid for id")]

    private void GenerateGuid()
    {
        id = System.Guid.NewGuid().ToString();
    }
    
    [Header("Config")]
    [SerializeField] private int deckGained = 1;

    [Header("Visual Cue")] [SerializeField]
    private GameObject visualCue;

    private CircleCollider2D _circleCollider;
    private SpriteRenderer _visual;

    private bool playerInRange;

    private bool collected = false;
    

    private void Awake() 
    {
        _circleCollider = GetComponent<CircleCollider2D>();
        _visual = GetComponentInChildren<SpriteRenderer>();
        visualCue.SetActive(false);
        playerInRange = false;
    }

    public void LoadData(GameData data)
    {
        data.cardsCollected.TryGetValue(id, out collected);
        if (collected)
        {
            _visual.gameObject.SetActive(false);
        }
    }

    public void SaveData(GameData data)
    {
        if (data.cardsCollected.ContainsKey(id))
        {
            data.cardsCollected.Remove(id);
        }
        data.cardsCollected.Add(id, collected);
    }
    
    private void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            if (!collected)
            {
                CollectCard();
            }
        }
    }
        
    private void CollectCard() 
    {
       
        _circleCollider.enabled = false;
        _visual.gameObject.SetActive(false);
        visualCue.SetActive(false);
        
        GameEventsManager.instance.deckEvents.DeckGained(deckGained);
        GameEventsManager.instance.miscEvents.CardCollected();
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
