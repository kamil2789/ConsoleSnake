using System;

namespace ConsoleSnake
{
    class Program
    {
        static void Main(string[] args)
        {
            //init//
            GameConfig gameConfig = new GameConfig(8, 12);
            View view = new View(gameConfig);
            UserInputController userInputController = new UserInputController(new UserInput());
            GameManager gameManager = new GameManager(gameConfig, new Snake(new Coordinates(4, 6)), new RandomGenerator());
            //init//

            //main loop Game//
            view.ReadGameManagerData(gameManager);
            view.DisplayGame();
            bool isValidMove = true;
            while (gameManager.CreateApple() && isValidMove)
            {
                isValidMove = gameManager.ProcessMove(userInputController.DecodeUserInput());

                view.ClearConsole();
                view.ReadGameManagerData(gameManager);
                view.DisplayGame();     
            }
        }
    }
}
