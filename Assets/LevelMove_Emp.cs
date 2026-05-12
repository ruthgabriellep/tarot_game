using UnityEngine;
using QuestSystem;
using UnityEngine.SceneManagement;

public class LevelMove_Emp : MonoBehaviour
{
    [SerializeField] private Vector3 spawnPositionInNextScene;

    [SerializeField] private QuestInfoSO requiredQuest;
    [SerializeField] private QuestState requiredState = QuestState.FINISHED;

    [Header("Next Scene")]
    [SerializeField] private string sceneToLoad;

    [Header("Visual Cue")]
    [SerializeField] private GameObject visualCue;

    private bool playerInRange;

    private void Awake()
    {
        visualCue.SetActive(false);
    }

    private void OnEnable()
    {
        GameEventsManager.instance.inputEvents.onSubmitPressed += SubmitPressed;
        GameEventsManager.instance.questEvents.onQuestStateChange += OnQuestStateChanged;
    }

    private void OnDisable()
    {
        GameEventsManager.instance.inputEvents.onSubmitPressed -= SubmitPressed;
        GameEventsManager.instance.questEvents.onQuestStateChange -= OnQuestStateChanged;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player"))
            return;

        playerInRange = true;
        UpdateVisualCue();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (!other.CompareTag("Player"))
            return;

        playerInRange = false;
        visualCue.SetActive(false);
    }

    private void OnQuestStateChanged(Quest quest)
    {
        if (quest.info.id != requiredQuest.id)
            return;

        UpdateVisualCue();
    }

    private void UpdateVisualCue()
    {
        if (!playerInRange)
        {
            visualCue.SetActive(false);
            return;
        }

        Quest quest = QuestManager.instance.GetQuestById(requiredQuest.id);

        if (quest == null)
        {
            visualCue.SetActive(false);
            return;
        }

        visualCue.SetActive(quest.state == requiredState);
    }

    private void SubmitPressed(InputEventContext inputEventContext)
    {
        if (!playerInRange)
            return;

        if (!inputEventContext.Equals(InputEventContext.DEFAULT))
            return;

        if (DialogueManager.instance.IsDialoguePlaying)
            return;

        Quest quest = QuestManager.instance.GetQuestById(requiredQuest.id);

        if (quest == null)
            return;

        if (quest.state != requiredState)
            return;

        GameManager.Instance.savedPosition = spawnPositionInNextScene;
        GameManager.Instance.hasSavedPosition = true;

        DataPersistenceManager.instance.SaveGame();

        SceneManager.LoadSceneAsync(sceneToLoad);
    }
}
