using System;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using QuestSystem;
using UnityEngine.SceneManagement;

public class DataPersistenceManager : MonoBehaviour
{
    [Header("Debugging")] [SerializeField] private bool disableDataPersistence = false;
    
    [SerializeField]
    private bool initializeDataIfNull = false;

    [SerializeField] private bool overrideSelectedProfileId = false;
    [SerializeField] private string testSelectedProfileId = "test";

    [Header("File Storage Config")] [SerializeField]
    private string fileName;

    [SerializeField] private bool useEncryption;

    private GameData gameData;

    private List<IDataPersistence> dataPersistenceObjects;

    private FileDataHandler dataHandler;

    private string selectedProfileId = "";
    public static DataPersistenceManager instance { get; private set; }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("Found more than one Data Persistence Manager in the scene.");
            Destroy(this.gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(this.gameObject);

        if (disableDataPersistence)
        {
            Debug.LogWarning("Data Persistence is currently disabled.");
        }
        
        this.dataHandler = new FileDataHandler(Application.persistentDataPath, fileName, useEncryption);
        this.selectedProfileId = dataHandler.GetMostRecentlyUpdatedProfileId();
        
        Debug.Log("Selected profile id on startup: " + selectedProfileId);
        Debug.Log("Has game data: " + HasGameData());
        
        if (overrideSelectedProfileId)
        {
            this.selectedProfileId = testSelectedProfileId;
            Debug.LogWarning("Overrode selected profile id with test id:" + testSelectedProfileId);
        }
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        SceneManager.sceneUnloaded += OnSceneUnloaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
        SceneManager.sceneUnloaded -= OnSceneUnloaded;
    }

    private void OnSceneUnloaded(Scene scene)
    {
        SaveGame();
    }

    public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("OnSceneLoaded - scene: " + scene.name);
        
        this.dataPersistenceObjects = FindAllDataPersistenceObjects();

        if (dataPersistenceObjects == null)
        {
            Debug.LogError("FindAllDataPersistenceObjects returned null");
            return;
        }

        if (scene.name == "Main_Menu")
        {
            this.gameData = dataHandler.Load(selectedProfileId);
            return;
        }
        
        if (scene.name == "TapestryInspect" || 
            scene.name == "WindowInspect" || 
            scene.name == "Bootstrap")
            return;
        
        Debug.Log("Calling LoadGame for scene: " + scene.name);
        LoadGame();
    }

    public void ChangeSelectedProfileId(string newProfileId)
    {
        this.selectedProfileId = newProfileId;
        LoadGame();
    }

    public void NewGame()
    {
        if (string.IsNullOrEmpty(selectedProfileId))
        {
            selectedProfileId = "profile1";
        }
        this.gameData = new GameData();

        if (QuestManager.instance != null)
        {
            QuestManager.instance.ResetQuests();
        }
    }

    public void LoadGame()
    {
        if (disableDataPersistence) return;

        if (dataHandler == null)
        {
            Debug.LogError("dataHandler is null in LoadGame");
            return;
        }

        this.gameData = dataHandler.Load(selectedProfileId);

        if (this.gameData == null)
        {
            if (initializeDataIfNull)
            {
                Debug.Log("No data found - starting new game.");
                NewGame();
            }
            else
            {
                Debug.Log("No data found and initializeDataIfNull is false. Aborting load.");
                return;
            }
        }

        if (this.gameData.questData == null)
            this.gameData.questData = new SerializableDictionary<string, QuestData>();

        if (this.gameData.cardsCollected == null)
            this.gameData.cardsCollected = new SerializableDictionary<string, bool>();
        
        if (this.gameData.woodCollected == null)
            this.gameData.woodCollected = new SerializableDictionary<string, bool>();

        if (this.gameData.boatRepaired == null)
            this.gameData.boatRepaired = new SerializableDictionary<string, bool>();

        if (dataPersistenceObjects == null)
        {
            Debug.LogError("dataPersistenceObjects is null in LoadGame");
            return;
        }

        foreach (IDataPersistence dataPersistenceObj in dataPersistenceObjects)
        {
            if (dataPersistenceObj == null) continue;
            dataPersistenceObj.LoadData(gameData);
        }
    }

    public void SaveGame()
    {
        
        if (disableDataPersistence)
        {
            return;
        }

        if (this.gameData == null)
        {
            Debug.LogWarning("No data was found. A New Game needs to be started before data can be saved.");
            return;
        }
        
        Debug.Log("Saving to profile id: " + selectedProfileId);
        
        foreach (IDataPersistence dataPersistenceObj in dataPersistenceObjects)
        {
            dataPersistenceObj.SaveData(gameData);
        }

        gameData.lastUpdated = System.DateTime.Now.ToBinary();
        
        dataHandler.Save(gameData, selectedProfileId);
    }

    private void OnApplicationQuit()
    {
        SaveGame();
    }

    private List<IDataPersistence> FindAllDataPersistenceObjects()
    {
        IEnumerable<IDataPersistence> dataPersistenceObjects = FindObjectsOfType<MonoBehaviour>(true)
            .OfType<IDataPersistence>();

        return new List<IDataPersistence>(dataPersistenceObjects);
    }

    public bool HasGameData()
    {
        return gameData != null;
    }

    public Dictionary<string, GameData> GetAllProfilesGameData()
    {
        return dataHandler.LoadAllProfiles();
    }
    
    public string GetLastSavedScene()
    {
        if (gameData != null && !string.IsNullOrEmpty(gameData.currentLevelName))
        {
            return gameData.currentLevelName;
        }
        return "The_Forest";
    }
}
