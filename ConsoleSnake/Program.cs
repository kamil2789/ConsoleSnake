using System;

namespace ConsoleSnake
{
    class Program
    {
        static void Main(string[] args)
        {
            //init//
            GameConfig gameConfig = new GameConfig(12, 8);
            View view = new View(gameConfig);
            UserInputController userInputController = new UserInputController(new UserInput(1000));
            GameManager gameManager = new GameManager(gameConfig, new Snake(new Coordinates(4, 6)), new RandomGenerator());
            //init//

            //main loop Game//
            view.ReadGameManagerData(gameManager);
            view.DisplayGame();
            bool isRunGame = true;
            bool isPlaceForApple = true;
            while (isRunGame && isPlaceForApple)
            {
                if (gameManager.IsApple == false)
                {
                    isPlaceForApple = gameManager.CreateApple();
                    userInputController.DecreaseDelay();
                }

                isRunGame = gameManager.ProcessMove(userInputController.DecodeUserInput());

                view.ClearConsole();
                view.ReadGameManagerData(gameManager);
                view.DisplayGame();     
            }

            //Fixed never endind side thread
            //Refactoring classes
            //Write Main
            //Write mainMenu
            //Add custom configuration
            //Add UT whenever if possible
        }
    }
}
