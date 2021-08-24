using System;
using System.Collections.Generic;

namespace CardGameSchool
{
    public class Player
    {
        // Player data
        private string _name;
        private Queue<Card> _deck = new Queue<Card>();

        public Player(string name)
        {
            Name = name;
        }

        // If no name was given.
        public Player()
        {
            Random random = new Random();
            string[] randoms = new string[] { "John", "Mark", "Mike", "Martin", "Thomas", "Daniel", "Jessica", "Anna", "Emma", "Jenny", "Sanna", "Alexandra" };
            Name = randoms[random.Next(0, randoms.Length - 1)];
        }

        public string Name { get => _name; set => _name = value; }
        public Queue<Card> Deck { get => _deck; set => _deck = value; }
    }
}
