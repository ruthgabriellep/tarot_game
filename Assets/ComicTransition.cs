using UnityEngine;
using UnityEngine.SceneManagement;

public class ComicTransition : MonoBehaviour
{
    
    [SerializeField] private Vector3 spawnPositionInNextScene;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            GameManager.Instance.savedPosition = spawnPositionInNextScene;
            GameManager.Instance.hasSavedPosition = true;
            
            SceneManager.LoadSceneAsync("The_Forest");
        }
    }
}
