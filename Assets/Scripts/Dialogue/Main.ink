EXTERNAL StartQuest(questId)
EXTERNAL AdvanceQuest(questId)
EXTERNAL FinishQuest(questId)

VAR CollectCardsQuestId = "CollectCardsQuest"

VAR CollectCardsQuestState = "REQUIREMENTS_NOT_MET"

INCLUDE collect_cards_magician.ink
