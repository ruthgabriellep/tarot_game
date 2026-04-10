using System;

public class MiscEvents
{
    public event Action onCardCollected;
    public void CardCollected() 
    {
        if (onCardCollected != null) 
        {
            onCardCollected();
        }
    }

    // public event Action onGemCollected;
    // public void GemCollected() 
    // {
    //     if (onGemCollected != null) 
    //     {
    //         onGemCollected();
    //     }
    // }
}
