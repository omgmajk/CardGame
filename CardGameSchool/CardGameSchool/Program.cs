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
            // Game main screen and display rules.
            Console.Title = "War Game";
            Console.WriteLine("Welcome to...");
            Console.WriteLine(
            @"
         __      __  _____ __________ 
        /  \    /  \/  _  \\______   \
        \   \/\/   /  /_\  \|       _/
         \        /    |    \    |   \
          \__/\  /\____|__  /____|_  /
               \/         \/       \/ 
        A game interpretation by Mike.
        ");

            Console.WriteLine("\n\nPress enter to continue.");
            Console.ReadLine();

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
                if (mode[0].ToString().ToLower() == "y") Game.Automatic = false;

            // Second warning...
            var gameMode = Game.Automatic ? "Good! The game will sleep for 0.1s each turn." + " Press enter to begin." : "I warned you!" + " Press enter to begin.";
            Console.WriteLine(gameMode);
            Console.ReadLine();

            if (Game.Automatic == false)
            {
                Console.Clear();
                Console.WriteLine("All you can do is press enter, the game has no player logic. Press enter to begin.");
                Console.ReadLine();
            }

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
                    +playerTwo.Deck.Count);
                    Console.WriteLine($"Current turn: {turns}");
                    if (Game.Automatic == true)
                        Thread.Sleep(100);
                    else
                    {
                        Console.WriteLine("\n\n\nPress enter to flip next card...");
                        Console.ReadLine();
                    }
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

                // Will never break if yes is entered.
                break;

            } while (true);

        }
    }
}
