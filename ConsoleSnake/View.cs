using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace ConsoleSnake
{
    class View : IView
    {
        private readonly GameConfig gameConfig;
        private int collectedApples;
        private char[,] gameBoard;

        public View(GameConfig gameConfig)
        {
            this.gameConfig = gameConfig;
            collectedApples = 0;
            gameBoard = new char[gameConfig.GameSize.Item1,gameConfig.GameSize.Item2];
        }

        public void ReadGameData(SnakeController snakeController, int Apples)
        {
            Array.Clear(gameBoard, 0, gameBoard.Length);
            GetSnakeTail(snakeController.snake.Tails);
            GetSnakeHead(snakeController.snake.Head);
            GetApple(snakeController.Apple, Apples);
        }

        public void DisplayGame()
        {
            DisplayTopFrame();
            DisplayGameBoard();
            DisplayTopFrame();
            DisplayAppleCounter();
        }

        public void ClearConsole()
        {
            Console.Clear();
        }

        private void DisplayAppleCounter()
        {
            Console.WriteLine($"Collected apples {collectedApples}");
        }

        private void GetSnakeTail(LinkedList<Coordinates> snakeCoordinates)
        {
            foreach(Coordinates cord in snakeCoordinates)
            {
                gameBoard[cord.cordX, cord.cordY] = snakeTail;
            }
        }

        private void GetSnakeHead(Coordinates snakeHeadCords)
        {
            gameBoard[snakeHeadCords.cordX, snakeHeadCords.cordY] = snakeHead;
        }

        private void GetApple(Coordinates apple, int appleCount)
        {
            if (apple.cordX > 0 || apple.cordY > 0 )
            {
                gameBoard[apple.cordX, apple.cordY] = appleSymbol;
            }

            collectedApples = appleCount;
        }

        private void DisplayTopFrame()
        {
            var gameSize = gameConfig.GameSize;

            Console.Write(fullBlock);
            for (int i = 0; i < gameSize.Item1; i++)
            {
                Console.Write(endOfGuardedArea);
            }
            Console.Write(fullBlock);
            Console.Write("\n");
        }

        private void DisplayGameBoard()
        {
            for (int y=0; y< gameConfig.GameSize.Item2; y++)
            {
                Console.Write(sidewalls);
                for (int x = 0; x < gameConfig.GameSize.Item1; x++)
                {
                    Console.Write((char)gameBoard[x,y]);
                }
                Console.Write(sidewalls);
                Console.Write("\n");
            }
        }

        const char endOfGuardedArea = '-';
        const char fullBlock = (char)9608;
        const char sidewalls = (char)124;
        const char snakeHead = 'H';
        const char snakeTail = 'x';
        const char appleSymbol = 'a';
    }
}
