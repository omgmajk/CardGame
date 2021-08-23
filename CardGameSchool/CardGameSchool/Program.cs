using System;

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

            // Set game mode
            Console.WriteLine("Do you want to play manually? (y/yes/n/no) WARNING: Game is extremely dull...");
            string mode = Console.ReadLine();

            if (!String.IsNullOrEmpty(mode))
                if (mode[0].ToString().ToLower() == "y") Game.Automatic = true;

            // Make the hands.
            Game.GenerateHands(playerOne, playerTwo);

        }
    }
}
