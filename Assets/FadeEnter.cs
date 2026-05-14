using UnityEngine;
using System.Collections;

public class FadeEnter : MonoBehaviour
{
    [SerializeField] private SpriteRenderer targetRenderer;

    [SerializeField] private float fadeDuration = 0.5f;

    [SerializeField] private float fadedAlpha = 0.2f;

    private Coroutine fadeCoroutine;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player"))
            return;

        StartFade(fadedAlpha);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (!isActiveAndEnabled)
            return;
        
        if (!other.CompareTag("Player"))
            return;

        StartFade(1f);
    }

    private void StartFade(float targetAlpha)
    {
        if (!isActiveAndEnabled)
            return;
        
        if (fadeCoroutine != null)
            StopCoroutine(fadeCoroutine);

        fadeCoroutine = StartCoroutine(FadeRoutine(targetAlpha));
    }

    private IEnumerator FadeRoutine(float targetAlpha)
    {
        Color color = targetRenderer.color;

        float startAlpha = color.a;

        float time = 0f;

        while (time < fadeDuration)
        {
            time += Time.deltaTime;

            float t = time / fadeDuration;

            color.a = Mathf.Lerp(startAlpha, targetAlpha, t);

            targetRenderer.color = color;

            yield return null;
        }

        color.a = targetAlpha;

        targetRenderer.color = color;
    }
}
