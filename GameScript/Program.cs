using GameScript.Game;
using static GameScript.ExtendedFunc;
using static GameScript.Game.BotActions;
using static GameScript.Game.GameProcesses;
using static GameScript.Game.DeckActions;
using GameScript.Useful_Functions;

Program1.ShowWindow(Program1.ThisConsole, Program1.MAXIMIZE);
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
    
    CConsole.Write($"\n\u2022 {"Fire":red} beats {"Snow":white}\n");
    CConsole.Write($"\u2022 {"Water":cyan} beats {"Fire":red}\n");
    CConsole.Write($"\u2022 {"Snow":white} beats {"Water":cyan}\n");
    Console.Write('\n' +
                  "However, in the event of similar types of cards being played, the card with the highest number will win. If the numbers also matched, a draw will happen." +
                  '\n' +
                  "If you want to start, press \"Enter\"");

    #endregion


    if (Console.ReadKey().Key == ConsoleKey.Enter)
    {
       int diff = 0;
        ConsoleKey pressedKey;
        while (diff is not (1 or 2 or 3)) 
        {
            Console.Clear();
            Console.Write("Choose difficulty:" + '\n' +
                      "1: Easy - Chance to get good response is 10%" + '\n' +
                      "2: Standard - Bot will play as good as he can" + '\n'+ 
                      "3: No chance to win. Bot has in hand all of card library");
            pressedKey = Console.ReadKey().Key;
            int temp=0;
            if (int.TryParse(pressedKey.ToString().Remove(0, 1), out temp))
            {
                diff = int.Parse(pressedKey.ToString().Remove(0, 1));
            }
        } 
        bool gameison = true;
        while (gameison)
        {
            var botLennys = new List<string>();
            var playerLennys = new List<string>();
            var usedlennys = new List<string>();
            var usedcards = new List<Card>();
            var cardhistory = new List<List<Card>>();
            var lennyElementP1 = new List<string[]>();
            var lennyElementP2 = new List<string[]>();
            bool winner = true;
            while (gameison)
            {
                List<Card> deckP1 = CreateDeck(), deckP2 = CreateDeck();
                Shuffle(deckP1);
                Shuffle(deckP2);
                List<Card> handP1 = GetHand(deckP1), handP2 = GetHand(deckP2);
                while (gameison)
                {
                    var playerCard = PlayerTurn(handP1, cardhistory, lennyElementP1, lennyElementP2,diff,out diff);
                    var botCard = BotTurn(diff, playerCard, usedcards, usedlennys, deckP2, handP2);
                    cardhistory.Add(new List<Card>() { playerCard, botCard });
                    handP1.Remove(playerCard);
                    GetCardFromDeck(deckP1, handP1);
                    Console.WriteLine();
                    if (CompareCards(playerCard, botCard))
                    {
                        playerLennys.Add(playerCard.Lenny);
                        lennyElementP1.Add(new[] { playerCard.Lenny, playerCard.Element });
                        if (VictoryCondition(playerLennys))
                        {
                            gameison = false;
                        }
                    }
                    else if (CompareCards(botCard, playerCard) && !SameCards(playerCard, botCard))
                    {
                        botLennys.Add(botCard.Lenny);
                        lennyElementP2.Add(new[] { botCard.Lenny, botCard.Element });
                        if (VictoryCondition(botLennys))
                        {
                            winner = false;
                            gameison = false;
                        }
                    }
                }

                if (winner)
                {
                    OutputBox(winner);
                    Thread.Sleep(1500);
                }
                else
                {
                    OutputBox(winner);
                    Thread.Sleep(1500);
                }
            }
            EndBox();
            pressedKey = Console.ReadKey().Key;
            if (pressedKey != ConsoleKey.E)
            {
                Environment.Exit(0);
            }
            gameison = true;
        }
    }
