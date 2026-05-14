using UnityEngine;
using UnityEngine.SceneManagement;

public class Fountain : MonoBehaviour
{
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
            GameEventsManager.instance.miscEvents.FountainInspected();
            
            GameManager.Instance.savedPosition = Player.instance.transform.position;
            GameManager.Instance.hasSavedPosition = true;
            
            DataPersistenceManager.instance.SaveGame();
            
            SceneManager.LoadScene("FountainInspect");
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
