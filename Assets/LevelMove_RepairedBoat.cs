using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMove_RepairedBoat : MonoBehaviour
{
    [SerializeField] private Vector3 spawnPositionInNextScene;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.savedPosition = spawnPositionInNextScene;
            GameManager.Instance.hasSavedPosition = true;
            DataPersistenceManager.instance.SaveGame();
            SceneManager.LoadSceneAsync("HighPriestess_Temple");
        }
    }
}
