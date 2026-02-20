using TMPro;
using UnityEngine;
using Ink.Runtime;

public class DialogueManager : MonoBehaviour
    {

        [Header("Dialogue UI")] [SerializeField]
        private GameObject dialoguePanel;

        [SerializeField] private TextMeshProUGUI dialogueText;

        private Story _currentStory;

        public bool dialogueIsPlaying;

        private static DialogueManager _instance;

        private void Awake()
        {
            if (_instance != null)
            {
                Debug.LogWarning("Found more than one Dialogue Manager in the scene");
            }

            _instance = this;
        }

        public static DialogueManager GetInstance()
        {
            return _instance;
        }

        private void Start()
        {
            dialogueIsPlaying = false;
            dialoguePanel.SetActive(false);
        }

        private void Update()
        {
            if (!dialogueIsPlaying)
            {
                return;
            }

            if (InputManager.GetInstance().GetSubmitPressed())
            {
                ContinueStory();
            }
        }

        public void EnterDialogueMode(TextAsset inkJson)
        {
            _currentStory = new Story(inkJson.text);
            dialogueIsPlaying = true;
            dialoguePanel.SetActive(true);

            ContinueStory();

        }

        private void ExitDialogueMode()
        {
            dialogueIsPlaying = false;
            dialoguePanel.SetActive(false);
            dialogueText.text = "";
        }

        private void ContinueStory()
        {
            if (_currentStory.canContinue)
            {
                dialogueText.text = _currentStory.Continue();
            }
            else
            {
                ExitDialogueMode();
            }
        }
    }