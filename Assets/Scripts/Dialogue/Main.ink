EXTERNAL StartQuest(questId)
EXTERNAL AdvanceQuest(questId)
EXTERNAL FinishQuest(questId)

VAR CollectCardsQuestId = "CollectCardsQuest"
VAR CollectCardsQuestState = "REQUIREMENTS_NOT_MET"

VAR InspectPaintingQuestId = "InspectPaintingQuest"
VAR InspectPaintingQuestState = "REQUIREMENTS_NOT_MET"

INCLUDE collect_cards_magician.ink

INCLUDE inspect_painting_npc.ink

=== broken_boat ===
There's a hole in the side of the boat.
-> END

=== repaired_boat ===
The boat is ready to sail!
-> END