using System.Collections.Generic;
using System.Linq;

namespace CardsGame
{
    internal class Player : CardList
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
            while (deckOfCards.Count < 6 && deck.Remained() > 0) Catch(deck.Pop());
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
            var punchList = new List<Card>();


            startIn:
            punchList.Clear();
            var temp = ConsoleUserInterface.Input();
            if (!(temp >= 0 && temp <= deckOfCards.Count() - 1))
            {
                UI.ST.PrintFail(1);
                goto startIn;
            }

            punchList.Add(Pop(temp));
            if (deckOfCards.Contains(punchList[punchList.Count() - 1]))
            {
                // TODO: Спросить хочет ли игрок положить ещё одну карту и если да, то доложить из руки
            }

            table.AddRange(punchList);
        }

        //защита
        public bool Answer(List<Card> table)
        {
            //TODO: Сделать отмену
            //Проверка: Можно ли побить
            if (!CanFight(table)) return false;

            var answerList = new List<int>();

            for (var i = 0; i < table.Count(); i++)
            {
                UI.ST.MessageWithCard(table[i], 2);


                //Ввод карт для ответа
                StartInput:
                var tempUserInput = UI.ST.Input(); //
                if (deckOfCards.Count() > tempUserInput && tempUserInput > -2)
                {
                    if (tempUserInput == -1)
                    {
                        Catch(table);
                        table.Clear();
                        return false;
                    }

                    if (deckOfCards[tempUserInput].Fight(table[i]))
                    {
                        if (answerList.Contains(tempUserInput))
                        {
                            UI.ST.PrintFail(0);
                            goto StartInput;
                        }

                        answerList.Add(tempUserInput);
                    }
                    else
                    {
                        UI.ST.MessageWithCard(table[i], 0);
                        goto StartInput;
                    }
                }
                else
                {
                    UI.ST.PrintFail(1);
                    goto StartInput;
                }
            }

            foreach (var i in answerList) Pop(i);
            return true;
        }

        #endregion

        #region Вспомогательные

        // Проверка способности побить стол
        private bool CanFight(List<Card> table)
        {
            var checkList = new List<Card>();

            foreach (var i in table)
            {
                var temp = false;
                foreach (var j in deckOfCards)
                    if (j.Fight(i) && !checkList.Contains(j))
                    {
                        temp = true;
                        checkList.Add(j);
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
            var temp = 0;
            foreach (var i in players)
                if (i.Remained() == 0)
                    temp++;
            if (temp == players.Count - 1 && deck.Remained() == 0)
                return true;
            return false;
        }

        #endregion
    }
}