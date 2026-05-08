using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyFollowPlayer : MonoBehaviour
{
    [SerializeField] private float speed = 1.5f;

    private GameObject player;

    private static EnemyFollowPlayer instance;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        
        DontDestroyOnLoad(gameObject);
    }
    
    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
    
    void Start()
    {
        FindPlayer();
        // player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        }
       
    }
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        FindPlayer();
        
        if (player != null)
        {
            // transform.position = player.transform.position + new Vector3(-1.5f, 0, 0);

            Vector3 offset = new Vector3(-1.5f, 0, 0);
            
            transform.position = player.transform.position + offset;
        }
    }

    void FindPlayer()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
}

