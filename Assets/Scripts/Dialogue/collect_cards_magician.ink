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
...
-> END

= canStart
Don't you know it's rude not to knock?
Oh! Uh... 
Who might you be?
I suppose you were just following that dog... 
Anyway, you probably already knew, but I am the oh-so-great Magician!
And I hate to be the bearer of bad news, but the Whimsy, Will, and Wonder show isn't scheduled for today, kid.
...
You've got a name, right?
* [Shrug]
So you don't have a name?
... I guess you're not much of a talker.
Cat got your tongue?
And since you're here, why not do me a favour?
I need you to find something for me.
-> answer
* [...]
Alright then...
Cat got your tongue?
And since you're here, why not do me a favour?
I need you to find something for me.
-> answer

= inProgress
Found the card yet?
I'm sure it's around here somewhere.
Unless I left it at- never mind.
-> END

= canFinish
Ha! You found it.
I've been looking high and low for that thing.
Thanks, kid. You're one smart cookie.
And as promised, you can keep it.
...
I know, I know- no need to thank me.
~ FinishQuest(CollectCardsQuestId)
-> END

= finished
Uh... Did you want to help me with something else?
Maybe try next door. 
Not much for conversation, that one… always so mysterious.
You'll have to find your own way to get there. 
The water's unpredictable - my boat broke but I haven't been bothered to fix it yet.
So, unless you manage to fix her up, I guess you can't get over there, kid.

-> END

=== answer ===
My Magician card - I seem to have misplaced it somewhere in this room.
I think I last saw it on my bookshelf. 
And to express my gratitude,
you can keep it once you find it.
~ StartQuest(CollectCardsQuestId)

- -> END


