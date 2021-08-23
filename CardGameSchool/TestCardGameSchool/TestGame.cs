using Microsoft.VisualStudio.TestTools.UnitTesting;
using CardGameSchool;

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
