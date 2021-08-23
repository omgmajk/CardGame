using System;

namespace CardGameSchool
{
    public class Card
    {
        private string _name;
        private Suit _suit;
        private int _value;
        private string _shortName;

        public string Name { get => _name; set => _name = value; }
        public Suit Suit { get => _suit; set => _suit = value; }
        public int Value { get => _value; set => this._value = value; }
        public string ShortName { get => _shortName; set => _shortName = value; }

        public static string GetString(int val)
        {
            switch (val)
            {
                case <= 10: // Must be compiled with .NET 5.0
                    return val.ToString();
                case 11:
                    return "Jack";
                case 12:
                    return "Queen";
                case 13:
                    return "King";
                case 14:
                    return "Ace";
                default:
                    return "Something went wrong...";
            }
        }

        public static string GetLongName(Card card){
            if (card.Value > 10)
                return $"{GetString(card.Value)} of {card.Suit}";
            else
                return $"{card.Value} of {card.Suit}";
        }
    }
}
