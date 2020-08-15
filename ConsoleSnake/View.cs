using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace ConsoleSnake
{
    class View : IView
    {
        public View(GameConfig gameConfig) => this.gameConfig = gameConfig;
        public void GetSnakeCoordinates(List<Coordinates> snakeCoordinates)
        {

        }

        public void DisplayGame()
        {

        }

        readonly GameConfig gameConfig;
    }
}
