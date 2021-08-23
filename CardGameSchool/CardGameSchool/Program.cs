using System;

namespace CardGameSchool
{
    // Quick enum to make a difference between suits for deck building. Not needed in the game I ended up with.
    public enum Suit { Diamonds, Clubs, Spades, Hearts }

    class Program
    {
        static void Main(string[] args)
        {
            // Save these "♠♥♦♣"

            Player mike = new Player("Mike");
            Card aceofspades = new Card();
            aceofspades.Name = "Ace of Spades";
            aceofspades.Suit = Suit.Spades;
            aceofspades.Value = 14;
            aceofspades.ShortName = "♠A";

            // Actually works! Three cards in the deck.
            mike.Deck.Enqueue(aceofspades);
            mike.Deck.Enqueue(aceofspades);
            mike.Deck.Enqueue(aceofspades);
            var test = mike.Deck.Peek();
            Console.WriteLine(Card.GetLongName(aceofspades));
            Console.WriteLine(test.ShortName);
            Console.WriteLine(mike.Deck.Count);
        }
    }
}
