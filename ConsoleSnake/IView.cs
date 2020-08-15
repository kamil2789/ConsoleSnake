using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleSnake
{
    interface IView
    {
        void GetSnakeCoordinates(List<Coordinates> snakeCoordinates);
        void DisplayGame();
    }
}
