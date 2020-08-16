using System;

namespace ConsoleSnake
{
    class Program
    {
        static void Main(string[] args)
        {
            GameConfig gameConfig = new GameConfig(8, 4, 1000);
            GameManager gameManager = GameManager.BuildGameManager(gameConfig);
            gameManager.MainGameLoop();

            //Fixed never endind side thread
            //Refactoring classes
            //Write Main
            //Write mainMenu
            //Add custom configuration
            //Add UT whenever if possible
        }
    }
}
