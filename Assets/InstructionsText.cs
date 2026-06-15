using UnityEngine;

public class InstructionsText : MonoBehaviour
{
    [SerializeField] private CanvasGroup imageCanvasGroup;
    [SerializeField] private float fadeSpeed = 2f;

    private bool shouldFade = false;

    private void Update()
    {
        if (!shouldFade && (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D)))
        {
            shouldFade = true;
        }

        if (shouldFade && imageCanvasGroup.alpha > 0)
        {
            imageCanvasGroup.alpha -= fadeSpeed * Time.deltaTime;
        }
    }
}
