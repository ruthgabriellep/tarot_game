using System;
using QuestSystem;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMove_Ref : MonoBehaviour
{
    [SerializeField] private Vector3 spawnPositionInNextScene;
    [SerializeField] private QuestInfoSO requiredQuest;
    [SerializeField] private QuestState requiredState;

    private bool hasTriggered = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !hasTriggered)
        {
            Quest quest = QuestManager.instance.GetQuestById(requiredQuest.id);

            if (quest.state != requiredState)
                return;

            hasTriggered = true;
            GameManager.Instance.savedPosition = spawnPositionInNextScene;
            GameManager.Instance.hasSavedPosition = true;
            DataPersistenceManager.instance.SaveGame();
            SceneManager.LoadSceneAsync("Coast_Puzzle_Level");
        }
    }
}
