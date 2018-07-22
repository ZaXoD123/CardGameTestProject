using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardsGame
{
    //Класс обёртка для консольного  ui
    //Пока не придумал что с ним делать
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
        public static void Print(Card [] a)
        {
            for (int i = 0; i < a.Length; i++)
            {
                Console.Write($"{i}) ");
                Console.WriteLine(a[i].Show());
            }
        }
        public static void Print(List<Card> a)
        {
            for (int i = 0; i < a.Count(); i++)
            {
                Console.Write($"{i}) ");
                Console.WriteLine(a[i].Show());
            }
        }
        //Ввод
        public static string Input()
        {
            return Console.ReadLine();
        }
    }
}
