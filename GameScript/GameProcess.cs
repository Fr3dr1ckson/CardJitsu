using System.Text;
namespace GameScript;

public class GameProcess
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

    public static void GetCardFromDeck(List<Card> deck,List<Card> hand)
    {
        hand.Add(deck[0]);
        deck.Remove(deck[0]);
    }

    public static bool CompareCards(Card cardP1, Card cardP2)
    {
        return cardP1.Element switch
        {
            "Fire" => cardP2.Element == "Snow" && cardP1.Power > cardP2.Power,
            "Water" => cardP2.Element == "Fire" && cardP1.Power > cardP2.Power,
            "Snow" => cardP2.Element == "Water" && cardP1.Power > cardP2.Power,
            _ => false
        };
    }

    public static bool VictoryCondition(string[] wincolors)
    {
        string[] checker = new string[3];
        byte i = 0;
        checker[0] = wincolors[0];
        foreach(var color in wincolors)
            if (checker[i] != color)
            {
                i++;
                checker[i] = color;
            }
            else if (i > 2)
            {
                return true;
            }

        return false;
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
        if (card.Power < 10)
        {
            numstring[1] = Convert.ToChar(Convert.ToString(card.Power));
        }
        else
        {
            numstring[1] = Convert.ToChar(Convert.ToString(card.Power / 10));
            numstring[2] = Convert.ToChar(Convert.ToString(card.Power % 10));
        }
        Console.ForegroundColor = (ConsoleColor) Enum.Parse(typeof(ConsoleColor),card.Color);
        CConsole.WriteLine($"{sunderscore:red:green}\n{numstring:red:green}\n{blankspace:red:green}\n{blankspace:red:green}");
        switch (card.Element)
        {
            case "Fire":
                CConsole.Write($"|     {card.Element:red}     |");
                break;
            case "Water":
                CConsole.Write($"{"|     ":red:darkgreen}{card.Element:darkblue:darkgreen}{"     |":red:darkgreen}");
                break;
            case "Snow":
                CConsole.Write($"|     {card.Element:white}     |");
                break;
        }
        CConsole.Write($"\n{blankspace:red:green}\n{blankspace:red:green}\n{blankspace:red:green}\n{sblanks:red:green} \n");
    }

    public static void ShowFullHand(List<Card> hand)
    {
        for(int i =0;i<9;i++)
        {
            for (int j = 0; j < 6; j++)
            {
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
                else if (i == 4)
                {
                    switch (hand[j].Color)
                    {
                        case "Red":
                            //switch (hand[j].Element)
                            //{
                                /* case "Fire":
                                    CConsole.Write($"{"|":red}     {hand[j].Element:red}     {"|":red}");
                                    break;
                                case "Water":
                                    CConsole.Write($"{"|":red}     {hand[j].Element:darkblue}     {"|":red}");
                                    break;
                                case "Snow":*/
                                    CConsole.Write($"{"|":darkred}     {hand[j].Element:gray}     {"|":darkred}");
                                    Console.Write("\t");
                                    break;
                            //}

                            //Console.Write("\t");
                            //break;
                        case "Yellow":
                            /*switch (hand[j].Element)
                            {
                                case "Fire":
                                    CConsole.Write($"{"|":yellow}     {hand[j].Element:red}     {"|":yellow}");
                                    break;
                                case "Water":
                                    CConsole.Write($"{"|":yellow}     {hand[j].Element:darkblue}     {"|":yellow}");
                                    break;
                                case "Snow":*/
                            CConsole.Write($"{"|":darkyellow}     {hand[j].Element:gray}     {"|":darkyellow}");
                            Console.Write("\t");
                            break;
                            //}
                            //Console.Write("\t");
                            //break;
                        case "Green":
                            /*switch (hand[j].Element)
                            {
                                case "Fire":
                                    CConsole.Write($"{"|":green}     {hand[j].Element:red}     {"|":green}");
                                    break;
                                case "Water":
                                    CConsole.Write($"{"|":green}     {hand[j].Element:darkblue}     {"|":green}");
                                    break;
                                case "Snow":*/
                                    CConsole.Write($"{"|":darkgreen}     {hand[j].Element:gray}     {"|":darkgreen}");
                                    Console.Write("\t");
                                    break;
                            //}
                           // Console.Write("\t");
                            //break;
                        case "Blue":
                            /*switch (hand[j].Element)
                            {
                                case "Fire":
                                    CConsole.Write($"{"|":darkblue}     {hand[j].Element:red}     {"|":darkblue}");
                                    break;
                                case "Water":
                                    CConsole.Write($"{"|":darkblue}     {hand[j].Element:darkblue}     {"|":darkblue}");
                                    break;
                                case "Snow":*/
                                    CConsole.Write($"{"|":darkblue}     {hand[j].Element:gray}     {"|":darkblue}");
                                    Console.Write("\t");
                                    break;
                           // }
                           // Console.Write("\t");
                            //break;
                    }
                }
                else if (i == 8)
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
    
}