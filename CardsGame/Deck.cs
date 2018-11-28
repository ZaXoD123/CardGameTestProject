using System;

namespace CardsGame
{
    internal class Deck : CardList
    {
        public static Deck singleTone;

        //Конструктор

        private Deck()
        {
            for (var suit = 0; suit <= 3; suit++)
            for (var num = 2; num <= 14; num++)
                deckOfCards.Add(new Card((Number) num, (Suits) suit, false));
            Shuffle();
            TrumpSuit = ShowLast().ShowSuit();
        }

        public static Suits TrumpSuit { get; private set; }

        //SingleTone 
        public static Deck AddChild()
        {
            if (singleTone == null)
            {
                singleTone = new Deck();
                return singleTone;
            }

            return singleTone;
        }

        //Показать последнюю карту
        public Card ShowLast()
        {
            return deckOfCards[deckOfCards.Count - 1];
        }

        //Снять верхнюю карту
        public Card Pop()
        {
            return base.Pop(0);
        }

        //Перемешать
        public void Shuffle()
        {
            for (var j = 0; j < deckOfCards.Count / 2; j++)
            for (var i = 0; i < deckOfCards.Count; i++)
            {
                var tempRandom = new Random().Next(i, deckOfCards.Count);
                var tempCard = deckOfCards[i];
                deckOfCards[i] = deckOfCards[tempRandom];
                deckOfCards[tempRandom] = tempCard;
            }
        }
    }
}