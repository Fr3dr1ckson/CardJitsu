
using System.Runtime.InteropServices;

namespace GameScript.Game;

public class Deck
{
    public Deck()
    {
        FillDefault();
        Size = Content.Count;
    }
    public Card this[int index]
    {
        get => Content[index];
        set => Content[index] = value;
    }

    public bool Contains(Card card)
    {
        return Content.Any(element => ExtendedFunc.SameCards(element, card));
    }
    private void FillDefault()
    {
        byte[] lennys = { 0, 0, 0, 0 };
        Random r = new Random();
        string[] elementList = Card.ElementList;
        foreach (string element in elementList)
        {
            int[] excludedPower = new int[10];
            for (int power = 1; power < 11; power++)
            {
                string lenny = Lenny.Faces[Array.IndexOf(lennys, lennys.Min())];
                switch (lenny)
                {
                    case "( ͡° ͜ʖ ͡°)":
                        lennys[0]++;
                        break;
                    case "( ͡♥ ͜ʖ ͡♥ )":
                        lennys[1]++;
                        break;
                    case "(▀̿Ĺ̯▀̿ ̿)":
                        lennys[2]++;
                        break;
                    default:
                        lennys[3]++;
                        break;
                }
                int getRand = ExtendedFunc.ControllableRandom(r, 1, 11, excludedPower);
                excludedPower[power-1] = getRand;
                Content.Add(new Card(getRand, element, lenny));
            }
        }
    }

    private void Fill1()
    {
        Random r = new Random();
        foreach (string element in Card.ElementList)
        {
            int[] excludedPower = new int[10];
            for (int power = 1; power < 13; power++)
            {
                string lenny = Lenny.Faces[r.Next(0,4)];
                int getRand = ExtendedFunc.ControllableRandom(r, 1, 11, excludedPower);
                excludedPower[power-1] = getRand;
                Content.Add(power > 10
                    ? new Card(getRand, element, lenny, r.Next(1, Card.AbilitiesLength()))
                    : new Card(getRand, element, lenny));
            }
        }
    }
    private int Size { get; }
    
    public List<Card> GetHand()
    {
        var hand = new List<Card>(6);
        for (int card = 0; card < 6; card++)
        {
            hand.Add(Content[card]);
            hand.Remove(Content[card]);
        }
        return hand;
    }
    
    public void Remove(Card card)
    {
        Content.Remove(card);
    }
    public List<Card> Content { get; private set; } 
    public void Shuffle()
    {
        var deck = this;
        var random = new Random();
        for (int i = 0; i < deck.Size; i++)
        {
            var randomValue = random.Next(0, deck.Size - 1);
            (Content[i], Content[randomValue]) = (Content[randomValue], Content[i]);
        }
    }
}