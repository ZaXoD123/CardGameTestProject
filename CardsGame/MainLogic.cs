using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                UserInterface.Print($"Player {((step & 1) + 1)}, your turn. Cards in the deck: {myDeck.Remained()}");
                
                Console.ReadKey();
                
                if (table.Count() > 0)
                {
                    Console.Clear();
                    UserInterface.Print("Player " + ((step & 1) +1).ToString() + "Answer!");
                    UserInterface.Print("On the table:");
                    UserInterface.Print(table);
                    Console.WriteLine();

                    players[step & 1].Show();
                    if (!players[step & 1].Answer(table))
                    {
                        continue;
                    }
                    table.Clear();
                Console.ReadKey();
                Console.Clear();  
                }
                
                

                players[step & 1].CatchFromDeck(myDeck);
                players[(step +1) & 1].CatchFromDeck(myDeck);
                UserInterface.Print("Player " + ((step & 1) + 1).ToString() + " attack!");
                players[step & 1].Punch(table,ref myDeck);
                step++;
                Console.Clear();
            }
            Console.ReadKey();
        }
    }
}
