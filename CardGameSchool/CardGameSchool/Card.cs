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

        // Simple switch to get the name of the card for the long card name.
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

        // Returns the card's short name. Example A♦
        public static string GetShortName(int val, Suit suit)
        {
            // Same order as enum in Program.cs
            char[] suitShort = new char[] { '♦', '♣', '♠', '♥' };

            switch (val)
                {
                    case < 11:
                        return val.ToString() + $"{suitShort[(int)suit]}";
                    case 11:
                        return "J" + $"{suitShort[(int)suit]}";
                    case 12:
                        return "Q" + $"{suitShort[(int)suit]}";
                case 13:
                        return "K" + $"{suitShort[(int)suit]}";
                case 14:
                        return "A" + $"{suitShort[(int)suit]}";
                default:
                        return "Something went wrong...";
            }
        }

        // Gets the long name of a card, example Ace of Spades
        public static string GetLongName(int val, Suit suit)
        {
            if (val > 10)
                return $"{GetString(val)} of {suit.ToString()}";
            else
                return $"{val} of {suit.ToString()}";
        }
    }
}
