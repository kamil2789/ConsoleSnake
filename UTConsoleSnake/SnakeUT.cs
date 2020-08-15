using System;
using Xunit;
using ConsoleSnake;

namespace UTConsoleSnake
{
    public class SnakeUT
    {
        [Fact]
        public void MoveSnake_ChangeSnakeCoordinates_ReturnTrue()
        {
            const int cordX = 3;
            const int cordY = 3;
            Snake snake = new Snake(new Coordinates(cordX, cordY));

            var result = snake.MoveSnake(Direction.Down);

            Coordinates expectedCoord = new Coordinates(cordX, cordY + 1);
            Coordinates expectedTailCoord = new Coordinates(cordX, cordY);

            Assert.True(result);
            Assert.Equal(expectedCoord, snake.Head);
            Assert.Equal(expectedTailCoord, snake.Tails.First.Value);
        }

        [Fact]
        public void MoveSnake_InvalidChangeCoordinates_ReturnFalse()
        {
            const int cordX = 3;
            const int cordY = 3;
            Snake snake = new Snake(new Coordinates(cordX, cordY));

            var result = snake.MoveSnake(Direction.Right);

            Coordinates expectedHead = new Coordinates(cordX, cordY);
            Assert.False(result);
            Assert.Equal(expectedHead, snake.Head);
        }

        [Fact]
        public void ExpandSnake_SnakeExpandWithSuccess_ReturnTrue()
        {
            const int cordX = 3;
            const int cordY = 3;
            Snake snake = new Snake(new Coordinates(cordX, cordY));

            var result = snake.ExpandSnake(Direction.Up);

            Coordinates expectedHead = new Coordinates(cordX, cordY-1);
            Coordinates expectedPreviousHead = new Coordinates(cordX, cordY);
            Coordinates expectedTail = new Coordinates(cordX+1, cordY);

            Assert.True(result);
            Assert.Equal(expectedHead, snake.Head);
            Assert.Equal(expectedPreviousHead, snake.Tails.First.Value);
            Assert.Equal(expectedTail, snake.Tails.Last.Value);
        }

        [Fact]
        public void ExpandSnake_SnakeExpandWithFailed_ReturnFalse()
        {
            const int cordX = 3;
            const int cordY = 3;
            Snake snake = new Snake(new Coordinates(cordX, cordY));

            var result = snake.ExpandSnake(Direction.Right);

            Assert.False(result);
        }
    }
}
