using UnityEngine;

namespace QuestSystem
{
    [RequireComponent(typeof(CircleCollider2D))]
    public class QuestPoint : MonoBehaviour
    {
        [Header("Dialogue")] [SerializeField] private string dialogueKnotName;
        
        [Header("Quest")] [SerializeField] private QuestInfoSO questInfoForPoint;

        [Header("Parameters")] [SerializeField] private GameObject barrier1;
        
        [Header("Objectives")]
        [SerializeField] private GameObject objective1;
        [SerializeField] private GameObject objective2;

        [Header("Config")] [SerializeField] private bool startPoint = true;
        [SerializeField] private bool finishPoint = true;

        [Header("Visual Cue")] [SerializeField]
        private GameObject visualCue;

        private bool _playerIsNear;

        private string _questId;

        private QuestState _currentQuestState;

        private QuestIcon _questIcon;

        private void Awake()
        {
            _questId = questInfoForPoint.id;
            _questIcon = GetComponentInChildren<QuestIcon>();
        }

        private void Start()
        {
            barrier1.SetActive(true); 
            objective1.SetActive(false);
            objective2.SetActive(false);
            visualCue.SetActive(false);
        }

        private void Update()
        {
            if (!_currentQuestState.Equals(QuestState.CAN_START))
            {
                barrier1.SetActive(false);
            }

            if (_currentQuestState.Equals(QuestState.IN_PROGRESS))
            {
                objective2.SetActive(true);
                objective1.SetActive(false);
            }

            if (_currentQuestState.Equals(QuestState.CAN_FINISH))
            {
                objective2.SetActive(false);
                objective1.SetActive(true);
            }

            if (_currentQuestState.Equals(QuestState.FINISHED))
            {
                objective1.SetActive(false);
            }
        }

        private void OnEnable()
        {
            GameEventsManager.instance.questEvents.onQuestStateChange += QuestStateChange;
            GameEventsManager.instance.inputEvents.onSubmitPressed += SubmitPressed;
        }

        private void OnDisable()
        {
            GameEventsManager.instance.questEvents.onQuestStateChange -= QuestStateChange;
            GameEventsManager.instance.inputEvents.onSubmitPressed -= SubmitPressed;
        }

        private void SubmitPressed(InputEventContext inputEventContext)
        {
            if (!_playerIsNear || !inputEventContext.Equals(InputEventContext.DEFAULT))
            {
                return;
            }

            if (!dialogueKnotName.Equals(""))
            {
                GameEventsManager.instance.dialogueEvents.EnterDialogue(dialogueKnotName);
            }
            else
            {
                if (_currentQuestState.Equals(QuestState.CAN_START) && startPoint)
                {
                    GameEventsManager.instance.questEvents.StartQuest(_questId);
                }
                else if (_currentQuestState.Equals(QuestState.CAN_FINISH) && finishPoint)
                {
                    GameEventsManager.instance.questEvents.FinishQuest(_questId);
                }
            }

        }

        private void QuestStateChange(Quest quest)
        {
            if (quest.info.id.Equals(_questId))
            {
                _currentQuestState = quest.state;
                _questIcon.SetState(_currentQuestState, startPoint, finishPoint);
            }
        }

        private void OnTriggerEnter2D(Collider2D otherCollider)
        {
            if (otherCollider.CompareTag("Player"))
            {
                _playerIsNear = true;
                visualCue.SetActive(true);
                
                if (_currentQuestState == QuestState.CAN_START)
                {
                    visualCue.SetActive(false);
                    GameEventsManager.instance.dialogueEvents.EnterDialogue(dialogueKnotName);
                }
                else
                {
                    visualCue.SetActive(true);
                }
            }
        }

        private void OnTriggerExit2D(Collider2D otherCollider)
        {
            if (otherCollider.CompareTag("Player"))
            {
                _playerIsNear = false;
                visualCue.SetActive(false);
            }
        }

    }
}