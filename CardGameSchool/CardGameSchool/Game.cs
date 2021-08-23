using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace CardGameSchool
{
    public class Game
    {
        // Game rules
        private static bool automatic = false;

        public static bool Automatic { get => automatic; set => automatic = value; }

        // Returns a shuffled list of Cards.
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

        // Divides cards out to players.
        public static void GenerateHands(Player one, Player two)
        {
            var deck = Game.FillDeck();
            for (int i = deck.Count; i > 0; i--)
            {
                if (i % 2 == 0)
                {
                    one.Deck.Enqueue(deck[0]);
                    deck.RemoveAt(0);
                }
                else
                {
                    two.Deck.Enqueue(deck[0]);
                    deck.RemoveAt(0);
                }
            }
        }
        // Returns the winner.
        public static string Winner(Player one, Player two) 
                             => one.Deck.Count > two.Deck.Count ? $"{one.Name} wins the game!" : $"{two.Name} wins the game!";

        public static void Putbacks(List<Card> cards, Player player)
        {
            Random random = new Random();
            cards = cards.OrderBy(x => random.Next()).ToList();
            foreach (var card in cards)
            {
                player.Deck.Enqueue(card);
            }
        }

        // Battle method, main game.
        public static void Battle(Player one, Player two)
        {
            Card[] cards = new Card[2];
            Console.WriteLine($"{one.Name}\t\t\tVS.\t\t{two.Name}");
            Console.WriteLine("+--------------------------------------------+");
            Console.WriteLine($"{one.Deck.Peek().Name}({one.Deck.Peek().ShortName})\t\tVS.\t\t{two.Deck.Peek().Name}({two.Deck.Peek().ShortName})");

            if(one.Deck.Peek().Value > two.Deck.Peek().Value)
            {
                Console.WriteLine("+--------------------------------------------+");
                Console.WriteLine($"{one.Name} wins!");
                cards[0] = one.Deck.Dequeue();
                cards[1] = two.Deck.Dequeue();
                Putbacks(cards.ToList(), one);
            }
            else if(one.Deck.Peek().Value < two.Deck.Peek().Value)
            {
                Console.WriteLine("+--------------------------------------------+");
                Console.WriteLine($"{two.Name} wins!");
                cards[0] = one.Deck.Dequeue();
                cards[1] = two.Deck.Dequeue();
                Putbacks(cards.ToList(), two); 
            }
            else
            {
                War(one, two);
            }
        }

        // War method, main game.
        public static void War(Player one, Player two)
        {
            Console.WriteLine("+--------------------------------------------+");
            Console.WriteLine("One, two, three, four... I declare a card war!");

            // Check if any player has too few cards...
            if(one.Deck.Count < 4)
            {
                Console.WriteLine($"{one.Name} has too few cards!");
                one.Deck.Clear();
                return;
            }
            if(two.Deck.Count < 4)
            {
                Console.WriteLine($"{two.Name} has too few cards!");
                two.Deck.Clear();
                return;
            }
            // If both players has enough cards. Go go go! War!

            Card[] cards = new Card[8];
            //Console.WriteLine($"{one.Name}\t\tVS.\t\t{two.Name}");
            Console.WriteLine("+--------------------------------------------+");
            cards[0] = one.Deck.Dequeue();
            cards[1] = one.Deck.Dequeue();
            cards[2] = one.Deck.Dequeue();
            cards[3] = one.Deck.Dequeue();
            cards[4] = two.Deck.Dequeue();
            cards[5] = two.Deck.Dequeue();
            cards[6] = two.Deck.Dequeue();
            cards[7] = two.Deck.Dequeue();

            // Player's last cards vs eachother.
            for (int i = cards.Length; i > 0 ; i-=2)
            {
                
                Console.WriteLine($"{cards[i-5].Name}({cards[i-5].ShortName})\t\tVS.\t\t{cards[i-1].Name}({cards[i-1].ShortName})");
                Thread.Sleep(4000);
                if (cards[i - 1].Value < cards[i - 5].Value)
                {
                    Console.WriteLine($"{one.Name} wins the war!");
                    Thread.Sleep(500);
                    Putbacks(cards.ToList(), one);
                    break;
                }
                else if (cards[i - 1].Value > cards[i - 5].Value)
                {
                    Console.WriteLine($"{two.Name} wins the war!");
                    Thread.Sleep(500);
                    Putbacks(cards.ToList(), two);
                    break;
                }
                else 
                {
                    Console.WriteLine("The war is a draw!");
                    Thread.Sleep(500);
                    continue;
                }
                     
            }
        }

        
    }
}
