-> highpriestess_temple

=== highpriestess_temple ===
//{ InspectPaintingQuestState : 
//- "REQUIREMENTS_NOT_MET" : -> requirementsNotMet
//- "CAN_START" : -> canStart
//- "IN_PROGRESS" : -> inProgress
//- "CAN_FINISH" : -> canFinish
//- "FINISHED" : -> finished
//- else: -> END
//}

= requirementsNotMet
...
-> END

= canStart
Hello...
I'm glad you made it here safely...
It's a shame the Magician didn't chaperone you here...
...
You're lost... 
* [I forgot my name]
I see... That's alright... 
* [I don't know why I'm here]
* [I'm scared]
//~ StartQuest(InspectPaintingQuestId)
- -> DONE

= inProgress
-> END

= canFinish
-> END

= finished
-> END
