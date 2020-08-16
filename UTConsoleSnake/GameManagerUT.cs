using Xunit;
using Moq;
using ConsoleSnake;
using System.Threading;

namespace UTConsoleSnake
{
    public class GameManagerUT
    {
        [Fact]
        public void ProcessMove_NoColission_ReturnTrue()
        {
            const int gameSizeX = 10;
            const int gameSizeY = 10;
            var randomGeneratorMock = new Mock<IRandomGenerator>();
            randomGeneratorMock.Setup(m => m.generateRandomCords()).Returns(new Coordinates(2, 2));

            SnakeController snakeController = new SnakeController(new Snake(new Coordinates(5, 5)));
            var result = snakeController.ProcessMove(Direction.Down, gameSizeX, gameSizeY);

            Assert.Equal(SnakeEvent.MoveSnake, result);
        }
    }
}
