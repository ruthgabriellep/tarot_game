using UnityEngine;
using UnityEngine.SceneManagement;

public class Boat_Transition : MonoBehaviour
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
            Debug.Log("Change Scene");
            ChangeSceneToLevel();
        }
    }

    void ChangeSceneToLevel()
    {
        SceneManager.LoadScene("HighPriestess_Level_1");
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
