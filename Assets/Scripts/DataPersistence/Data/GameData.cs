using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public long lastUpdated;
    
    // public Vector3 playerPosition;
    public SerializableVector3 playerPosition;

    public SerializableDictionary<string, bool> cardsCollected;

    public string currentLevelName;

    public SerializableDictionary<string, QuestData> questData;

    public int playerLevel;

    public int currentDeck;

    public GameData()
    {
        currentLevelName = "";
        playerPosition = new SerializableVector3(Vector3.zero);
        cardsCollected = new SerializableDictionary<string, bool>();
        questData = new SerializableDictionary<string, QuestData>();
    }
}
