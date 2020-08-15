using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleSnake
{
    interface IRandomGenerator
    {
        Coordinates generateRandomCords(int rangeX, int rangeY);
    }
}
