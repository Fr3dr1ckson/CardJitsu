using System.Text;
using GameScript.Game;
using static GameScript.ExtendedFunc;
using static GameScript.Game.BotActions;
using static GameScript.Game.GameProcesses;
using static GameScript.Game.GameScreens;

Program1.ShowWindow(Program1.ThisConsole, Program1.MAXIMIZE);

    


    Start();
    Console.OutputEncoding = Encoding.UTF8;
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
            var usedLennys = new List<string>();
            var usedCards = new List<Card>();
            var cardHistory = new List<List<Card>>();
            bool winner = true;
            while (gameison)
            {
                var Player = new Player(false);
                var Bot = new Player(true);
                Player.Deck.Shuffle();
                Bot.Deck.Shuffle();
                while (gameison)
                {
                    var playerCard = PlayerTurn(Player, Bot, cardHistory,diff,out diff);
                    var botCard = BotTurn(diff, playerCard, usedCards, usedLennys, Bot);
                    cardHistory.Add(new List<Card> { playerCard, botCard });
                    Player.TakeNewCard(playerCard);
                    Console.WriteLine();
                    if (CompareCards(playerCard, botCard))
                    {
                        Player.WinLennys.Add(playerCard.Lenny);
                        if (Player.WinCondition())
                        {
                            gameison = false;
                        }
                    }
                    else if (CompareCards(botCard, playerCard) && !SameCards(playerCard, botCard))
                    {
                        Bot.WinLennys.Add(botCard.Lenny);
                        if (Bot.WinCondition())
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
