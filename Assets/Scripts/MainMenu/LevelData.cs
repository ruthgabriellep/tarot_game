using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelData : MonoBehaviour, IDataPersistence
{
    public void LoadData(GameData data)
    {
        
    }

    public void SaveData(GameData data)
    {
        string activeScene = SceneManager.GetActiveScene().name;

        if (activeScene != "Main_Menu" &&
            activeScene != "TapestryInspect" &&
            activeScene != "WindowInspect" &&
            activeScene != "Bootstrap")
        {
            data.currentLevelName = activeScene;

            Debug.Log("Saved level: " + data.currentLevelName);
        }
    }
}
