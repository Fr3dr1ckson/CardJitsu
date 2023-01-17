namespace GameScript.Game;

public class Lenny
{
    public string value { get; set; }
    
    public string? element { get; set; }

    public static readonly string[] Faces =
    {
        "( ͡° ͜ʖ ͡°)", "( ͡♥ ͜ʖ ͡♥ )", "(▀̿Ĺ̯▀̿ ̿)", "(ᴗ ͜ʖ ᴗ)"
    };

    public static int FacesCount = Faces.Length;
    public char this[int index] => value[index];

    public Lenny(int number)
    {
        if (number < Faces.Length)
            value = Faces[number];
    }
}