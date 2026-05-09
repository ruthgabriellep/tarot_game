using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public long lastUpdated;
    
    public Vector3 playerPosition;

    public SerializableDictionary<string, bool> cardsCollected;

    public string currentLevelName;

    public GameData()
    {
        currentLevelName = "";
        playerPosition = Vector3.zero;
        cardsCollected = new SerializableDictionary<string, bool>();
    }
}
