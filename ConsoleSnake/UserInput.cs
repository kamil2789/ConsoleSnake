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

        public ConsoleKey GetUserInput()
        {
            if (!isRunInputThread)
            {
                userInput = new Thread(() => ProcessUserInput(ref inputKey));
                userInput.Start();
                isRunInputThread = true;
            }

            Thread.Sleep(delay);
            return inputKey;
        }

        public void DecreaseDelay()
        {
            delay -= 30;
        }

        private static void ProcessUserInput(ref ConsoleKey input)
        {
            while(true)
            {
                input = Console.ReadKey().Key;
            }
        }
    }
}
