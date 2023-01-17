using System.Runtime.CompilerServices;
using System.Text;
using GameScript.DebugFunction;
using GameScript.Useful_Functions;
using static System.ConsoleKey;

namespace GameScript.Game;

public static class GameProcesses
{
    


    public static Card PlayerTurn(Player player, Player bot,
        List<List<Card>> cardhistory , int diff,
        out int diff2)
    {
        diff2 = diff;
        while (true)
        {
            GameScreens.OutputBox();
            ConsoleKey pressedKey = Console.ReadKey().Key;
            switch (pressedKey)
            {
                case E: //Hand Showcase
                {
                    bool[] ifinside = { true, true };
                    while (ifinside[0])
                    {
                        Console.Clear();
                        ShowCards(player.Hand);
                        Console.WriteLine('\n' + "Press R, to return"
                                               + " or choose one of your card to play. You can see numbers below the cards");
                        Console.WriteLine("\n");
                        Console.Write("Your lennys:");
                        Console.WriteLine();
                        if (player.WinLennys.Count > 0)
                        {
                            foreach (var lenny in player.WinLennys.Where(lenny => lenny.element == "Fire"))
                            {
                                CConsole.Write($"{lenny.value:red}\t");
                            }

                            Console.WriteLine("\n");
                            foreach (var lenny in player.WinLennys.Where(lenny => lenny.element == "Water"))
                            {
                                CConsole.Write($"{lenny.value:cyan}\t");
                            }

                            Console.WriteLine("\n");
                            foreach (var lenny in player.WinLennys.Where(lenny => lenny.element == "Snow"))
                            {
                                CConsole.Write($"{lenny.value:white}\t");
                            }
                        }

                        Console.WriteLine("\n");
                        Console.Write("Enemy lennys:");
                        Console.WriteLine();
                        if (bot.WinLennys.Count > 0)
                        {
                            foreach (var lenny in bot.WinLennys.Where(lenny => lenny.element == "Fire"))
                            {
                                CConsole.Write($"{lenny.value:red}\t");
                            }

                            Console.WriteLine("\n");
                            foreach (var lenny in bot.WinLennys.Where(lenny => lenny.element == "Water"))
                            {
                                CConsole.Write($"{lenny.value:cyan}\t");
                            }

                            Console.WriteLine("\n");
                            foreach (var lenny in bot.WinLennys.Where(lenny => lenny.element == "Snow"))
                            {
                                CConsole.Write($"{lenny.value:white}\t");
                            }
                        }

                        pressedKey = Console.ReadKey().Key;
                        ifinside[1] = true;
                        int number = 0;
                        if (int.TryParse(pressedKey.ToString().Remove(0, 1), out int t))
                        {
                            number = int.Parse(pressedKey.ToString().Remove(0, 1));
                        }

                        switch (pressedKey)
                        {
                            case R:
                            {
                                Console.Clear();
                                ifinside[0] = false;
                                break;
                            }
                            case D1:
                            case D2:
                            case D3:
                            case D4:
                            case D5:
                            case D6:
                            {
                                while (ifinside[1])
                                {
                                    Console.Clear();
                                    ShowCardinHand(player.Hand[number - 1]);
                                    Console.Write('\n' + "You've chosen this card to play. Are you sure? (y/n): ");
                                    pressedKey = Console.ReadKey().Key;
                                    Console.WriteLine();
                                    switch (pressedKey)
                                    {
                                        case Y:
                                            return player.Hand[number - 1];
                                        case N:
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
                case Tab:
                {
                    diff2 = 0;
                    ConsoleKey pressedKeyDif;
                    Console.Clear();
                    Console.Write($"Current difficulty: {diff}" + '\n' +
                                  $"Choose between :" + '\n' +
                                  "1: Easy - Chance to get good response is 10%" + '\n' +
                                  "2: Standard - Bot will play as good as he can" + '\n' +
                                  "3: No chance to win. Bot has in hand all of card library");
                    while (diff2 is not (1 or 2 or 3))
                    {
                        pressedKeyDif = Console.ReadKey().Key;
                        if (int.TryParse(pressedKeyDif.ToString().Remove(0, 1), out int t))
                        {
                            diff2 = int.Parse(pressedKeyDif.ToString().Remove(0, 1));
                        }

                        diff = diff2;
                    }

                    break;
                }
                case Q:
                {
                    if (cardhistory.Count == 0)
                        break;
                    Console.Clear();
                    byte turnnum = 1;
                    foreach (var t in cardhistory)
                    {
                        Console.Write($"Turn number: {turnnum}\n");
                        Console.WriteLine();
                        if (CompareCards(t[0], t[1]))
                            CConsole.Write($"{"You won this turn":yellow}");

                        else if (ExtendedFunc.SameCards(t[0], t[1]))
                            CConsole.Write($"{"No one won this turn":gray}");

                        else CConsole.Write($"{"Enemy won this turn":red}");

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
                case NumPad7:
                {
                    var isInside = true;
                    Console.Clear();
                    while (isInside)
                    {
                        GameScreens.FuncBox();
                        var pressedkey = Console.ReadKey().Key;
                        switch (pressedkey)
                        {
                            case E:
                                Console.Clear();
                                Card p1;
                                Card p2;
                                p1 = CardMethods.CreateCard();
                                p2 = CardMethods.CreateCard();
                                Console.Clear();
                                ShowCardinHand(p1);
                                Console.WriteLine();
                                CardResult(p1, p2);
                                break;
                            case R:
                                isInside = false;
                                break;
                        }
                    }
                    break;
                }
                case NumPad8:
                    Console.Write("Choose OutputBox:" + '\n' +
                                  "1: WinBox" + '\n' +
                                  "2: LoseBox" + '\n' +
                                  "3: FuncBox" + '\n' +
                                  "4: EndBox" + '\n');
                    ConsoleKey pressKey = Console.ReadKey().Key;
                    switch (pressKey)
                    {
                        case D1:
                            GameScreens.OutputBox(true);
                            break;
                        case D2:
                            GameScreens.OutputBox(false);
                            break;
                        case D3:
                            GameScreens.FuncBox();
                            break;
                        case D4:
                            GameScreens.EndBox();
                            break;
                    }
                    Console.ReadKey();
                    break;
                case Escape:
                    Environment.Exit(0);
                    break;
            }
        }
    }
    private static void CardResult(Card p1Card, Card p2Card )
    { 
        Console.WriteLine();
        if(CompareCards(p1Card, p2Card))
            CConsole.Write($"{"Player I Won!":blue}");
        else if (ExtendedFunc.SameCards(p1Card,p2Card)) CConsole.Write($"{"Tie!":gray}");
        else CConsole.Write($"{"Player II Won!":red}");
        Console.WriteLine();
        Console.ResetColor();
        ShowCardinHand(p2Card);
        Console.WriteLine();
        Thread.Sleep(2000);
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
        for (int emoji = 0; emoji < card.Lenny.value.Length; emoji++)
        {
            lennystring[(lennystring.Length - card.Lenny.value.Length) / 2 + emoji] = card.Lenny[emoji];
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
                            CConsole.Write($"{sunderscore:red}");
                            Console.Write("\t");
                            break;
                        case "Water":
                            CConsole.Write($"{sunderscore:cyan}");
                            Console.Write("\t");
                            break;
                        case "Snow":
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
                            CConsole.Write($"{element:red}");
                            break;
                        case "Water":
                            CConsole.Write($"{element:cyan}");
                            break;
                        case "Snow":
                            CConsole.Write($"{element:white}");
                            break;
                    }

                    Console.WriteLine();
                    break;
                case 11:
                    switch (card.Element)
                    {
                        case "Fire":
                            CConsole.Write($"{sblanks:red}");
                            break;
                        case "Water":
                            CConsole.Write($"{sblanks:cyan}");
                            break;
                        case "Snow":
                            CConsole.Write($"{sblanks:white}");
                            break;
                    }

                    Console.WriteLine();
                    break;
                case 1:
                    switch (card.Element)
                    {
                        case "Fire":
                            CConsole.Write($"{numstring:red}");
                            break;
                        case "Water":
                            CConsole.Write($"{numstring:cyan}");
                            break;
                        case "Snow":
                            CConsole.Write($"{numstring:white}");
                            break;
                    }

                    Console.WriteLine();
                    break;
                case 10:
                    switch (card.Element)
                    {
                        case "Fire":
                            CConsole.Write($"{lennystring:red}");
                            break;
                        case "Water":
                            CConsole.Write($"{lennystring:cyan}");
                            break;
                        case "Snow":
                            CConsole.Write($"{lennystring:white}");
                            break;
                    }

                    Console.WriteLine();
                    break;
                default:
                    switch (card.Element)
                    {
                        case "Fire":
                            CConsole.Write($"{blankspace:red}");
                            break;
                        case "Water":
                            CConsole.Write($"{blankspace:cyan}");
                            break;
                        case "Snow":
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
                for (int lenny = 0; lenny < card.Lenny.value.Length; lenny++)
                {
                    lennystring[(lennystring.Length - card.Lenny.value.Length) / 2 + lenny] = card.Lenny[lenny];
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
                                CConsole.Write($"{sunderscore:red}");
                                Console.Write("\t");
                                break;
                            case "Water":
                                CConsole.Write($"{sunderscore:cyan}");
                                Console.Write("\t");
                                break;
                            case "Snow":
                                CConsole.Write($"{sunderscore:white}");
                                Console.Write("\t");
                                break;
                        }

                        break;
                    case 6:
                        switch (card.Element)
                        {
                            case "Fire":
                                CConsole.Write($"{element:red}");
                                Console.Write("\t");
                                break;
                            case "Water":
                                CConsole.Write($"{element:cyan}");
                                Console.Write("\t");
                                break;
                            case "Snow":
                                CConsole.Write($"{element:white}");
                                Console.Write("\t");
                                break;
                        }

                        break;
                    case 11:
                        switch (card.Element)
                        {
                            case "Fire":
                                CConsole.Write($"{sblanks:red}");
                                Console.Write("\t");
                                break;
                            case "Water":
                                CConsole.Write($"{sblanks:cyan}");
                                Console.Write("\t");
                                break;
                            case "Snow":
                                CConsole.Write($"{sblanks:white}");
                                Console.Write("\t");
                                break;
                        }

                        break;
                    case 1:
                        switch (card.Element)
                        {
                            case "Fire":
                                CConsole.Write($"{numstring:red}");
                                Console.Write("\t");
                                break;
                            case "Water":
                                CConsole.Write($"{numstring:cyan}");
                                Console.Write("\t");
                                break;
                            case "Snow":
                                CConsole.Write($"{numstring:white}");
                                Console.Write("\t");
                                break;
                        }

                        break;
                    case 10:
                        switch (card.Element)
                        {
                            case "Fire":
                                CConsole.Write($"{lennystring:red}");
                                Console.Write("\t");
                                break;
                            case "Water":
                                CConsole.Write($"{lennystring:cyan}");
                                Console.Write("\t");
                                break;
                            case "Snow":
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
                                CConsole.Write($"{blankspace:red}");
                                Console.Write("\t");
                                break;
                            case "Water":
                                CConsole.Write($"{blankspace:cyan}");
                                Console.Write("\t");
                                break;
                            case "Snow":
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
    
