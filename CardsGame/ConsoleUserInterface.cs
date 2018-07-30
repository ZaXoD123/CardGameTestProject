using System;
using System.Collections.Generic;
using System.Linq;


namespace CardsGame
{

    //Класс обёртка для консольного  ui

    static class ConsoleUserInterface
    {
        #region Вывод
        //вывод
        static void PrintListOfCards(List<Card> a)
        {
            for (int i = 0; i < a.Count(); i++)
            {
                Console.Write($"{i}) ");
                Console.WriteLine(a[i].Show());
            }
        }
        //Показать руку
        public static void ShowPlayerHand(this List<Card> hand)
        {
            Console.WriteLine("You have this cards:");
            PrintListOfCards(hand);
        }
        #endregion

        #region Игровые сообщения
        //Сообщение о новом шаге
        public static void GameStepStart(int Player, int DeckRemained)
        {
            Console.Clear();
            Console.WriteLine($"Player {Player}, your turn. Cards in the deck: {DeckRemained}");
            Console.WriteLine($"Trump suit is {Deck.TrumpSuit}");
            GameDelay();
        }
        //Сообщение о защите
        public static void GameMessage(int Player, List<Card> table)
        {

            Console.WriteLine("Player " + Player.ToString() + " answer!");
            Console.WriteLine("On the table:");
            PrintListOfCards(table);
            Console.WriteLine();

        }
        //Сообщение об атаке
        public static void GameMessage(int Player, List<Card> table, Player player)
        {
            Console.WriteLine("Player " + Player.ToString() + " attack!");
            GameDelay();
            Console.WriteLine("Select card(s) to attack");
            player.Show();
        }

        //Пауза
        public static void GameDelay()
        {
            Console.WriteLine("Press any key...");
            Console.ReadKey();
            Console.Clear();
        }
        #endregion

        #region Сообщения об ошибке
        //Фейлы общие
        public static void PrintFail(int Situation)
        {
            switch (Situation)
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
        //Фейлы конкретных ситуаций
        public static void MessageWithCard(Card card, int Situation)
        {
            switch (Situation)
            {
                case 0:
                    Console.WriteLine($"This card does not hit { card.Show()}. Select another");
                    break;
                case 1:
                    Console.WriteLine("you can`t hit this card: " + card.Show() + ".You are taking!");
                    break;
                case 2:
                    Console.WriteLine($"Select a card to answer {card.Show()} or -1 to take");
                    break;
                default:
                    Console.WriteLine("EPIC FAIL, NEO. WE ARE IN SHI...");
                    break;
            }

        }
        #endregion

        #region Ввод
        public static int Input()
        {
            string tempInput = Console.ReadLine();
            int tempInputAsNum;
            while ((string.IsNullOrEmpty(tempInput)) || !(int.TryParse(tempInput, out tempInputAsNum)))
            {
                PrintFail(1);
                tempInput = Console.ReadLine();
            }
            
            return tempInputAsNum;
        }
        #endregion
    }
}
