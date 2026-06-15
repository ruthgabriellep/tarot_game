using UnityEngine;

public class InstructionsTextCoast : MonoBehaviour
{
    [SerializeField] private CanvasGroup imageCanvasGroup;
    [SerializeField] private float fadeSpeed = 2f;

    private bool shouldFade = false;

    private void Update()
    {
        if (!shouldFade && Input.GetMouseButtonDown(0))
        {
            shouldFade = true;
        }

        if (shouldFade && imageCanvasGroup.alpha > 0)
        {
            imageCanvasGroup.alpha -= fadeSpeed * Time.deltaTime;
        }
    }
}
