namespace RB.MartianRobots.Tests
{
    public class GridTests
    {
        [Theory]
        [InlineData(0, 0, false)]
        [InlineData(5, 3, false)]
        [InlineData(2, 2, false)]
        [InlineData(6, 3, true)]
        [InlineData(3, 4, true)]
        [InlineData(-1, 0, true)]
        [InlineData(0, -1, true)]
        public void IsOffGrid_ThenReturnExpectedResult(int x, int y, bool expected)
        {
            // Arrange
            var grid = new Grid(5, 3);

            // Act
            var result = grid.IsOffGrid(x, y);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void AddScent_ThenAddCoordinateToScentList()
        {
            // Arrange
            var grid = new Grid(5, 3);
            int x = 2, y = 1;

            // Act
            grid.AddScent(x, y);

            // Assert
            Assert.True(grid.IsScented(x, y));
        }

        [Fact]
        public void IsScented_ThenReturnFalse_ForUnmarkedCoordinates()
        {
            // Arrange
            var grid = new Grid(5, 3);

            // Act
            bool result = grid.IsScented(1, 1);

            // Assert
            Assert.False(result);
        }
    }
}
