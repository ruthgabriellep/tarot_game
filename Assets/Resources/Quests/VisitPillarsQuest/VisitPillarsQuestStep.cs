using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class VisitPillarsQuestStep : QuestStep
{

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        if (otherCollider.CompareTag("Player"))
        {
            FinishQuestStep();
        }
    }

    protected override void SetQuestStepState(string state)
    {
        
    }
    
}
