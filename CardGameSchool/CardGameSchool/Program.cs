using System;
using System.Collections.Generic;

namespace CardGameSchool
{
    // Quick enum to make a difference between suits for deck building.
    public enum Suit
    {
        Diamonds,
        Clubs,
        Spades,
        Hearts
    }
    
    public class Card
    {
        private string name;
        private Suit suit;
        private int value;

        public string Name { get => name; set => name = value; }
        public Suit Suit { get => suit; set => suit = value; }
        public int Value { get => value; set => this.value = value; }
    }

    public class Player
    {
        private string name;
        private Queue<Card> deck = new Queue<Card>();

        public Player(string name)
        {
            Name = name;
        }
        public Player()
        {
            Name = "John Doe";
        }

        public string Name { get => name; set => name = value; }
        public Queue<Card> Deck { get => deck; set => deck = value; }
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
