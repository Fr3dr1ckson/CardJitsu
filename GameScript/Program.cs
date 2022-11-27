using GameScript;
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
Console.Write(" Fire");
Console.ForegroundColor = ConsoleColor.Gray;
Console.Write(" beats");
Console.ForegroundColor = ConsoleColor.White;
Console.Write(" Snow " + '\n');
Console.ForegroundColor = ConsoleColor.Gray;
Console.Write('\u2022');
Console.ForegroundColor = ConsoleColor.White;
Console.Write(" Snow");
Console.ForegroundColor = ConsoleColor.Gray;
Console.Write(" beats");
Console.ForegroundColor = ConsoleColor.DarkBlue;
Console.Write(" Water" + '\n');
Console.ForegroundColor = ConsoleColor.Gray;
Console.Write('\u2022');
Console.ForegroundColor = ConsoleColor.DarkBlue;
Console.Write(" Water");
Console.ForegroundColor = ConsoleColor.Gray;
Console.Write(" beats");
Console.ForegroundColor = ConsoleColor.Red;
Console.Write(" Fire" + '\n');
Console.ResetColor();
Console.Write('\n' +
                  "However, in the event of similar types of cards being played, the card with the highest number will win. If the numbers also matched, a draw will happen." + '\n' +
                  "If you want to start, press \"Enter\"");
#endregion
if (Console.ReadKey().Key == ConsoleKey.Enter)
{
    List<Card> deckP1 = DeckActions.CreateDeck();
    DeckActions.Shuffle(deckP1);
    var handP1 = GameProcess.GetHand(deckP1);
    List<Card> deckP2 = DeckActions.CreateDeck();
    DeckActions.Shuffle(deckP2);
    var handP2 = GameProcess.GetHand(deckP2);
    /*foreach (var card in handP1)
    {
        GameProcess.ShowCardinHand(card);
    }*/
    //
    //GameProcess.ShowCardinHand(deckP1[0]);
    GameProcess.ShowFullHand(deckP1);
}                     