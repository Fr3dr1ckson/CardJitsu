using System.Text;
using GameScript.Useful_Functions;

namespace GameScript.Game;

public class GameScreens
{
    public static void EndBox()
    {
        int boxsize = 120;
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.DarkBlue;
        string boxTop = new string('_', boxsize);
        string boxBot = new string('-', boxsize);
        StringBuilder borders = new StringBuilder(new string(' ', boxsize), boxsize)
        {
            [0] = '|',
            [boxsize - 1] = '|'
        };
        string centreblank = new string(' ', 60);
        for (int i = 0; i < 20; i++)
        {
            Console.WriteLine();
        }

        string press = "Want to Restart Game?";
        Console.Write($"{centreblank}{boxTop}");
        CConsole.WriteLine(
            $"{new string(' ', 117)}|{new string(' ', boxsize / 2 - 3)}    {new string(' ', boxsize / 2 - 3)}|");
        for (int i = 0; i < 14; i++)
        {
            switch (i)
            {
                case 6:
                    CConsole.WriteLine(
                        $"{centreblank}|{new string(' ', boxsize / 3 + 8)}{press:green}{new string(' ', boxsize - press.Length - boxsize / 3 - 10)}|");
                    break;
                case 8:
                case 12:
                    CConsole.WriteLine(
                        $"{centreblank}|{new string(' ', 5)}{new string('-', 11)}{new string(' ', boxsize - 35)}{new string('-', 12)}{new string(' ', 5)}|");
                    break;
                case 9:
                case 11:   
                    CConsole.WriteLine(
                        $"{centreblank}|{new string(' ', 4)}| {new string(' ', 9)} |{new string(' ', boxsize - 37)}| {new string(' ', 10)} |{new string(' ', 4)}|");
                    break;
                case 10:
                    CConsole.WriteLine(
                        $"{centreblank}|{new string(' ', 4)}| {"Yes":white} {"  E  ":darkgray} |{new string(' ', boxsize - 37)}| {"No":white} {"Any_Key":darkgray} |{new string(' ', 4)}|");
                    break;
                default:
                    Console.WriteLine($"{centreblank}{borders}");
                    break;
            }
        }
        Console.WriteLine($"{centreblank}{boxBot}");
        Console.ResetColor();
    }
    public static void OutputBox(bool winner)
    {
        int boxsize = 120;
        Console.Clear();
        if (winner)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            string boxTop = new string('_', boxsize);
            string boxBot = new string('-', boxsize);
            StringBuilder borders = new StringBuilder(new string(' ', boxsize), boxsize)
            {
                [0] = '|',
                [boxsize - 1] = '|'
            };
            string centreblank = new string(' ', 60);
            for (int i = 0; i < 20; i++)
            {
                Console.WriteLine();
            }

            string press = "You Win!";
            Console.WriteLine($"{centreblank}{boxTop}");
            CConsole.WriteLine(
                $"{centreblank}|{new string(' ', boxsize / 2 + 1)}{new string(' ', boxsize / 2 - 3)}|");
            for (int i = 0; i < 14; i++)
            {
                if (i is 6)
                {
                    CConsole.WriteLine(
                        $"{centreblank}|{new string(' ', boxsize / 3 + 13)}{press:yellow}{new string(' ', boxsize - press.Length - boxsize / 3 - 15)}|");
                }
                else
                    Console.WriteLine($"{centreblank}{borders}");
            }

            Console.WriteLine($"{centreblank}{boxBot}");
            Console.ResetColor();
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            string boxTop = new string('_', boxsize);
            string boxBot = new string('-', boxsize);
            StringBuilder borders = new StringBuilder(new string(' ', boxsize), boxsize)
            {
                [0] = '|',
                [boxsize - 1] = '|'
            };
            string centreblank = new string(' ', 60);
            for (int i = 0; i < 20; i++)
            {
                Console.WriteLine();
            }

            string press = "You lost";
            Console.WriteLine($"{centreblank}{boxTop}");
            CConsole.WriteLine(
                $"{centreblank}|{new string(' ', boxsize / 2 + 1)}{new string(' ', boxsize / 2 - 3)}|");
            for (int i = 0; i < 14; i++)
            {
                if (i is 8)
                {
                    CConsole.WriteLine(
                        $"{centreblank}|{new string(' ', boxsize / 3 + 13)}{press:red}{new string(' ', boxsize - press.Length - boxsize / 3 - 15)}|");
                }
                else
                    Console.WriteLine($"{centreblank}{borders}");
            }

            Console.WriteLine($"{centreblank}{boxBot}");
            Console.ResetColor();
        }
    }
    public static void FuncBox()
    {
        int boxsize = 120;
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Green;
        string boxTop = new string('_', boxsize);
        string boxBot = new string('-', boxsize);
        StringBuilder borders = new StringBuilder(new string(' ', boxsize), boxsize)
        {
            [0] = '|',
            [boxsize - 1] = '|'
        };
        string centreblank = new string(' ', 60);
        for (int i = 0; i < 20; i++)
        {
            Console.WriteLine();
        }

        string[] press =
        {
            "1: Press E, to check card fights",
            "2: Press R, to return"
        };
        Console.WriteLine($"{centreblank}{boxTop}");
        Console.WriteLine($"{centreblank}{borders}");
        CConsole.WriteLine(
            $"{centreblank}|{new string(' ', boxsize / 2 - 3)}{"Debug":red}{new string(' ', boxsize / 2 - 4)}|");
        for (int i = 0; i < 11+press.Length; i++)
        {
            if (i >= 4 && i%2==0 && i<3+press.Length*2)
            {
                CConsole.WriteLine(
                    $"{centreblank}|{new string(' ', boxsize / 3 + 3)}{press[(i - 4) / 2]:magenta}{new string(' ', boxsize - press[(i - 4) / 2].Length - boxsize / 3 - 5)}|");
            }
            else
                Console.WriteLine($"{centreblank}{borders}");
        }

        Console.WriteLine($"{centreblank}{boxBot}");
        Console.ResetColor();
    }
    public static void OutputBox()
    {
        int boxsize = 120;
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.DarkBlue;
        string boxTop = new string('_', boxsize);
        string boxBot = new string('-', boxsize);
        StringBuilder borders = new StringBuilder(new string(' ', boxsize), boxsize)
        {
            [0] = '|',
            [boxsize - 1] = '|'
        };
        string centreblank = new string(' ', 60);
        for (int i = 0; i < 20; i++)
        {
            Console.WriteLine();
        }

        string[] press =
        {
            "1: Press E, to check your hand",
            "2: Press Tab, to change difficulty",
            "3: Press Q, to get fight history",
            "4: Press Esc, to quit"
        };
        Console.WriteLine($"{centreblank}{boxTop}");
        Console.WriteLine($"{centreblank}{borders}");
        CConsole.WriteLine(
            $"{centreblank}|{new string(' ', boxsize / 2 - 3)}{"Menu":green}{new string(' ', boxsize / 2 - 3)}|");
        for (int i = 0; i < 11+press.Length; i++)
        {
            if (i >= 4 && i%2==0 && i<3+press.Length*2)
            {
                CConsole.WriteLine(
                    $"{centreblank}|{new string(' ', boxsize / 3 + 3)}{press[(i - 4) / 2]:green}{new string(' ', boxsize - press[(i - 4) / 2].Length - boxsize / 3 - 5)}|");
            }
            else
                Console.WriteLine($"{centreblank}{borders}");
        }

        Console.WriteLine($"{centreblank}{boxBot}");
        Console.ResetColor();
    }

    public static void Start()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Title = "Card Jitsu";
        Console.Write($"Welcome to the Card Jitsu!\n");
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
    
        CConsole.Write($"\n\u2022 {"Fire":red} beats {"Snow":white}\n");
        CConsole.Write($"\u2022 {"Water":cyan} beats {"Fire":red}\n");
        CConsole.Write($"\u2022 {"Snow":white} beats {"Water":cyan}\n");
        Console.Write('\n' +
                      "However, in the event of similar types of cards being played, the card with the highest number will win. If the numbers also matched, a draw will happen." +
                      '\n' +
                      "If you want to start, press \"Enter\"");

    }

/*
    private static void CheatBox()
    {
        int boxsize = 120;
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        string boxTop = new string('_', boxsize);
        string boxBot = new string('-', boxsize);
        StringBuilder borders = new StringBuilder(new string(' ', boxsize), boxsize)
        {
            [0] = '|',
            [boxsize - 1] = '|'
        };
        string centreblank = new string(' ', 60);
        for (int i = 0; i < 20; i++)
        {
            Console.WriteLine();
        }

        string[] press =
        {
            "1: Press E, to check your hand",
            "2: Press Tab, to change difficulty",
            "3: Press Q, to get fight history",
            "4: Press L, to quit"
        };
        Console.WriteLine($"{centreblank}{boxTop}");
        Console.WriteLine($"{centreblank}{borders}");
        CConsole.WriteLine(
            $"{centreblank}|{new string(' ', boxsize / 2 - 3)}{"Cheatbox":darkblue}{new string(' ', boxsize / 2 - 3)}|");
        for (int i = 0; i < 11+press.Length; i++)
        {
            if (i >= 4 && i%2==0 && i<3+press.Length*2)
            {
                CConsole.WriteLine(
                    $"{centreblank}|{new string(' ', boxsize / 3 + 3)}{press[(i - 4) / 2]:green}{new string(' ', boxsize - press[(i - 4) / 2].Length - boxsize / 3 - 5)}|");
            }
            else
                Console.WriteLine($"{centreblank}{borders}");
        }

        Console.WriteLine($"{centreblank}{boxBot}");
        Console.ResetColor();
    }
*/

}