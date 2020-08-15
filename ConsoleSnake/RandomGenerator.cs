using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleSnake
{
    class RandomGenerator : IRandomGenerator
    {
        public Coordinates generateRandomCords(int rangeX, int rangeY)
        {
            Random rand = new Random();
            int randCordX = rand.Next(0, rangeX);
            int randCordY = rand.Next(0, rangeY);

            return new Coordinates(randCordX, randCordY);
        }
    }
}
