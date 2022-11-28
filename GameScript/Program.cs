using System.Diagnostics;
using GameScript;
using System.Diagnostics.PerformanceData;
using System.Runtime.InteropServices;
using System.Text;

#region StartText




Console.OutputEncoding = System.Text.Encoding.UTF8;
Console.ForegroundColor = ConsoleColor.Green;
Console.Title = "Card Jitsu";
Console.Write("Welcome to the Card Jitsu!");
Console.WriteLine();
              Console.ForegroundColor = ConsoleColor.Gray;
Console.WriteLine('\n' +
                  "It's the game, where you can show how lucky and smart you are by chosing the right card in the right moment" +
                  '\n' + '\n' +
                  "The objective of the game is to beat opponents by collecting sets of winning Card-Jitsu cards." +
                  '\n' +
                  "Only certain cards will beat others, via the form of Rock, Paper, Scissors." + '\n' +
                  "Once players have an opponent, they will be taken to the arena, and will bow to each other. Both players have 20 seconds to choose a card. If they fail to choose a card, one will automatically be selected when the timer reaches zero" +
                  '\n' +
                  "Once both players have chosen a card, they are revealed. The winner keeps the card to help make a set. Remember that:");
Console.Write('\u2022');
Console.ForegroundColor = ConsoleColor.Red;
Console.Write(" 🔥Fire🔥");
Console.ForegroundColor = ConsoleColor.Gray;
Console.Write(" beats");
Console.ForegroundColor = ConsoleColor.White;
Console.Write(" 🕸️Snow🕸️ " + '\n');
Console.ForegroundColor = ConsoleColor.Gray;
Console.Write('\u2022');
Console.ForegroundColor = ConsoleColor.White;
Console.Write(" 🕸️Snow🕸️");
Console.ForegroundColor = ConsoleColor.Gray;
Console.Write(" beats");
Console.ForegroundColor = ConsoleColor.DarkBlue;
Console.Write(" 💧Water💧" + '\n');
Console.ForegroundColor = ConsoleColor.Gray;
Console.Write('\u2022');
Console.ForegroundColor = ConsoleColor.DarkBlue;
Console.Write(" 💧Water💧");
Console.ForegroundColor = ConsoleColor.Gray;
Console.Write(" beats");
Console.ForegroundColor = ConsoleColor.Red;
Console.Write(" 🔥Fire🔥" + '\n');
Console.ResetColor();
Console.Write('\n' +
                  "However, in the event of similar types of cards being played, the card with the highest number will win. If the numbers also matched, a draw will happen." + '\n' +
                  "If you want to start, press \"Enter\"");
#endregion
if (Console.ReadKey().Key == ConsoleKey.Enter)
{
    
    byte fire = 0, ice = 0, water = 0;
    var r = new Random();
    List<Card> deckP1 = DeckActions.CreateDeck();
    DeckActions.Shuffle(deckP1);
    foreach (var x in deckP1)
    {
        Console.WriteLine(deckP1.Count);
        if (x.Element == "Fire")
            fire++;
        else if (x.Element == "Water")
            water++;
        else
            ice++;
        GameProcess.ShowCardinHand(x);
    }
    var handP1 = GameProcess.GetHand(deckP1);
    List<Card> deckP2 = DeckActions.CreateDeck();
    DeckActions.Shuffle(deckP2);
    var handP2 = GameProcess.GetHand(deckP2);
    for(int i = 0;i<6;i++)
    {
        GameProcess.ShowFullHandCringe(handP1);
        Console.WriteLine($"Size: {handP1.Count}");
        handP1.Remove(handP1[r.Next(0, handP1.Count - 1)]); 
        GameProcess.ShowCardinHand(deckP1[0]);
        GameProcess.GetCardFromDeck(deckP1,handP1);
    }
    
    Console.WriteLine($"Fire: {fire}, Ice: {ice}, Water: {water}");
    //GameProcess.ShowCardinHand(deckP1[0]);
    //GameProcess.ShowFullHandCringe(deckP1);
    //GameProcess.ShowFullHand(deckP1);
    Console.ReadKey();
}       
public class PowerShellUtils
    {
        public static bool IsCurrentProcessRunningFromPowerShellIse()
        {
            var processList = new uint[1];
            var count = GetConsoleProcessList(processList, 1);
            if (count <= 0)
            {
                return false;
            }

            processList = new uint[count];
            count = GetConsoleProcessList(processList, (uint)processList.Length);
            for (var pid = 0; pid < count; pid++)
            {
                var buffer = new StringBuilder(260);
                var dwSize = (uint) buffer.Capacity;

                var process = OpenProcess(PROCESS_QUERY_LIMITED_INFORMATION, false, (int) processList[pid]);
                QueryFullProcessImageName(process, 0, buffer, ref dwSize);

                var exeFileName = buffer.ToString(0, (int) dwSize);

                // Name of EXE is PowerShell_ISE.exe or powershell.exe
                if (exeFileName.IndexOf("PowerShell_ISE.exe", StringComparison.OrdinalIgnoreCase) != -1 ||
                    exeFileName.IndexOf("powershell.exe", StringComparison.OrdinalIgnoreCase) != -1)
                {
                    return true;
                }
            }

            return false;
        }

        [DllImport("kernel32.dll", ExactSpelling=true, EntryPoint="QueryFullProcessImageNameW", CharSet = CharSet.Unicode)]
        internal static extern bool QueryFullProcessImageName(IntPtr hProcess, uint dwFlags, StringBuilder lpExeName, ref uint lpdwSize);

        [DllImport("kernel32.dll", ExactSpelling=true)]
        internal static extern IntPtr OpenProcess(uint dwDesiredAccess, bool bInheritHandle, int dwProcessId);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern uint GetConsoleProcessList(uint[] processList, uint processCount);

        // ReSharper disable InconsistentNaming
        internal const uint PROCESS_QUERY_LIMITED_INFORMATION = 0x1000;
        // ReSharper restore InconsistentNaming
    }        