using UnityEngine;

public class BoatRepair : MonoBehaviour, IDataPersistence
{
    [SerializeField] private string id;
    
    [ContextMenu("Generate guid for id")]
    private void GenerateGuid()
    {
        id = System.Guid.NewGuid().ToString();
    }

    [SerializeField] private GameObject brokenBoat;
    [SerializeField] private GameObject repairedBoat;
    [SerializeField] private GameObject woodUIItem;
    
    [Header("Dialogue")]
    [SerializeField] private string brokenBoatDialogueKnot;
    [SerializeField] private string repairedBoatDialogueKnot;
    
    [Header("Visual Cue")]
    [SerializeField] private GameObject visualCue;

    private bool repaired = false;
    private bool playerInRange = false;

    private void Awake()
    {
        repairedBoat.SetActive(false);
        brokenBoat.SetActive(true);
        if (visualCue != null)
            visualCue.SetActive(false);
    }
    
    private void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            if (!repaired && !string.IsNullOrEmpty(brokenBoatDialogueKnot))
            {
                GameEventsManager.instance.dialogueEvents.EnterDialogue(brokenBoatDialogueKnot);
            }
            else if (repaired && !string.IsNullOrEmpty(repairedBoatDialogueKnot))
            {
                GameEventsManager.instance.dialogueEvents.EnterDialogue(repairedBoatDialogueKnot);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            if (visualCue != null)
                visualCue.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            if (visualCue != null)
                visualCue.SetActive(false);
        }
    }

    public void LoadData(GameData data)
    {
        data.boatRepaired.TryGetValue(id, out repaired);

        if (repaired)
        {
            brokenBoat.SetActive(false);
            repairedBoat.SetActive(true);
            if (woodUIItem != null)
                woodUIItem.SetActive(false);
        }
    }

    public void SaveData(GameData data)
    {
        data.boatRepaired[id] = repaired;
    }
    
    public void RepairBoat()
    {
        if (repaired) return;
        
        repaired = true;
        brokenBoat.SetActive(false);
        repairedBoat.SetActive(true);
        
        if (woodUIItem != null)
            woodUIItem.SetActive(false);
            
        DataPersistenceManager.instance.SaveGame();
    }
}
