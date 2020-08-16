using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleSnake
{
    public interface IRandomGenerator
    {
        Coordinates generateRandomCords();
    }
}
