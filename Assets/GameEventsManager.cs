using UnityEngine;
using UnityEngine.UIElements.InputSystem;

public class GameEventsManager : MonoBehaviour
{
    public static GameEventsManager instance { get; private set; }
    
    public InputEvents inputEvents;
    
    public PlayerEvents playerEvents;
    
    public MiscEvents miscEvents;
    
    public QuestEvents questEvents;

    public DeckEvents deckEvents;
    
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Found more than one Game Events Manager in the scene.");
        }
    
        instance = this;
    
        inputEvents = new InputEvents();
        playerEvents = new PlayerEvents();
        miscEvents = new MiscEvents();
        questEvents = new QuestEvents();
        deckEvents = new DeckEvents();
    }

}
