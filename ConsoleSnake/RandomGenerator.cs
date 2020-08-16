using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleSnake
{
    public class RandomGenerator : IRandomGenerator
    {
        private readonly int rangeX;
        private readonly int rangeY;

        public RandomGenerator(int rangeX, int rangeY)
        {
            this.rangeX = rangeX;
            this.rangeY = rangeY;
        }

        public Coordinates generateRandomCords()
        {
            Random rand = new Random();
            int randCordX = rand.Next(0, rangeX);
            int randCordY = rand.Next(0, rangeY);

            return new Coordinates(randCordX, randCordY);
        }
    }
}
