using UnityEngine;
using UnityEngine.SceneManagement;

public class Tower_Door : MonoBehaviour
{
    [Header("Visual Cue")] [SerializeField]
    private GameObject visualCue;
    
    [SerializeField] private Vector3 spawnPositionInNextNextScene;

    private BoxCollider2D _boxCollider;
    private SpriteRenderer _visual;

    private bool _playerInRange;

    private void Awake() 
    {
        visualCue.SetActive(false);
        _playerInRange = false;
    }
    
    private void Update()
    {
        if (_playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Change Scene");
            ChangeSceneToLevel();
        }
    }

    void ChangeSceneToLevel()
    {
        GameManager.Instance.savedPosition = spawnPositionInNextNextScene;
        GameManager.Instance.hasSavedPosition = true;
        SceneManager.LoadScene("Magician_Level_1");
    }
    
    private void OnTriggerEnter2D(Collider2D otherCollider) 
    {
        if (otherCollider.CompareTag("Player"))
        {
            _playerInRange = true;
            visualCue.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D otherCollider)
    {
        if (otherCollider.CompareTag("Player"))
        {
            _playerInRange = false;
            visualCue.SetActive(false);
        }
    }
}
