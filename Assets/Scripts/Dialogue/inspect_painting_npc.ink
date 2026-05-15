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
    You can look into the fountain for answers(?)
        -> END

= inProgress
You may not know the answers yet, but look within and believe what you see...
Gaze into the water and tell me what you notice...
-> END

= canFinish
What did you notice?
    * [I saw myself becoming part of the sky. There were stars in my hair.]
        Most look only at their faces... 
        At the tangible...
        -> canFinish
    * [The water rippled.]
        There is always stillness after the ripples.
        -> canFinish
    * [I could see my reflection but I looked different.]
        It looked like you, didn't it?
        
        -> canFinish
    * [That's it.]
    This is just the beginning of your journey...
    It may seem uncertain now, but everything will fall into place...
    Continue your journey...
    Your boat will take you to the other side of the coast...
    Be careful... the water can turn crayzay
    ~ FinishQuest(InspectPaintingQuestId)
        -> END
        

= finished
-> END
