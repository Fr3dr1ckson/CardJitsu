
using GameScript.Useful_Functions;

namespace GameScript.Game;

using static GameProcesses;

public static class BotActions
{
    public static Card BotTurn(int difficulty,Card playercard,List<Card> usedcards,List<string> usedLennys = null!, List<Card> deck = null!, List<Card> hand = null! )
    {
        var random = new Random();
        string[] goodTurn = new string[10];
        Thread.Sleep(2000);
        switch (difficulty)
        {
            case 1:
                int clever = random.Next(0, goodTurn.Length-1);
                for (int i = 0; i < goodTurn.Length; i++)
                {
                    goodTurn[i] = i == clever ? "clever" : "stupid";
                }
                if (goodTurn[random.Next(0, goodTurn.Length-1)] == "clever")
                {
                    foreach (var botcard in hand)
                    {
                        if (ExtendedFunc.HaveWinningCard(hand, playercard))
                        {
                            Thread.Sleep(2000);
                            hand.Remove(botcard);
                            GetCardFromDeck(deck,hand);
                            CardResult(botcard,playercard);
                            return botcard;
                        }
                        CardResult(botcard,playercard);
                        return hand[random.Next(0, 6)];
                    }
                }
                foreach (var botcard in hand.Where(botcard => CompareCards(playercard, botcard)&& !ExtendedFunc.SameCards(playercard,botcard)))
                {
                    CardResult(botcard,playercard);
                    return botcard;
                }
                break;
            case 2:
                foreach (var botcard in hand)
                {
                    if (ExtendedFunc.HaveWinningCard(hand, playercard))
                    {
                        Thread.Sleep(2000);
                        hand.Remove(botcard);
                        GetCardFromDeck(deck,hand);
                        CardResult(botcard,playercard);
                        return botcard;
                    }
                    CardResult(botcard,playercard);
                    return hand[random.Next(0, 6)];
                }
                break;
            case 3:
                foreach (var botcard in Card.CardLib.Where(botcard => CompareCards(botcard,playercard) && !ExtendedFunc.DeckContains(usedcards,botcard) && !usedLennys.Contains(botcard.Lenny)))
                {
                        usedcards.Add(botcard);
                        usedLennys.Add(botcard.Lenny);
                        CardResult(botcard,playercard);
                        return botcard;
                }break;
            
        }
        return hand[0];
    }

    private static void CardResult(Card botcard, Card playercard = null!)
    {
        Console.WriteLine();
        if(!(playercard==null) && CompareCards(playercard, botcard))
            CConsole.Write($"{"You Won!":yellow}");
        else if (playercard != null && ExtendedFunc.SameCards(playercard,botcard)) CConsole.Write($"{"Tie!":gray}");
        else CConsole.Write($"{"Bot Won!":red}");
        Console.WriteLine();
        Console.ResetColor();
        ShowCardinHand(botcard);
        Console.WriteLine();
        Thread.Sleep(2000);
    }
}