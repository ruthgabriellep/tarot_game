using UnityEngine;

namespace QuestSystem
{
    [RequireComponent(typeof(CircleCollider2D))]
    public class QuestPoint : MonoBehaviour
    {
        [Header("Quest")] [SerializeField] private QuestInfoSO questInfoForPoint;

        [Header("Config")] [SerializeField] private bool startPoint = true;
        [SerializeField] private bool finishPoint = true;

        private bool _playerIsNear;

        private string _questId;

        private QuestState _currentQuestState;

        private QuestIcon _questIcon;

        private void Awake()
        {
            _questId = questInfoForPoint.id;
            _questIcon = GetComponentInChildren<QuestIcon>();
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

        private void SubmitPressed(InputEventContext context)
        {
            if (!_playerIsNear)
            {
                return;
            }

            if (_currentQuestState.Equals(QuestState.CAN_START) && startPoint)
            {
                GameEventsManager.instance.questEvents.StartQuest(_questId);
            }
            else if (_currentQuestState.Equals(QuestState.CAN_FINISH) && finishPoint)
            {
                GameEventsManager.instance.questEvents.FinishQuest(_questId);
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
            }
        }

        private void OnTriggerExit2D(Collider2D otherCollider)
        {
            if (otherCollider.CompareTag("Player"))
            {
                _playerIsNear = false;
            }
        }
    }
}