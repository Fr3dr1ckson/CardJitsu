using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using GameScript.Game;
using static GameScript.Game.GameProcesses;
namespace GameScript;

public static class ExtendedFunc
{
    public static int ControllableRandom(Random r, int start, int end, int[] exclude)
    {
        while (true)
        {
            int randomint = r.Next(start, end);
            if (exclude.Contains(randomint)) continue;
            return randomint;
        }
    }
    public static bool SameCards(Card card1,Card card2)
    {
        return card1.Element == card2.Element && card1.Power == card2.Power && card1.Lenny == card2.Lenny;
    }

    public static bool DeckContains(List<Card> deck, Card card)
    {
        return deck.Any(element => SameCards(element, card));
    }
    public static bool HaveWinningCard(List<Card> hand, Card card)
    {
        return hand.Any(botcard => CompareCards(card,botcard) && !SameCards(card,botcard));
    }

    public static Card CreateCard()
    {
        string element = " ";
        string lenny = " ";
        Console.Write("Enter card power: ");
        int power = int.Parse(Console.ReadLine());
        Console.WriteLine('\n' + "Chose card lenny: " + '\n' +
                          $"1: {Card.lenny[0]}\n" +$"2: {Card.lenny[1]}\n"+$"3: {Card.lenny[2]}\n"+$"4: {Card.lenny[3]}");
        ConsoleKey keypress = Console.ReadKey().Key;
        lenny = keypress switch
        {
            ConsoleKey.D1 => Card.lenny[0],
            ConsoleKey.D2 => Card.lenny[1],
            ConsoleKey.D3 => Card.lenny[2],
            ConsoleKey.D4 => Card.lenny[3],
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

    public static int UniqueLenny(List<string> lennys)
    {
        List<string> unilen = lennys;
        string[] staticLenny = Card.lenny;
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
        return unilen.Count;
    }
    public class Program1
    {
        [DllImport("kernel32.dll", ExactSpelling = true)]
        private static extern IntPtr GetConsoleWindow();

        public static IntPtr ThisConsole = GetConsoleWindow();

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        public const int HIDE = 0;
        public const int MAXIMIZE = 3;
        private const int MINIMIZE = 6;
        private const int RESTORE = 9;

    }
}