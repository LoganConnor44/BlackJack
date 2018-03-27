using System.Collections.Generic;

namespace BlackJack
{
    public class Deck
    {
        /// <summary>
        /// Are aces high?
        /// </summary>
        private bool _acesHigh;

        /// <summary>
        /// Suites available for a deck.
        /// </summary>
        private enum Suites
        {
            heart = 'H',
            diamond = 'D',
            spade = 'S',
            club = 'C'
        };

        /// <summary>
        /// The cards.
        /// </summary>
        private List<Card> _cards;

        /// <summary>
        /// Gets or sets the cards.
        /// </summary>
        /// <value>The cards.</value>
        public List<Card> Cards { get => _cards; set => _cards = value; }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:BlackJack.Deck"/> class.
        /// </summary>
        public Deck()
        {
            this._cards = new List<Card>();
            this.BuildDeck();
            this._cards.Shuffle();
        }

        /// <summary>
        /// Sets the aces value.
        /// </summary>
        /// <param name="AcesHigh">If set to <c>true</c> aces high.</param>
        public void SetAcesValue(bool AcesHigh)
        {
            this._acesHigh = AcesHigh;
        }

        /// <summary>
        /// Builds the deck.
        /// </summary>
        private void BuildDeck()
        {
            for (int i = 1; i <= 13; i++)
            {
                Card heartCard = new Card(i, (char)Suites.heart);
                this._cards.Add(heartCard);
                Card diamondCard = new Card(i, (char)Suites.diamond);
                this._cards.Add(diamondCard);
                Card spadeCard = new Card(i, (char)Suites.spade);
                this._cards.Add(spadeCard);
                Card clubCard = new Card(i, (char)Suites.club);
                this._cards.Add(clubCard);
            }
        }

        public Card RetrieveCard()
        {
            this._cards.Shuffle();
            Card dealtCard = this._cards[0];
            this._cards.RemoveAt(0);
            return dealtCard;
        }
    }
}