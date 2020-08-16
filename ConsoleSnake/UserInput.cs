using System;
using System.Threading;

namespace ConsoleSnake
{
    class UserInput : IUserInput
    {
        private int delay;
        private bool isRunInputThread;
        private Thread userInput;
        ConsoleKey inputKey;

        public UserInput(int startingDelay)
        {
            delay = startingDelay;
            isRunInputThread = false;
            userInput = null;
            inputKey = ConsoleKey.A;
        }

        public Direction GetUserInput()
        {
            if (!isRunInputThread)
            {
                isRunInputThread = true;
                userInput = new Thread(() => ProcessUserInput(ref inputKey, ref isRunInputThread));
                userInput.Start();
            }

            Thread.Sleep(delay);
            return DecodeUserInput(inputKey);
        }

        public void DecreaseDelay()
        {
            delay -= 30;
        }

        public void StopUserInput()
        {
            isRunInputThread = false;
        }

        private Direction DecodeUserInput(ConsoleKey inputKey)
        {
            switch (inputKey)
            {
                case ConsoleKey.S:
                    return Direction.Down;
                case ConsoleKey.D:
                    return Direction.Right;
                case ConsoleKey.A:
                    return Direction.Left;
                case ConsoleKey.W:
                    return Direction.Up;
                default:
                    throw new ArgumentException();
            }
        }

        private static void ProcessUserInput(ref ConsoleKey input, ref bool isRunInputThread)
        {
            while(isRunInputThread)
            {
                input = Console.ReadKey().Key;
            }
        }
    }
}
