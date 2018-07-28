﻿using System.Collections.Generic;

namespace CardsGame
{
    abstract class CardList
    {
        protected List<Card> deckOfCards = new List<Card>();
        
        //Осталось карт
        public int Remained()
        {
            return deckOfCards.Count;
        }
        
        //Удалить карту
        public virtual Card Pop(int i)
        {
            Card temp = deckOfCards[i];
            deckOfCards.RemoveAt(i);
            return temp;
        }
    }
}
