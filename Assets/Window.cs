using UnityEditor.Search;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Window : MonoBehaviour
{
    [Header("Visual Cue")] [SerializeField]
    private GameObject visualCue;
    
    [SerializeField] public GameObject otherUI;

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
            GameManager.Instance.savedPosition = Player.instance.transform.position;
            GameManager.Instance.hasSavedPosition = true;
            
            SceneManager.LoadScene("WindowInspect");
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
