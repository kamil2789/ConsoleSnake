using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleSnake
{
    public interface IUserInput
    {
        Direction GetUserInput();
        void StopUserInput();
        void DecreaseDelay();
    }
}
