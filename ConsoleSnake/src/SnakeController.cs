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

        public SnakeEvent ProcessMove(Direction direction, int maxCordX, int maxCordY)
        {
            var headCords = snake.CalculateNewHeadPosition(direction);

            if (headCords.Equals(snake.Tails.First.Value))
            {
                direction = lastDirection;
                return snake.MoveSnake(direction) ? SnakeEvent.MoveSnake : SnakeEvent.GameEnd;
            }

            if (headCords.Equals(applePosition))
            {
                isApple = false;
                applePosition.cordX = -1;
                applePosition.cordY = -1;
                lastDirection = direction;
                return snake.ExpandSnake(direction) ? SnakeEvent.ExpandSnake : SnakeEvent.GameEnd;
            }

            if (headCords.cordX >= maxCordX || headCords.cordX < 0)
            {
                return SnakeEvent.GameEnd;
            }

            if (headCords.cordY >= maxCordY || headCords.cordY < 0)
            {
                return SnakeEvent.GameEnd;
            }

            lastDirection = direction;
            return snake.MoveSnake(direction) ? SnakeEvent.MoveSnake : SnakeEvent.GameEnd;
        }

        public SnakeEvent CreateApple(Coordinates randomCords, int maxCordX, int maxCordY)
        {
            applePosition = randomCords;

            if (IsCordsConflictWithSnake(randomCords) == false)
            {
                isApple = true;
                return SnakeEvent.CreateApple;
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

                    if (applePosition.cordX == randomCords.cordX && applePosition.cordY == randomCords.cordY)
                    {
                        applePosition.cordX = -1;
                        applePosition.cordY = -1;
                        return SnakeEvent.GameEnd;
                    }
                }

                isApple = true;
                return SnakeEvent.CreateApple;
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
