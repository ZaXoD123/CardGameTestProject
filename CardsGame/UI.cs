using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardsGame
{
    internal delegate void UICurrent();
    internal delegate void UICurrent<T>(T a);
    internal delegate void UICurrent<T, U>(T a, U b);
    internal delegate void UICurrent<T, U, K>(T a, U b, K c);

    class UI
    {
        static UI sT = null;

        static public UI ST
        {
            get
            {
                return sT;
            }
        }
        public UICurrent GameDelay { get; }
        public UICurrent<List<Card>> ShowPlayerHand { get; }
        public UICurrent<int> PrintFail { get; }
        public UICurrent<int, int> GameStepStart { get; }
        public UICurrent<int, List<Card>> GameMessage { get; }
        public UICurrent<Card, int> MessageWithCard { get; }
        public UICurrent<int, List<Card>, Player> GameMessageAttack { get; }
        
        UI(bool gui)
        {
            if (!gui)
            {
                GameDelay = new UICurrent(ConsoleUserInterface.GameDelay);
                PrintFail = new UICurrent<int>(ConsoleUserInterface.PrintFail);
                ShowPlayerHand = new UICurrent<List<Card>>(ConsoleUserInterface.ShowPlayerHand);
                GameStepStart = new UICurrent<int, int>(ConsoleUserInterface.GameStepStart);
                GameMessage = new UICurrent<int, List<Card>>(ConsoleUserInterface.GameMessage);
                MessageWithCard = new UICurrent<Card, int>(ConsoleUserInterface.MessageWithCard);
                GameMessageAttack = new UICurrent<int, List<Card>, Player>(ConsoleUserInterface.GameMessage);
            }
        }
        public static UI AddChild(bool gui)
        {
            if (sT == null)
            {
                sT = new UI(gui);
                return sT;
            }
            else
            {
                return sT;
            }
        }

    }
}
