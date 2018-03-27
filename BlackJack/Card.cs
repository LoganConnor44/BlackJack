namespace BlackJack
{
    public class Card
    {
        /// <summary>
        /// The value.
        /// </summary>
        public int Value;

        /// <summary>
        /// The suite.
        /// </summary>
        public char Suite;

        /// <summary>
        /// The face.
        /// </summary>
        public string Face;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:BlackJackConsole.Card"/> class.
        /// </summary>
        /// <param name="value">Value.</param>
        /// <param name="suite">Suite.</param>
        public Card(int value, char suite)
        {
            this.Value = value;
            if (value == 1 || value > 10)
            {
                this.SetFaceCards();
            }
            this.Suite = suite;
        }

        /// <summary>
        /// Sets the face cards.
        /// </summary>
        private void SetFaceCards()
        {
            switch (this.Value)
            {
                case 1:
                    this.Face = "Ace";
                    break;
                case 11:
                    this.Value = 10;
                    this.Face = "Jack";
                    break;
                case 12:
                    this.Value = 10;
                    this.Face = "Queen";
                    break;
                case 13:
                    this.Value = 10;
                    this.Face = "King";
                    break;
            }
        }
    }
}