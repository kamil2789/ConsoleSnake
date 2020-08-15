using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleSnake
{
    class UserInputController
    {
        private IUserInput userInput;

        public UserInputController(IUserInput userInput) => this.userInput = userInput;
        public Direction DecodeUserInput()
        {
            switch(userInput.GetUserInput().Key)
            {
                case ConsoleKey.S:
                    return Direction.Down;
                case ConsoleKey.D:
                    return Direction.Right;
                case ConsoleKey.A:
                    return Direction.Left;
                case ConsoleKey.W:
                    return Direction.Up;
                default:
                    throw new ArgumentException();
            }
        }
    }
}
