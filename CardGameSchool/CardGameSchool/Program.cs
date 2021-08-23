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
            var deck = Game.FillDeck();
            for (int i = deck.Count; i > 0; i--)
            {
                if (i % 2 == 0)
                {
                    playerOne.Deck.Enqueue(deck[0]);
                    deck.RemoveAt(0);
                }
                else
                {
                    playerTwo.Deck.Enqueue(deck[0]);
                    deck.RemoveAt(0);
                }
            }
            Console.WriteLine(playerOne.Name + " " + playerTwo.Name + " " + Game.Automatic.ToString());
        }
    }
}
