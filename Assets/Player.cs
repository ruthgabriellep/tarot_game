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
        Debug.Log($"OnSceneLoaded - scene: {scene.name}, " +
                  $"hasSavedPosition: {GameManager.Instance?.hasSavedPosition}, " +
                  $"savedPosition: {GameManager.Instance?.savedPosition}");
        
        if (GameManager.Instance != null && GameManager.Instance.hasSavedPosition)
        {
            transform.position = GameManager.Instance.savedPosition;
            GameManager.Instance.hasSavedPosition = false;
        }
    }
}
