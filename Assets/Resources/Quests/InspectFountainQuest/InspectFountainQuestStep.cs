using UnityEngine;

public class InspectFountainQuestStep : QuestStep
{
    private void OnEnable()
    {
        GameEventsManager.instance.miscEvents.onFountainInspected += FountainInspected;
    }

    private void OnDisable()
    {
        GameEventsManager.instance.miscEvents.onFountainInspected -= FountainInspected;
    }

    private void FountainInspected()
    {
        FinishQuestStep();
    }

    protected override void SetQuestStepState(string state)
    {

    }
}
