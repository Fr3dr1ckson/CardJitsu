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
            int randomNum = r.Next(start, end);
            if (exclude.Contains(randomNum)) continue;
            return randomNum;
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
        return hand.Any(botCard => CompareCards(card,botCard) && !SameCards(card,botCard));
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