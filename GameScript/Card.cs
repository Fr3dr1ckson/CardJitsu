namespace GameScript;

public class Card
{

    public static readonly string[] ElementList =
    {
        "Fire", "Water", "Snow"
    };
    public static readonly string[] ElementListEmoji = {"🔥", "💧", "🕸️"};
    public static readonly string[] lenny = { "( ͡° ͜ʖ ͡°)", "( ͡♥ ͜ʖ ͡♥ )", "(▀̿Ĺ̯▀̿ ̿)", "(ᴗ ͜ʖ ᴗ)" };
    public string Element { get; }
    public string Color{ get; }
    public string Lenny { get; }
    public byte Power{ get;}

    public Card(string color, byte power, string element, string lenny)
    {
        this.Color = color;
        this.Power = power;
        this.Element = element;
        this.Lenny = lenny;
    }
}

