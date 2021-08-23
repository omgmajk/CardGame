using System.Collections.Generic;

namespace CardGameSchool
{
    public class Player
    {
        private string _name;
        private Queue<Card> _deck = new Queue<Card>();

        public Player(string name)
        {
            Name = name;
        }

        public Player()
        {
            Name = "John Doe";
        }

        public string Name { get => _name; set => _name = value; }
        public Queue<Card> Deck { get => _deck; set => _deck = value; }
    }
}
