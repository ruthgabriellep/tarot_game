=== Magician_Start ===
{ CollectCardsQuestState : 
- "REQUIREMENTS_NOT_MET" : -> requirementsNotMet
- "CAN_START" : -> canStart
- "IN_PROGRESS" : -> inProgress
- "CAN_FINISH" : -> canFinish
- "FINISHED" : -> finished
- else: -> END
}

= requirementsNotMet
Who might you be?
Don't you know it's rude not to knock?
-> END

= canStart
Who might you be?
Don't you know it's rude not to knock?
* [Nod]
I suppose you were just following that dog. 
~ StartQuest(CollectCardsQuestId)
-> answer
* [...]
Alright then...
~ StartQuest(CollectCardsQuestId)
-> answer

= inProgress
Found the card yet?
I'm sure it's around here somewhere.
Unless I left it at... Nevermind.
-> END

= canFinish
Ha! You found it.
I was looking high and low for that thing.
Thanks, kid. You're one smart cookie.
And as promised, you can keep it.
...
I know, I know, no need to thank me.
~ FinishQuest(CollectCardsQuestId)
-> END

= finished
Uh... Did you wanna help me with something else?
You've done everything I need, so you can be on your way.
Maybe try next door. 
That one's always so mysterious... 
-> END

=== answer ===
Cat got your tongue? 
Since you're here, why not do me a favour?
I need you to find something for me.
I lost my Magician card somewhere in this room.
I think I last saw it on my bookshelf. 
And to express my gratitude,
once you find it, you can keep it. 
- -> END


