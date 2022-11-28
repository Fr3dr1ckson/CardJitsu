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
        Console.Write(deck.Count);
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

    public static bool VictoryCondition(string[] winlennys)
    {
        string[] checker = new string[3];
        byte i = 0;
        checker[0] = winlennys[0];
        foreach(var lenny in winlennys)
            if (checker[i] != lenny)
            {
                i++;
                checker[i] = lenny;
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
        //Console.ForegroundColor = (ConsoleColor) Enum.Parse(typeof(ConsoleColor),card.Color);
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
    }

    public static void ShowFullHand(List<Card> hand)
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

    public static void ShowFullHandCringe(List<Card> hand)
    {
       Console.OutputEncoding = Encoding.UTF8;
        for(int i =0;i<12;i++)
        {
            for (int j = 0; j < hand.Count; j++)
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
                var lennystring = new StringBuilder(blankspace.ToString());
                for (int emoji = 0; emoji < hand[j].Lenny.Length; emoji++)
                {
                    lennystring[(lennystring.Length-hand[j].Lenny.Length)/2+emoji] = hand[j].Lenny[emoji];
                }
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
                    switch (hand[j].Element)
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
                }
                else if (i == 6)
                {
                    switch (hand[j].Element)
                    {
                        case "Fire":case "🔥":
                                    CConsole.Write($"{cock:red}");
                                    Console.Write("\t");
                                    break;
                        case "Water":case"💧":
                            CConsole.Write($"{cock:cyan}");
                            Console.Write("\t");
                            break;
                        case "Snow":case"🕸️":
                                    CConsole.Write($"{cock:white}");
                                    Console.Write("\t");
                                    break;
                    }
                }
                else if (i == 11)
                {
                    switch (hand[j].Element)
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
                }
                else if (i == 1)
                {
                    switch (hand[j].Element)
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
                }
                else if (i == 10)
                {
                    switch (hand[j].Element)
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
                }
                else
                {
                    switch (hand[j].Element)
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
                }
            }
            Console.WriteLine();
        }
    }
    
}