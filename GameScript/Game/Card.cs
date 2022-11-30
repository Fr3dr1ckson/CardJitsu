using GameScript.Useful_Functions;

namespace GameScript.Game;

public class Card
{
    public static readonly string[] ElementList =
    {
        "Fire", "Water", "Snow"
    };
    public static readonly string[] ElementListEmoji =
    {
        "🔥", "💧", "🕸️"
    };
    public static readonly string[] lenny =
    {
        "( ͡° ͜ʖ ͡°)", "( ͡♥ ͜ʖ ͡♥ )", "(▀̿Ĺ̯▀̿ ̿)", "(ᴗ ͜ʖ ᴗ)"
    };
    public string Element { get;}
    public string Lenny { get;}
    public int Power{ get;}

    public Card(int power, string element, string lenny)
    {
        Power = power;
        Element = element;
        Lenny = lenny;
    }
    private static List<Card> GenerateLib()
    {
        List<Card> deck = new List<Card>();
        string[] elementList = PowerShellUtils.IsCurrentProcessRunningFromPowerShellIse() ? ElementListEmoji : ElementList;
        foreach (string element in elementList)
        {
            foreach (string lenny in lenny)
            {
                for (int power = 1; power < 11; power++)
                {
                    deck.Add(new Card(power, element, lenny));
                }
            }
        }
        return deck;
    }

    public static readonly List<Card> CardLib = GenerateLib();
}

