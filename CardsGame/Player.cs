using System;
using System.Collections.Generic;
using System.Linq;


namespace CardsGame
{
    class Player : CardList
    {
        #region Ввод и вывод руки
        //взять карту
        public void Catch(List<Card> newCards)
        {
            deckOfCards.AddRange(newCards);
        }
        public void Catch(Card a)
        {
            deckOfCards.Add(a);
        }

        //заполнить руку из колоды
        public void CatchFromDeck(Deck deck)
        {
            while ((deckOfCards.Count < 6) && (deck.Remained() > 0))
            {
                Catch(deck.Pop());
            }
        }
        //показать
        public void Show()
        {
            UI.ST.ShowPlayerHand(deckOfCards);
        }
        #endregion

        #region Атака и защита
        //атака
        public void Punch(List<Card> table, ref Deck myDeck)
        {
            List<Card> punchList = new List<Card>();



            startIn:
            punchList.Clear();
            int temp = ConsoleUserInterface.Input();
            if (!((temp >= 0) && (temp <= deckOfCards.Count() - 1)))
            {
                UI.ST.PrintFail(1);
                goto startIn;
            }
            punchList.Add(Pop(temp));
            if (deckOfCards.Contains(punchList[punchList.Count() - 1]))
            {
                // TODO спросить хочет ли игрок положить ещё одну карту
                // и если да, то доложить
            }
            table.AddRange(punchList);

        }

        //защита
        public bool Answer(List<Card> table)
        {
            //TODO: Сделать отмену
            //Проверка: Можно ли побить
            if (!CanFight(table))
            {
                return false;
            }

            List<int> answerList = new List<int>();

            for (int i = 0; i < table.Count(); i++)
            {
                UI.ST.MessageWithCard(table[i], 2);


                //Ввод карт для ответа
                StartInput:
                int tempUserInput = UI.ST.Input(); //
                if ((deckOfCards.Count() > tempUserInput) && (tempUserInput > -2))
                {
                    if (tempUserInput == -1)
                    {
                        Catch(table);
                        table.Clear();
                        return false;
                    }
                    else
                    {
                        if (deckOfCards[tempUserInput].Fight(table[i]))
                        {
                            if (answerList.Contains(tempUserInput))
                            {
                                UI.ST.PrintFail(0);
                                goto StartInput;
                            }
                            else
                                answerList.Add(tempUserInput);
                        }
                        else
                        {
                            UI.ST.MessageWithCard(table[i], 0);
                            goto StartInput;
                        }
                    }
                }
                else
                {
                    UI.ST.PrintFail(1);
                    goto StartInput;
                }
            }
            foreach (var i in answerList)
            {
                Pop(i);
            }
            return true;
        }
        #endregion

        #region Вспомогательные
        // Проверка способности побить стол
        bool CanFight(List<Card> table)
        {
            List<Card> checkList = new List<Card>();

            foreach (var i in table)
            {
                bool temp = false;
                foreach (var j in deckOfCards)
                {
                    if ((j.Fight(i)) && (!checkList.Contains(j)))
                    {
                        temp = true;
                        checkList.Add(j);
                    }
                }
                if (temp == false)
                {
                    UI.ST.MessageWithCard(i, 1);
                    Catch(table);
                    table.Clear();
                    return false;
                }
            }
            return true;
        }
        //если карты закончились у всех игроков кроме одного то true
        public static bool GameOver(List<Player> players, Deck deck)
        {
            int temp = 0;
            foreach (Player i in players)
            {
                if (i.Remained() == 0) temp++;
            }
            if ((temp == players.Count - 1) && (deck.Remained() == 0))
            {
                return true;
            }
            else return false;
        }
        #endregion
    }
}