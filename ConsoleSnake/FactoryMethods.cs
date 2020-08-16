using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleSnake
{
    public static class FactoryMethods
    {
        public static IUserInput CreateUserInput(int startingDelay)
        {
            return new UserInput(startingDelay);
        }

        public static IRandomGenerator CreateRandomGenerator(int rangeX, int rangeY)
        {
            return new RandomGenerator(rangeX, rangeY);
        }

        public static IView CreateView(GameConfig gameConfig)
        {
            return new View(gameConfig);
        }
    }
}
