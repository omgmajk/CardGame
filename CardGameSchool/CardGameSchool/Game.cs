using System;
using System.Collections.Generic;
using System.Linq;

namespace CardGameSchool
{
    public static class Game
    {
        public static List<Card> FillDeck()
        {
            List<Card> deck = new List<Card>();

            foreach (Suit suit in Enum.GetValues(typeof(Suit)))
            {
                for (int i = 2; i <= 14; i++)
                {
                    deck.Add(new Card()
                    {
                        Suit = suit,
                        Value = i,
                        Name = Card.GetLongName(i, suit),
                        ShortName = Card.GetShortName(i, suit)
                    });

                }
            }
            Random random = new Random();
            return deck.OrderBy(x => random.Next()).ToList();
        }
        
    }
}
