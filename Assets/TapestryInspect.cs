using UnityEngine;
using UnityEngine.SceneManagement;

public class TapestryInspect : MonoBehaviour
{
    // [SerializeField] private Vector3 spawnPositionInNextScene;
    //
    // public void ExitInspect()
    // {
    //     GameManager.Instance.savedPosition = spawnPositionInNextScene;
    //     GameManager.Instance.hasSavedPosition = true;
    //     SceneManager.LoadSceneAsync("Magician_Level_1");
    // }
    
    [SerializeField] private Vector3 spawnPositionInNextScene;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            ExitInspect();
        }
    }

    public void ExitInspect()
    {
        GameManager.Instance.savedPosition = spawnPositionInNextScene;
        GameManager.Instance.hasSavedPosition = true;

        SceneManager.LoadSceneAsync("Magician_Level_1");
    }
}
