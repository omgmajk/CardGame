using CardGameSchool;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCardGameSchool
{
    [TestClass]
    public class TestGame
    {
        [TestMethod]
        public void TestDeck()
        {
            Assert.AreEqual(52, Game.FillDeck().Count);
        }
        [TestMethod]
        public void TestHands()
        {
            Player one = new Player();
            Player two = new Player();
            Game.GenerateHands(one, two);
            Assert.AreEqual(26, one.Deck.Count);
            Assert.AreEqual(26, two.Deck.Count);
        }
        [TestMethod]
        public void TestDraw()
        {
            Player one = new Player();
            Player two = new Player();
            // Generate cards for a single Battle;
            one.Deck.Enqueue(new Card()
            {
                Suit = Suit.Clubs,
                Value = 10,
                Name = Card.GetLongName(10, Suit.Clubs),
                ShortName = Card.GetShortName(10, Suit.Clubs)
            });
            two.Deck.Enqueue(new Card()
            {
                Suit = Suit.Hearts,
                Value = 10,
                Name = Card.GetLongName(11, Suit.Hearts),
                ShortName = Card.GetShortName(11, Suit.Hearts)
            });
            Game.Battle(one, two);
            Assert.AreEqual(2, two.Deck.Count);
            Assert.AreEqual(0, one.Deck.Count);
        }
        // Test if cards are put back if war is a total draw.
        [TestMethod]
        public void TestWar()
        {
            Player one = new Player();
            Player two = new Player();
            one.Deck.Enqueue(new Card()
            {
                Suit = Suit.Clubs,
                Value = 10,
                Name = Card.GetLongName(10, Suit.Clubs),
                ShortName = Card.GetShortName(10, Suit.Clubs)
            });
            two.Deck.Enqueue(new Card()
            {
                Suit = Suit.Hearts,
                Value = 10,
                Name = Card.GetLongName(11, Suit.Hearts),
                ShortName = Card.GetShortName(11, Suit.Hearts)
            });
            one.Deck.Enqueue(new Card()
            {
                Suit = Suit.Clubs,
                Value = 10,
                Name = Card.GetLongName(10, Suit.Clubs),
                ShortName = Card.GetShortName(10, Suit.Clubs)
            });
            two.Deck.Enqueue(new Card()
            {
                Suit = Suit.Hearts,
                Value = 10,
                Name = Card.GetLongName(11, Suit.Hearts),
                ShortName = Card.GetShortName(11, Suit.Hearts)
            });
            one.Deck.Enqueue(new Card()
            {
                Suit = Suit.Clubs,
                Value = 10,
                Name = Card.GetLongName(10, Suit.Clubs),
                ShortName = Card.GetShortName(10, Suit.Clubs)
            });
            two.Deck.Enqueue(new Card()
            {
                Suit = Suit.Hearts,
                Value = 10,
                Name = Card.GetLongName(11, Suit.Hearts),
                ShortName = Card.GetShortName(11, Suit.Hearts)
            });
            one.Deck.Enqueue(new Card()
            {
                Suit = Suit.Clubs,
                Value = 10,
                Name = Card.GetLongName(10, Suit.Clubs),
                ShortName = Card.GetShortName(10, Suit.Clubs)
            });
            two.Deck.Enqueue(new Card()
            {
                Suit = Suit.Hearts,
                Value = 10,
                Name = Card.GetLongName(11, Suit.Hearts),
                ShortName = Card.GetShortName(11, Suit.Hearts)
            });
            Game.War(one, two);
            Assert.AreEqual(4, one.Deck.Count);
            Assert.AreEqual(4, two.Deck.Count);
        }
    }
    [TestClass]
    public class TestCardNames
    {
        [TestMethod]
        public void TestName()
        {
            Assert.AreEqual("Ace of Spades", Card.GetLongName(14, Suit.Spades));
        }
        [TestMethod]
        public void TestShortName()
        {
            Assert.AreEqual("A♠", Card.GetShortName(14, Suit.Spades));
        }
    }
}
