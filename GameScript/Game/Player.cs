namespace GameScript.Game;

public class Player
{
    /// <summary>
    /// Player initialisation
    /// </summary>
    public Player(bool isBot)
    {
        if (isBot)
        {
            Deck = new Deck();
            Hand = Deck.GetHand();
        }
        else
        {
            Deck = new Deck();
            Hand = Deck.GetHand();
        }
    }

    public List<Lenny> WinLennys{get; set;}

    public static class Lennys
    {
        
    }

    public Deck Deck { get; }

    public List<Card> Hand { get; set; }

    public void GetCard()
    {
        Hand.Add(Deck.Content[0]);
        Deck.Remove(Deck.Content[0]);
    }

    public void TakeNewCard(Card card)
    {
        Hand.Remove(card);
        GetCard();
    }

    private List<string> GetLennyValue()
    {
        List<string> value = new List<string>();
        foreach (var lenny in WinLennys)
        {
            value.Add(lenny.value);
        }

        return value;
    }
    public bool WinCondition()
    {
        List<string> unilen = GetLennyValue();
        string[] staticLenny = Lenny.Faces;
        for (int i = 0; i < 4; i++)
        {
            byte counter = 0;
            foreach (var obj in unilen.Where(obj => obj == staticLenny[i]))
            {
                counter++;
            }

            if (counter <= 1) continue;
            for(int j = 0;j<counter-1;j++)
            {
                unilen.Remove(staticLenny[i]);
            }
        }
        return unilen.Count == 3;
    }
}