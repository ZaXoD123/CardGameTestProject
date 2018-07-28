using System;
using System.Collections.Generic;

namespace CardsGame 
{
    class Deck : CardList
    {
        static public Deck singleTone = null;
        static Suits trumpSuit;
        static public Suits TrumpSuit
        {
            get
            {
                return trumpSuit;
            }
        }
        
        //Конструктор

        private Deck()
        {
            for (int suit =  0; suit <= 3; suit++)
            {
                for (int num = 2; num <= 14; num++)
                {
                    deckOfCards.Add(new Card((Number) num, (Suits) suit ,false));
                }
            }
            Shuffle();
            trumpSuit = ShowLast().ShowSuit(); 
        }

        //SingleTone 
        public static Deck AddChild()
        {
            if (singleTone == null)
            {
                singleTone = new Deck();
                return singleTone;
            }
            else
            {
                return singleTone;
            }
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
            for (int j = 0; j < deckOfCards.Count/2; j++)
            {
                for (int i = 0; i < deckOfCards.Count; i++)
                {
                    int tempRandom = new Random().Next(i, deckOfCards.Count);
                    Card tempCard = deckOfCards[i];
                    deckOfCards[i] = deckOfCards[tempRandom];
                    deckOfCards[tempRandom]  = tempCard;

                }
            }
        }
    }
}
