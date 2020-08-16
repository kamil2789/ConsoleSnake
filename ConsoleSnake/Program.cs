using System;

namespace ConsoleSnake
{
    class Program
    {
        static void Main(string[] args)
        {
            GameConfig gameConfig = new GameConfig(3, 3, 1000);
            GameManager gameManager = GameManager.BuildGameManager(gameConfig);
            gameManager.MainGameLoop();

            //Write mainMenu
            //First delete last element, then move HEAD (BUG) Fixed is change snake tail beginning length to 2
            //Optional add graphic, big map and faster
            //Add custom configuration
            //Add UT whenever if possible
        }
    }
}
