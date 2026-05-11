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
    [SerializeField] private GameObject woodUIItem; // hide this after repair

    private bool repaired = false;

    private void Awake()
    {
        repairedBoat.SetActive(false);
        brokenBoat.SetActive(true);
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

    // call this from your existing drag script when wood is dropped on the boat
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
