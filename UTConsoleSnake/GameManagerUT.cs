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
            randomGeneratorMock.Setup(m => m.generateRandomCords(gameSizeX, gameSizeY)).Returns(new Coordinates(2, 2));

            GameManager gameManager = new GameManager(new GameConfig(gameSizeX, gameSizeY), new Snake(new Coordinates(5, 5)), randomGeneratorMock.Object);
            var result = gameManager.ProcessMove(Direction.Down);

            Assert.True(result);
        }
    }
}
