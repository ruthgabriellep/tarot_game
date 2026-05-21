using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyFollowPlayer : MonoBehaviour
{
    [SerializeField] private float speed = 1.5f;

    private GameObject player;

    public bool followingPlayer = true;

    private static EnemyFollowPlayer instance;
    
    [SerializeField] private Transform visual;
    
    private Vector2 lastDirection;

    // void Awake()
    // {
    //     if (instance != null)
    //     {
    //         Destroy(gameObject);
    //         return;
    //     }
    //
    //     instance = this;
    //
    //     DontDestroyOnLoad(gameObject);
    // }
    //
    // void OnEnable()
    // {
    //     SceneManager.sceneLoaded += OnSceneLoaded;
    // }
    //
    // void OnDisable()
    // {
    //     SceneManager.sceneLoaded -= OnSceneLoaded;
    // }

    void Start()
    {
        FindPlayer();
    }

    void Update()
    {
        if (!followingPlayer) return;

        if (player != null)
        {
            
            Vector2 direction = (player.transform.position - transform.position).normalized;

            lastDirection = direction;
            
            transform.position = Vector2.MoveTowards(
                transform.position,
                player.transform.position,
                speed * Time.deltaTime
            );
            
            UpdateFacing(direction);
        }
    }

    // void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    // {
    //     FindPlayer();
    //
    //     // if (player != null)
    //     // {
    //     //     Vector3 offset = new Vector3(-1.5f, 0, 0);
    //     //
    //     //     transform.position = player.transform.position + offset;
    //     // }
    // }

    void FindPlayer()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    
    private void UpdateFacing(Vector2 direction)
    {
        if (Mathf.Abs(direction.x) < 0.01f)
            return;

        if (direction.x > 0)
            visual.localScale = new Vector3(1, 1, 1);
        else
            visual.localScale = new Vector3(-1, 1, 1);
    }
}

