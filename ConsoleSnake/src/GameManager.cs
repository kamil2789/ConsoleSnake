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
        private readonly IRandomGenerator randomGenerator;
        private readonly IView view;

        public void MainGameLoop()
        {
            view.ReadGameData(snakeController, gameConfig.Apples);
            view.DisplayGame();

            SnakeEvent snakeEvent = SnakeEvent.None;
            while(snakeEvent != SnakeEvent.GameEnd)
            {
                if (snakeController.IsApple == false)
                {
                    snakeEvent = snakeController.CreateApple(randomGenerator.generateRandomCords(), gameConfig.GameSizeX, gameConfig.GameSizeY);
                }
                else
                {
                    snakeEvent = snakeController.ProcessMove(userInput.GetUserInput(), gameConfig.GameSizeX, gameConfig.GameSizeY);
                    if (snakeEvent == SnakeEvent.ExpandSnake)
                    {
                        gameConfig.IncrementApples();
                        userInput.DecreaseDelay();
                    }
                }

                view.ClearConsole();
                view.ReadGameData(snakeController, gameConfig.Apples);
                view.DisplayGame();
            }
            endingMessage();
            userInput.StopUserInput();
        }

        private void endingMessage()
        {
            if (gameConfig.Apples == gameConfig.MaxApplesToCollect)
            {
                Console.WriteLine("You won the game!");
            }
            else
            {
                Console.WriteLine($"Game over! Your score is {gameConfig.Apples}");
            }
            Console.WriteLine("Press any key to continue");
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
