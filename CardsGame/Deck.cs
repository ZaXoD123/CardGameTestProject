using System;

namespace CardsGame 
{
    class Deck : CardList
    {
        static public Deck singleTone = null;
        static public Suits TrumpSuit { get; } /*= (Suits)0;*/ = (Suits)(new Random().Next(0, 3));
        //List<Card> deckOfCards = new List<Card>(52);
        
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

        //Показать колоду
        //TODO: Сделать через return
        public override void Show()
        {
            UserInterface.Print(deckOfCards);               
        }

        public void Show(int index)
        {
            UserInterface.Print(deckOfCards[index]); 
        }

        public void Show(int indexStart, int indexStop)
        {
            for (int i = indexStart; i < indexStop; i++)
            {
                UserInterface.Print(deckOfCards[i]);
            }
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

        //TODO: Перемешать
    }
}
