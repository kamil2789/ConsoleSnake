using System;

namespace ConsoleSnake
{
    class Program
    {
        static void Main(string[] args)
        {
            MainMenu mainMenu = new MainMenu();
            while(true)
            {
                GameManager gameManager = GameManager.BuildGameManager(mainMenu.ProcessMainMenu());
                gameManager.MainGameLoop();
            }
            //fix snake decrease delay by percentage value 
        }
    }
}
