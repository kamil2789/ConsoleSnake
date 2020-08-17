using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleSnake
{
    public class MainMenu
    {
        private ConsoleKey input;
        GameConfig gameConfig;

        public MainMenu()
        {
            input = ConsoleKey.Escape;
            gameConfig = new GameConfig(12, 8, 500);
        }

        public GameConfig ProcessMainMenu()
        {
            bool isRunMainMenu = true;
            while(isRunMainMenu)
            {
                DisplayMenu();
                if (ValidateMainMenuUserInput(ReadUserDecision()))
                {
                    switch (input)
                    {
                        case ConsoleKey.D1:
                            isRunMainMenu = false;
                            break;
                        case ConsoleKey.D2:
                            ProcessConfigurationSubMenu();
                            break;
                        case ConsoleKey.D3:
                            ProcessHowToPlaySubMenu();
                            break;
                        case ConsoleKey.D4:
                            Environment.Exit(0);
                            break;
                    }
                }
            }
            return gameConfig;
        }

        private void DisplayMenu()
        {
            Console.WriteLine("Welcome in Snake");
            Console.WriteLine("1. Start game");
            Console.WriteLine("2. Game confguration");
            Console.WriteLine("3. How to play");
            Console.WriteLine("4. Quit");
        }

        private void ProcessConfigurationSubMenu()
        {

        }

        private void ProcessHowToPlaySubMenu()
        {

        }

        private ConsoleKey ReadUserDecision()
        {
            input = Console.ReadKey().Key;
            return input;
        }

        private bool ValidateMainMenuUserInput(ConsoleKey choose)
        {
            switch (choose)
            {
                case ConsoleKey.D1:
                case ConsoleKey.D2:
                case ConsoleKey.D3:
                case ConsoleKey.D4:
                    return true;
                default:
                    return false;
            }
        }
    }
}
