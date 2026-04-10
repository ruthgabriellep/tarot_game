using TMPro;
using UnityEngine;
using Ink.Runtime;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using System.Collections;

public class DialogueManager : MonoBehaviour
{
//     [Header("Dialogue UI")] [SerializeField]
//     private GameObject dialoguePanel;
//
//     [SerializeField] private TextMeshProUGUI dialogueText;
//
//     [Header("Choices UI")] [SerializeField]
//     private GameObject[] choices;
//
//     private TextMeshProUGUI[] _choicesText; 
//     
//     private Story _currentStory;
//
//     public bool dialogueIsPlaying;
//     
//     private static DialogueManager _instance;
//
//     private void Awake()
//     {
//         if (_instance != null)
//         {
//             Debug.LogWarning("Found more than one Dialogue Manager in the scene");
//         }
//             
//         _instance = this;
//     }
//
//     public static DialogueManager GetInstance()
//     {
//         return _instance;
//     }
//
//     private void Start()
//     {
//         dialogueIsPlaying = false;
//         dialoguePanel.SetActive(false);
//
//         _choicesText = new TextMeshProUGUI[choices.Length];
//         int index = 0;
//         foreach (GameObject choice in choices)
//         {
//             _choicesText[index] = choice.GetComponentInChildren<TextMeshProUGUI>();
//             index++;
//         }
//     }
//
//     private void Update()
//     {
//         if (!dialogueIsPlaying)
//         {
//             return;
//         }
//
//         if (InputManager.GetInstance().GetInteractPressed())
//         {
//             ContinueStory();
//         }
//     }
//
//     public void EnterDialogueMode(TextAsset inkJson)
//     {
//         _currentStory = new Story(inkJson.text);
//         dialogueIsPlaying = true;
//         dialoguePanel.SetActive(true);
//         
//     }
//
//     private void ExitDialogueMode()
//     {
//         dialogueIsPlaying = false;
//         dialoguePanel.SetActive(false);
//         dialogueText.text = "";
//     }
//
//     private void ContinueStory()
//     {
//         if (_currentStory.canContinue)
//         {
//             dialogueText.text = _currentStory.Continue();
//             DisplayChoices();
//         }
//         else
//         {
//             ExitDialogueMode();
//         }
//     }
//
//     private void DisplayChoices()
//     {
//         List<Choice> currentChoices = _currentStory.currentChoices;
//
//         if (currentChoices.Count > choices.Length)
//         {
//             Debug.LogError("More choices were given than the UI can support. Number of choices given: " + currentChoices.Count);
//         }
//
//         int index = 0;
//
//         foreach (Choice choice in currentChoices)
//         {
//             choices[index].gameObject.SetActive(true);
//             _choicesText[index].text = choice.text;
//             index++;
//         }
//
//         for (int i = index; i < choices.Length; i++)
//         {
//             choices[i].gameObject.SetActive(false);
//         }
//
//         StartCoroutine(SelectFirstChoice());
//
//     }
//
//     private IEnumerator SelectFirstChoice()
//     {
//         EventSystem.current.SetSelectedGameObject(null);
//         yield return new WaitForEndOfFrame();
//         EventSystem.current.SetSelectedGameObject(choices[0].gameObject);
//     }
//
//     public void MakeChoice(int choiceIndex)
//     {
//         _currentStory.ChooseChoiceIndex(choiceIndex);
//         ContinueStory();
//     }
//     
}