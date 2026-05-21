=== Magician_Start ===
{ CollectCardsQuestState : 
- "REQUIREMENTS_NOT_MET" : -> requirementsNotMetM
- "CAN_START" : -> canStartM
- "IN_PROGRESS" : -> inProgressM
- "CAN_FINISH" : -> canFinishM
- "FINISHED" : -> finishedM
- else: -> END
}

= requirementsNotMetM
...
-> END

= canStartM
Don't you know it's rude not to knock?
Hm...
And who might you be?
I do suppose you were just following that dog... 
...
Let me introduce myself. I, am the oh-so-great Magician... But I bet you already knew that, didn't you?
The Whimsy, Will, and Wonder Show isn't scheduled for today, yellow boots.
...
Your name?
    * [...]
        ... I guess that's not important.
    * [*Shake head*]
        Not telling me?
        
    - Well, since you're here... why don't you do me a favour?
    I need you to find something for me.
    My Magician card. 
    I seem to have misplaced it somewhere in this room.
    The stage is where I last saw it.
    That I'm sure of.
    Straight back to me once you've found it.
~ StartQuest(CollectCardsQuestId)
-> END


= inProgressM
Found the card yet?
I'm sure it's around here somewhere...
Unless- never mind.
-> END

= canFinishM
You found it. I'm impressed.
I've been looking high and low for that card of mine.
Thanks a lot, yellow boots.
And as a token of my gratitude, you get to keep it.
Pleased?
...
Still around?
...I do have another friend who might be in need of assistance.
Try next door. 
Not much for conversation, that one. Always so mysterious.
You need to get to the beach and I have a boat. If you're fine using a sinking ship that is.
You'll probably find some scrap laying in the sand.
It'll be useful.
Well, run along now. Best not keep them waiting.
~ FinishQuest(CollectCardsQuestId)
-> END

= finishedM
Go on now, yellow boots.
-> END



