using GameScript.Useful_Functions;

namespace GameScript.Game;

public static class DeckActions
{
    public static List<Card> CreateDeck()
    {
        byte[] lennys = { 0, 0, 0, 0 };
        Random r = new Random();
        List<Card> deck = new List<Card>(30);
        string[] elementList = PowerShellUtils.IsCurrentProcessRunningFromPowerShellIse() ? Card.ElementListEmoji : Card.ElementList;
        foreach (string element in elementList)
        {
            int[] controlpow = new int[10];
            for (int power = 1; power < 11; power++)
            {
                string lenny = Card.lenny[Array.IndexOf(lennys, lennys.Min())];
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
                int getrand = ExtendedFunc.ControllableRandom(r, 1, 11, controlpow);
                controlpow[power-1] = getrand;
                deck.Add(new Card(getrand, element, lenny));
            }
            
        }
        return deck;
    }
    public static void Shuffle(List<Card> deck)
    {
        var random = new Random();
        for (int i = 0; i < deck.Count; i++)
        {
            var randomValue = random.Next(0, deck.Count - 1);
            (deck[i], deck[randomValue]) = (deck[randomValue], deck[i]);
        }
    }
}