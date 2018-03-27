using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlackJack;

namespace BlackJackTest {
    [TestClass]
    public class CardTests {
        [TestMethod]
        public void TestInstantiation() {
            Card card = new Card(4, 'H');
            Assert.IsInstanceOfType(card, typeof(Card));
        }
        [TestMethod]
        public void TestSetFaceCards() {
            Card Ace = new Card(1, 'H');
            Assert.AreEqual("Ace", Ace.Face);

            Card Jack = new Card(11, 'H');
            Assert.AreEqual("Jack", Jack.Face);

            Card Queen = new Card(12, 'H');
            Assert.AreEqual("Queen", Queen.Face);

            Card King = new Card(13, 'H');
            Assert.AreEqual("King", King.Face);
        }
    }
}