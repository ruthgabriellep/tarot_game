using UnityEngine;
using TMPro;

public class EndTextTrigger : MonoBehaviour
{
    public EndText fadeText;

    private bool triggered = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (triggered) return;

        if (other.CompareTag("Player"))
        {
            triggered = true;
            fadeText.FadeIn();
        }
    }
}
