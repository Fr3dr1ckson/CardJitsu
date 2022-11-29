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


    public static Card PlayerTurn(List<Card> deck, List<Card> hand,List<string> lennysP1, List<string> lennysP2, List<List<Card>> cardhistory)
    {
        bool gameison = true;
        while (gameison)
        {
            OutputBox();
            ConsoleKey pressedKey = Console.ReadKey().Key;
            switch (pressedKey)
            {
                case ConsoleKey.E: //Hand Showcasee
                {
                    bool[] ifinside = {true,true};
                    while(ifinside[0]){
                        Console.Clear();
                        ShowCards(hand);
                        Console.WriteLine('\n' + "Press R, to return"
                                               + " or choose one of your card to play. You can see numbers below the cards");
                        pressedKey = Console.ReadKey().Key;
                        ifinside[1] = true;
                        int kok=0;
                        int number = 0;
                        if (int.TryParse(pressedKey.ToString().Remove(0, 1), out kok))
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
                                }break;
                            }
                        }
                    }
                    break;
                }
                case ConsoleKey.Tab: //ScoreBoard
                {
                        OutputBox(lennysP1,lennysP2);
                    break;
                }
                case ConsoleKey.Q:
                {
                    if (cardhistory.Count == 0)
                        break;
                    Console.Clear();
                    byte trunnum = 1;
                    foreach (var t in cardhistory)
                    {
                        Console.Write($"Turn number: {trunnum}");
                        Console.WriteLine();
                        Console.WriteLine();
                        if(CompareCards(t[0], t[1]))
                        {
                            
                        }
                        Console.Write($"Your card:{new string(' ',15)}Bot's card:");
                        Console.WriteLine();
                        trunnum++;
                        ShowCards(t);
                    }
                    Thread.Sleep(5000);
                    break;
            }
                case ConsoleKey.NumPad5:
                {
                    Console.WriteLine();
                    ShowCards(hand);
                    Console.WriteLine();
                    for (int i = 0; i < 4; i++)
                    {
                        List<Card> showcase = new List<Card>
                        {
                            deck[0 + 6 * i], deck[1 + 6 * i], deck[2 + 6 * i], deck[3 + 6 * i], deck[4 + 6 * i],
                            deck[5 + 6 * i]
                        };
                        ShowCards(showcase);
                    }
                    break;
                }
                case ConsoleKey.L:
                    Environment.Exit(0);
                    break;
            }
        }

        return hand[0];
    }

    private static void OutputBox(List<string> lennysP1 , List<string> lennysP2)
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
    }
    
    public static void OutputBox(List<string> lennys, bool winner = false)
    {
        int boxsize = 120;
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Magenta;
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
        string press = "You lost";
        Console.Write($"{centreblank}{boxTop}");
        CConsole.WriteLine($"{new string(' ',117)}|{new string(' ', boxsize / 2 +1)}{new string(' ', boxsize / 2 - 3 )}|");
        //                CConsole.WriteLine($"{new string(' ',90)}|{new string(' ', boxsize / 2 - 3)}{"Menu":green}{new string(' ', boxsize / 2 - 3)}|");
        for (int i = 0; i < 14; i++)
        {
            if (i is 8)
            {
                CConsole.WriteLine($"{centreblank}|{new string(' ',boxsize/3+13)}{press:red}{new string(' ',boxsize-press.Length-boxsize/3-15)}|");
            }
            else
                Console.WriteLine($"{centreblank}{borders}");
        }
                
        Console.WriteLine($"{centreblank}{boxBot}");
        Console.ResetColor();
        Console.ReadKey();
    }
    public static void OutputBox(bool winner)
    {
        int boxsize = 120;
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Green;
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
        string press = "You Win!";
        Console.Write($"{centreblank}{boxTop}");
        CConsole.WriteLine($"{new string(' ',117)}|{new string(' ', boxsize / 2 +1)}{new string(' ', boxsize / 2 - 3 )}|");
        for (int i = 0; i < 14; i++)
        {
            if (i is 8)
            {
                CConsole.WriteLine($"{centreblank}|{new string(' ',boxsize/3+13)}{press:yellow}{new string(' ',boxsize-press.Length-boxsize/3-15)}|");
            }
            else
                Console.WriteLine($"{centreblank}{borders}");
        }
                
        Console.WriteLine($"{centreblank}{boxBot}");
        Console.ResetColor();
        Console.ReadKey();
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
            [boxsize-1] = '|'
        };
        string centreblank = new string(' ',60);
        for (int i = 0; i < 20; i++)
        {
            Console.WriteLine();
        }
        string[] press = {
                        "1: Press E, to check your hand", 
                        "2: Press Tab, to check total score",
                        "3: Press Q, to access cheatsheet",
                        "4: Press L, to quit"
                };
                Console.Write($"{centreblank}{boxTop}");
                CConsole.WriteLine($"{new string(' ',117)}|{new string(' ', boxsize / 2 - 3)}{"Menu":green}{new string(' ', boxsize / 2 - 3)}|");
                //                CConsole.WriteLine($"{new string(' ',90)}|{new string(' ', boxsize / 2 - 3)}{"Menu":green}{new string(' ', boxsize / 2 - 3)}|");
                for (int i = 0; i < 14; i++)
                {
                    if (i is 4 or 6 or 8 or 10)
                    {
                        CConsole.WriteLine($"{centreblank}|{new string(' ',boxsize/3+3)}{press[(i-4)/2]:green}{new string(' ',boxsize-press[(i-4)/2].Length-boxsize/3-5)}|");
                    }
                    else
                        Console.WriteLine($"{centreblank}{borders}");
                }
                
                Console.WriteLine($"{centreblank}{boxBot}");
                Console.ResetColor();
    }
    
    
    public static void GetCardFromDeck(List<Card> deck,List<Card> hand)
    {
        hand.Add(deck[0]);
        deck.Remove(deck[0]);
        Console.Write(deck.Count);
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
        var userLennys = winlennys;
        var checker = new List<string>(Card.lenny);
        byte counter = 0;
        for(int i = 0;i<checker.Count;i++)
        {
            for(int j = 0;j<userLennys.Count;j++)
            {
                if (userLennys[j] == checker[i]) continue;
                counter++;
                if (counter == 3) return true;
                userLennys.Remove(userLennys[j]);
                checker.Remove(checker[i]);
                i--;
                j--;
                break;
            }
        } return false;
    }

    public static void ShowCardinHand(Card card)
    {
        string cock = $"|     {card.Element}     |";
        string blankFilling = new string(' ', cock.Length);
        string minusFilling = new string('-', cock.Length);
        string underscoreFilling = new string('_', cock.Length);
        var sblanks = new StringBuilder(minusFilling)
        {
            [0] = ' ',
            [cock.Length-1] = ' '
        };
        var sunderscore = new StringBuilder(underscoreFilling)
        {
            [0] = ' ',
            [cock.Length - 1] = ' '
        };
        var blankspace = new StringBuilder(blankFilling)
        {
            [0] = '|',
            [cock.Length-1] = '|'
        };
        var numstring = new StringBuilder(blankspace.ToString());
        var lennystring = new StringBuilder(blankspace.ToString());
        for (int emoji = 0; emoji < card.Lenny.Length; emoji++)
        {
            lennystring[(lennystring.Length-card.Lenny.Length)/2+emoji] = card.Lenny[emoji];
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
        switch (card.Element)
        {
            case "Fire":
                CConsole.WriteLine($"{sunderscore:red}\n{numstring:red}\n{blankspace:red}\n{blankspace:red}\n{cock:red}\n{blankspace:red}\n{blankspace:red}\n{lennystring:red:}\n{sblanks:red}\n");
                break;
            case "Water":
                CConsole.WriteLine($"{sunderscore:cyan}\n{numstring:cyan}\n{blankspace:cyan}\n{blankspace:cyan}\n{cock:cyan}\n{blankspace:cyan}\n{blankspace:cyan}\n{lennystring:cyan:}\n{sblanks:cyan}\n");
                break;
            case "Snow":
                CConsole.WriteLine($"{sunderscore:white}\n{numstring:white}\n{blankspace:white}\n{blankspace:white}\n{cock:white}\n{blankspace:white}\n{blankspace:white}\n{lennystring:white:}\n{sblanks:white}\n");
                break;
        }
        Console.WriteLine();
    }

 
    private static void ShowCards(List<Card> hand)
    {
       Console.OutputEncoding = Encoding.UTF8;
        for(int i =0;i<13;i++)
        {
            byte counter = 1;
            foreach (var card in hand)
            {
                string element = $"|     {card.Element}     |";
                string blankFilling = new string(' ', element.Length);
                var blankspace = new StringBuilder(blankFilling)
                {
                    [0] = '|',
                    [element.Length-1] = '|'
                };
                string minusFilling = new string('-', element.Length);
                var sblanks = new StringBuilder(minusFilling)
                {
                    [0] = ' ',
                    [element.Length-1] = ' '
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
                    lennystring[(lennystring.Length-card.Lenny.Length)/2+lenny] = card.Lenny[lenny];
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
                            case "Fire":case "🔥":
                                CConsole.Write($"{sunderscore:red}");
                                Console.Write("\t");
                                break;
                            case "Water":case"💧":
                                CConsole.Write($"{sunderscore:cyan}");
                                Console.Write("\t");
                                break;
                            case "Snow":case"🕸️":
                                CConsole.Write($"{sunderscore:white}");
                                Console.Write("\t");
                                break;
                        }

                        break;
                    case 6:
                        switch (card.Element)
                        {
                            case "Fire":case "🔥":
                                CConsole.Write($"{element:red}");
                                Console.Write("\t");
                                break;
                            case "Water":case"💧":
                                CConsole.Write($"{element:cyan}");
                                Console.Write("\t");
                                break;
                            case "Snow":case"🕸️":
                                CConsole.Write($"{element:white}");
                                Console.Write("\t");
                                break;
                        }

                        break;
                    case 11:
                        switch (card.Element)
                        {
                            case "Fire":case "🔥":
                                CConsole.Write($"{sblanks:red}");
                                Console.Write("\t");
                                break;
                            case "Water":case"💧":
                                CConsole.Write($"{sblanks:cyan}");
                                Console.Write("\t");
                                break;
                            case "Snow":case"🕸️":
                                CConsole.Write($"{sblanks:white}");
                                Console.Write("\t");
                                break;
                        }

                        break;
                    case 1:
                        switch (card.Element)
                        {
                            case "Fire":case "🔥":
                                CConsole.Write($"{numstring:red}");
                                Console.Write("\t");
                                break;
                            case "Water":case"💧":
                                CConsole.Write($"{numstring:cyan}");
                                Console.Write("\t");
                                break;
                            case "Snow":case"🕸️":
                                CConsole.Write($"{numstring:white}");
                                Console.Write("\t");
                                break;
                        }

                        break;
                    case 10:
                        switch (card.Element)
                        {
                            case "Fire":case "🔥":
                                CConsole.Write($"{lennystring:red}");
                                Console.Write("\t");
                                break;
                            case "Water":case"💧":
                                CConsole.Write($"{lennystring:cyan}");
                                Console.Write("\t");
                                break;
                            case "Snow":case"🕸️":
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
                        shownum[shownum.Length/2+1] = ')';
                        shownum[shownum.Length/2 - 1] = '(';
                        Console.Write($"{shownum}"+'\t');
                        break;
                    }
                    default:
                        switch (card.Element)
                        {
                            case "Fire":case "🔥":
                                CConsole.Write($"{blankspace:red}");
                                Console.Write("\t");
                                break;
                            case "Water":case"💧":
                                CConsole.Write($"{blankspace:cyan}");
                                Console.Write("\t");
                                break;
                            case "Snow":case"🕸️":
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
    
}

    /*  public static void ShowFullHand(List<Card> hand)
    {
        Console.OutputEncoding = Encoding.UTF8;
        for(int i =0;i<12;i++)
        {
            for (int j = 0; j < hand.Count; j++)
            {
                var r = new Random();
                string cock = $"|     {hand[j].Element}     |";
                string blankFilling = new string(' ', cock.Length);
                var blankspace = new StringBuilder(blankFilling)
                {
                    [0] = '|',
                    [cock.Length-1] = '|'
                };
                string minusFilling = new string('-', cock.Length);
                var sblanks = new StringBuilder(minusFilling)
                {
                    [0] = ' ',
                    [cock.Length-1] = ' '
                };
                string underscoreFilling = new string('_', cock.Length);
                var sunderscore = new StringBuilder(underscoreFilling)
                {
                    [0] = ' ',
                    [cock.Length - 1] = ' '
                };
                var numstring = new StringBuilder(blankspace.ToString());
                if (hand[j].Power < 10)
                {
                    numstring[1] = Convert.ToChar(Convert.ToString(hand[j].Power));
                }
                else
                {
                    numstring[1] = Convert.ToChar(Convert.ToString(hand[j].Power / 10));
                    numstring[2] = Convert.ToChar(Convert.ToString(hand[j].Power % 10));
                }
                if (i == 0)
                {
                    switch (hand[j].Color)
                    {
                        case "Red":
                            CConsole.Write($"{sunderscore:darkred}");
                            Console.Write("\t");
                            break;
                        case "Yellow":
                            CConsole.Write($"{sunderscore:darkyellow}");
                            Console.Write("\t");
                            break;
                        case "Green":
                            CConsole.Write($"{sunderscore:darkgreen}");
                            Console.Write("\t");
                            break;
                        case "Blue":
                            CConsole.Write($"{sunderscore:darkblue}");
                            Console.Write("\t");
                            break;
                    }
                }
                else if (i == 6)
                {
                    switch (hand[j].Color)
                    {
                        case "Red":
                                    CConsole.Write($"{"|":darkred}     {hand[j].Element:red}     {"|":darkred}");
                                    Console.Write("\t");
                                    break;
                        
                        case "Yellow":
                            CConsole.Write($"{"|":darkyellow}     {hand[j].Element:yellow}     {"|":darkyellow}");
                            Console.Write("\t");
                            break;
                        
                        case "Green":
                                    CConsole.Write($"{"|":darkgreen}     {hand[j].Element:green}     {"|":darkgreen}");
                                    Console.Write("\t");
                                    break;
                        
                        case "Blue":
                            
                                    CConsole.Write($"{"|":darkblue}     {hand[j].Element:blue}     {"|":darkblue}");
                                    Console.Write("\t");
                                    break;
                    }
                }
                else if (i == 11)
                {
                    switch (hand[j].Color)
                    {
                        case "Red":
                            CConsole.Write($"{sblanks:darkred}");
                            Console.Write("\t");
                            break;
                        case "Yellow":
                            CConsole.Write($"{sblanks:darkyellow}");
                            Console.Write("\t");
                            break;
                        case "Green":
                            CConsole.Write($"{sblanks:darkgreen}");
                            Console.Write("\t");
                            break;
                        case "Blue":
                            CConsole.Write($"{sblanks:darkblue}");
                            Console.Write("\t");
                            break;
                    }
                }
                else if (i == 1)
                {
                    switch (hand[j].Color)
                    {
                        case "Red":
                            CConsole.Write($"{numstring:darkred}");
                            Console.Write("\t");
                            break;
                        case "Yellow":
                            CConsole.Write($"{numstring:darkyellow}");
                            Console.Write("\t");
                            break;
                        case "Green":
                            CConsole.Write($"{numstring:darkgreen}");
                            Console.Write("\t");
                            break;
                        case "Blue":
                            CConsole.Write($"{numstring:darkblue}");
                            Console.Write("\t");
                            break;
                    }
                }
                else
                {
                    switch (hand[j].Color)
                    {
                        case "Red":
                            CConsole.Write($"{blankspace:darkred}");
                            Console.Write("\t");
                            break;
                        case "Yellow":
                            CConsole.Write($"{blankspace:darkyellow}");
                            Console.Write("\t");
                            break;
                        case "Green":
                            CConsole.Write($"{blankspace:darkgreen}");
                            Console.Write("\t");
                            break;
                        case "Blue":
                            CConsole.Write($"{blankspace:darkblue}");
                            Console.Write("\t");
                            break;
                    }
                }
            }
            Console.WriteLine();
        }
    }
*/
