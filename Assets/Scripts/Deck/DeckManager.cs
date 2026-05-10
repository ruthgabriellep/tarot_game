using UnityEngine;

public class DeckManager : MonoBehaviour
{
    [Header("Configuration")] [SerializeField]
    private int startingDeck;

    public int currentDeck { get; private set; }

    private void Awake()
    {
        currentDeck = startingDeck;
    }

    private void OnEnable()
    {
        GameEventsManager.instance.deckEvents.onDeckGained += DeckGained;
    }

    
    private void OnDisable()
    {
        GameEventsManager.instance.deckEvents.onDeckGained -= DeckGained;
    }

    private void Start()
    {
        GameEventsManager.instance.deckEvents.DeckChange(currentDeck);
    }

    private void DeckGained(int deck)
    {
        currentDeck += deck;
        GameEventsManager.instance.deckEvents.DeckChange(currentDeck);
    }
}


