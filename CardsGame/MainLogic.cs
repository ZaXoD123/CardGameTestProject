using System;
using System.Collections.Generic;
using System.Linq;

namespace CardsGame
{
    class MainLogic
    {
        static void Main(string[] args)
        {
            //Создаём колоду myDeck, стол table и задаём константу отвечающую
            //за количество игроков
            int step = 0;
            const int countOfPlayers = 2;
            Deck myDeck = Deck.AddChild();
            List<Card> table = new List<Card>();
            

            //Создаём игроков
            List<Player> players = new List<Player>();

            for (int i = 0; i < countOfPlayers; i++)
            {
                players.Add(new Player());
                players[i].CatchFromDeck(myDeck);
            }

            //myDeck.Show();

            
            while (!Player.GameOver(players, myDeck))
            {
                // TODO сделать ситуативные методы ввода вывода. 
                // Добавить вывод козыря (Deck.TrumpSuit) в консоль

                UserInterface.GameStepStart(((step & 1) + 1), myDeck.Remained());
                
                if (table.Count() > 0)
                {
                    UserInterface.GameMessage(((step & 1) + 1), table);
                    
                    players[step & 1].Show();
                    if (!players[step & 1].Answer(table))
                    {
                        continue;
                    }
                    table.Clear();
                    UserInterface.GameDelay();
                }
                
                players[step & 1].CatchFromDeck(myDeck);
                players[(step +1) & 1].CatchFromDeck(myDeck);

                UserInterface.GameMessage(((step & 1) + 1), table, players[step & 1]);
                players[step & 1].Punch(table,ref myDeck);
                step++;
                UserInterface.UIClear();
            }
            Console.ReadKey();
        }
    }
}
