using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleSnake
{
    interface IView
    {
        void GetSnakeTail(LinkedList<Coordinates> snakeCoordinates);
        void GetSnakeHead(Coordinates snakeCoordinates);
        void DisplayGame();
    }
}
