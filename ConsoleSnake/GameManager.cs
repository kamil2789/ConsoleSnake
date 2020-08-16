using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleSnake
{
    class GameManager
    {
        private GameConfig gameConfig;
        private SnakeController snakeController;
        private readonly IUserInput userInput;
        private  readonly IRandomGenerator randomGenerator;
        private readonly IView view;

        public void MainGameLoop()
        {
            view.ReadGameData(snakeController, gameConfig.Apples);
            view.DisplayGame();

            bool isRunGame = true;
            while(isRunGame)
            {
                if (snakeController.IsApple == false)
                {
                    isRunGame = snakeController.CreateApple(randomGenerator.generateRandomCords(), gameConfig.GameSizeX, gameConfig.GameSizeY);
                    gameConfig.IncrementApples();
                    userInput.DecreaseDelay();
                }
                else
                {
                    isRunGame = snakeController.ProcessMove(userInput.GetUserInput(), gameConfig.GameSizeX, gameConfig.GameSizeY);

                    view.ClearConsole();
                    view.ReadGameData(snakeController, gameConfig.Apples);
                    view.DisplayGame();
                }
            }
            userInput.StopUserInput();
        }

        private GameManager(GameConfig gameConfig, SnakeController snakeController, IUserInput userInput, IRandomGenerator randomGenerator, IView view)
        {
            this.gameConfig = gameConfig;
            this.snakeController = snakeController;
            this.userInput = userInput;
            this.randomGenerator = randomGenerator;
            this.view = view;
        }

        public static GameManager BuildGameManager(GameConfig gameConfig)
        {
            SnakeController snakeControllerBuild = new SnakeController(new Snake(gameConfig.GameSizeX / 2, gameConfig.GameSizeY / 2));
            IUserInput userInputBuild = FactoryMethods.CreateUserInput(gameConfig.StartingDelay);
            IRandomGenerator randomGeneratorBuild = FactoryMethods.CreateRandomGenerator(gameConfig.GameSizeX, gameConfig.GameSizeY);
            IView viewBuild = FactoryMethods.CreateView(gameConfig);

            return new GameManager(gameConfig, snakeControllerBuild, userInputBuild, randomGeneratorBuild, viewBuild);
        }
    }
}
