using System;
using System.Collections.Generic;

namespace CardGameSchool
{

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
        private Queue<Card> hand = new Queue<Card>();

        public Player(string name)
        {
            Name = name;
        }
        public Player()
        {
            Name = "John Doe";
        }

        public Queue<Card> Hand { get => hand; set => hand = value; }
        public string Name { get => name; set => name = value; }
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
            mike.Hand.Enqueue(aceofspades);
            var test = mike.Hand.Peek();
            Console.WriteLine(test.Value);
        }
    }
}
