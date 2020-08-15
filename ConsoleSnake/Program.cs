using System;

namespace ConsoleSnake
{
    class Program
    {
        static void Main(string[] args)
        {
            GameConfig gameConfig = new GameConfig(8, 12);
            Snake snake = new Snake(new Coordinates(4,6));
            View view = new View(gameConfig);

            view.GetSnakeTail(snake.Tails);
            view.GetSnakeHead(snake.Head);

            view.DisplayGame();
        }
    }
}
