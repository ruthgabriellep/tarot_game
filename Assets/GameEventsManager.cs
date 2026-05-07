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

    public DialogueEvents dialogueEvents;
    
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
            // Debug.LogError("Found more than one Game Events Manager in the scene.");
        }
    
        instance = this;
        DontDestroyOnLoad(gameObject);
    
        inputEvents = new InputEvents();
        playerEvents = new PlayerEvents();
        miscEvents = new MiscEvents();
        questEvents = new QuestEvents();
        deckEvents = new DeckEvents();
        dialogueEvents = new DialogueEvents();
    }

}
