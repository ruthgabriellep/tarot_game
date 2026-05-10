using UnityEngine;
using UnityEngine.SceneManagement;

public class WindowInspect : MonoBehaviour
{
    
    [SerializeField] private Vector3 spawnPositionInNextScene;
    
    public void ExitInspect()
    {
        GameManager.Instance.savedPosition = spawnPositionInNextScene;
        GameManager.Instance.hasSavedPosition = true;
        SceneManager.LoadSceneAsync("Magician_Level_1");
    }
}