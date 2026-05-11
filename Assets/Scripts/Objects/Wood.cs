using UnityEngine;

public class Wood : MonoBehaviour, IDataPersistence
{
    [SerializeField] private string id;
    
    [ContextMenu("Generate guid for id")]
    private void GenerateGuid()
    {
        id = System.Guid.NewGuid().ToString();
    }

    [SerializeField] private GameObject visualCue;
    [SerializeField] private GameObject woodUIItem; // the draggable UI wood at the bottom

    private CircleCollider2D _circleCollider;
    private SpriteRenderer _visual;
    private bool playerInRange;
    private bool collected = false;

    private void Awake()
    {
        _circleCollider = GetComponent<CircleCollider2D>();
        _visual = GetComponentInChildren<SpriteRenderer>();
        visualCue.SetActive(false);
        woodUIItem.SetActive(false); // hidden until collected
        playerInRange = false;
    }

    public void LoadData(GameData data)
    {
        data.woodCollected.TryGetValue(id, out collected);

        if (collected)
        {
            _circleCollider.enabled = false;
            _visual.gameObject.SetActive(false);
            visualCue.SetActive(false);
            playerInRange = false;
            woodUIItem.SetActive(true); // show UI wood if already collected
        }
    }

    public void SaveData(GameData data)
    {
        data.woodCollected[id] = collected;
    }

    private void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E) && !collected)
        {
            CollectWood();
        }
    }

    private void CollectWood()
    {
        collected = true;
        _circleCollider.enabled = false;
        _visual.gameObject.SetActive(false);
        visualCue.SetActive(false);
        woodUIItem.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            visualCue.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            visualCue.SetActive(false);
        }
    }
}
