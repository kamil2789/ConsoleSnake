using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleSnake
{
    public interface IView
    {
        void ReadGameData(SnakeController gameManager, int apples);
        void DisplayGame();
        void ClearConsole();
    }
}
