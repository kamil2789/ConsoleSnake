using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleSnake
{
    public class SnakeController
    {
        public Snake snake;
        private bool isApple;
        private Coordinates applePosition;
        private Direction lastDirection;

        public SnakeController(Snake snake)
        {
            isApple = false;
            this.snake = snake;
            applePosition.cordX = -1;
            applePosition.cordY = -1;
            lastDirection = Direction.Left;
        }

        public Coordinates Apple
        {
            get => applePosition;
        }

        public bool IsApple
        {
            get => isApple;
        }

        /*
        public int GetAppleCount()
        {
            return gameConfig.Apple;
        }
        */

        public bool ProcessMove(Direction direction, int maxCordX, int maxCordY)
        {
            var headCords = snake.CalculateNewHeadPosition(direction);

            if (headCords.Equals(snake.Tails.First.Value))
            {
                direction = lastDirection;
                return snake.MoveSnake(direction);
            }

            if (headCords.Equals(applePosition))
            {
                snake.ExpandSnake(direction);
                isApple = false;
                applePosition.cordX = -1;
                applePosition.cordY = -1;
                lastDirection = direction;
                return true;
            }

            if (headCords.cordX >= maxCordX || headCords.cordX < 0)
            {
                return false;
            }

            if (headCords.cordY >= maxCordY || headCords.cordY < 0)
            {
                return false;
            }

            lastDirection = direction;
            return snake.MoveSnake(direction);
        }

        public bool CreateApple(Coordinates randomCords, int maxCordX, int maxCordY)
        {
            applePosition = randomCords;

            if (IsCordsConflictWithSnake(randomCords) == false)
            {
                isApple = true;
                return true;
            }
            else
            {
                while (IsCordsConflictWithSnake(applePosition))
                {
                    if (applePosition.cordX < maxCordX - 1)
                    {
                        applePosition.cordX++;
                    }
                    else if (applePosition.cordY < maxCordY - 1)
                    {
                        applePosition.cordX = 0;
                        applePosition.cordY++;
                    }
                    else if (applePosition.cordX == maxCordX - 1 && applePosition.cordY == maxCordY - 1)
                    {
                        applePosition.cordX = 0;
                        applePosition.cordY = 0;
                    }
                    else if (applePosition.cordX == randomCords.cordX && applePosition.cordY == randomCords.cordY)
                    {
                        return false;
                    }
                }

                isApple = true;
                return true;
            }
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
