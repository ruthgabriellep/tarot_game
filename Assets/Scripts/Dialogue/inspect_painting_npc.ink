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

=== canStart ===
Young one, hello...
It brings me piece of mind that you are here safe and sound with the Magician's boat.
...
-> firstquestion
=== firstquestion ===
I'm sensing that you're lost... 
    * [I don't know who I am.]
        Oh, but that's something you have to discover for yourself, young one.
        That's why you were called here.
        -> firstquestion
    * [Why am I here and how do I get back?]
        The answer is beyond me, for this is only the beginning,
        but you already know that don't you?
        -> firstquestion
    * [What is this place?]
        A place where you aren't bound by spoken word or your flesh.
        -> firstquestion
    * [Can you help me?]
    The fountain can.
    ~ StartQuest(InspectPaintingQuestId)
        -> END

=== inProgress===
Gaze into the water and tell me what you notice...
-> END

=== canFinish===
What did you notice?
    * [There were stars in my hair.]
        Most look only at their faces. 
        -> canFinish
    * [The water rippled.]
        There is always stillness after the ripples.
        -> canFinish
    * [I could see my reflection but I looked different.]
        Different? But, you recognised yourself.
        
        -> canFinish
    * [That's it.]
    Like I said before, it is only the beginning.
    All you have to do is let the moment pass.
    Take the Magician's boat pass the mountains.
    Careful now, still waters run deep...
    ~ FinishQuest(InspectPaintingQuestId)
        -> END
        

=== finished===
You may not know the answers yet, but look within and believe what you see...
-> END
