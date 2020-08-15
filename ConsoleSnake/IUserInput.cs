using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleSnake
{
    interface IUserInput
    {
        ConsoleKey GetUserInput();
        void DecreaseDelay();
    }
}
