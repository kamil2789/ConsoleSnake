using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleSnake
{
    class GameConfig
    {
        private readonly int gameSizeX;
        private readonly int gameSizeY;
        private int apples;

        public GameConfig(int gameSizeX, int gameSizeY)
        {
            this.gameSizeX = gameSizeX;
            this.gameSizeY = gameSizeY;
            apples = 0;
        }

        public (int, int) GameSize
        {
            get => (gameSizeX, gameSizeY);
        }

        public int IncrementApples()
        {
            return apples++;
        }
    }
}
