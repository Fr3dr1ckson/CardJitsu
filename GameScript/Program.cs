using System.Runtime.InteropServices;
using GameScript;
using static GameScript.ExtendedFunc;
using static GameScript.BotActions;
using static GameScript.GameProcesses;
using static GameScript.DeckActions;


Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
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
    Console.Write(" Water " + '\n');
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
                  "However, in the event of similar types of cards being played, the card with the highest number will win. If the numbers also matched, a draw will happen." +
                  '\n' +
                  "If you want to start, press \"Enter\"");

    #endregion

    if (Console.ReadKey().Key == ConsoleKey.Enter)
    {
        Console.Write("Choose difficulty:" + '\n' +
                      "1: Easy - Chance to get good response is 10%" + '\n' +
                      "2: Standard - Bot will play as good as he can" + '\n'
                      + "3: No chance to win. Bot has in hand all of card library");
        byte diff = byte.Parse(Console.ReadLine());
        var botLennys = new List<string>();
        var playerLennys = new List<string>();
        var usedlennys = new List<string>();
        var usedcards = new List<Card>();
        var cardhistory = new List<List<Card>>();
        bool winner = true;
        bool gameison = true;
        List<Card> deckP1 = CreateDeck(), deckP2 = CreateDeck();
        Shuffle(deckP1);
        Shuffle(deckP2);
        List<Card> handP1 = GetHand(deckP1), handP2 = GetHand(deckP2);
        while (gameison)
        {
            var playerCard = PlayerTurn(deckP1, handP1, playerLennys, botLennys, cardhistory);
            var botCard = BotTurn(diff, playerCard, usedcards, usedlennys, deckP2, handP2);
            cardhistory.Add(new List<Card>() { playerCard, botCard });
            handP1.Remove(playerCard);
            GetCardFromDeck(deckP1, handP1);
            Console.WriteLine();
            ShowCardinHand(botCard);
            if (CompareCards(playerCard, botCard))
            {
                playerLennys.Add(playerCard.Lenny);
                if (botLennys.Count >= 3 && VictoryCondition(botLennys))
                {
                    gameison = false;
                }
            }
            else if (SameCards(playerCard, botCard))
            {
            }
            else
            {
                botLennys.Add(botCard.Lenny);
                if (botLennys.Count >= 3 && VictoryCondition(botLennys))
                {
                    winner = false;
                    gameison = false;
                }
            }

        }

        if (winner)
            OutputBox(winner);
        OutputBox(botLennys);

        /*
         catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }*/
    }

    else
    {
        Environment.Exit(0);
    }
