namespace GameScript;

public static class DeckActions
{
    public static List<Card> CreateDeck()
    {
        byte[] colors = {0, 0, 0, 0};
        Random r = new Random();
        List<Card> deck = new List<Card>(30);
        foreach (string element in Card.ElementList)
        {
            for (byte power = 1; power < 12; power++)
            {
                string color = Card.ColorList[Array.IndexOf(colors,colors.Min())];
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
                }
                deck.Add(new Card(color,power,element));
            }
        }
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.Write($"GreenCount:{colors[0]},YellowCount:{colors[1]},RedCount:{colors[2]},BlueCount:{colors[3]}" + "\n");
        Console.ForegroundColor = ConsoleColor.Gray;
        return deck;
    }

    public static void ShowProps(List<Card> deck)
    {
        int counter=0;
        foreach (var x in deck)
        {
            Console.Write($"Color: {x.Color}, Power: {x.Power}, Element: {x.Element}" + "\n");
            counter++;
        }
        Console.WriteLine($"CardsInDeck: {counter}");
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