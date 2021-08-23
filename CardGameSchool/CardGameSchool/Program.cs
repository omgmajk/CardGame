using System;
using System.Threading;

namespace CardGameSchool
{
    // Quick enum to make a difference between suits for deck building. Not needed in the game I ended up with.
    public enum Suit { Diamonds, Clubs, Spades, Hearts }

    class Program
    {
        static void Main(string[] args)
        {
            // Start game
            Console.WriteLine("What is the name of player one? Enter for random name.");
            string first = Console.ReadLine();
            Console.WriteLine("What is the name of player two? Enter for random name.");
            string second = Console.ReadLine();
            
            // Names set to random until changed.
            Player playerOne = new Player();
            Player playerTwo = new Player();

            // If we want set names
            if (!String.IsNullOrEmpty(first))
                playerOne.Name = first;
            if (!String.IsNullOrEmpty(second))
                playerTwo.Name = second;

            // Set game modes
            Console.WriteLine("WARNING: Game is extremely dull. ");
            Console.WriteLine("Do you want to play manually? (y/yes/n/no). Auto(Empty/No).");
            string mode = Console.ReadLine();

            if (!String.IsNullOrEmpty(mode))
                if (mode[0].ToString().ToLower() == "y") Game.Automatic = true;

            var gameMode = Game.Automatic ? "Good!" : "I warned you!";
            Console.WriteLine(gameMode);

            // Game loop.
            int turns = 0;
            do
            {
                // Make the hands.
                Game.GenerateHands(playerOne, playerTwo);

                while (playerOne.Deck.Count > 0 && playerTwo.Deck.Count > 0)
                {
                    turns++;
                    Console.Clear();
                    Game.Battle(playerOne, playerTwo);
                    Console.WriteLine("\n\n\nCurrent deck count: \n" + 
                    playerOne.Name + ": " + 
                    playerOne.Deck.Count + ", " +
                    playerTwo.Name + ": " +
                    + playerTwo.Deck.Count);
                    Console.WriteLine($"Current turn: {turns}");
                    if (Game.Automatic == true)
                        Thread.Sleep(100);
                    else
                        Console.ReadLine();
                }

                Console.WriteLine(Game.Winner(playerOne, playerTwo));

                Console.WriteLine("Do you want to play again? (y/yes/n/no). Auto(Empty/No).");
                string playAgain = Console.ReadLine();

                if (!String.IsNullOrEmpty(playAgain))
                    if (playAgain[0].ToString().ToLower() == "y")
                    {
                        playerOne.Deck.Clear();
                        playerTwo.Deck.Clear();
                        continue;
                    }
                
                // Will never run if yes is entered.
                break;

            } while (true);

        }
    }
}
