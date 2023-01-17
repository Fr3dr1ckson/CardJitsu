
using GameScript.Useful_Functions;

namespace GameScript.Game;

using static GameProcesses;

public static class BotActions
{
    public static Card BotTurn(int difficulty,Card playerCard,List<Card> usedcards,List<string> usedLennys = null!, Player bot  = null! )
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
                    foreach (var botcard in bot.Hand)
                    {
                        if (ExtendedFunc.HaveWinningCard(bot.Hand, playerCard))
                        {
                            Thread.Sleep(2000);
                            bot.Hand.Remove(botcard);
                            bot.GetCard();
                            CardResult(botcard,playerCard);
                            return botcard;
                        }
                        CardResult(botcard,playerCard);
                        return bot.Hand[random.Next(0, 6)];
                    }
                }
                foreach (var botcard in bot.Hand.Where(botcard => CompareCards(playerCard, botcard)&& !ExtendedFunc.SameCards(playerCard,botcard)))
                {
                    CardResult(botcard,playerCard);
                    return botcard;
                }
                break;
            case 2:
                foreach (var botcard in bot.Hand)
                {
                    if (ExtendedFunc.HaveWinningCard(bot.Hand, playerCard))
                    {
                        Thread.Sleep(2000);
                        bot.Hand.Remove(botcard);
                        bot.GetCard();
                        CardResult(botcard,playerCard);
                        return botcard;
                    }
                    CardResult(botcard,playerCard);
                    return bot.Hand[random.Next(0, 6)];
                }
                break;
            case 3:
                foreach (var botcard in Card.CardLib.Where(botcard => CompareCards(botcard,playerCard) && !ExtendedFunc.DeckContains(usedcards,botcard) && !usedLennys.Contains(botcard.Lenny.value)))
                {
                        usedcards.Add(botcard);
                        usedLennys.Add(botcard.Lenny.value);
                        CardResult(botcard,playerCard);
                        return botcard;
                }break;
            
        }
        return bot.Hand[0];
    }
    private static void CardResult(Card botcard, Card playercard)
    {
        Console.WriteLine();
        if(CompareCards(playercard, botcard))
            CConsole.Write($"{"You Won!":yellow}");
        else if (ExtendedFunc.SameCards(playercard,botcard)) CConsole.Write($"{"Tie!":gray}");
        else CConsole.Write($"{"Bot Won!":red}");
        Console.WriteLine();
        Console.ResetColor();
        ShowCardinHand(botcard);
        Console.WriteLine();
        Thread.Sleep(2000);
    }
}