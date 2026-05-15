using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public static Player instance { get; private set; }

    void Awake()
    {
        if (instance != null && instance != this)
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
    
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        string[] scenesWithoutPlayer = { "FountainInspect", "TapestryInspect", "WindowInspect" };
    
        bool hidePlayer = System.Array.Exists(scenesWithoutPlayer, s => s == scene.name);
    
        // hide/show player visuals and collider
        GetComponentInChildren<SpriteRenderer>().enabled = !hidePlayer;
        GetComponent<Collider2D>().enabled = !hidePlayer;
        GetComponent<Rigidbody2D>().simulated = !hidePlayer;
        
        if (GameManager.Instance != null && GameManager.Instance.hasSavedPosition)
        {
            transform.position = GameManager.Instance.savedPosition;
            GameManager.Instance.hasSavedPosition = false;
        }
    }
}
