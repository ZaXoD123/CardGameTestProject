using System;
using System.Collections.Generic;
using System.Linq;

namespace CardsGame
{
    class MainLogic
    {
        

        static void Main(string[] args)
        {
            //колода myDeck, стол table и константа количества игроков countOfPlayers
            int step = 0;
            const int countOfPlayers = 2;
            Deck myDeck = Deck.AddChild();
            List<Card> table = new List<Card>();

            //Создание игроков
            List<Player> players = new List<Player>();
            for (int i = 0; i < countOfPlayers; i++)
            {
                players.Add(new Player());
                players[i].CatchFromDeck(myDeck);
            }

            // Определение интерфейса
            const bool gui = false;
            UI ui = UI.AddChild(gui);

            
            
            while (!Player.GameOver(players, myDeck))
            {
                //TODO:
                //1. Сделать меньше связь с UserInterface [+-]
                //2. Переписать логику для игроков. step & 1 Способна лишь на 2 значения. [-]
                //3. Доделать Player.Punch [-]
                ui.GameStepStart(((step & 1) + 1), myDeck.Remained());
                
                if (table.Count() > 0)
                {
                    ui.GameMessage(((step & 1) + 1), table);
                    
                    players[step & 1].Show();
                    if (!players[step & 1].Answer(table))
                    {
                        continue;
                    }
                    table.Clear();
                    ui.GameDelay();
                }
                
                players[step & 1].CatchFromDeck(myDeck);
                players[(step +1) & 1].CatchFromDeck(myDeck);

                ui.GameMessageAttack(((step & 1) + 1), table, players[step & 1]);
                players[step & 1].Punch(table,ref myDeck);
                step++;
                
            }
            Console.ReadKey();
        }
    }
}
