namespace GameScript;

public class Card
{
    public static readonly string[] ElementList = { "Fire", "Water", "Snow" };
    public static readonly string[] ColorList = { "Red", "Green", "Blue","Yellow"};
    public string Element { get; set; }
    public string Color{ get; set; }
    
    public byte Power{ get; set; }

    public Card(string color, byte power, string element)
    {
        this.Color = color;
        this.Power = power;
        this.Element = element;
    }
}

