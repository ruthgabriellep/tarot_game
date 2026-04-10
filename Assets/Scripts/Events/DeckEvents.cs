using System;

public class DeckEvents
{
    public event Action<int> onDeckGained;

    public void DeckGained(int deck)
    {
        if (onDeckGained != null)
        {
            onDeckGained(deck);
        }
    }

    public event Action<int> onDeckChange;

    public void DeckChange(int deck)
    {
        if (onDeckChange != null)
        {
            onDeckChange(deck);
        }
    }
}