using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleSnake
{
    interface IView
    {
        void ReadGameManagerData(GameManager gameManager);
        void DisplayGame();
        void ClearConsole();
    }
}
