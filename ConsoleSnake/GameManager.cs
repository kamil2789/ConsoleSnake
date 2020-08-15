using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleSnake
{
    class GameManager
    {
        public Snake snake;
        private bool isAppleInGame;
        private Coordinates apple;
        private GameConfig gameConfig;
        private IRandomGenerator randomGenerator;

        public GameManager(GameConfig gameConfig, Snake snake, IRandomGenerator randomGenerator)
        {
            isAppleInGame = false;
            this.gameConfig = gameConfig;
            this.snake = snake;
            apple.cordX = -1;
            apple.cordY = -1;
            this.randomGenerator = randomGenerator;
        }

        public Coordinates Apple
        {
            get => apple;
        }

        public bool IsApple
        {
            get => isAppleInGame;
        }

        public bool ProcessMove(Direction direction)
        {
            var headCords = snake.CalculateNewHeadPosition(direction);
            if (headCords.Equals(apple))
            {
                snake.ExpandSnake(direction);
                gameConfig.IncrementApples();
                isAppleInGame = false;
                return true;
            }

            if (headCords.cordX >= gameConfig.GameSize.Item1 || headCords.cordX < 0)
            {
                return false;
            }

            if (headCords.cordY >= gameConfig.GameSize.Item2 || headCords.cordY < 0)
            {
                return false;
            }

            return snake.MoveSnake(direction);
        }

        public bool CreateApple()
        {
            if (isAppleInGame)
            {
                return true;
            }

            const int maxRetry = 10;
            int actualRetry = 0;
            while(actualRetry < maxRetry)
            {
                apple = randomGenerator.generateRandomCords(gameConfig.GameSize.Item1, gameConfig.GameSize.Item2);
                if (IsCordsConflictWithSnake(apple) == false)
                {
                    isAppleInGame = true;
                    return true;
                }
                actualRetry++;
            }

            apple.cordX = 0;
            apple.cordY = 0;
            while (IsCordsConflictWithSnake(apple))
            {
                if (apple.cordX < gameConfig.GameSize.Item1 - 1)
                {
                    apple.cordX++;
                }
                else if (apple.cordY < gameConfig.GameSize.Item2 - 1)
                {
                    apple.cordX = 0;
                    apple.cordY++;
                }
                else if (apple.cordX == gameConfig.GameSize.Item1 - 1 && apple.cordY == gameConfig.GameSize.Item2 - 1)
                {
                    return false;
                }
            }

            isAppleInGame = true;
            return true;
        }

        private bool IsCordsConflictWithSnake(Coordinates cord)
        {
            var tailCords = snake.Tails;
            foreach(var obj in tailCords)
            {
                if (obj.Equals(cord))
                {
                    return true;
                }
            }

            var headCords = snake.Head;
            if (headCords.Equals(cord))
            {
                return true;
            }

            return false;
        }
    }
}
