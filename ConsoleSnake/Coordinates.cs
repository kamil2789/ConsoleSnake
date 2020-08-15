using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleSnake
{
    public struct Coordinates
    {
        public Coordinates(int x, int y)
        {
            cordX = x;
            cordY = y;
        }

        public int cordX;
        public int cordY;

        /*
        public override bool Equals(object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                Coordinates cords = (Coordinates)obj;
                return cordX == cords.cordX && cordY == cords.cordY;
            }
        }

        public override int GetHashCode()
        {
            return cordX * cordY + (cordX + cordY);
        }
        */
    }

    public enum Direction
    {
        Up,
        Down,
        Left,
        Right
    }
}
