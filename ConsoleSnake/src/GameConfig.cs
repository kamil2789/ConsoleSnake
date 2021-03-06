﻿using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleSnake
{
    public class GameConfig
    {
        private readonly int gameSizeX;
        private readonly int gameSizeY;
        private readonly int startingDelay;
        private int apples;
        private int maxApplesToCollect;

        public GameConfig(int gameSizeX, int gameSizeY, int startingDelay)
        {
            this.gameSizeX = gameSizeX;
            this.gameSizeY = gameSizeY;
            this.startingDelay = startingDelay;
            apples = 0;
            maxApplesToCollect = gameSizeX * gameSizeY - 2;
        }

        public int Apples
        {
            get => apples;
        }

        public int GameSizeX
        {
            get => gameSizeX;
        }

        public int GameSizeY
        {
            get => gameSizeY;
        }

        public int MaxApplesToCollect
        {
            get => maxApplesToCollect;
        }

        public int StartingDelay
        {
            get => startingDelay;
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
