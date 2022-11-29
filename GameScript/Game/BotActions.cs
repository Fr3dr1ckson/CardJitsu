
namespace GameScript;

using static GameScript.GameProcesses;

public class BotActions
{
    public static Card BotTurn(byte difficulty,Card playercard,List<Card> usedcards,List<string> usedLennys = null, List<Card> deck = null, List<Card> hand = null )
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
                            Thread.Sleep(3000);
                            hand.Remove(botcard);
                            GetCardFromDeck(deck,hand);
                            CardResult(botcard);
                            return botcard;
                        }
                        CardResult(botcard);
                        return hand[random.Next(0, 6)];
                    }
                }
                foreach (var botcard in hand.Where(botcard => CompareCards(playercard, botcard)))
                {
                    CardResult(botcard);
                    return botcard;
                }
                break;
            case 2:
                foreach (var botcard in hand)
                {
                    if (ExtendedFunc.HaveWinningCard(hand, playercard))
                    {
                        Thread.Sleep(3000);
                        hand.Remove(botcard);
                        GetCardFromDeck(deck,hand);
                        CardResult(botcard);
                        return botcard;
                    }
                    CardResult(botcard);
                    return hand[random.Next(0, 6)];
                }
                break;
            case 3:
                foreach (var botcard in Card.CardLib.Where(botcard => CompareCards(botcard,playercard) && !ExtendedFunc.DeckContains(usedcards,botcard) && !usedLennys.Contains(botcard.Lenny)))
                {
                        usedcards.Add(botcard);
                        usedLennys.Add(botcard.Lenny);
                        CardResult(botcard);
                        return botcard;
                }break;
            
        }
        return hand[0];
    }

    private static void CardResult(Card botcard)
    {
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine($"Bot have chosen this card, maybe you still have a tiny chance: ");
        Console.ResetColor();
        ShowCardinHand(botcard);
        Console.WriteLine();
        Thread.Sleep(3000);
    }
}