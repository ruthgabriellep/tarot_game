using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class Card : MonoBehaviour
{ 
    [Header("Config")]
    // [SerializeField] private float respawnTimeSeconds = 8;
    [SerializeField] private int deckGained = 1;

    private CircleCollider2D _circleCollider;
    private SpriteRenderer _visual;

    private void Awake() 
    {
        _circleCollider = GetComponent<CircleCollider2D>();
        _visual = GetComponentInChildren<SpriteRenderer>();
    }

    private void CollectCoin() 
    {
        _circleCollider.enabled = false;
        _visual.gameObject.SetActive(false);
        GameEventsManager.instance.deckEvents.DeckGained(deckGained);
        GameEventsManager.instance.miscEvents.CardCollected();
        // StopAllCoroutines();
        // StartCoroutine(RespawnAfterTime());
    }

    // private IEnumerator RespawnAfterTime()
    // {
    //     yield return new WaitForSeconds(respawnTimeSeconds);
    //     circleCollider.enabled = true;
    //     visual.gameObject.SetActive(true);
    // }

    private void OnTriggerEnter2D(Collider2D otherCollider) 
    {
        if (otherCollider.CompareTag("Player"))
        {
            CollectCoin();
        }
    }
}
