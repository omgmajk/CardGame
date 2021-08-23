using System;

namespace CardGameSchool
{
    // Quick enum to make a difference between suits for deck building. Not needed in the game I ended up with.
    public enum Suit { Diamonds, Clubs, Spades, Hearts }
    
    public class Card
    {
        private string _name;
        private Suit _suit;
        private int _value;

        public string Name { get => _name; set => _name = value; }
        public Suit Suit { get => _suit; set => _suit = value; }
        public int Value { get => _value; set => this._value = value; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Player mike = new Player("Mike");
            Card aceofspades = new Card();
            aceofspades.Name = "Ace of Spades";
            aceofspades.Suit = Suit.Spades;
            aceofspades.Value = 14;
            
            // Actually works! Three cards in the deck.
            mike.Deck.Enqueue(aceofspades);
            mike.Deck.Enqueue(aceofspades);
            mike.Deck.Enqueue(aceofspades);
            var test = mike.Deck.Peek();
            Console.WriteLine(test.Value);
            Console.WriteLine(mike.Deck.Count);
        }
    }
}
