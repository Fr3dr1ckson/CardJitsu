using System.Text;

namespace GameScript;

public static class GameProcesses
{
    public static List<Card> GetHand(List<Card> deck)
    {
        List<Card> hand = new List<Card>(6);
        for (int card = 0; card < 6; card++)
        {
            hand.Add(deck[card]);
            deck.Remove(deck[card]);
        }

        return hand;
    }


    public static Card PlayerTurn(List<Card> hand,
        List<List<Card>> cardhistory, List<string[]> lennyelementP1, List<string[]> lennyelementP2, int diff, out int diff2)
    {
        diff2 = diff;
        while (true)
        {
            OutputBox();
            ConsoleKey pressedKey = Console.ReadKey().Key;
            switch (pressedKey)
            {
                case ConsoleKey.E: //Hand Showcase
                {
                    bool[] ifinside = { true, true };
                    while (ifinside[0])
                    {
                        Console.Clear();
                        ShowCards(hand);
                        Console.WriteLine('\n' + "Press R, to return"
                                               + " or choose one of your card to play. You can see numbers below the cards");
                        Console.WriteLine("\n");
                        Console.Write("Your lennys:");
                        Console.WriteLine();
                        if (lennyelementP1.Count > 0)
                        {
                            foreach (var fire in lennyelementP1.Where(fire => fire[1] != null && fire[1] == "Fire"))
                            {
                                CConsole.Write($"{fire[0]:red}\t");
                            }
                            Console.WriteLine("\n");
                            foreach (var water in lennyelementP1.Where(water => water[1] != null && water[1] == "Water"))
                            {
                                CConsole.Write($"{water[0]:cyan}\t");
                            }
                            Console.WriteLine("\n");
                            foreach (var snow in lennyelementP1.Where(snow => snow[1] != null && snow[1] == "Snow"))
                            {
                                CConsole.Write($"{snow[0]:white}\t");
                            }
                        }
                        Console.WriteLine("\n");
                        Console.Write("Enemy lennys:");
                        Console.WriteLine();
                        if (lennyelementP2.Count > 0)
                        {
                            foreach (var fire in lennyelementP2.Where(fire => fire[1] != null && fire[1] == "Fire"))
                            {
                                CConsole.Write($"{fire[0]:red}\t");
                            }
                            Console.WriteLine("\n");
                            foreach (var water in lennyelementP2.Where(water => water[1] != null && water[1] == "Water"))
                            {
                                CConsole.Write($"{water[0]:cyan}\t");
                            }
                            Console.WriteLine("\n");
                            foreach (var snow in lennyelementP2.Where(snow => snow[1] != null && snow[1] == "Snow"))
                            {
                                CConsole.Write($"{snow[0]:white}\t");
                            }
                        }
                        pressedKey = Console.ReadKey().Key;
                        ifinside[1] = true;
                        int temp = 0;
                        int number = 0;
                        if (int.TryParse(pressedKey.ToString().Remove(0, 1), out temp))
                        {
                            number = int.Parse(pressedKey.ToString().Remove(0, 1));
                        }

                        switch (pressedKey)
                        {
                            case ConsoleKey.R:
                            {
                                Console.Clear();
                                ifinside[0] = false;
                                break;
                            }
                            case ConsoleKey.D1:
                            case ConsoleKey.D2:
                            case ConsoleKey.D3:
                            case ConsoleKey.D4:
                            case ConsoleKey.D5:
                            case ConsoleKey.D6:
                            {
                                while (ifinside[1])
                                {
                                    Console.Clear();
                                    ShowCardinHand(hand[number - 1]);
                                    Console.Write('\n' + "You've chosen this card to play. Are you sure? (y/n): ");
                                    pressedKey = Console.ReadKey().Key;
                                    Console.WriteLine();
                                    switch (pressedKey)
                                    {
                                        case ConsoleKey.Y:
                                            return hand[number - 1];
                                        case ConsoleKey.N:
                                            ifinside[1] = false;
                                            break;
                                        default:
                                            ifinside[1] = true;
                                            break;
                                    }
                                }

                                break;
                            }
                        }
                    }

                    break;
                }
                case ConsoleKey.Tab: 
                {
                    diff2 = 0;
                    ConsoleKey pressedKeyDif;
                    Console.Clear();
                    Console.Write($"Current difficulty: {diff}" + '\n' +
                                  $"Choose between :" + '\n' +
                                  "1: Easy - Chance to get good response is 10%" + '\n' +
                                  "2: Standard - Bot will play as good as he can" + '\n'+ 
                                  "3: No chance to win. Bot has in hand all of card library");
                    while (diff2 is not (1 or 2 or 3)) 
                    {
                        pressedKeyDif = Console.ReadKey().Key;
                        int temp=0;
                        if (int.TryParse(pressedKeyDif.ToString().Remove(0, 1), out temp))
                        {
                            diff2 = int.Parse(pressedKeyDif.ToString().Remove(0, 1));
                        }
                        diff = diff2;
                    }
                    break;
                }
                case ConsoleKey.Q:
                {
                    if (cardhistory.Count == 0)
                        break;
                    Console.Clear();
                    byte turnnum = 1;
                    foreach (var t in cardhistory)
                    {
                        Console.Write($"Turn number: {turnnum}\n");
                        Console.WriteLine();
                        CConsole.Write(CompareCards(t[0], t[1])
                            ? (FormattableString)$"{"You won this turn":yellow}"
                            : (FormattableString)$"{"Enemy won this turn":red}");
                        Console.WriteLine("");
                        Console.WriteLine();
                        Console.Write($"Your card:{new string(' ', 15)}Bot's card:");
                        Console.WriteLine();
                        turnnum++;
                        ShowCards(t);
                    }
                    Console.ReadKey();
                    break;
                }
                case ConsoleKey.O:
                {
                    foreach (var obj in lennyelementP1)
                    {
                        Console.Write($"Lenny: {obj[0]} Element: {obj[1]}" + "\n");
                        Console.WriteLine();
                    }
                    Console.ReadKey();
                    break;
                }
                case ConsoleKey.L:
                    Environment.Exit(0);
                    break;
            }
        }
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
            Console.Write($"{centreblank}{boxTop}");
            CConsole.WriteLine(
                $"{new string(' ', 117)}|{new string(' ', boxsize / 2 + 1)}{new string(' ', boxsize / 2 - 3)}|");
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
            Console.Write($"{centreblank}{boxTop}");
            CConsole.WriteLine(
                $"{new string(' ', 117)}|{new string(' ', boxsize / 2 + 1)}{new string(' ', boxsize / 2 - 3)}|");
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

    private static void OutputBox()
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
            "4: Press L, to quit"
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

    public static void GetCardFromDeck(List<Card> deck, List<Card> hand)
    {
        hand.Add(deck[0]);
        deck.Remove(deck[0]);
    }

    public static bool CompareCards(Card cardP1, Card cardP2)
    {
        if (cardP1.Element == cardP2.Element)
        {
            return (cardP1.Power <= cardP2.Power) switch
            {
                true => false,
                false => true
            };
        }

        return cardP1.Element switch
        {
            "Fire" => cardP2.Element == "Snow",
            "Water" => cardP2.Element == "Fire",
            "Snow" => cardP2.Element == "Water",
            _ => false
        };
    }

    public static bool VictoryCondition(List<string> winlennys)
    {
        return ExtendedFunc.UniqueLenny(winlennys) == 3;
    }

    public static void ShowCardinHand(Card card)
    {
        string element = $"|     {card.Element}     |";
        string blankFilling = new string(' ', element.Length);
        string minusFilling = new string('-', element.Length);
        string underscoreFilling = new string('_', element.Length);
        var sblanks = new StringBuilder(minusFilling)
        {
            [0] = ' ',
            [element.Length - 1] = ' '
        };
        var sunderscore = new StringBuilder(underscoreFilling)
        {
            [0] = ' ',
            [element.Length - 1] = ' '
        };
        var blankspace = new StringBuilder(blankFilling)
        {
            [0] = '|',
            [element.Length - 1] = '|'
        };
        var numstring = new StringBuilder(blankspace.ToString());
        var lennystring = new StringBuilder(blankspace.ToString());
        for (int emoji = 0; emoji < card.Lenny.Length; emoji++)
        {
            lennystring[(lennystring.Length - card.Lenny.Length) / 2 + emoji] = card.Lenny[emoji];
        }

        if (card.Power < 10)
        {
            numstring[1] = Convert.ToChar(Convert.ToString(card.Power));
        }
        else
        {
            numstring[1] = Convert.ToChar(Convert.ToString(card.Power / 10));
            numstring[2] = Convert.ToChar(Convert.ToString(card.Power % 10));
        }

        for (int i = 0; i < 12; i++)
        {
            switch (i)
            {
                case 0:
                    switch (card.Element)
                    {
                        case "Fire":
                        case "🔥":
                            CConsole.Write($"{sunderscore:red}");
                            Console.Write("\t");
                            break;
                        case "Water":
                        case "💧":
                            CConsole.Write($"{sunderscore:cyan}");
                            Console.Write("\t");
                            break;
                        case "Snow":
                        case "🕸️":
                            CConsole.Write($"{sunderscore:white}");
                            Console.Write("\t");
                            break;
                    }

                    Console.WriteLine();
                    break;
                case 6:
                    switch (card.Element)
                    {
                        case "Fire":
                        case "🔥":
                            CConsole.Write($"{element:red}");
                            break;
                        case "Water":
                        case "💧":
                            CConsole.Write($"{element:cyan}");
                            break;
                        case "Snow":
                        case "🕸️":
                            CConsole.Write($"{element:white}");
                            break;
                    }

                    Console.WriteLine();
                    break;
                case 11:
                    switch (card.Element)
                    {
                        case "Fire":
                        case "🔥":
                            CConsole.Write($"{sblanks:red}");
                            break;
                        case "Water":
                        case "💧":
                            CConsole.Write($"{sblanks:cyan}");
                            break;
                        case "Snow":
                        case "🕸️":
                            CConsole.Write($"{sblanks:white}");
                            break;
                    }

                    Console.WriteLine();
                    break;
                case 1:
                    switch (card.Element)
                    {
                        case "Fire":
                        case "🔥":
                            CConsole.Write($"{numstring:red}");
                            break;
                        case "Water":
                        case "💧":
                            CConsole.Write($"{numstring:cyan}");
                            break;
                        case "Snow":
                        case "🕸️":
                            CConsole.Write($"{numstring:white}");
                            break;
                    }

                    Console.WriteLine();
                    break;
                case 10:
                    switch (card.Element)
                    {
                        case "Fire":
                        case "🔥":
                            CConsole.Write($"{lennystring:red}");
                            break;
                        case "Water":
                        case "💧":
                            CConsole.Write($"{lennystring:cyan}");
                            break;
                        case "Snow":
                        case "🕸️":
                            CConsole.Write($"{lennystring:white}");
                            break;
                    }

                    Console.WriteLine();
                    break;
                default:
                    switch (card.Element)
                    {
                        case "Fire":
                        case "🔥":
                            CConsole.Write($"{blankspace:red}");
                            break;
                        case "Water":
                        case "💧":
                            CConsole.Write($"{blankspace:cyan}");
                            break;
                        case "Snow":
                        case "🕸️":
                            CConsole.Write($"{blankspace:white}");
                            break;
                    }

                    Console.WriteLine();
                    break;
            }
        }

        Console.WriteLine();
    }

    private static void ShowCards(List<Card> hand)
    {
        Console.OutputEncoding = Encoding.UTF8;
        for (int i = 0; i < 13; i++)
        {
            byte counter = 1;
            foreach (var card in hand)
            {
                string element = $"|     {card.Element}     |";
                string blankFilling = new string(' ', element.Length);
                var blankspace = new StringBuilder(blankFilling)
                {
                    [0] = '|',
                    [element.Length - 1] = '|'
                };
                string minusFilling = new string('-', element.Length);
                var sblanks = new StringBuilder(minusFilling)
                {
                    [0] = ' ',
                    [element.Length - 1] = ' '
                };
                string underscoreFilling = new string('_', element.Length);
                var sunderscore = new StringBuilder(underscoreFilling)
                {
                    [0] = ' ',
                    [element.Length - 1] = ' '
                };
                var numstring = new StringBuilder(blankspace.ToString());
                var lennystring = new StringBuilder(blankspace.ToString());
                for (int lenny = 0; lenny < card.Lenny.Length; lenny++)
                {
                    lennystring[(lennystring.Length - card.Lenny.Length) / 2 + lenny] = card.Lenny[lenny];
                }

                if (card.Power < 10)
                {
                    numstring[1] = Convert.ToChar(Convert.ToString(card.Power));
                }
                else
                {
                    numstring[1] = Convert.ToChar(Convert.ToString(card.Power / 10));
                    numstring[2] = Convert.ToChar(Convert.ToString(card.Power % 10));
                }

                switch (i)
                {
                    case 0:
                        switch (card.Element)
                        {
                            case "Fire":
                            case "🔥":
                                CConsole.Write($"{sunderscore:red}");
                                Console.Write("\t");
                                break;
                            case "Water":
                            case "💧":
                                CConsole.Write($"{sunderscore:cyan}");
                                Console.Write("\t");
                                break;
                            case "Snow":
                            case "🕸️":
                                CConsole.Write($"{sunderscore:white}");
                                Console.Write("\t");
                                break;
                        }

                        break;
                    case 6:
                        switch (card.Element)
                        {
                            case "Fire":
                            case "🔥":
                                CConsole.Write($"{element:red}");
                                Console.Write("\t");
                                break;
                            case "Water":
                            case "💧":
                                CConsole.Write($"{element:cyan}");
                                Console.Write("\t");
                                break;
                            case "Snow":
                            case "🕸️":
                                CConsole.Write($"{element:white}");
                                Console.Write("\t");
                                break;
                        }

                        break;
                    case 11:
                        switch (card.Element)
                        {
                            case "Fire":
                            case "🔥":
                                CConsole.Write($"{sblanks:red}");
                                Console.Write("\t");
                                break;
                            case "Water":
                            case "💧":
                                CConsole.Write($"{sblanks:cyan}");
                                Console.Write("\t");
                                break;
                            case "Snow":
                            case "🕸️":
                                CConsole.Write($"{sblanks:white}");
                                Console.Write("\t");
                                break;
                        }

                        break;
                    case 1:
                        switch (card.Element)
                        {
                            case "Fire":
                            case "🔥":
                                CConsole.Write($"{numstring:red}");
                                Console.Write("\t");
                                break;
                            case "Water":
                            case "💧":
                                CConsole.Write($"{numstring:cyan}");
                                Console.Write("\t");
                                break;
                            case "Snow":
                            case "🕸️":
                                CConsole.Write($"{numstring:white}");
                                Console.Write("\t");
                                break;
                        }

                        break;
                    case 10:
                        switch (card.Element)
                        {
                            case "Fire":
                            case "🔥":
                                CConsole.Write($"{lennystring:red}");
                                Console.Write("\t");
                                break;
                            case "Water":
                            case "💧":
                                CConsole.Write($"{lennystring:cyan}");
                                Console.Write("\t");
                                break;
                            case "Snow":
                            case "🕸️":
                                CConsole.Write($"{lennystring:white}");
                                Console.Write("\t");
                                break;
                        }

                        break;
                    case 12:
                    {
                        if (hand.Count == 2)
                        {
                            break;
                        }

                        StringBuilder shownum = new StringBuilder(element);
                        for (int z = 0; z < element.Length; z++)
                        {
                            shownum[z] = ' ';
                        }

                        shownum[shownum.Length / 2] = Convert.ToChar(counter++.ToString());
                        shownum[shownum.Length / 2 + 1] = ')';
                        shownum[shownum.Length / 2 - 1] = '(';
                        Console.Write($"{shownum}" + '\t');
                        break;
                    }
                    default:
                        switch (card.Element)
                        {
                            case "Fire":
                            case "🔥":
                                CConsole.Write($"{blankspace:red}");
                                Console.Write("\t");
                                break;
                            case "Water":
                            case "💧":
                                CConsole.Write($"{blankspace:cyan}");
                                Console.Write("\t");
                                break;
                            case "Snow":
                            case "🕸️":
                                CConsole.Write($"{blankspace:white}");
                                Console.Write("\t");
                                break;
                        }

                        break;
                }
            }
            Console.WriteLine();
        }
    }
    /*private static void OutputBox(List<string> lennysP1 , List<string> lennysP2)
    {
        //Console.Write("BoxSize: ");
        int[] counterP1 = new int[17], counterP2 = new int[17];
        byte pozP1 = 0,pozP2 = 0;
        counterP2[pozP2] = lennysP1.Count;
        pozP2++;
        int boxsize = 120;
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.DarkBlue;
        string boxTop = new string('_', boxsize);
        string boxBot = new string('-', boxsize);
        StringBuilder borders = new StringBuilder(new string(' ', boxsize), boxsize)
        {
            [0] = '|',
            [boxsize-1] = '|'
        };
        string centreblank = new string(' ',60);
        for (int i = 0; i < 20; i++)
        {
            Console.WriteLine();
        }
        string[] lennyArrP1 = new string[lennysP1.Count];
        for (int i = 0; i < lennysP1.Count; i++)
        {
            lennyArrP1[i] = lennysP1[i];
        }
        string[] lennyArrP2 = new string[lennysP2.Count];
        for (int i = 0; i < lennysP2.Count; i++)
        {
            lennyArrP2[i] = lennysP2[i];
        }
        Console.WriteLine($"{centreblank}{boxTop}");
        Console.WriteLine($"{centreblank}{borders}");
        CConsole.WriteLine($"{centreblank}|{new string(' ', boxsize / 2 - 12)}{"Lennys in bag":green}{new string(' ', boxsize / 2 - 4)}|");
        for (int i = 0; i < 13; i++)
        {
            if ((i is 4 or 6 or 8 or 10 && lennyArrP1.Length != 0) &&
                     (i is 4 or 6 or 8 or 10 && lennyArrP2.Length != 0))
                CConsole.WriteLine(
                    $"{centreblank}|{new string(' ', 5)}{lennyArrP1[(i - 4) / 2]:green}{new string(' ', boxsize / 2 - 5 - lennyArrP1.Length - 1)}|{new string(' ', boxsize / 4)}{lennyArrP2[(i - 4) / 2]:green}{new string(' ', boxsize / 2 - boxsize / 4 -lennyArrP2.Length-2-5- lennyArrP1.Length)}|");
            
            if (i is 4 or 6 or 8 or 10 && lennyArrP1.Length != 0)
            {
                CConsole.WriteLine($"{centreblank}|{new string(' ',5)}{lennyArrP1[(i-4)/2]:green}{new string(' ',boxsize-lennysP1[(i-4)/2].Length-boxsize/3-5)}|");
            }
            else if(i == lennyArrP2.Length && lennyArrP2.Length != 0)
                CConsole.WriteLine($"{centreblank}|{new string(' ',boxsize*3/4)}{lennyArrP2[(i-4)/2]:green}{new string(' ',boxsize-boxsize*3/4-lennysP2[(i-4)/2].Length)}|");
            else
                Console.WriteLine($"{centreblank}{borders}");
        }
                
        Console.WriteLine($"{centreblank}{boxBot}");
        Console.ResetColor();
        Console.ReadKey();
    }*/
}
    
