using System;
using System.Collections.Generic;
using System.Linq;

namespace BlackJack
{
    /// <summary>
    /// Game logic.
    /// </summary>
    public class GameLogic
    {

        public bool GameOver;

        /// <summary>
        /// Are aces high or low?
        /// </summary>
        public bool? AcesHigh;

        /// <summary>
        /// The deck.
        /// </summary>
        private Deck _deck;

        /// <summary>
        /// Gets or sets the deck.
        /// </summary>
        /// <value>The deck.</value>
        public Deck Deck { get => _deck; set => _deck = value; }

        /// <summary>
        /// The players hand.
        /// </summary>
        public List<Card> PlayersHand;

        /// <summary>
        /// The dealers hand.
        /// </summary>
        public List<Card> DealersHand;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:BlackJackConsole.GameLogic"/> class.
        /// </summary>
        public GameLogic(Deck deck)
        {
            this._deck = deck;
            this.AcesHigh = this.SetHighOrLow();
            this._deck.SetAcesValue((bool)this.AcesHigh);
        }

        /// <summary>
        /// Sets the aces to high or low.
        /// </summary>
        /// <returns><c>true</c>, if high or low was set, <c>false</c> otherwise.</returns>
        public bool SetHighOrLow()
        {
            Console.WriteLine("Would you like Aces to be high or low?");
            string userResponse = Console.ReadLine();

            switch (userResponse.Trim().ToUpper())
            {
                case "HIGH":
                    return true;
                case "LOW":
                    return false;
                default:
                    Console.WriteLine("Not a valid response");
                    return this.SetHighOrLow();
            }
        }

        /// <summary>
        /// Start the game with these two cards.
        /// </summary>
        public void Start()
        {
            this.PlayersHand = new List<Card> {
                this._deck.RetrieveCard()
            };
            this.DealersHand = new List<Card> {
                this._deck.RetrieveCard()
            };
        }

        /// <summary>
        /// Displays the current standing.
        /// </summary>
        public void DisplayCurrentStanding()
        {
            Console.WriteLine("Your Hand");
            foreach (var card in this.PlayersHand)
            {
                Console.WriteLine(card.Value.ToString() + " of " + card.Suite.ToString());
            }

            Console.WriteLine("Dealer's Hand");
            foreach (var card in this.DealersHand)
            {
                Console.WriteLine(card.Value.ToString() + " of " + card.Suite.ToString());
            }
        }

        /// <summary>
        /// Displaies the winner.
        /// </summary>
        public void DisplayWinner()
        {
            int PlayerTotal = this.PlayersHand.Sum(card => card.Value);
            int DealerTotal = this.DealersHand.Sum(card => card.Value);
            int PlayerDifference = 21 - PlayerTotal;
            int DealerDifference = 21 - DealerTotal;
            int WinnerDifference = Math.Min(PlayerDifference, DealerDifference);

            Console.WriteLine("************");

            if (DealerTotal == 21 || PlayerDifference < 0 || WinnerDifference == DealerDifference)
            {
                Console.WriteLine("Dealer Wins.");
                Console.WriteLine("************");
                return;
            }


            if (PlayerTotal == 21 || DealerDifference < 0 || WinnerDifference == PlayerDifference)
            {
                Console.WriteLine("You Win!!!");
                Console.WriteLine("************");
                return;
            }
        }

        /// <summary>
        /// Ends the game.
        /// </summary>
        public void EndGame()
        {
            Console.WriteLine("Would you like to hit or stay?");
            string userResponse = Console.ReadLine();

            switch (userResponse.Trim().ToUpper())
            {
                case "HIT":
                    break;
                case "STAY":
                    this.GameOver = true;
                    break;
                default:
                    Console.WriteLine("Not a valid response");
                    this.EndGame();
                    break;
            }
            return;
        }

        /// <summary>
        /// Hit this instance.
        /// </summary>
        public void Hit()
        {
            this.PlayersHand.Add(this._deck.RetrieveCard());
        }

        /// <summary>
        /// Dealer's turn.
        /// </summary>
        public void DealersTurn()
        {
            int DealersSum = this.DealersHand.Sum(card => card.Value);
            if (DealersSum < 17)
            {
                this.DealersHand.Add(this._deck.RetrieveCard());
            }
        }
    }
}
