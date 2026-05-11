using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class PlayerLevelManager : MonoBehaviour, IDataPersistence
{
    
    [Header("Configuration")]
    [SerializeField] private int startingLevel = 1;

    [Header("Level Rules")]
    [SerializeField] private int cardsPerLevel = 1;

    private int currentLevel;
    private int cardsCollected;

    private void Awake()
    {
        currentLevel = startingLevel;
        DontDestroyOnLoad(gameObject);
    }

    private void OnEnable()
    {
        GameEventsManager.instance.deckEvents.onDeckGained += OnDeckGained;
    }

    private void OnDisable()
    {
        GameEventsManager.instance.deckEvents.onDeckGained -= OnDeckGained;
    }

    private void Start()
    {
        GameEventsManager.instance.playerEvents.PlayerLevelChange(currentLevel);
    }

    private void OnDeckGained(int amount)
    {
        cardsCollected += amount;

        int newLevel = (cardsCollected / cardsPerLevel) + startingLevel;

        if (newLevel != currentLevel)
        {
            currentLevel = newLevel;
            GameEventsManager.instance.playerEvents.PlayerLevelChange(currentLevel);
        }
    }

    public void LoadData(GameData data)
    {
        currentLevel = data.playerLevel;
        GameEventsManager.instance.playerEvents.PlayerLevelChange(currentLevel);
    }

    public void SaveData(GameData data)
    {
        data.playerLevel = currentLevel;
    }
}
