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
Hello, young one...
I see you fixed the Magician's boat...
I'm glad you made it here safely... 
...
I can sense that you're lost... 
    * [I don't know who I am.]
        Some things you have to learn yourself...
        Isn't that why you're here?
        -> canStart
    * [Why am I here and how do I get back?]
        I'm afraid I don't have the answer for that, but this is just the beginning of your journey... 
        -> canStart
    * [What is this place?]
        Here, you aren't bound by language or the physical body...
        ~ StartQuest(InspectPaintingQuestId)
        -> canStart
    * [Can you help me?]
    
        -> END

= inProgress
You may not know the answers yet, but look within and believe what you see...
Gaze into the water and tell me what you notice...
-> END

= canFinish
What did you notice?
    * [I saw myself becoming part of the sky. There were stars in my hair.]
        Most look only at their faces... 
        -> canFinish
    * [The water rippled.]
        There is always stillness after the ripples.
        -> canFinish
    * [I could see my reflection but I looked different.]
        It looked like you, didn't it?
        -> canFinish
    * [That's it.]
    This is just the beginning of your journey...
    It may seem uncertain now, but clarity will land...

    ~ FinishQuest(InspectPaintingQuestId)
        -> END
        

= finished
Once you pass the islands, the water won't be so forgiving. 
-> END
