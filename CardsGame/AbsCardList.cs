using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardsGame
{
    abstract class CardList
    {
        protected List<Card> deckOfCards = new List<Card>();
        //Показать
        abstract public void Show();

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
