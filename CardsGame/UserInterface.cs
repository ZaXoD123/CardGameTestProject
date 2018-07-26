using System;
using System.Collections.Generic;
using System.Linq;


namespace CardsGame
{
    //Класс обёртка для консольного  ui
    //TODO: выкинуть все принты кроме последнего.
    //Последний сделать private
    static class UserInterface
    {
        //вывод
        public static void Print(Card a)
        {
            Console.WriteLine(a.Show());
        }
        
            public static void Print(string a)
        {
            Console.WriteLine(a);
        }
        
        public static void Print(List<Card> a)
        {
            for (int i = 0; i < a.Count(); i++)
            {
                Console.Write($"{i}) ");
                Console.WriteLine(a[i].Show());
            }
        }
        //Общее
        public static void GameStepStart(int Player, int DeckRemained)
        {
            Console.WriteLine($"Player {Player}, your turn. Cards in the deck: {DeckRemained}");
            GameDelay();
        }
        public static void GameMessage(int Player, List<Card> table)
        {

            Console.WriteLine("Player " + Player.ToString() + " answer!");
            Console.WriteLine("On the table:");
            Print(table);
            Console.WriteLine();

        }
        public static void GameMessage(int Player, List<Card> table, Player player)
        {
            Console.WriteLine("Player " + Player.ToString() + " attack!");
            GameDelay();
            Console.WriteLine("Select card(s) to attack");
            player.Show();
        }


        public static void GameDelay()
        {
            Console.WriteLine("Press any key...");
            Console.ReadKey();
            UIClear();
        }
        public static void UIClear()
        {
            Console.Clear();
        }
        public static void PrintFail(int a)
        {
            switch (a)
            {
                case 0:
                    Console.WriteLine("This card has already been used. Select another");
                    break;
                case 1:
                    Console.WriteLine("Incorrect value. Select another");
                    break;
                default:
                    Console.WriteLine("EPIC FAIL, NEO. WE ARE IN SHI...");
                    break;
            }
        }
        public static void PrintFail(Card a)
        {
            Console.WriteLine($"This card does not hit { a.Show()}. Select another");
        }
        //Ввод
        public static string Input()
        {
            return Console.ReadLine();
        }
    }
}
