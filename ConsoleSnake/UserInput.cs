using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleSnake
{
    class UserInput : IUserInput
    {
        public ConsoleKeyInfo GetUserInput()
        {
            return Console.ReadKey();
        }
    }
}
