=== highpriestess_temple ===
{ InspectPaintingQuestState : 
- "REQUIREMENTS_NOT_MET" : -> requirementsNotMet
- "CAN_START" : -> canStart
- "IN_PROGRESS" : -> inProgress
- "CAN_FINISH" : -> canFinish
- "FINISHED" : -> finished
- else: -> END
}

= requirementsNotMet
...
-> END

= canStart
Hello...
I'm glad you made it here safely... 
...
You're lost... 
* [I forgot my name]
That's alright... You don't need it here. 
* [I don't know why I'm here]
I don't have the answer for that, but 
* [I'm scared]
Oh, child, do not fear.
~ StartQuest(InspectPaintingQuestId)
- -> DONE

= inProgress
You may not know the answers yet, but look within and believe what you see...
-> END

= canFinish
Tell me... did anything stick out to you?
*[A butterfly struggling to escape its chrysalis]
I see... so you believe the butterfly 
-> END
*[A butterfly readily emerging from its chrysalis]
-> END
*[My reflection]
~ FinishQuest(InspectPaintingQuestId)
-> END

= finished
Once you pass the islands, the water won't be so forgiving. 
-> END
