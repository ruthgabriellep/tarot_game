using UnityEngine;
using System.Collections;
using TMPro;

public class EndText : MonoBehaviour
{
    public TextMeshProUGUI textMesh;
    public float fadeDuration = 2f;

    private bool hasFaded = false;

    public void FadeIn()
    {
        if (hasFaded) return;

        hasFaded = true;
        StartCoroutine(FadeRoutine());
    }

    IEnumerator FadeRoutine()
    {
        Color color = textMesh.color;
        color.a = 0f;
        textMesh.color = color;

        float timer = 0f;

        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;

            float alpha = timer / fadeDuration;

            color = textMesh.color;
            color.a = alpha;
            textMesh.color = color;

            yield return null;
        }
        
        color.a = 1f;
        textMesh.color = color;
    }
}
