using UnityEngine;
using UnityEngine.SceneManagement;

public class FountainInspect : MonoBehaviour
{
    [SerializeField] private Vector3 spawnPositionInNextScene;

    private void Update()
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
        
        SceneManager.LoadSceneAsync("HighPriestess_Level_1");
    }
}
