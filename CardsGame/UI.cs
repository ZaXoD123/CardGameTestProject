using System.Collections.Generic;

namespace CardsGame
{
    internal delegate void UICurrent();

    internal delegate void UICurrent<T>(T a);

    internal delegate void UICurrent<T, U>(T a, U b);

    internal delegate void UICurrent<T, U, K>(T a, U b, K c);

    internal delegate int UICurrentInput();

    internal class UI
    {
        private UI(bool gui)
        {
            if (!gui)
            {
                Input = ConsoleUserInterface.Input;
                GameDelay = ConsoleUserInterface.GameDelay;
                PrintFail = ConsoleUserInterface.PrintFail;
                ShowPlayerHand = ConsoleUserInterface.ShowPlayerHand;
                GameStepStart = ConsoleUserInterface.GameStepStart;
                GameMessage = ConsoleUserInterface.GameMessage;
                MessageWithCard = ConsoleUserInterface.MessageWithCard;
                GameMessageAttack = ConsoleUserInterface.GameMessage;
            }

            /*
             else
             {
                gui
             }
            */
        }

        public static UI ST { get; private set; }

        public UICurrentInput Input { get; }
        public UICurrent GameDelay { get; }
        public UICurrent<List<Card>> ShowPlayerHand { get; }
        public UICurrent<int> PrintFail { get; }
        public UICurrent<int, int> GameStepStart { get; }
        public UICurrent<int, List<Card>> GameMessage { get; }
        public UICurrent<Card, int> MessageWithCard { get; }
        public UICurrent<int, List<Card>, Player> GameMessageAttack { get; }

        public static UI AddChild(bool gui)
        {
            if (ST == null)
            {
                ST = new UI(gui);
                return ST;
            }

            return ST;
        }
    }
}