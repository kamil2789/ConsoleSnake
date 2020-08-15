using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace ConsoleSnake
{
    class View : IView
    {
        readonly GameConfig gameConfig;
        char[,] gameBoard;

        public View(GameConfig gameConfig)
        {
            this.gameConfig = gameConfig;
            gameBoard = new char[gameConfig.GameSize.Item1,gameConfig.GameSize.Item2];
        }

        public void GetSnakeTail(LinkedList<Coordinates> snakeCoordinates)
        {
            foreach(Coordinates cord in snakeCoordinates)
            {
                gameBoard[cord.cordX, cord.cordY] = snakeTail;
            }
        }

        public void GetSnakeHead(Coordinates snakeHeadCords)
        {
            gameBoard[snakeHeadCords.cordX, snakeHeadCords.cordY] = snakeHead;
        }

        public void DisplayGame()
        {
            DisplayTopFrame();
            DisplayGameBoard();
            DisplayTopFrame();
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
    }
}
