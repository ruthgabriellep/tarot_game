using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [Header("Visual Cue")] 
    [SerializeField] private GameObject visualCue;

    [Header("Ink JSON")] 
    [SerializeField] private TextAsset inkJson;
    private bool _playerInRange;

    private void Awake()
    {
        _playerInRange = false;
        visualCue.SetActive(false);
    }

    private void Update()
    {
        if (_playerInRange && !DialogueManager.GetInstance().dialogueIsPlaying)
        {
            visualCue.SetActive(true);
            if (InputManager.GetInstance().GetInteractPressed())
            {
                DialogueManager.GetInstance().EnterDialogueMode(inkJson);
                Debug.Log("Entered dialogue mode");
            }
        }
        else
        {
            visualCue.SetActive(false);
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
