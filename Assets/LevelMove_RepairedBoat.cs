using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMove_RepairedBoat : MonoBehaviour
{
    [SerializeField] private Vector3 spawnPositionInNextScene;

    [Header("Visual Cue")] [SerializeField]
    private GameObject visualCue;

    private BoxCollider2D _boxCollider;
    private SpriteRenderer _visual;

    private bool playerInRange;

    private void Awake()
    {
        visualCue.SetActive(false);
        playerInRange = false;
    }
    
    private void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            GameManager.Instance.savedPosition = spawnPositionInNextScene;
            GameManager.Instance.hasSavedPosition = true;
            DataPersistenceManager.instance.SaveGame();
            SceneManager.LoadSceneAsync("HighPriestess_Level_1");
        }
    }

    private void OnTriggerEnter2D(Collider2D otherCollider) 
    {
        if (otherCollider.CompareTag("Player"))
        {
            playerInRange = true;
            visualCue.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D otherCollider)
    {
        if (otherCollider.CompareTag("Player"))
        {
            playerInRange = false;
            visualCue.SetActive(false);
        }
    }
    

}

