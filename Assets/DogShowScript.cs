using UnityEngine;
using QuestSystem;

public class DogShowScript : MonoBehaviour
{
    [SerializeField] private QuestInfoSO requiredQuest;
    [SerializeField] private QuestState requiredState;
    [SerializeField] private GameObject assetToShow;

    private void Update()
    {
        Quest quest = QuestManager.instance.GetQuestById(requiredQuest.id);

        if (quest == null)
            return;

        assetToShow.SetActive(quest.state == requiredState);
    }
}
