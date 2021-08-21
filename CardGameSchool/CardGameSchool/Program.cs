using System;
using System.Collections.Generic;

namespace CardGameSchool
{

    public enum Cards
    {
        Two = 2,
        Three = 3,
        Four = 4,
        Five = 5,
        Six = 6,
        Seven = 7,
        Eight = 8,
        Nine = 9,
        Ten = 10,
        Jack = 11,
        Queen = 12,
        King = 13,
        Ace = 14
    }

    class Program
    {
        static void Main(string[] args)
        {
            Queue<Enum> deck = new Queue<Enum>();
            deck.Enqueue(Cards.Ace);
            deck.Enqueue(Cards.Two);
            deck.Enqueue(Cards.Three);
            var currentCard = deck.Dequeue();
        }
    }
}
