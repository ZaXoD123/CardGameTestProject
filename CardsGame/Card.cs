namespace CardsGame
{
    internal struct Card
    {
        private readonly Number number;
        private readonly Suits suit;


        public Card(Number number, Suits suit, bool isTrump)
        {
            this.number = number;
            this.suit = suit;
        }

        //Бьёт ли эта карта другую карту
        public bool Fight(Card opponentCard)
        {
            if (suit == opponentCard.suit)
            {
                if (number > opponentCard.number) return true;
                return false;
            }

            if (Deck.TrumpSuit == suit && Deck.TrumpSuit != opponentCard.suit)
                return true;
            return false;
        }

        //Показать карту
        public string Show()
        {
            return $"{number} of {suit}";
        }

        public Suits ShowSuit()
        {
            return suit;
        }

        public Number ShowNumber()
        {
            return number;
        }
    }
}