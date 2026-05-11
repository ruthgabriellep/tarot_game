using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterController2D : MonoBehaviour, IDataPersistence
{
    
    [Header("Config")]
    [SerializeField] private float moveSpeed = 5f;

    private Rigidbody2D _rb;
    private Vector2 _velocity = Vector2.zero;


    private bool _movementDisabled = false;

    private void Awake() 
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    public void LoadData(GameData data)
    {
        if (GameManager.Instance != null && GameManager.Instance.hasSavedPosition)
            return; 
        
        if (data.currentLevelName == SceneManager.GetActiveScene().name)
        {
            this.transform.position = data.playerPosition.ToVector3();
        }
    }

    public void SaveData(GameData data)
    {
        data.playerPosition = new SerializableVector3(this.transform.position);
        Debug.Log("Saving player position: " + this.transform.position);
        
        string activeScene = SceneManager.GetActiveScene().name;
        Debug.Log("Saving scene: " + activeScene);
    }

    private void Start() 
    {
        GameEventsManager.instance.inputEvents.onMovePressed += MovePressed;
        GameEventsManager.instance.playerEvents.onDisablePlayerMovement += DisablePlayerMovement;
        GameEventsManager.instance.playerEvents.onEnablePlayerMovement += EnablePlayerMovement;
    }

    private void OnDestroy()
    {
        GameEventsManager.instance.inputEvents.onMovePressed -= MovePressed;
        GameEventsManager.instance.playerEvents.onDisablePlayerMovement -= DisablePlayerMovement;
        GameEventsManager.instance.playerEvents.onEnablePlayerMovement -= EnablePlayerMovement;
    }

    private void DisablePlayerMovement() 
    {
        _movementDisabled = true;
        _velocity = Vector2.zero;
    }

    private void EnablePlayerMovement() 
    {
        _movementDisabled = false;
    }

    private void MovePressed(Vector2 moveDir) 
    {
        _velocity = moveDir.normalized * moveSpeed;

        if (_movementDisabled) 
        {
            _velocity = Vector2.zero;
        }
    }

    private void FixedUpdate() 
    {
        _rb.linearVelocity = _velocity;
    }
    
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        _velocity = Vector2.zero;
        _rb.linearVelocity = Vector2.zero;
    }
}