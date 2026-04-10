
// namespace Resources.Quests.CollectCardsQuest
// {
    public class CollectCardsQuestStep : QuestStep
    {
        private int cardsCollected = 0;

        private int cardsToComplete = 1;

        private void OnEnable()
        {
            GameEventsManager.instance.miscEvents.onCardCollected += CardCollected;
        }

        private void OnDisable()
        {
            GameEventsManager.instance.miscEvents.onCardCollected -= CardCollected;
        }

        private void CardCollected()
        {
            if (cardsCollected < cardsToComplete)
            {
                cardsCollected++;
                UpdateState();
            }

            if (cardsCollected >= cardsToComplete)
            {
                FinishQuestStep();
            }
        }

        private void UpdateState()
        {
            string state = cardsCollected.ToString();
            ChangeState(state);
        }

        protected override void SetQuestStepState(string state)
        {
            this.cardsCollected = System.Int32.Parse(state);
            UpdateState();
        }
    }
// }
