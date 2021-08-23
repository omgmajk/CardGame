using System;

namespace CardGameSchool
{
    // Quick enum to make a difference between suits for deck building. Not needed in the game I ended up with.
    public enum Suit { Diamonds, Clubs, Spades, Hearts }

    class Program
    {
        static void Main(string[] args)
        {
            // Uncomment later
            //Console.WriteLine("What is the name of player one?");
            //string first = Console.ReadLine();
            //Console.WriteLine("What is the name of player two?");
            //string second = Console.ReadLine();

            // Testing things
            Player playerOne = new Player();
            Player playerTwo = new Player();

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
        }
    }
}
