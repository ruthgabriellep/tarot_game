using UnityEngine;
using System.Collections;

public class DogRunSequence : MonoBehaviour
{
    [SerializeField] private EnemyFollowPlayer dogFollow;
    [SerializeField] private Transform runTarget;
    [SerializeField] private float runSpeed = 8f;

    private bool triggered = false;

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
        // stop player movement
        GameEventsManager.instance.playerEvents.DisablePlayerMovement();

        // stop follow script
        dogFollow.followingPlayer = false;

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

        // optional
        dogFollow.gameObject.SetActive(false);

        // re-enable player movement
        GameEventsManager.instance.playerEvents.EnablePlayerMovement();
    }
}
