using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ink.Runtime;

public class DialoguePanelUI : MonoBehaviour
{
    [Header("Components")] [SerializeField]
    private GameObject contentParent;

    [SerializeField] private TextMeshProUGUI dialogueText;

    [SerializeField] private DialogueChoiceButton[] choiceButtons;
    
    [SerializeField] private float typingSpeed = 0.02f;

    private Coroutine typingCoroutine;
    private bool isTyping;
    private string currentLine;
    private List<Choice> currentChoices;

    private void Awake()
    {
        contentParent.SetActive(false);
        ResetPanel();
    }

    private void OnEnable()
    {
        GameEventsManager.instance.dialogueEvents.onDialogueStarted += DialogueStarted;
        GameEventsManager.instance.dialogueEvents.onDialogueFinished += DialogueFinished;
        GameEventsManager.instance.dialogueEvents.onDisplayDialogue += DisplayDialogue;
    }

    private void OnDisable()
    {
        GameEventsManager.instance.dialogueEvents.onDialogueStarted -= DialogueStarted;
        GameEventsManager.instance.dialogueEvents.onDialogueFinished -= DialogueFinished;
        GameEventsManager.instance.dialogueEvents.onDisplayDialogue -= DisplayDialogue;
    }

    private void DialogueStarted()
    {
        contentParent.SetActive(true);
    }

    private void DialogueFinished()
    {
        contentParent.SetActive(false);
        
        ResetPanel();
    }

    private void DisplayDialogue(string dialogueLine, List<Choice> dialogueChoices)
    {
        // dialogueText.text = dialogueLine;
        
        currentLine = dialogueLine;
        currentChoices = dialogueChoices;

        foreach (DialogueChoiceButton choiceButton in choiceButtons)
        {
            choiceButton.gameObject.SetActive(false);
        }

        if (typingCoroutine != null)
        {
            StopCoroutine(typingCoroutine);
        }

        typingCoroutine = StartCoroutine(TypeLine(dialogueLine));
    }
    
    private IEnumerator TypeLine(string line)
    {
        isTyping = true;
        dialogueText.text = "";

        foreach (char c in line)
        {
            dialogueText.text += c;
            
            float delay = typingSpeed;

            if (c == '.' || c == ',' || c == '!' || c == '?')
            {
                delay *= 3f;
            }
            
            yield return new WaitForSeconds(delay);
        }

        isTyping = false;

        DisplayChoices(currentChoices);
    }
    
    public bool IsTyping()
    {
        return isTyping;
    }

    public void CompleteTyping()
    {
        if (!isTyping) return;

        StopCoroutine(typingCoroutine);
        dialogueText.text = currentLine;
        isTyping = false;

        DisplayChoices(currentChoices);
    }

    private void DisplayChoices(List<Choice> dialogueChoices)
    {
        if (dialogueChoices.Count > choiceButtons.Length)
        {
            Debug.LogError("More dialogue choices ("
                           + dialogueChoices.Count + ") came through than are supported ("
                           + choiceButtons.Length + ").");
        }

        foreach (DialogueChoiceButton choiceButton in choiceButtons)
        {
            choiceButton.gameObject.SetActive(false);
        }

        int choiceButtonIndex = dialogueChoices.Count - 1;
        for (int inkChoiceIndex = 0; inkChoiceIndex < dialogueChoices.Count; inkChoiceIndex++)
        {
            Choice dialogueChoice = dialogueChoices[inkChoiceIndex];
            DialogueChoiceButton choiceButton = choiceButtons[choiceButtonIndex];
            
            choiceButton.gameObject.SetActive(true);
            choiceButton.SetChoiceText(dialogueChoice.text);
            choiceButton.SetChoiceIndex(inkChoiceIndex);

            if (inkChoiceIndex == 0)
            {
                choiceButton.SelectButton();
                GameEventsManager.instance.dialogueEvents.UpdateChoiceIndex(0);
            }
            
            choiceButtonIndex--;
        }
    }
    
    private void ResetPanel()
    {
        dialogueText.text = "";
    }
}
