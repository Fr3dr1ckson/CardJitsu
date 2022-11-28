namespace GameScript;

public static class DeckActions
{
    public static List<Card> CreateDeck()
    {
        byte[] lennys = { 0, 0, 0, 0 };
        Random r = new Random();
        List<Card> deck = new List<Card>(30);
        string[] elementList;
        if (PowerShellUtils.IsCurrentProcessRunningFromPowerShellIse())
        {
            elementList = Card.ElementListEmoji;
        }
        else
        {
            elementList = Card.ElementList;
        }
        foreach (string element in elementList)
        {
            for (byte power = 1; power < 11; power++)
            {
                /*string color = Card.ColorList[Array.IndexOf(colors,colors.Min())];
                switch (color)
                {
                    case "Red":
                        colors[0]++;
                        break;
                    case "Green":
                        colors[1]++;
                        break;
                    case "Blue":
                        colors[2]++;
                        break;
                    default:
                        colors[3]++;
                        break;
                }*/
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
                deck.Add(new Card("color", power, element, lenny));
                Console.WriteLine(power);
            }
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write($"GreenCount:{lennys[0]},YellowCount:{lennys[1]},RedCount:{lennys[2]},BlueCount:{lennys[3]}" +
                          "\n");
            Console.ForegroundColor = ConsoleColor.Gray;
            
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