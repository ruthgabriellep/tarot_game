using System;
using System.Collections.Generic;
using UnityEngine;

namespace QuestSystem
{
    public class QuestManager : MonoBehaviour, IDataPersistence
    {
    private Dictionary<string, Quest> _questMap;

    private int _currentPlayerLevel;

    private bool isLoaded = false;

    private bool hasStarted = false;

    public static QuestManager instance { get; private set; }

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);

        _questMap = CreateQuestMap();
    }

    private void OnEnable()
    {
        if (GameEventsManager.instance == null) return;

        GameEventsManager.instance.questEvents.onStartQuest += StartQuest;
        GameEventsManager.instance.questEvents.onAdvanceQuest += AdvanceQuest;
        GameEventsManager.instance.questEvents.onFinishQuest += FinishQuest;
        GameEventsManager.instance.questEvents.onQuestStepStateChange += QuestStepStateChange;

        GameEventsManager.instance.playerEvents.onPlayerLevelChange += PlayerLevelChange;
    }

    private void OnDisable()
    {
        if (GameEventsManager.instance == null) return;

        GameEventsManager.instance.questEvents.onStartQuest -= StartQuest;
        GameEventsManager.instance.questEvents.onAdvanceQuest -= AdvanceQuest;
        GameEventsManager.instance.questEvents.onFinishQuest -= FinishQuest;
        GameEventsManager.instance.questEvents.onQuestStepStateChange -= QuestStepStateChange;

        GameEventsManager.instance.playerEvents.onPlayerLevelChange -= PlayerLevelChange;
    }

    private void Start()
    {
        hasStarted = true;
        if (!isLoaded) return;
        InitializeRuntimeState();
    }
    
    private void InitializeRuntimeState()
    {
        GameEventsManager.instance.playerEvents.PlayerLevelChange(_currentPlayerLevel);

        RecheckAllQuests();

        foreach (Quest quest in _questMap.Values)
        {
            if (quest.state == QuestState.IN_PROGRESS)
            {
                quest.InstantiateCurrentQuestStep(transform);
            }

            GameEventsManager.instance.questEvents.QuestStateChange(quest);
        }
    }

    private void RecheckAllQuests()
    {
        foreach (Quest quest in _questMap.Values)
        {
            if (quest.state == QuestState.REQUIREMENTS_NOT_MET &&
                CheckRequirementsMet(quest))
            {
                ChangeQuestState(quest.info.id, QuestState.CAN_START);
            }
        }
    }

    private void ChangeQuestState(string id, QuestState state)
    {
        Quest quest = GetQuestById(id);
        quest.state = state;
        GameEventsManager.instance.questEvents.QuestStateChange(quest);
    }

    private void PlayerLevelChange(int level)
    {
        _currentPlayerLevel = level;
        
        RecheckAllQuests();
    }

    private bool CheckRequirementsMet(Quest quest)
    {
        if (_currentPlayerLevel < quest.info.levelRequirement)
            return false;

        foreach (QuestInfoSO prereq in quest.info.questPrerequisites)
        {
            if (GetQuestById(prereq.id).state != QuestState.FINISHED)
                return false;
        }

        return true;
    }

    // private void Update()
    // {
    //     // foreach (Quest quest in _questMap.Values)
    //     // {
    //     //     if (quest.state == QuestState.REQUIREMENTS_NOT_MET &&
    //     //         CheckRequirementsMet(quest))
    //     //     {
    //     //         ChangeQuestState(quest.info.id, QuestState.CAN_START);
    //     //     }
    //     // }
    //
    //     if (!isLoaded) return;
    // }

    private void StartQuest(string id)
    {
        Quest quest = GetQuestById(id);
        quest.InstantiateCurrentQuestStep(transform);
        ChangeQuestState(id, QuestState.IN_PROGRESS);
    }

    private void AdvanceQuest(string id)
    {
        Quest quest = GetQuestById(id);

        quest.MoveToNextStep();

        if (quest.CurrentStepExists())
            quest.InstantiateCurrentQuestStep(transform);
        else
            ChangeQuestState(id, QuestState.CAN_FINISH);
    }

    private void FinishQuest(string id)
    {
        Quest quest = GetQuestById(id);
        ClaimRewards(quest);
        ChangeQuestState(id, QuestState.FINISHED);
    }

    private void ClaimRewards(Quest quest)
    {
        GameEventsManager.instance.deckEvents.DeckGained(quest.info.cardReward);
    }

    private void QuestStepStateChange(string id, int stepIndex, QuestStepState questStepState)
    {
        Quest quest = GetQuestById(id);
        quest.StoreQuestStepState(questStepState, stepIndex);
        ChangeQuestState(id, quest.state);
    }

    private Dictionary<string, Quest> CreateQuestMap()
    {
        QuestInfoSO[] allQuests = Resources.LoadAll<QuestInfoSO>("Quests");

        Dictionary<string, Quest> map = new Dictionary<string, Quest>();

        foreach (QuestInfoSO questInfo in allQuests)
        {
            if (map.ContainsKey(questInfo.id))
            {
                Debug.LogWarning("Duplicate quest ID: " + questInfo.id);
                continue;
            }

            map.Add(questInfo.id, new Quest(questInfo));
        }

        return map;
    }

    private Quest GetQuestById(string id)
    {
        return _questMap[id];
    }

    public void SaveData(GameData data)
    {
        data.questData.Clear();

        foreach (Quest quest in _questMap.Values)
        {
            data.questData[quest.info.id] = quest.GetQuestData();
            Debug.Log($"Saving quest {quest.info.id} with state {quest.state}");
        }
        Debug.Log("Total quests saved: " + data.questData.Count);
    }

    public void LoadData(GameData data)
    {
        _currentPlayerLevel = data.playerLevel;

        foreach (Quest quest in _questMap.Values)
        {
            if (data.questData.TryGetValue(quest.info.id, out QuestData questData))
            {
                Debug.Log($"Loading quest {quest.info.id} with state {questData.state}");
                quest.LoadQuestData(questData);
            }
            else
            {
                Debug.Log($"No saved data found for quest {quest.info.id}");
            }
        }

        isLoaded = true;

        if (hasStarted) InitializeRuntimeState();
    }
    }
    
}
