using UnityEngine;
using System.Collections;

public class DogRunSequence : MonoBehaviour
{
    [SerializeField] private EnemyFollowPlayer dogFollow;
    [SerializeField] private Transform runTarget;
    [SerializeField] private float runSpeed = 8f;

    private bool triggered = false;

    [Header("SFX")] 
    [SerializeField] private AudioClip bark;

    [SerializeField] private AudioClip dogRun;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (triggered) return;

        if (other.CompareTag("Player"))
        {
            triggered = true;
            StartCoroutine(Sequence());
        }
    }

    IEnumerator Sequence()
    {
        AudioManager.Instance.PlaySFX(bark);
        
        GameEventsManager.instance.playerEvents.DisablePlayerMovement();
        
        dogFollow.followingPlayer = false;
        
        AudioManager.Instance.PlaySFX(dogRun);

        // dog runs away
        while (Vector2.Distance(dogFollow.transform.position, runTarget.position) > 0.1f)
        {
            dogFollow.transform.position = Vector2.MoveTowards(
                dogFollow.transform.position,
                runTarget.position,
                runSpeed * Time.deltaTime
            );

            yield return null;
        }
        dogFollow.gameObject.SetActive(false);
        
        GameEventsManager.instance.playerEvents.EnablePlayerMovement();
    }
}
