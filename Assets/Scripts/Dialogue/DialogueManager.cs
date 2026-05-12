using System;
using System.Collections;
using System.Net.Mime;
using TMPro;
using UnityEngine;
using Ink.Runtime;
using UnityEditor;

public class DialogueManager : MonoBehaviour
{
    [Header("Ink Story")] [SerializeField] private TextAsset inkJson;

    private Story story;

    private int currentChoiceIndex = -1;

    private bool dialoguePlaying = false;

    public bool IsDialoguePlaying => dialoguePlaying;

    private InkExternalFunctions inkExternalFunctions;

    private InkDialogueVariables inkDialogueVariables;

    // [SerializeField] private DialoguePanelUI dialogueUI;

    private DialoguePanelUI dialogueUI;

    private bool waitingForUI = false;
    
    public static DialogueManager instance { get; private set; }

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
        
        story = new Story(inkJson.text);
        inkExternalFunctions = new InkExternalFunctions();
        inkExternalFunctions.Bind(story);
        inkDialogueVariables = new InkDialogueVariables(story);
    }

    private void OnDestroy()
    {
        if (inkExternalFunctions != null)
        {
            inkExternalFunctions.Unbind(story);
        }
    }
    private void OnEnable()
    {
        GameEventsManager.instance.dialogueEvents.onEnterDialogue += EnterDialogue;
        GameEventsManager.instance.inputEvents.onSubmitPressed += SubmitPressed;
        GameEventsManager.instance.dialogueEvents.onUpdateChoiceIndex += UpdateChoiceIndex;
        GameEventsManager.instance.dialogueEvents.onUpdateInkDialogueVariable += UpdateInkDialogueVariable;
        GameEventsManager.instance.questEvents.onQuestStateChange += QuestStateChange;
    }

    private void OnDisable()
    {
        GameEventsManager.instance.dialogueEvents.onEnterDialogue -= EnterDialogue;
        GameEventsManager.instance.inputEvents.onSubmitPressed -= SubmitPressed;
        GameEventsManager.instance.dialogueEvents.onUpdateChoiceIndex -= UpdateChoiceIndex;
        GameEventsManager.instance.dialogueEvents.onUpdateInkDialogueVariable -= UpdateInkDialogueVariable;
        GameEventsManager.instance.questEvents.onQuestStateChange -= QuestStateChange;
    }

    private void QuestStateChange(Quest quest)
    {
        Debug.Log($"QuestStateChange received - quest: {quest.info.id}, state: {quest.state}");
        GameEventsManager.instance.dialogueEvents.UpdateInkDialogueVariable(
            quest.info.id + "State",
            new StringValue(quest.state.ToString())
            );
    }

    private void UpdateInkDialogueVariable(string name, Ink.Runtime.Object value)
    {
        inkDialogueVariables.UpdateVariableState(name, value);
    }

    private void UpdateChoiceIndex(int choiceIndex)
    {
        this.currentChoiceIndex = choiceIndex;
    }

    private void SubmitPressed(InputEventContext inputEventContext)
    {
        if (!inputEventContext.Equals(InputEventContext.DIALOGUE))
        {
            return;
        }

        if (dialogueUI.IsTyping())
        {
            dialogueUI.CompleteTyping();
        }
        else
        {
            ContinueOrExitStory();
        }
        
    }

    private void EnterDialogue(string knotName)
    {
        if (dialoguePlaying) return;

        if (dialogueUI == null)
        {

            if (waitingForUI)
                return;

            waitingForUI = true;
            
            StartCoroutine(WaitForUIAndEnterDialogue(knotName));
            return;
        }

        StartDialogue(knotName);
    }

    private IEnumerator WaitForUIAndEnterDialogue(string knotName)
    {

        while (dialogueUI == null)
        {
            yield return null;
        }

        waitingForUI = false; 
        
        StartDialogue(knotName);
    }
    
    private void StartDialogue(string knotName)
    {
        Debug.Log("START DIALOGUE");
        
        if (dialoguePlaying)
            return;
        
        dialoguePlaying = true;

        GameEventsManager.instance.dialogueEvents.DialogueStarted();
        GameEventsManager.instance.playerEvents.DisablePlayerMovement();
        GameEventsManager.instance.inputEvents.ChangeInputEventContext(InputEventContext.DIALOGUE);

        if (!string.IsNullOrEmpty(knotName))
        {
            story.ChoosePathString(knotName);
        }
        else
        {
            Debug.LogWarning("Knot name was the empty string when entering dialogue.");
        }

        inkDialogueVariables.SyncVariablesAndStartListening(story);
        ContinueOrExitStory();
    }

    private void ContinueOrExitStory()
    {
        if (story.currentChoices.Count > 0 && currentChoiceIndex != -1)
        {
            story.ChooseChoiceIndex(currentChoiceIndex);
            currentChoiceIndex = -1;
        }
            
        if (story.canContinue)
        {
            string dialogueLine = story.Continue();

            while (IsLineBlank(dialogueLine) && story.canContinue)
            {
                dialogueLine = story.Continue();
            }

            if (IsLineBlank(dialogueLine) && !story.canContinue)
            {
                ExitDialogue();
            }
            else
            {
                GameEventsManager.instance.dialogueEvents.DisplayDialogue(dialogueLine, story.currentChoices);
            }

            Debug.Log($"canContinue: {story.canContinue}, choices: {story.currentChoices.Count}");
        }
        else if (story.currentChoices.Count == 0)
        {
            ExitDialogue();
        }
    }
    
    private void ExitDialogue()
    {
        Debug.Log("EXIT DIALOGUE");
        
        dialoguePlaying = false;
        
        GameEventsManager.instance.dialogueEvents.DialogueFinished();
        
        GameEventsManager.instance.playerEvents.EnablePlayerMovement();
        
        GameEventsManager.instance.inputEvents.ChangeInputEventContext(InputEventContext.DEFAULT);
        
        inkDialogueVariables.StopListening(story);
        
        story.ResetState();
    }

    private bool IsLineBlank(string dialogueLine)
    {
        return dialogueLine.Trim().Equals("") || dialogueLine.Trim().Equals("\n");
    }
    
    public void RegisterDialogueUI(DialoguePanelUI ui)
    {
        dialogueUI = ui;
        Debug.Log("DialogueUI registered successfully");
    }
    
}