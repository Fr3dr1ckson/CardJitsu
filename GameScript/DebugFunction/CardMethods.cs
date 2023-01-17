using GameScript.Game;

namespace GameScript.DebugFunction;

public class CardMethods
{
    public static Card CreateCard()
    {
        string element = " ";
        string lenny = " ";
        Console.Write("Enter card power: ");
        int power = int.Parse(Console.ReadLine());
        Console.WriteLine('\n' + "Chose card lenny: " + '\n' +
                          $"1: {Lenny.Faces[0]}\n" +$"2: {Lenny.Faces[1]}\n"+$"3: {Lenny.Faces[2]}\n"+$"4: {Lenny.Faces[3]}");
        ConsoleKey keypress = Console.ReadKey().Key;
        lenny = keypress switch
        {
            ConsoleKey.D1 => Lenny.Faces[0],
            ConsoleKey.D2 => Lenny.Faces[1],
            ConsoleKey.D3 => Lenny.Faces[2],
            ConsoleKey.D4 => Lenny.Faces[3],
            _ => lenny
        };
        Console.WriteLine('\n' + "Chose card element: " + '\n' +
                          $"1: {Card.ElementList[0]}\n" +$"2: {Card.ElementList[1]}\n"+$"3: {Card.ElementList[2]}");
        keypress = Console.ReadKey().Key;
        element = keypress switch
        {
            ConsoleKey.D1 => Card.ElementList[0],
            ConsoleKey.D2 => Card.ElementList[1],
            ConsoleKey.D3 => Card.ElementList[2],
            _ => lenny
        };
        return new Card(power, element, lenny);
    }
}