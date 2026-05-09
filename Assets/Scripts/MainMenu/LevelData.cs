using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelData : MonoBehaviour, IDataPersistence
{
    public void LoadData(GameData data)
    {
        
    }

    public void SaveData(GameData data)
    {
        data.currentLevelName = SceneManager.GetActiveScene().name;
        
        Debug.Log("Saved level: " + data.currentLevelName);
    }
}
