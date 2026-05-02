using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.UI;

public class TypewriterEffect : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public float typingSpeed = 0.05f;
    public Button buttonToDisable;

    private string fullText;

    void Start()
    {
        fullText = textComponent.text;
        textComponent.text = "";
    }

    public void StartTyping()
    {
        StopAllCoroutines();
        StartCoroutine(TypeText());
    }
    IEnumerator TypeText()
    {
        buttonToDisable.interactable = false;
        textComponent.text = fullText;
        textComponent.maxVisibleCharacters = 0;

        for (int i = 0; i <= fullText.Length; i++)
        {
            textComponent.maxVisibleCharacters = i;
            yield return new WaitForSeconds(typingSpeed);
        }
        
        buttonToDisable.interactable = true;
    }
}
