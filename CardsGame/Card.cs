namespace CardsGame
{
    struct Card
    {
        Number number;
        Suits suit;
        

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
                if (number > opponentCard.number)
                {
                    return true;
                }
                return false;
            }
            else if ((Deck.TrumpSuit==suit) && (Deck.TrumpSuit!=opponentCard.suit))
            {
                return true;
            }
            else
            {
                return false;
            }
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
