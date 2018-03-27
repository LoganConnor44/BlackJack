using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlackJack;

namespace BlackJackTest {
    [TestClass]
    public class DeckTests {
        [TestMethod]
        public void TestInstantiation() {
            Deck deck = new Deck();
            Assert.IsInstanceOfType(deck, typeof(Deck));
        }
        [TestMethod]
        public void TestTotalNumberOfCardsInDeck() {
            Deck deck = new Deck();
            Assert.AreEqual(52, deck.Cards.Count);
        }
    }
}